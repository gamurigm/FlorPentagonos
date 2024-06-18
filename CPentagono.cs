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
                public PointF Start;
                public PointF End;

                public Line(PointF start, PointF end)
                {
                    Start = start;
                    End = end;
                }
            }
            public float CalculateDistance(PointF p1, PointF p2)
            {
                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;
                return (float)Math.Sqrt(dx * dx + dy * dy);
            }
            public void DrawPentagon(Graphics graphics, int sideLength)
            {
                // Calcular el radio del círculo
                float radius = (float)(sideLength / (2 * Math.Sin(Math.PI / 5)));

                // Coordenadas de los vértices del pentágono
                PointF[] vertices = new PointF[5];
                for (int i = 0; i < 5; i++)
                {
                    float angle = (float)(2 * Math.PI / 5 * i - Math.PI / 2);
                    float x = (float)(radius * Math.Cos(angle) + radius);
                    float y = (float)(radius * Math.Sin(angle) + radius);

           
                    vertices[i] = new PointF(x, y);
                }


                using (Pen pen = new Pen(Color.DarkTurquoise, 2))
                {
                    graphics.DrawPolygon(pen, vertices.Select(v => new Point((int)v.X, (int)v.Y)).ToArray());
                }

                DrawStar(graphics, vertices);

                List<PointF> intersections = CalculateIntersections(graphics, vertices);
                foreach (var intersection in intersections)
                {
                    graphics.FillEllipse(Brushes.Red, intersection.X - 3, intersection.Y - 3, 6, 6);
                }

                for (int i = 0; i < 5; i++)
                {
                    int nextIndex = (i + 1) % 5;
                    float side = CalculateDistance(vertices[i], vertices[nextIndex]);
                    MessageBox.Show($"Longitud del lado {i + 1}: {side}");
                }


            }

            public void DrawStar(Graphics graphics, PointF[] vertices)
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

            public List<PointF> CalculateIntersections(Graphics graphics, PointF[] vertices)
            {
                List<PointF> intersections = new List<PointF>();

                // líneas que se cruzan
                Line line1 = new Line(vertices[0], vertices[2]);
                Line line2 = new Line(vertices[1], vertices[4]);
                Line line3 = new Line(vertices[4], vertices[2]);
                Line line4 = new Line(vertices[0], vertices[3]);
                Line line5 = new Line(vertices[3], vertices[1]);

                PointF intersection1 = CalculateLineIntersection(line1, line2);
                PointF intersection2 = CalculateLineIntersection(line2, line4);
                PointF intersection4 = CalculateLineIntersection(line3, line5);
                PointF intersection3 = CalculateLineIntersection(line4, line3);
                PointF intersection5 = CalculateLineIntersection(line5, line1);



                float distance12 = CalculateDistance(intersection1, intersection2);
                float distance23 = CalculateDistance(intersection2, intersection3);
                float distance34 = CalculateDistance(intersection3, intersection4);
                float distance45 = CalculateDistance(intersection4, intersection5);
                float distance51 = CalculateDistance(intersection5, intersection1);


                using (Pen pen = new Pen(Color.Red, 2))
                {
                    DrawPointAtDistance(vertices[0], vertices[1], distance12, graphics, pen);
                    DrawPointAtDistance(vertices[1], vertices[2], distance23, graphics, pen);
                    DrawPointAtDistance(vertices[2], vertices[3], distance34, graphics, pen);
                    DrawPointAtDistance(vertices[3], vertices[4], distance45, graphics, pen);
                    DrawPointAtDistance(vertices[4], vertices[0], distance51, graphics, pen);

                    DrawPointAtDistance(vertices[1], vertices[0], distance12, graphics, pen);
                    DrawPointAtDistance(vertices[2], vertices[1], distance23, graphics, pen);
                    DrawPointAtDistance(vertices[3], vertices[2], distance34, graphics, pen);
                    DrawPointAtDistance(vertices[4], vertices[3], distance45, graphics, pen);
                    DrawPointAtDistance(vertices[0], vertices[4], distance51, graphics, pen);
                }

                //MessageBox.Show($"Distancia entre intersection1 y intersection2: {distance12}");
                //MessageBox.Show($"Distancia entre intersection2 y intersection3: {distance23}");
                //MessageBox.Show($"Distancia entre intersection3 y intersection4: {distance34}");
                //MessageBox.Show($"Distancia entre intersection4 y intersection5: {distance45}");
                //MessageBox.Show($"Distancia entre intersection5 y intersection1: {distance51}");


                // interceptos

                if (intersection1 != PointF.Empty)
                    intersections.Add(intersection1);
                if (intersection2 != PointF.Empty)
                    intersections.Add(intersection2);
                if (intersection3 != PointF.Empty)
                    intersections.Add(intersection3);
                if (intersection4 != PointF.Empty)
                    intersections.Add(intersection4);
                if (intersection5 != PointF.Empty)
                    intersections.Add(intersection5);

                return intersections;
            }

            private PointF CalculateLineIntersection(Line line1, Line line2)
            {
                float x1 = line1.Start.X;
                float y1 = line1.Start.Y;
                float x2 = line1.End.X;
                float y2 = line1.End.Y;

                float x3 = line2.Start.X;
                float y3 = line2.Start.Y;
                float x4 = line2.End.X;
                float y4 = line2.End.Y;

                // Calcular las pendientes 
                float m1 = (y2 - y1) / (x2 - x1);
                float m2 = (y4 - y3) / (x4 - x3);

                // Calcular las intersecciones si no son paralelas
                if (m1 != m2)
                {
                    float x = ((m1 * x1 - m2 * x3) + y3 - y1) / (m1 - m2);
                    float y = m1 * (x - x1) + y1;

                    return new PointF(x, y);
                }
                else
                {
                    return PointF.Empty;
                }
            }

         
            public void DrawPointAtDistance(PointF vertex1, PointF vertex2, float distanceL, Graphics graphics, Pen pen)
            {
                float dx = vertex2.X - vertex1.X;
                float dy = vertex2.Y - vertex1.Y;

                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                PointF point = new PointF(vertex1.X + distanceL * dx, vertex1.Y + distanceL * dy);

                graphics.DrawEllipse(pen, point.X - 2, point.Y - 2, 4, 4);
        }

    }
    }
}