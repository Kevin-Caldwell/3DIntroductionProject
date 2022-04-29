using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DIntroductionProject
{
    internal class ObjectBuilder
    {
        public static Camera CreateDefaultCamera(Point screenSize)
        {
            Camera camera = new Camera(new Vector3(1, 0, 0), new Vector3(0, 0, 1), new Vector3(9, 0, 3), 70, screenSize)
            {
                Name = "Camera"
            };
            return camera;
        }
        public static Object CreateCube(double size)
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
            Object cube = new Object(vertices);

            //(0, 0, 0) 0
            //(0, 0, s) 1
            //(0, s, 0) 2
            //(0, s, s) 3
            //(s, 0, 0) 4
            //(s, 0, s) 5
            //(s, s, 0) 6
            //(s, s, s) 7

            List<Edge> edges = new List<Edge>
            {
                new Edge(cube.TransformedVertices[0], cube.TransformedVertices[1]),
                new Edge(cube.TransformedVertices[0], cube.TransformedVertices[2]),
                new Edge(cube.TransformedVertices[0], cube.TransformedVertices[4]),

                new Edge(cube.TransformedVertices[3], cube.TransformedVertices[1]),
                new Edge(cube.TransformedVertices[3], cube.TransformedVertices[2]),
                new Edge(cube.TransformedVertices[3], cube.TransformedVertices[7]),

                new Edge(cube.TransformedVertices[5], cube.TransformedVertices[1]),
                new Edge(cube.TransformedVertices[5], cube.TransformedVertices[4]),
                new Edge(cube.TransformedVertices[5], cube.TransformedVertices[7]),

                new Edge(cube.TransformedVertices[6], cube.TransformedVertices[2]),
                new Edge(cube.TransformedVertices[6], cube.TransformedVertices[4]),
                new Edge(cube.TransformedVertices[6], cube.TransformedVertices[7])
            };

            cube.Edges = edges;

            List<Face> faces = new List<Face>();
            faces.Add(new Face(cube.TransformedVertices[0],
                cube.TransformedVertices[1],
                cube.TransformedVertices[3],
                cube.TransformedVertices[2]));

            faces.Add(new Face(cube.TransformedVertices[0],
                cube.TransformedVertices[1],
                cube.TransformedVertices[5], 
                cube.TransformedVertices[4]));

            faces.Add(new Face(cube.TransformedVertices[0],
                cube.TransformedVertices[2], 
                cube.TransformedVertices[6], 
                cube.TransformedVertices[4]));

            faces.Add(new Face(cube.TransformedVertices[1],
                cube.TransformedVertices[3],
                cube.TransformedVertices[7], 
                cube.TransformedVertices[5]));

            faces.Add(new Face(cube.TransformedVertices[2], 
                cube.TransformedVertices[3], 
                cube.TransformedVertices[7], 
                cube.TransformedVertices[6]));

            faces.Add(new Face(cube.TransformedVertices[6], 
                cube.TransformedVertices[4], 
                cube.TransformedVertices[5], 
                cube.TransformedVertices[7]));

            cube.Faces = faces;

            cube.Name = "Cube";
            return cube;
        }
        public static Object CreateCylinder(double radius, double height, int subdivisions)
        {
            Object cylinder = new Object();

            List<Vertex> vertices = new List<Vertex>();
            List<Edge> edges = new List<Edge>();
            List<Face> faces = new List<Face>();

            double angle = 0;
            for (int i = 0; i < subdivisions; i++)
            {
                vertices.Add(new Vertex(radius * Math.Cos(angle), radius * Math.Sin(angle), height / 2));
                angle += 2 * Math.PI / subdivisions;
            }

            angle = 0;
            for (int i = 0; i < subdivisions; i++)
            {
                vertices.Add(new Vertex(radius * Math.Cos(angle), radius * Math.Sin(angle), -height / 2));
                angle += 2 * Math.PI / subdivisions;
            }

            cylinder.Vertices = vertices;

            for (int i = 0; i < subdivisions - 1; i++)
            {
                edges.Add(new Edge(cylinder.TransformedVertices[i], 
                    cylinder.TransformedVertices[i + 1]));

                edges.Add(new Edge(cylinder.TransformedVertices[subdivisions + i],
                    cylinder.TransformedVertices[subdivisions + i + 1]));
            }
            edges.Add(new Edge(cylinder.TransformedVertices[0], 
                cylinder.TransformedVertices[subdivisions - 1]));

            edges.Add(new Edge(cylinder.TransformedVertices[subdivisions],
                cylinder.TransformedVertices[2 * subdivisions - 1]));

            for (int i = 0; i < subdivisions; i++)
            {
                edges.Add(new Edge(cylinder.TransformedVertices[i], 
                    cylinder.TransformedVertices[subdivisions + i]));

                edges.Add(new Edge(cylinder.TransformedVertices[i + subdivisions],
                    cylinder.TransformedVertices[i]));
            }

            Face topFace = new Face();
            Face bottomFace = new Face();
            for(int i = 0; i < subdivisions; i++)
            {
                topFace.Vertices.Add(cylinder.TransformedVertices[i]);
                bottomFace.Vertices.Add(cylinder.TransformedVertices[subdivisions + i]);
            }

            faces.Add(topFace);
            faces.Add(bottomFace);

            for (int i = 0; i < subdivisions - 1; i++)
            {
                faces.Add(new Face(cylinder.TransformedVertices[i],
                    cylinder.TransformedVertices[i + 1],
                    cylinder.TransformedVertices[subdivisions + i + 1],
                    cylinder.TransformedVertices[subdivisions + i]
                    ));
            }

            faces.Add(new Face(cylinder.TransformedVertices[0],
                cylinder.TransformedVertices[subdivisions - 1],
                cylinder.TransformedVertices[2 * subdivisions - 1],
                cylinder.TransformedVertices[subdivisions]));

            cylinder.Edges = edges;
            cylinder.Faces = faces;
            cylinder.Name = "Cylinder";
            return cylinder;
        }
        public static Object CreatePlane(double size)
        {
            Object plane = new Object();
            plane.Name = "Plane";

            List<Vertex> vertices = new List<Vertex>();


            vertices.Add(new Vertex(size / 2, size / 2, 0));
            vertices.Add(new Vertex(-size / 2, size / 2, 0));
            vertices.Add(new Vertex(-size / 2, -size / 2, 0));
            vertices.Add(new Vertex(size / 2, -size / 2, 0));

            plane.Vertices = vertices;

            plane.UpdateTransformedVertices();

            plane.Edges.Add(new Edge(plane.TransformedVertices[0], plane.TransformedVertices[1]));
            plane.Edges.Add(new Edge(plane.TransformedVertices[1], plane.TransformedVertices[2]));
            plane.Edges.Add(new Edge(plane.TransformedVertices[2], plane.TransformedVertices[3]));
            plane.Edges.Add(new Edge(plane.TransformedVertices[0], plane.TransformedVertices[3]));

            plane.Faces.Add(new Face(plane.TransformedVertices[0],
                plane.TransformedVertices[1],
                plane.TransformedVertices[2],
                plane.TransformedVertices[3]));

            return plane;
        }
    }
}
