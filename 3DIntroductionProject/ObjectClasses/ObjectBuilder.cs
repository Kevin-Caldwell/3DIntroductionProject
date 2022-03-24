using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class ObjectBuilder
    {
        public static Object createCube(double size)
        {
            List<Vertex> vertices = new List<Vertex>();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        double x = i == 1 ? size / 2 : -size / 2;
                        double y = j == 1 ? size / 2 : -size / 2;
                        double z = k == 1 ? size / 2 : -size / 2;

                        vertices.Add(new Vertex(x, y, z));
                    }
                }
            }
            //(0, 0, 0) 0
            //(0, 0, s) 1
            //(0, s, 0) 2
            //(0, s, s) 3
            //(s, 0, 0) 4
            //(s, 0, s) 5
            //(s, s, 0) 6
            //(s, s, s) 7

            List<Edge> edges = new List<Edge>();

            edges.Add(new Edge(0, 1));
            edges.Add(new Edge(0, 2));
            edges.Add(new Edge(0, 4));

            edges.Add(new Edge(3, 1));
            edges.Add(new Edge(3, 2));
            edges.Add(new Edge(3, 7));

            edges.Add(new Edge(5, 1));
            edges.Add(new Edge(5, 4));
            edges.Add(new Edge(5, 7));

            edges.Add(new Edge(6, 2));
            edges.Add(new Edge(6, 4));
            edges.Add(new Edge(6, 7));

            List<Face> faces = new List<Face>();
            faces.Add(new Face(0, 1, 3, 2));
            faces.Add(new Face(0, 1, 5, 4));

            faces.Add(new Face(0, 2, 6, 4));
            faces.Add(new Face(1, 3, 7, 5));

            faces.Add(new Face(2, 3, 7, 6));
            faces.Add(new Face(6, 4, 5, 7));
            Object cube = new Object(vertices, edges, faces);
            cube.Name = "Cube";
            return cube;
        }

    }
}
