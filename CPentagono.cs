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
                // radio del círculo circunscrito
                float radius = (float)(sideLength / (2 * Math.Sin(Math.PI / 5)));

             
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

                PointF intersection1 = CalculateLineIntersection(line1, line2); // Sent. Antihorario
                PointF intersection2 = CalculateLineIntersection(line2, line4);
                PointF intersection4 = CalculateLineIntersection(line3, line5);
                PointF intersection3 = CalculateLineIntersection(line4, line3);
                PointF intersection5 = CalculateLineIntersection(line5, line1);


                float ladoP = CalculateDistance(intersection1, intersection2);


                using (Pen pen = new Pen(Color.Red, 2))
                {
                    PointF M=  GetPointAtDistance(vertices[0], vertices[1], ladoP, graphics, pen);
                    PointF N = GetPointAtDistance(vertices[1], vertices[2], ladoP, graphics, pen);
                    PointF O = GetPointAtDistance(vertices[2], vertices[3], ladoP, graphics, pen);
                    PointF P = GetPointAtDistance(vertices[3], vertices[4], ladoP, graphics, pen);
                    PointF Q = GetPointAtDistance(vertices[4], vertices[0], ladoP, graphics, pen);

                    PointF R = GetPointAtDistance(vertices[1], vertices[0], ladoP, graphics, pen);
                    PointF S = GetPointAtDistance(vertices[2], vertices[1], ladoP, graphics, pen);
                    PointF T = GetPointAtDistance(vertices[3], vertices[2], ladoP, graphics, pen);
                    PointF U = GetPointAtDistance(vertices[4], vertices[3], ladoP, graphics, pen);
                    PointF V = GetPointAtDistance(vertices[0], vertices[4], ladoP, graphics, pen);

                    JoinPoints(M, intersection1, graphics, pen);
                    JoinPoints(R, intersection1, graphics, pen);

                    JoinPoints(N, intersection5, graphics, pen);
                    JoinPoints(S, intersection5, graphics, pen);

                    JoinPoints(O, intersection4, graphics, pen);
                    JoinPoints(T, intersection4, graphics, pen);

                    JoinPoints(P, intersection3, graphics, pen);
                    JoinPoints(U, intersection3, graphics, pen);

                    JoinPoints(Q, intersection2, graphics, pen);
                    JoinPoints(V, intersection2, graphics, pen);



                    ColorPentagons(graphics, vertices[0], M, intersection1, intersection2, V);
                    ColorPentagons(graphics, Q, intersection2, intersection3, U, vertices[4]);
                    ColorPentagons(graphics, intersection3, P, vertices[3], T, intersection4);
                    ColorPentagons(graphics, intersection4, O, vertices[2], S, intersection5);
                    ColorPentagons(graphics,intersection1, R, vertices[1], N, intersection5);


                }


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

            public PointF GetPointAtDistance(PointF vertex1, PointF vertex2, float distanceL, Graphics graphics, Pen pen)
            {
                float dx = vertex2.X - vertex1.X;
                float dy = vertex2.Y - vertex1.Y;

                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                PointF point = new PointF(vertex1.X + distanceL * dx, vertex1.Y + distanceL * dy);

                graphics.DrawEllipse(pen, point.X - 2, point.Y - 2, 4, 4);

                return point;
            }

            public void JoinPoints(PointF point1, PointF point2, Graphics graphics, Pen pen)
            {
                graphics.DrawLine(pen, point1.X, point1.Y, point2.X, point2.Y);
            }

            private void ColorPentagons(Graphics graphics, PointF p1, PointF p2, PointF p3, PointF p4, PointF p5)
            {
                PointF[] pentagon = new PointF[] { p1, p2, p3, p4, p5 };
                ColorPentagon(graphics, pentagon, Color.Red);
            }

            private void ColorPentagon(Graphics graphics, PointF[] pentagon, Color color)
            {
                using (Brush brush = new SolidBrush(color))
                {
                    graphics.FillPolygon(brush, pentagon);
                }
            }



        }
    }
}