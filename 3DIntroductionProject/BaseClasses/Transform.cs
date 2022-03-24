using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class Transform
    {
        private Vector3 _translation;
        private Vector3 _rotation;
        private Vector3 _scale;

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

        public Transform()
        {
            _translation = new Vector3(0, 0, 0);
            _rotation = new Vector3(0, 0, 0);
            _scale = new Vector3(1, 1, 1);
        }

        public Vertex getTransformedVertex(Vertex v)
        {
            Vertex transformedVertex = new Vertex(v);

            //Scaling
            transformedVertex.X *= _scale.X;
            transformedVertex.Y *= _scale.Y;
            transformedVertex.Z *= _scale.Z;

            double X = transformedVertex.X;
            double Y = transformedVertex.Y;
            double Z = transformedVertex.Z;

            // X Rotation
            double sinX = Math.Sin(_rotation.X);
            double cosX = Math.Cos(_rotation.X);

            transformedVertex.Y = (Y * cosX + Z * sinX);
            transformedVertex.Z = (-Y * sinX + Z * cosX);

            X = transformedVertex.X;
            Y = transformedVertex.Y;
            Z = transformedVertex.Z;

            // Y Rotation
            double sinY = Math.Sin(_rotation.Y);
            double cosY = Math.Cos(_rotation.Y);

            transformedVertex.X = (X * cosY + Z * sinY);
            transformedVertex.Z = (Z * cosY - X * sinY);

            X = transformedVertex.X;
            Y = transformedVertex.Y;
            Z = transformedVertex.Z;

            // Z Rotation
            double sinZ = Math.Sin(_rotation.Z);
            double cosZ = Math.Cos(_rotation.Z);

            transformedVertex.X = (X * cosZ - Y * sinZ);
            transformedVertex.Y = (X * sinZ + Y * cosZ);

            X = transformedVertex.X;
            Y = transformedVertex.Y;
            Z = transformedVertex.Z;

            //Translation
            transformedVertex.X += _translation.X;
            transformedVertex.Y += _translation.Y;
            transformedVertex.Z += _translation.Z;

            return transformedVertex;
        }
    }
}
