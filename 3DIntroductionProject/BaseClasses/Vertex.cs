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

        private Vector3 _normal;
        #endregion

        #region Properties
        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public double Z { get { return _z; } set { _z = value; } }

        public Vector3 Normal { get { return _normal; } set { _normal = value; } }
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

        #region Operation Definitions
        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vertex operator - (Vertex a, Vertex b)
        {
            return new Vertex(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vertex operator / (Vertex a, double v)
        {
            return new Vertex(a.X / v, a.Y / v, a.Z / v);
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
        public override bool Equals(object obj)
        {
            bool equal = false;
            if (obj is Vertex v)
            {
                if(v.X == this.X && v.Y == this.Y && v.Z == this.Z)
                {
                    equal = true;
                }
            }
            return equal;
        }
        public override string ToString()
        {
            return _x + " , " + _y + " , " + _z;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}