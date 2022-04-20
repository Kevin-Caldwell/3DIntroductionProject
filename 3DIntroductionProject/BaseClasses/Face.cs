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
        #endregion

        #region Properties
        public List<Vertex> Vertices { get { return _vertices; } set { _vertices = value; } }
        public Vector3 Normal { get { return _normal; } set { _normal = value; } }
        #endregion

        #region Constructor
        public Face(params Vertex[] Vertices)
        {
            _vertices = new List<Vertex>(Vertices);
        }
        #endregion

    }
}
