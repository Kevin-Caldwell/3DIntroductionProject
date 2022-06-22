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
                if (obj is Face face)
                {
                    PointF[] points = new PointF[face.Vertices.Count];

                    for (int i = 0; i < face.Vertices.Count; i++)
                    {
                        points[i] = ViewportCamera.ToScreen(face.Vertices[i].ConvertToVector());
                    }

                    double scale = ((face.Median - ViewportCamera.Basis.Position).Normalize() * -1).DotProduct(face.Normal);
                    if (scale > 0)
                    {
                        scale = scale > 1 ? 1 : scale;
                        //scale *= -1;
                        Color faceColor = Color.FromArgb(255,
                            (int) (Settings.FILL_COLOR.R * scale),
                            (int) (Settings.FILL_COLOR.G * scale),
                            (int) (Settings.FILL_COLOR.B * scale));

                        _graphics.FillPolygon(new SolidBrush(faceColor), points);
                    }

                    /*PointF p1 = ViewportCamera.ToScreen(face.Median + face.Normal);
                    PointF p2 = ViewportCamera.ToScreen(face.Median);


                    _graphics.DrawLine(new Pen(Settings.VERTEX_COLOR), p1, p2);*/
                }
            }
        }
    }
}
