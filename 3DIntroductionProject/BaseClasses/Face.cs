using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Face
    {

        #region Fields
        private List<Vertex> _vertices;
        private Vector3 _normal;
        private Vector3 _median;
        #endregion

        #region Properties
        public List<Vertex> Vertices { get { return _vertices; } set { _vertices = value; UpdateMedian(); } }
        public Vector3 Normal { get { return _normal; } set { _normal = value; } }
        public Vector3 Median { get { return _median; } set { _median = value; } }
        #endregion

        #region Constructor
        public Face(params Vertex[] Vertices)
        {
            _vertices = new List<Vertex>(Vertices);
            UpdateMedian();
        }
        #endregion

        public void UpdateMedian()
        {
            Vector3 median = new Vector3();

            foreach(Vertex v in _vertices)
            {
                median.X += v.X;
                median.Y += v.Y;
                median.Z += v.Z;
            }
/*            for(int i = 0; i < _vertices.Count; i++)
            {
                median.Z+= 2;

                //median.add(_vertices[i].ConvertToVector());
            }*/
            median.X /= _vertices.Count;
            median.Y /= _vertices.Count;
            median.Z /= _vertices.Count;

            _median = median;
        }

        public bool Contains(Vertex v)
        {
            bool found = false;
            foreach(Vertex vertex in _vertices)
            {
                if (vertex.Equals(v))
                {
                    found = true;
                }
            }
            return found;
        }
    }
}
