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
        private bool _renderable = true;
        private Transform _transform;

        private List<Face> _faces;
        private List<Edge> _edges;
        private List<Vertex> _vertices;

        private List<Vertex> _transformedVertices;

        #region Properties
        public String Name { get { return _name; } set { _name = value; } }
        public List<Face> Faces 
        { 
            get 
            { 
                return _faces; 
            } 
            set 
            {
                _faces = value;
            }
        }
        public List <Edge> Edges 
        { 
            get 
            { 
                return _edges; 
            }
            set 
            { 
                _edges = value;
            }
        }
        public List<Vertex> Vertices 
        {
            get 
            { 
                return _vertices; 
            } 
            set 
            { 
                _vertices = value;
                updateTransformedVertices();
            } 
        }
        public Vector3 Translation 
        { 
            get 
            { 
                return _transform.Translation; 
            } 
            set 
            {
                _transform.Translation = value;
                updateTransformedVertices();
            } 
        }
        public Vector3 Rotation 
        { 
            get 
            { 
                return _transform.Rotation; 
            } 
            set 
            {
                _transform.Rotation = value;
                updateTransformedVertices();
            } 
        }
        public Vector3 Scale 
        { 
            get 
            { 
                return _transform.Scale; 
            } 
            set 
            { 
                _transform.Scale = value;
                updateTransformedVertices();
            } 
        }
        public bool Renderable { get { return _renderable; } set { _renderable = value; } }
        public List<Vertex> TransformedVertices { get { return _transformedVertices; } set { _transformedVertices = value; } }
        #endregion

        public Object()
        {
            _vertices = new List<Vertex>(0);
            _edges = new List<Edge>(0);
            _faces = new List<Face>(0);

            _transform = new Transform();
            _transformedVertices = new List<Vertex>(0);
            updateTransformedVertices();
        }

        public Object(List<Vertex> Vertices)
        {
            _vertices = Vertices;
            _edges = new List<Edge>();
            _faces = new List<Face>();

            _transform = new Transform();
            _transformedVertices = new List<Vertex>(_vertices.Count);
            updateTransformedVertices();
        }

        public Object(List<Vertex> vertices, List<Edge> edges, List<Face> faces)
        {
            _vertices = vertices;
            _edges = edges;
            _faces = faces;

            _transform = new Transform();
            _transformedVertices = new List<Vertex>(_vertices.Count);
            updateTransformedVertices();
        }

        public void updateTransformedVertices()
        {
            TransformedVertices.Clear();
            for(int i = 0; i < Vertices.Count; i++)
            {
                TransformedVertices.Add(_transform.getTransformedVertex(_vertices[i]));
            }
            calculateFaceNormals();
        }

        public void calculateFaceNormals()
        {
            foreach(Face face in Faces)
            {
                if(face.Vertices.Count > 2)
                {
                    Vector3 v0 = _transformedVertices[face.Vertices[0]].convertToVector();
                    Vector3 v1 = _transformedVertices[face.Vertices[1]].convertToVector();
                    Vector3 v2 = _transformedVertices[face.Vertices[face.Vertices.Count - 1]].convertToVector();

                    face.Normal = v1.subtract(v0).crossProduct(v2.subtract(v1)).normalize();
                }
            }
        }
        
        public override string ToString() {return _name;}
    }
}
