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
        private int _A;
        private int _B;
        #endregion

        #region Properties
        public int A { get { return _A; } set { _A = value; } }
        public int B { get { return _B; } set { _B = value; } }
        #endregion

        #region Constructor
        public Edge()
        {
            _A = 0;
            _B = 0;
        }
        public Edge(int a, int b)
        {
            _A = a;
            _B = b;
        }
        #endregion
    }
}
