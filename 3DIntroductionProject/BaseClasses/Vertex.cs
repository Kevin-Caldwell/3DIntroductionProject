using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Vertex
    {
        #region Fields
        private double _x;
        private double _y;
        private double _z;
        #endregion

        #region Properties
        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public double Z { get { return _z; } set { _z = value; } }
        #endregion

        #region Constructors
        public Vertex()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }
        public Vertex(double X, double Y, double Z)
        {
            _x = X;
            _y = Y;
            _z = Z;
        }
        public Vertex(Vertex v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }
        #endregion

        #region Instance Methods
        public Vector3 ConvertToVector()
        {
            return new Vector3(X, Y, Z);
        }
        public void SetVertex(Vertex v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }
        #endregion
    }
}