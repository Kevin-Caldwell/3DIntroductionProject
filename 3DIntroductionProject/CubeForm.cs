using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DIntroductionProject
{
    public partial class CubeForm : Form
    {
        private int _screenWidth, _screenHeight;

        private Bitmap CubeBitmap;
        private Graphics cubeDrawingSurface;

        private Camera camera;
        private double cameraAngle = 0;

        private List<Object> objects;

        public CubeForm()
        {
            InitializeComponent();
            _screenHeight = GraphicsDisplayPictureBox.Height;
            _screenWidth = GraphicsDisplayPictureBox.Width;
            CubeBitmap = new Bitmap(_screenWidth, _screenHeight);

            cubeDrawingSurface = Graphics.FromImage(CubeBitmap);
            camera = new Camera(new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 1, 0), 70, new Vector3(0, 0, 0), new Point(_screenWidth, _screenHeight));
            objects = new List<Object>();
        }

        public Object getCube(double s)
        {
            Object cube = new Object();
            
            List<Vertex> vertices = new List<Vertex>();

            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    for(int k = 0; k < 2; k++)
                    {
                        double x = i == 1 ? s / 2 : -s / 2;
                        double y = j == 1 ? s / 2 : -s / 2;
                        double z = k == 1 ? s / 2 : -s / 2;

                        vertices.Add(new Vertex(x, y, z));
                    }
                }
            }
            //(0, 0, 0) 0
            //(0, 0, s) 1
            //(0, s, 0) 2
            //(0, s, s) 3
            //(s, 0, 0) 4
            //(s, 0, s) 5
            //(s, s, 0) 6
            //(s, s, s) 7

            List<Edge> edges = new List<Edge>();

            edges.Add(new Edge(0, 1));
            edges.Add(new Edge(0, 2));
            edges.Add(new Edge(0, 4));

            edges.Add(new Edge(3, 1));
            edges.Add(new Edge(3, 2));
            edges.Add(new Edge(3, 7));

            edges.Add(new Edge(5, 1));
            edges.Add(new Edge(5, 4));
            edges.Add(new Edge(5, 7));

            edges.Add(new Edge(6, 2));
            edges.Add(new Edge(6, 4));
            edges.Add(new Edge(6, 7));

            List<Face> faces = new List<Face>();
            faces.Add(new Face(0, 1, 3, 2));
            faces.Add(new Face(0, 1, 5, 4));

            faces.Add(new Face(0, 2, 6, 4));
            faces.Add(new Face(1, 3, 7, 5));

            faces.Add(new Face(2, 3, 7, 6));
            faces.Add(new Face(6, 4, 5, 7));

            cube.Vertices = vertices;
            cube.Edges = edges;
            cube.Faces = faces;

            return cube;
        }

        private void GraphicsDisplayPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(CubeBitmap, 0, 0);
        }

        private void Clock_Tick(object sender, EventArgs e)
        {
            /*Vector3 pos = camera.Basis.Position;

            camera.Basis.Forward = camera.Basis.Forward.rotateZ(0.02);
            camera.Basis.Right = camera.Basis.Right.rotateZ(0.02);

            pos.X = Math.Cos(cameraAngle) * 5;
            pos.Y = Math.Sin(cameraAngle) * 5;

            cameraAngle += 0.02;*/
            objects[0].Rotation[0] += 0.01;
            objects[0].Rotation[1] += 0.01;
            objects[0].Rotation[2] += 0.01;

            //objects[0].Scale[1] += 0.01;


            refreshDrawing();
        }

        private void DrawButton_Click(object sender, EventArgs e)
        {
            objects.Add(getCube(1));
            foreach (Object obj in objects)
            {
                drawObject(obj);
            }
            GraphicsDisplayPictureBox.Refresh();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            camera.Basis.Position.X += 1;
            refreshDrawing();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            camera.Basis.Position.X -= 1;
            refreshDrawing();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            camera.Basis.Position.Y += 1;
            refreshDrawing();
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            camera.Basis.Position.Y -= 1;
            refreshDrawing();
        }

        public void refreshDrawing()
        {
            foreach (Object obj in objects)
            {
                drawObject(obj);
            }
            GraphicsDisplayPictureBox.Refresh();
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            camera.Basis.Position.Z += 1;
            refreshDrawing();
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            camera.Basis.Position.Z -= 1;
            refreshDrawing();
        }

        private void TurnLeftButton_Click(object sender, EventArgs e)
        {
            cameraAngle += 0.1;
            camera.Basis.Forward = camera.Basis.Forward.rotateDegreesZ(10);
            camera.Basis.Right = camera.Basis.Right.rotateDegreesZ(10);
            refreshDrawing();
        }

        private void TurnRightButton_Click(object sender, EventArgs e)
        {
            cameraAngle -= 0.1;
            camera.Basis.Forward = camera.Basis.Forward.rotateDegreesZ(-10);
            camera.Basis.Right = camera.Basis.Right.rotateDegreesZ(-10);
            refreshDrawing();
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            if (ClockTimer.Enabled)
            {
                ClockTimer.Stop();
            }
            else
            {
                ClockTimer.Start();
            }

        }


        public void drawObject(Object obj)
        {
            Graphics g = Graphics.FromImage(CubeBitmap);
            g.Clear(Color.White);

            for (int i = 0; i < obj.Edges.Count; i++)
            {
                Edge edge = obj.Edges[i];
                PointF[] points = new PointF[2];
                points[0] = camera.toScreen(obj.getTransformedVertex(obj.Vertices[edge.A]).convertToVector());
                points[1] = camera.toScreen(obj.getTransformedVertex(obj.Vertices[edge.B]).convertToVector());
                Pen pen = new Pen(Color.Tan);
                pen.Width = 5;
                g.DrawPolygon(pen, points);
            }

            /*for (int i = 0; i < obj.Faces.Count; i++)
            {
                Face face = obj.Faces[i];
                PointF[] points = new PointF[face.Vertices.Count];
                for (int j = 0; j < face.Vertices.Count; j++)
                {
                    points[j] = camera.toScreen(obj.getTransformedVertex(obj.Vertices[face.Vertices[j]]).convertToVector());
                }
                g.FillPolygon(new SolidBrush(Color.Blue), points);
            }*/
        }
    }
}