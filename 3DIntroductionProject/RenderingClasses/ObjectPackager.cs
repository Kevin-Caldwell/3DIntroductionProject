using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    /// <summary>
    /// Packages All the Objects in the Scene as Vertices, Edges and Faces for rendering
    /// </summary>
    internal class ObjectPackager
    {
        public ObjectPackager()
        {
        }

        public List<object> PrepareRenderingQueue(List<Object> objectList)
        {
            List<object> RenderQueue = new List<object>();

            foreach (Object obj in objectList)
            {
                if (obj.Visible)
                {
                    foreach (Vertex v in obj.TransformedVertices)
                    {
                        RenderQueue.Add(v);
                    }
                    foreach (Edge edge in obj.Edges)
                    {
                        RenderQueue.Add(edge);
                    }
                    foreach (Face face in obj.Faces)
                    {
                        RenderQueue.Add(face);
                    }
                }
            }
            return RenderQueue;
        }

    }
}
