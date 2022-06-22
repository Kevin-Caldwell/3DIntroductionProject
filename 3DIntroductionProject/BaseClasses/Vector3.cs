using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Vector3
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

        public static Vector3 operator +(Vector3 left, Vector3 right) 
        {
                return new Vector3(left._x + right._x, left._y + right._y, left._z + right._z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right._x, left.Y - right._y, left.Z - right.Z);
        }

        public static Vector3 operator *(Vector3 v, double k)
        {
            return new Vector3(v._x * k, v._y * k, v._z * k);
        }

        public static Vector3 operator /(Vector3 v, double k)
        {
            return new Vector3(v._x / k, v._y / k, v._z / k);
        }

        #endregion

        #region Constructor
        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }
        public Vector3(double X, double Y, double Z)
        {
            _x = X;
            _y = Y;
            _z = Z;
        }
        public Vector3(Vector3 v)
        {
            _x = v.X;
            _y = v.Y;
            _z = v.Z;
        }
        #endregion

        #region Instance Methods
        public void SetVector(Vector3 v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }
        public Vector3 Add(Vector3 v)
        {
            return new Vector3(_x + v.X, _y + v.Y, _z + v.Z);
        }
        public Vector3 Subtract(Vector3 v)
        {
            return new Vector3(_x - v.X, _y - v.Y, _z - v.Z);
        }
        public Vector3 Normalize()
        {
            double mag = Magnitude();
            return new Vector3(_x / mag, _y / mag, _z / mag);
        }
        public Vector3 MultiplyScalar(double a)
        {
            _x *= a;
            _y *= a;
            _z *= a;
            return this;
        }
        public double DotProduct(Vector3 v)
        {
            return _x * v.X + _y * v.Y + _z * v.Z;
        }
        public double Magnitude()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }
        public double SquareOfMagnitude()
        {
            return (_x * _x + _y * _y + _z * _z);
        }
        public Vector3 CrossProduct(Vector3 v)
        {
            return new Vector3(_y * v.Z - _z * v.Y, _z * v.X - _x * v.Z, _x * v.Y - _y * v.X);
        }
        public Vector3 RotateX(double thetaRadians)
        {
            double x = _x;
            double y = Math.Cos(thetaRadians) * _y - Math.Sin(thetaRadians) * _z;
            double z = Math.Sin(thetaRadians) * _y + Math.Cos(thetaRadians) * _z;

            return new Vector3(x, y, z);
        }
        public Vector3 RotateDegreesX(double thetaDegrees)
        {
            double thetaRadians = thetaDegrees * Math.PI / 180;
            return RotateX(thetaRadians);

        }
        public Vector3 RotateY(double thetaRadians)
        {
            double x = Math.Sin(thetaRadians) * _z + Math.Cos(thetaRadians) * _x;
            double y = _y;
            double z = Math.Cos(thetaRadians) * _z - Math.Sin(thetaRadians) * _x;

            return new Vector3(x, y, z);
        }
        public Vector3 RotateDegreesY(double thetaDegrees)
        {
            double thetaRadians = thetaDegrees * Math.PI / 180;
            return RotateY(thetaRadians);
        }
        public Vector3 RotateZ(double thetaRadians)
        {
            double x = Math.Cos(thetaRadians) * _x - Math.Sin(thetaRadians) * _y;
            double y = Math.Sin(thetaRadians) * _x + Math.Cos(thetaRadians) * _y;
            double z = _z;

            return new Vector3(x, y, z);
        }
        public Vector3 RotateDegreesZ(double thetaDegrees)
        {
            double thetaRadians = thetaDegrees * Math.PI / 180;
            return RotateZ(thetaRadians);

        }

        public override string ToString()
        {
            return _x + " , " + _y + " , " + _z;
        }
        #endregion
    }
}
