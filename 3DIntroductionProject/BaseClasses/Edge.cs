using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Edge
    {
        #region Fields
        private Vertex _A;
        private Vertex _B;
        #endregion

        #region Properties
        public Vertex A { get { return _A; } set { _A = value; } }
        public Vertex B { get { return _B; } set { _B = value; } }
        #endregion

        #region Constructors
        public Edge()
        {
            _A = new Vertex();
            _B = new Vertex();
        }
        public Edge(Vertex a, Vertex b)
        {
            _A = a;
            _B = b;
        }
        #endregion
    }
}
