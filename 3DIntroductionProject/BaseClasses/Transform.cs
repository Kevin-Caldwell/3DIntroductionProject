using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class Transform
    {
        #region Fields
        private Vector3 _translation;
        private Vector3 _rotation;
        private Vector3 _scale;
        #endregion

        #region Properties
        public Vector3 Translation
        {
            get
            {
                return _translation;
            }
            set
            {
                _translation = value;
            }
        }
        public Vector3 Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
            }
        }
        public Vector3 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
            }
        }
        #endregion

        #region Constructor
        public Transform()
        {
            _translation = new Vector3(0, 0, 0);
            _rotation = new Vector3(0, 0, 0);
            _scale = new Vector3(1, 1, 1);
        }
        #endregion

        #region Instance Methods
        public Vertex getTransformedVertex(Vertex v)
        {
            Vertex transformedVertex = new Vertex(v);

            ApplyScale(transformedVertex);

            transformedVertex = ApplyRotationX(transformedVertex);
            transformedVertex = ApplyRotationY(transformedVertex);
            transformedVertex = ApplyRotationZ(transformedVertex);

            ApplyTranslation(transformedVertex);

            return transformedVertex;
        }
        public Vertex ApplyScale(Vertex v)
        {
            v.X *= _scale.X;
            v.Y *= _scale.Y;
            v.Z *= _scale.Z;
            return v;
        }
        public Vertex ApplyTranslation(Vertex v)
        {
            v.X += _translation.X;
            v.Y += _translation.Y;
            v.Z += _translation.Z;
            return v;
        }
        public Vertex ApplyRotationX(Vertex v)
        {
            Vertex rotatedV = new Vertex(v);

            double sinX = Math.Sin(_rotation.X);
            double cosX = Math.Cos(_rotation.X);

            rotatedV.Y = (v.Y * cosX + v.Z * sinX);
            rotatedV.Z = (-v.Y * sinX + v.Z * cosX);

            return rotatedV;
        }
        public Vertex ApplyRotationY(Vertex v)
        {
            Vertex rotatedV = new Vertex(v);

            double sinY = Math.Sin(_rotation.Y);
            double cosY = Math.Cos(_rotation.Y);
            
            rotatedV.X = (v.X * cosY + v.Z * sinY);
            rotatedV.Z = (v.Z * cosY - v.X * sinY);

            return rotatedV;
        }
        public Vertex ApplyRotationZ(Vertex v)
        {
            Vertex rotatedV = new Vertex(v);

            double sinZ = Math.Sin(_rotation.Z);
            double cosZ = Math.Cos(_rotation.Z);

            rotatedV.X = (v.X * cosZ - v.Y * sinZ);
            rotatedV.Y = (v.X * sinZ + v.Y * cosZ);

            return rotatedV;
        }
        #endregion
    }
}
