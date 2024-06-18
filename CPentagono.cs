using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conjunta1
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

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
            public double CalculateDistance(Point p1, Point p2)
            {
                int dx = p2.X - p1.X;
                int dy = p2.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
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
                    double x = radius * Math.Cos(angle) + radius;
                    double y = radius * Math.Sin(angle) + radius;

                    // Redondear al entero más cercano utilizando Math.Round
                    vertices[i] = new Point((int)Math.Round(x), (int)Math.Round(y));
                }

                using (Pen pen = new Pen(Color.DarkTurquoise, 2))
                {
                    graphics.DrawPolygon(pen, vertices);
                }

                DrawStar(graphics, vertices);

                List<Point> intersections = CalculateIntersections(vertices);
                foreach (var intersection in intersections)
                {
                    graphics.FillEllipse(Brushes.Red, intersection.X - 3, intersection.Y - 3, 6, 6);
                }

                for (int i = 0; i < 5; i++)
                {
                    int nextIndex = (i + 1) % 5;
                    double side = CalculateDistance(vertices[i], vertices[nextIndex]);
                    MessageBox.Show($"Longitud del lado {i + 1}: {side}");
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
                Point intersection2 = CalculateLineIntersection(line2, line4);
                Point intersection4 = CalculateLineIntersection(line3, line5);
                Point intersection3 = CalculateLineIntersection(line4, line3);
                Point intersection5 = CalculateLineIntersection(line5, line1);

        

                double distance12 = CalculateDistance(intersection1, intersection2);
                double distance23 = CalculateDistance(intersection2, intersection3);
                double distance34 = CalculateDistance(intersection3, intersection4);
                double distance45 = CalculateDistance(intersection4, intersection5);
                double distance51 = CalculateDistance(intersection5, intersection1);

                MessageBox.Show($"Distancia entre intersection1 y intersection2: {distance12}");
                MessageBox.Show($"Distancia entre intersection2 y intersection3: {distance23}");
                MessageBox.Show($"Distancia entre intersection3 y intersection4: {distance34}");
                MessageBox.Show($"Distancia entre intersection4 y intersection5: {distance45}");
                MessageBox.Show($"Distancia entre intersection5 y intersection1: {distance51}");


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

                // Calcular las pendientes 
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
                    // no hay intersección
                    return Point.Empty;
                }
            }




        }
    }
}
