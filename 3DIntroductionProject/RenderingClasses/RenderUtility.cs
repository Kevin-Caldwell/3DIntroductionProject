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
        private int _screenWidth, _screenHeight;

        private Camera ViewportCamera;
        private Bitmap RenderBitmap;
        private ObjectManager objectManager;

        private PictureBox RenderedPictureBox;
        private Graphics DrawingSurface;

        private List<object> RenderQueue;

        public bool isRendering = false;
        #endregion

        #region Constructors
        public RenderUtility(ObjectManager OM, PictureBox pictureBox)
        {
            _screenHeight = pictureBox.Height;
            _screenWidth = pictureBox.Width;
            RenderBitmap = new Bitmap(_screenWidth, _screenHeight);
            DrawingSurface = Graphics.FromImage(RenderBitmap);

            objectManager = OM;

            ViewportCamera = OM.ViewportCamera;
            RenderedPictureBox = pictureBox;
            RenderedPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);
        }
        #endregion

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(RenderBitmap, 0, 0);
        }

        public void refreshBitmap()
        {
            Graphics g = Graphics.FromImage(RenderBitmap);
            g.Clear(Color.White);

            RenderQueue = PrepareRenderingQueue(objectManager.Objects);
            BubbleSort(RenderQueue);

            RenderAllObjects(RenderQueue, g);

            isRendering = false;
            RenderedPictureBox.Refresh();
        }

        private List<object> PrepareRenderingQueue(List<Object> objectList)
        {
            List<object> RenderQueue = new List<object>();
            foreach (Object obj in objectList)
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

            return RenderQueue;
        }

        private void RenderAllObjects(List<object> ObjectAttributes, Graphics g)
        {
            Pen pen = new Pen(Settings.VERTEX_COLOR);
            foreach (object obj in ObjectAttributes)
            {
                //Thread.Sleep(100);
                //RenderedPictureBox.Refresh();

                if (obj is Vertex v)
                {
                    pen = new Pen(Settings.VERTEX_COLOR);

                    PointF point = ViewportCamera.ToScreen(v.convertToVector());
                    pen.Width = 5;
                    g.FillEllipse(new SolidBrush(Settings.WIREFRAME_COLOR), point.X, point.Y, 2, 2);

                }
                else if (obj is Edge edge)
                {
                    PointF[] points = new PointF[2];

                    points[0] = ViewportCamera.ToScreen(edge.A.convertToVector());
                    points[1] = ViewportCamera.ToScreen(edge.B.convertToVector());

                    pen = new Pen(Settings.WIREFRAME_COLOR) {Width = 5};

                    g.DrawLine(pen, points[0], points[1]);
                }
                else if (obj is Face face)
                {
                    PointF[] points = new PointF[face.Vertices.Count];

                    for (int i = 0; i < face.Vertices.Count; i++)
                    {
                        points[i] = ViewportCamera.ToScreen(face.Vertices[i].convertToVector());
                    }

                    g.FillPolygon(new SolidBrush(Settings.FILL_COLOR), points);
                }
            }
        }

        private void BubbleSort(List<object> list)
        {

            bool sorted = false;

            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (GetDistanceFromCamera(list[i + 1]) < GetDistanceFromCamera(list[i]))
                    {
                        object temp = list[i + 1];
                        list[i + 1] = list[i];
                        list[i] = temp;

                        sorted = false;
                    }
                }
            }
        }

        private double GetDistanceFromCamera(object obj)
        {
            double x = -1;

            if(obj is Vertex)
            {
                x = Minimum(x, ViewportCamera.toCameraCoordinates(((Vertex)obj).convertToVector()).X);
            } else if(obj is Edge)
            {
                Edge edge = (Edge)obj;
                double avg = (ViewportCamera.toCameraCoordinates((edge.A).convertToVector()).X
                    + ViewportCamera.toCameraCoordinates((edge.B).convertToVector()).X) / 2;
                x = Minimum(x, avg);

            } else if (obj is Face)
            {
                foreach (Vertex v in ((Face)obj).Vertices)
                {
                    x = Minimum(x, ViewportCamera.toCameraCoordinates((v).convertToVector()).X);
                }
            }

            return x;
        }

        private double Minimum(double x, double y)
        {
            return x < y ? x : y;
        }
    }
}

