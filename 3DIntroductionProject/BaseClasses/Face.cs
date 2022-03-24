using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Face
    {
        private List<int> _vertices;
        private Vector3 _normal;
        
        public List<int> Vertices { get { return _vertices; } set { _vertices = value; } }

        public Vector3 Normal { get { return _normal; } set { _normal = value; } }

        public Face(params int[] Vertices)
        {
            _vertices = new List<int>(Vertices);
        }
        
    }
}
