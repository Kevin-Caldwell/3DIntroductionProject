using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class WireframeRenderMode : RenderMode
    {
        public WireframeRenderMode(Graphics graphics, Camera cam) : base(graphics, cam)
        {
        }

        public override void Render(List<object> ObjectAttributes)
        {
            _graphics.Clear(Color.White);
            foreach (object obj in ObjectAttributes)
            {
                Pen pen = new Pen(Color.White);

                if (obj is Vertex v)
                {
                    pen.Color = Settings.VERTEX_COLOR;

                    PointF point = ViewportCamera.ToScreen(v.ConvertToVector());
                    pen.Width = 5;
                    _graphics.FillEllipse(new SolidBrush(Settings.VERTEX_COLOR), point.X - 5, point.Y - 5, 10, 10);

                }
                else if (obj is Edge edge)
                {
                    PointF[] points = new PointF[2];

                    points[0] = ViewportCamera.ToScreen(edge.A.ConvertToVector());
                    points[1] = ViewportCamera.ToScreen(edge.B.ConvertToVector());

                    pen.Width = 5;
                    pen.Color = Settings.EDGE_COLOR;

                    _graphics.DrawLine(pen, points[0], points[1]);
                }
            }
        }
    }
}
