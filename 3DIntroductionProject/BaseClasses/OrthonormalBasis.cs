using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class OrthonormalBasis
    {
        #region Fields
        private Vector3 _position, _forward, _right, _up;
        #endregion Fields

        #region Properties
        public Vector3 Position { get { return _position; } set { _position = value; } }
        public Vector3 Forward { get { return _forward; } set { _forward = value; } }
        public Vector3 Right { get { return _right; } set { _right = value; } }
        public Vector3 Up { get { return _up; } set { _up = value; } }
        #endregion Properties

        #region Constructor
        public OrthonormalBasis(Vector3 forward, Vector3 up)
        {
            generateBasis(forward, up);
        }
        #endregion

        #region Instance Methods
        public void generateBasis(Vector3 forward, Vector3 up)
        {
            _forward = forward.Normalize();
            _right = forward.CrossProduct(up).Normalize();
            _up = _right.CrossProduct(_forward).Normalize();
        }
        public Vector3 ProjectOntoAxes(Vector3 v, bool isPosition)
        {
            if (isPosition)
            {
                v -= _position;
            }

            Vector3 projection = new Vector3();

            projection.X = _forward.DotProduct(v);
            projection.Y = _right.DotProduct(v);
            projection.Z = _up.DotProduct(v);

            v.SetVector(projection);
            
            return projection;
        }

        override public string ToString()
        {
            return "Forward: (" + _forward.X + ", " + _forward.Y + ", " + _forward.Z + ") \n"
                + "Up: (" + _up.X + ", " + _up.Y + ", " + _up.Z + ") \n"
                + "Right: (" + _right.X + ", " + _right.Y + ", " + _right.Z + ") ";
        }
        #endregion


    }
}
