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
        private int _screenWidth, _screenHeight;

        private Camera ViewportCamera;
        private Bitmap RenderBitmap;
        private ObjectManager objectManager;

        private PictureBox RenderedPictureBox;
        private Graphics DrawingSurface;

        public bool isRendering = false;

        public RenderUtility(Camera activeCamera, ObjectManager OM, PictureBox pictureBox)
        {
            _screenHeight = pictureBox.Height;
            _screenWidth = pictureBox.Width;
            RenderBitmap = new Bitmap(_screenWidth, _screenHeight);
            DrawingSurface = Graphics.FromImage(RenderBitmap);

            ViewportCamera = activeCamera;
            objectManager = OM;
            RenderedPictureBox = pictureBox;
            RenderedPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Paint);

        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(RenderBitmap, 0, 0); 
        }

        public void refreshBitmap()
        {
            Graphics g = Graphics.FromImage(RenderBitmap);
            g.Clear(Color.White);

            for (int i = 0; i < objectManager.Size; i++)
            {
                if (objectManager.GetObject(i).Renderable)
                {
                    drawObject(objectManager.GetObject(i), g);
                }
            }
            isRendering = false;
            RenderedPictureBox.Refresh();
        }

        private void drawObject(Object obj, Graphics g)
        {
            Pen pen = new Pen(ColorTheme.WIREFRAME_COLOR);
            for (int i = 0; i < obj.Edges.Count; i++)
            {
                Edge edge = obj.Edges[i];
                PointF[] points = new PointF[2];

                points[0] = ViewportCamera.toScreen(obj.TransformedVertices[edge.A].convertToVector());
                points[1] = ViewportCamera.toScreen(obj.TransformedVertices[edge.B].convertToVector());
                pen.Width = 5;

                g.DrawLine(pen, points[0], points[1]);
            }

            for (int i = 0; i < obj.Faces.Count; i++)
            {
                Face face = obj.Faces[i];
                PointF[] points = new PointF[face.Vertices.Count];

                for (int j = 0; j < face.Vertices.Count; j++)
                {
                    points[j] = ViewportCamera.toScreen(obj.TransformedVertices[face.Vertices[j]].convertToVector());
                }

                g.FillPolygon(new SolidBrush(ColorTheme.FILL_COLOR), points);
            }

            PointF p = ViewportCamera.toScreen(obj.Translation);
            pen.Color = (ColorTheme.POSITION_COLOR);
            g.DrawEllipse(pen, p.X, p.Y, 0.5f, 0.5f);
        }
    }
}

