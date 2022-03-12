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

        private double[,] _transformation;


        public String Name { get { return _name; } set { _name = value; } }
        public Vector3 Position { get { return _position; } set { _position = value; } }
        public List<Face> Faces { get { return _faces; } set { _faces = value;} }
        public List <Edge> Edges { get { return _edges; } set { _edges = value;} }
        public List<Vertex> Vertices { get { return _vertices; } set { _vertices = value; } }
        public double[,] Tranformation { get { return _transformation; } set { _transformation = value; } }

        public Object()
        {
            _transformation = new double[3, 3];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    _transformation[i, j] = 0;
                }
            }


        }
    }
}
