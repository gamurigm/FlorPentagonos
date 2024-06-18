using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conjunta1
{
    using System;
    using System.Drawing;

    namespace Conjunta1
    {
        public class CPentagono
        {
            private int scaleFactor;

            public int SF
            {
                get { return scaleFactor; }
                set { scaleFactor = value; }
            }

            public CPentagono(int scaleFactor)
            {
                this.scaleFactor = scaleFactor;
            }

            public void DrawPentagon(Graphics graphics, int sideLength)
            {
                // Calcular el radio del círculo
                double radius = sideLength / (2 * Math.Sin(Math.PI / 5));

                // Coordenadas de los vértices del pentágono
                Point[] vertices = new Point[5];
                for (int i = 0; i < 5; i++)
                {
                    double angle = 2 * Math.PI / 5 * i - Math.PI / 2;
                    int x = (int)(radius * Math.Cos(angle)) + (int)radius;
                    int y = (int)(radius * Math.Sin(angle)) + (int)radius;
                    vertices[i] = new Point(x, y);
                }

                // Dibujar el pentágono
                using (Pen pen = new Pen(Color.DarkTurquoise, 2))
                {
                    graphics.DrawPolygon(pen, vertices);
                }

                // Dibujar la estrella conectando los vértices del pentágono
                DrawStar(graphics, vertices);

                // Calcular e imprimir los puntos de intersección
                List<Point> intersections = CalculateIntersections(vertices);
                foreach (var intersection in intersections)
                {
                    graphics.FillEllipse(Brushes.Red, intersection.X - 3, intersection.Y - 3, 6, 6);
                }
            }

            public void DrawStar(Graphics graphics, Point[] vertices)
            {
                using (Pen starPen = new Pen(Color.Black, 1))
                {
                    graphics.DrawLine(starPen, vertices[0], vertices[2]); 
                    graphics.DrawLine(starPen, vertices[1], vertices[4]); 
                    graphics.DrawLine(starPen, vertices[4], vertices[2]); 
                    graphics.DrawLine(starPen, vertices[0], vertices[3]); 
                    graphics.DrawLine(starPen, vertices[3], vertices[1]); 
                }
            }

            public List<Point> CalculateIntersections(Point[] vertices)
            {
                List<Point> intersections = new List<Point>();

                // líneas que se cruzan
                Line line1 = new Line(vertices[0], vertices[2]); 
                Line line2 = new Line(vertices[1], vertices[4]); 
                Line line3 = new Line(vertices[4], vertices[2]); 
                Line line4 = new Line(vertices[0], vertices[3]); 
                Line line5 = new Line(vertices[3], vertices[1]);

               
                Point intersection1 = CalculateLineIntersection(line1, line2);
                Point intersection4 = CalculateLineIntersection(line2, line4);
                Point intersection2 = CalculateLineIntersection(line3, line5);
                Point intersection5 = CalculateLineIntersection(line4, line3);
                Point intersection3 = CalculateLineIntersection(line5, line1);
                



                // interceptos

                if (intersection1 != Point.Empty)
                    intersections.Add(intersection1);
               if (intersection2 != Point.Empty)
                    intersections.Add(intersection2);
                if (intersection3 != Point.Empty)
                    intersections.Add(intersection3);
                if (intersection4 != Point.Empty)
                    intersections.Add(intersection4);
                if (intersection5 != Point.Empty)
                    intersections.Add(intersection5); 

                return intersections;
            }

            private Point CalculateLineIntersection(Line line1, Line line2)
            {
                double x1 = line1.Start.X;
                double y1 = line1.Start.Y;
                double x2 = line1.End.X;
                double y2 = line1.End.Y;

                double x3 = line2.Start.X;
                double y3 = line2.Start.Y;
                double x4 = line2.End.X;
                double y4 = line2.End.Y;

                // Calcular las pendientes (m) de las líneas
                double m1 = (y2 - y1) / (x2 - x1);
                double m2 = (y4 - y3) / (x4 - x3);

                // Calcular las intersecciones si no son paralelas
                if (m1 != m2)
                {
                    double x = ((m1 * x1 - m2 * x3) + y3 - y1) / (m1 - m2);
                    double y = m1 * (x - x1) + y1;

                    return new Point((int)x, (int)y);
                }
                else
                {
                    // Devolver un punto que indique que no hay intersección
                    return Point.Empty;
                }
            }

            // Estructura Line para representar una línea entre dos puntos
            public struct Line
            {
                public Point Start;
                public Point End;

                public Line(Point start, Point end)
                {
                    Start = start;
                    End = end;
                }
            }
        }
    }
}
