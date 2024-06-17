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
        public class CHexagono
        {
            private int scaleFactor; 

            public int SF
            {
                get { return scaleFactor; }
                set { scaleFactor = value; }
            }

            public CHexagono(int scaleFactor)
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

                // Dibujar las líneas que forman la estrella dentro del pentágono

                using (Pen starPen = new Pen(Color.Black, 3))
                {
                    graphics.DrawLine(starPen, vertices[0], vertices[2]); 
                    graphics.DrawLine(starPen, vertices[1], vertices[4]); 
                    graphics.DrawLine(starPen, vertices[4], vertices[2]);
                    graphics.DrawLine(starPen, vertices[0], vertices[3]);
                    graphics.DrawLine(starPen, vertices[3], vertices[1]);
                }
            }


        }
    }
}
