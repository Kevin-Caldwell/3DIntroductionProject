using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace _3DIntroductionProject
{
    internal class RenderUtility
    {
        #region Fields
        private readonly int _screenWidth, _screenHeight;

        private Camera ViewportCamera;
        private Bitmap RenderBitmap;
        private ObjectManager ObjectStorage;

        private List<Lamp> lightSources;

        private PictureBox RenderedPictureBox;
        private Graphics DrawingSurface;

        private List<object> RenderQueue;

        public bool isRendering = false;

        private Monitoring monitor;
        #endregion

        #region Constructors
        public RenderUtility(ObjectManager OM, PictureBox pictureBox, Monitoring monitor)
        {
            _screenHeight = pictureBox.Height;
            _screenWidth = pictureBox.Width;
            RenderBitmap = new Bitmap(_screenWidth, _screenHeight);
            DrawingSurface = Graphics.FromImage(RenderBitmap);

            ObjectStorage = OM;

            ViewportCamera = OM.ViewportCamera;
            RenderedPictureBox = pictureBox;
            RenderedPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
            this.monitor = monitor;
        }
        #endregion

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(RenderBitmap, 0, 0);
        }

        public void RefreshBitmap()
        {
            Graphics g = Graphics.FromImage(RenderBitmap);
            g.Clear(Color.White);

            RenderQueue = PrepareRenderingQueue(ObjectStorage.Objects);
            //MergeSort(RenderQueue.ToArray(), 0, RenderQueue.Count - 1, 0);
            //BubbleSort(RenderQueue);

            RenderAllObjects(RenderQueue, g);

            isRendering = false;
            RenderedPictureBox.Refresh();
        }

        private List<object> PrepareRenderingQueue(List<Object> objectList)
        {
            List<object> RenderQueue = new List<object>();

            foreach (Object obj in objectList)
            {
                if (obj.Visible)
                {
                    foreach (Vertex v in obj.TransformedVertices)
                    {
                        RenderQueue.Add(v);
                    }

                    foreach (Edge edge in obj.Edges)
                    {
                        RenderQueue.Add(edge);
                    }

                    foreach (Face face in obj.Faces)
                    {
                        RenderQueue.Add(face);
                    }
                }
            }
            return RenderQueue;
        }

        /// <summary>
        /// Method for rendering all renderable objects.
        /// </summary>
        /// <param name="ObjectAttributes">List of Object Attributes (Vertices, Edges, Faces)</param>
        /// <param name="g">Graphics Object</param>
        private void RenderAllObjects(List<object> ObjectAttributes, Graphics g)
        {
            foreach (object obj in ObjectAttributes)
            {
                Pen pen;

                //RenderedPictureBox.Refresh();
                //Thread.Sleep(100);
                //Application.DoEvents();

                if (obj is Vertex v)
                {
                    pen = new Pen(Settings.VERTEX_COLOR);

                    PointF point = ViewportCamera.ToScreen(v.ConvertToVector());
                    pen.Width = 5;
                    g.FillEllipse(new SolidBrush(Settings.WIREFRAME_COLOR), point.X - 4, point.Y - 4, 8, 8);

                }
                else if (obj is Edge edge)
                {
                    PointF[] points = new PointF[2];

                    points[0] = ViewportCamera.ToScreen(edge.A.ConvertToVector());
                    points[1] = ViewportCamera.ToScreen(edge.B.ConvertToVector());

                    pen = new Pen(Settings.WIREFRAME_COLOR) { Width = 5 };

                    g.DrawLine(pen, points[0], points[1]);
                }
                else if (obj is Face face)
                {
                    if (ViewportCamera.Basis.Forward.dotProduct(face.Normal) < 0.1)
                    {
                        PointF[] points = new PointF[face.Vertices.Count];

                        for (int i = 0; i < face.Vertices.Count; i++)
                        {
                            points[i] = ViewportCamera.ToScreen(face.Vertices[i].ConvertToVector());
                        }

                        double scale = Math.Abs(ViewportCamera.Basis.Forward.subtract(face.Median).dotProduct(face.Normal));
                        scale = scale < 1 ? scale : 1;

                        Color faceColor = Color.FromArgb(1, (int)(Settings.FILL_COLOR.R * scale),
                            (int)(Settings.FILL_COLOR.G * scale),
                           (int)(Settings.FILL_COLOR.B * scale));

                        g.FillPolygon(new SolidBrush(Settings.FILL_COLOR), points);
                    }

                    PointF p1 = ViewportCamera.ToScreen(face.Median.add(face.Normal));
                    PointF p2 = ViewportCamera.ToScreen(face.Median);


                    g.DrawLine(new Pen(Settings.VERTEX_COLOR), p1, p2);
                }
            }
        }
        /// <summary>
        /// Extremely temporary method for sorting Properties of Objects.
        /// </summary>
        /// <param name="list"></param>
        private void BubbleSort(List<object> list)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (GetDistanceFromCamera(list[i + 1]) > GetDistanceFromCamera(list[i]))
                    {
                        (list[i], list[i + 1]) = (list[i + 1], list[i]);
                        sorted = false;
                    }
                }
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="obj">Vertex, Edge or Face object</param>
        /// <returns>Distance of Vertex / Mid Point / Median from the Camera</returns>
        private double GetDistanceFromCamera(object obj)
        {
            double x = -1;

            if (obj is Vertex v)
            {
                x = PointDistanceFromOrigin(ViewportCamera.ToCameraCoordinates(v.ConvertToVector()));
            }
            else if (obj is Edge edge)
            {
                Vertex midPoint = new Vertex();
                (midPoint.X, midPoint.Y, midPoint.Z) = (midPoint.Y, midPoint.Z, midPoint.X);

                midPoint.X += edge.A.X;
                midPoint.Y += edge.A.Y;
                midPoint.Z += edge.A.Z;

                midPoint.X += edge.B.X;
                midPoint.Y += edge.B.Y;
                midPoint.Z += edge.B.Z;

                midPoint.X /= 2;
                midPoint.Y /= 2;
                midPoint.Z /= 2;

                x = PointDistanceFromOrigin(ViewportCamera.ToCameraCoordinates(midPoint.ConvertToVector()));

            }
            else if (obj is Face face)
            {

                Vertex median = new Vertex();
                foreach (Vertex vertex in face.Vertices)
                {
                    median.X += vertex.X;
                    median.Y += vertex.Y;
                    median.Z += vertex.Z;
                }

                median.X /= face.Vertices.Count;
                median.Y /= face.Vertices.Count;
                median.Z /= face.Vertices.Count;


                x = PointDistanceFromOrigin(ViewportCamera.ToCameraCoordinates(median.ConvertToVector()));
            }

            return x;
        }
        /*        private double Minimum(double x, double y)
                {
                    return x < y ? x : y;
                }*/
        private double PointDistanceFromOrigin(Vector3 v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }
    }
}

