using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject.RenderingClasses
{
    internal class ObjectPackager
    {
        private ObjectManager _objectManager;
        private Camera ViewportCamera;

        public ObjectPackager(ObjectManager objectManager)
        {
            _objectManager = objectManager;
            ViewportCamera = objectManager.ViewportCamera;
        }

        private List<object> PrepareRenderingQueue(List<Object> objectList)
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


        /// <summary>
        /// Extremely temporary method for sorting Properties of Objects.
        /// </summary>
        /// <param name="list"></param>
        private void BubbleSort(List<object> list)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (GetDistanceFromCamera(list[i + 1]) > GetDistanceFromCamera(list[i]))
                    {
                        (list[i], list[i + 1]) = (list[i + 1], list[i]);
                        sorted = false;
                    }
                }
            }
        }



            /// <summary>
            /// </summary>
            /// <param name="obj">Vertex, Edge or Face object</param>
            /// <returns>Distance of Vertex / Mid Point / Median from the Camera</returns>
            private double GetDistanceFromCamera(object obj)
            {
                double x = -1;

                if (obj is Vertex v)
                {
                    x = PointDistanceFromOrigin(ViewportCamera.ToCameraCoordinates(v.ConvertToVector()));
                }
                else if (obj is Edge edge)
                {
                    Vertex midPoint = new Vertex();
                    (midPoint.X, midPoint.Y, midPoint.Z) = (midPoint.Y, midPoint.Z, midPoint.X);

                    midPoint.X += edge.A.X;
                    midPoint.Y += edge.A.Y;
                    midPoint.Z += edge.A.Z;

                    midPoint.X += edge.B.X;
                    midPoint.Y += edge.B.Y;
                    midPoint.Z += edge.B.Z;

                    midPoint.X /= 2;
                    midPoint.Y /= 2;
                    midPoint.Z /= 2;

                    x = PointDistanceFromOrigin(ViewportCamera.ToCameraCoordinates(midPoint.ConvertToVector()));

                }
                else if (obj is Face face)
                {

                    Vertex median = new Vertex();
                    foreach (Vertex vertex in face.Vertices)
                    {
                        median.X += vertex.X;
                        median.Y += vertex.Y;
                        median.Z += vertex.Z;
                    }

                    median.X /= face.Vertices.Count;
                    median.Y /= face.Vertices.Count;
                    median.Z /= face.Vertices.Count;


                    x = PointDistanceFromOrigin(ViewportCamera.ToCameraCoordinates(median.ConvertToVector()));
                }

                return x;
            }
            /*        private double Minimum(double x, double y)
                    {
                        return x < y ? x : y;
                    }*/
            private double PointDistanceFromOrigin(Vector3 v)
            {
                return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
            }
        }
    }
