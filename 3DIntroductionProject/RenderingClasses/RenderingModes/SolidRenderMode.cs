using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class SolidRenderMode : RenderMode
    {
        public SolidRenderMode(Graphics graphics, Camera cam) : base(graphics, cam)
        {

        }

        public override void Render(List<object> ObjectAttributes)
        {
            _graphics.Clear(Color.White);
            foreach (object obj in ObjectAttributes)
            {
                Pen pen;

                if (obj is Vertex v)
                {
                    pen = new Pen(Settings.VERTEX_COLOR);

                    PointF point = ViewportCamera.ToScreen(v.ConvertToVector());
                    pen.Width = 5;
                    _graphics.FillEllipse(new SolidBrush(Settings.WIREFRAME_COLOR), point.X - 4, point.Y - 4, 8, 8);

                }
                else if (obj is Edge edge)
                {
                    PointF[] points = new PointF[2];

                    points[0] = ViewportCamera.ToScreen(edge.A.ConvertToVector());
                    points[1] = ViewportCamera.ToScreen(edge.B.ConvertToVector());

                    pen = new Pen(Settings.WIREFRAME_COLOR) { Width = 5 };

                    _graphics.DrawLine(pen, points[0], points[1]);
                }
                else if (obj is Face face)
                {
                    if (ViewportCamera.Basis.Forward.DotProduct(face.Normal) < 0.1)
                    {
                        PointF[] points = new PointF[face.Vertices.Count];

                        for (int i = 0; i < face.Vertices.Count; i++)
                        {
                            points[i] = ViewportCamera.ToScreen(face.Vertices[i].ConvertToVector());
                        }

                        double scale = Math.Abs(ViewportCamera.Basis.Forward.Subtract(face.Median).DotProduct(face.Normal));
                        scale = scale < 1 ? scale : 1;

                        Color faceColor = Color.FromArgb(1, (int)(Settings.FILL_COLOR.R * scale),
                            (int)(Settings.FILL_COLOR.G * scale),
                           (int)(Settings.FILL_COLOR.B * scale));

                        _graphics.FillPolygon(new SolidBrush(Settings.FILL_COLOR), points);
                    }

                    PointF p1 = ViewportCamera.ToScreen(face.Median.Add(face.Normal));
                    PointF p2 = ViewportCamera.ToScreen(face.Median);


                    _graphics.DrawLine(new Pen(Settings.VERTEX_COLOR), p1, p2);
                }
            }
        }
    }
}
