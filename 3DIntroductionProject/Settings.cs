using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class Settings
    {
        public static Color FILL_COLOR = Color.Wheat;
        public static readonly Color WIREFRAME_COLOR = Color.Black;
        public static readonly Color POSITION_COLOR = Color.Teal;
        public static readonly Color VERTEX_COLOR = Color.Red;
        public static readonly Color EDGE_COLOR = Color.Blue;
        public static readonly Vector3 CAMERA_STARTING_LOCATION = new Vector3(20, 0, 2);
    }
}
