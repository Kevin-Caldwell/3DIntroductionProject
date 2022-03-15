using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    public class Object
    {
        private string _name;
        private Vector3 _position;

        private List<Face> _faces;
        private List<Edge> _edges;
        private List<Vertex> _vertices;

        private double[] _translation;
        private double[] _rotation;
        private double[] _scale;

        #region Properties
        public String Name { get { return _name; } set { _name = value; } }
        public Vector3 Position { get { return _position; } set { _position = value; } }
        public List<Face> Faces { get { return _faces; } set { _faces = value;} }
        public List <Edge> Edges { get { return _edges; } set { _edges = value;} }
        public List<Vertex> Vertices { get { return _vertices; } set { _vertices = value; } }
        public double[] Translation { get { return _translation; } set { _translation = value; } }
        public double[] Rotation { get { return _rotation; } set { _rotation = value; } }
        public double[] Scale { get { return _scale; } set { _scale = value; } }
        #endregion


        public Object()
        {
            Translation = new double[3];
            Rotation = new double[3];
            Scale = new double[3];

            for(int i = 0; i < 3; i++)
            {
                Translation[i] = 0;
                Rotation[i] = 0;
                Scale[i] = 1;
            }
        }

        public Object(List<Vertex> Vertices)
        {
            this.Vertices = Vertices;
        }

        public Object(List<Vertex> vertices, List<Edge> edges, List<Face> faces)
        {
            Vertices = vertices;
            Edges = edges;
            Faces = faces;
        }

        public Vertex getTransformedVertex(Vertex v)
        {
            Vertex transformedVertex = new Vertex(v);

            // X Rotation
            double sinX = Math.Sin(Rotation[0]);
            double cosX = Math.Cos(Rotation[0]);

            transformedVertex.Y *= (cosX + sinX);
            transformedVertex.Z *= (cosX - sinX);

            // Y Rotation
            double sinY = Math.Sin(Rotation[1]);
            double cosY = Math.Cos(Rotation[1]);

            transformedVertex.X *= (cosY - sinY);
            transformedVertex.Z *= (sinY + cosY);

            // Z Rotation
            double sinZ = Math.Sin(Rotation[2]);
            double cosZ = Math.Cos(Rotation[2]);

            transformedVertex.X *= (cosZ + sinZ);
            transformedVertex.Y *= (cosZ - sinZ);


            //Scaling
            transformedVertex.X *= Scale[0];
            transformedVertex.Y *= Scale[1];
            transformedVertex.Z *= Scale[2];

            //Translation
            transformedVertex.X += Translation[0];
            transformedVertex.Y += Translation[1];
            transformedVertex.Z += Translation[2];

            return transformedVertex;
        }
    }
}
