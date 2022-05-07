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
        public void setVector(Vector3 v)
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
        }
        public Vector3 add(Vector3 v)
        {
            return new Vector3(_x + v.X, _y + v.Y, _z + v.Z);
        }
        public Vector3 subtract(Vector3 v)
        {
            return new Vector3(_x - v.X, _y - v.Y, _z - v.Z);
        }
        public Vector3 normalize()
        {
            double mag = magnitude();
            return new Vector3(_x / mag, _y / mag, _z / mag);
        }
        public Vector3 multiplyScalar(double a)
        {
            _x *= a;
            _y *= a;
            _z *= a;
            return this;
        }
        public double dotProduct(Vector3 v)
        {
            return _x * v.X + _y * v.Y + _z * v.Z;
        }
        public double magnitude()
        {
            return Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }
        public double squareOfMagnitude()
        {
            return (_x * _x + _y * _y + _z * _z);
        }
        public Vector3 crossProduct(Vector3 v)
        {
            return new Vector3(_y * v.Z + _z * v.Y, _x * v.Z + _x * v.Y, _x * v.Y + _y * v.X);
        }
        public Vector3 rotateX(double thetaRadians)
        {
            double x = _x;
            double y = Math.Cos(thetaRadians) * _y - Math.Sin(thetaRadians) * _z;
            double z = Math.Sin(thetaRadians) * _y + Math.Cos(thetaRadians) * _z;

            return new Vector3(x, y, z);
        }
        public Vector3 rotateDegreesX(double thetaDegrees)
        {
            double thetaRadians = thetaDegrees * Math.PI / 180;
            return rotateX(thetaRadians);

        }
        public Vector3 rotateY(double thetaRadians)
        {
            double x = Math.Sin(thetaRadians) * _z + Math.Cos(thetaRadians) * _x;
            double y = _y;
            double z = Math.Cos(thetaRadians) * _z - Math.Sin(thetaRadians) * _x;

            return new Vector3(x, y, z);
        }
        public Vector3 rotateDegreesY(double thetaDegrees)
        {
            double thetaRadians = thetaDegrees * Math.PI / 180;
            return rotateY(thetaRadians);
        }
        public Vector3 rotateZ(double thetaRadians)
        {
            double x = Math.Cos(thetaRadians) * _x - Math.Sin(thetaRadians) * _y;
            double y = Math.Sin(thetaRadians) * _x + Math.Cos(thetaRadians) * _y;
            double z = _z;

            return new Vector3(x, y, z);
        }
        public Vector3 rotateDegreesZ(double thetaDegrees)
        {
            double thetaRadians = thetaDegrees * Math.PI / 180;
            return rotateZ(thetaRadians);

        }

        public override string ToString()
        {
            return _x + " , " + _y + " , " + _z;
        }
        #endregion
    }
}
