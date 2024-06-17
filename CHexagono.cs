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
                // Calcular el radio del círculo circunscrito al pentágono
                double radius = sideLength / (2 * Math.Sin(Math.PI / 5));

                // Coordenadas de los vértices del pentágono
                Point[] vertices = new Point[5];
                for (int i = 0; i < 5; i++)
                {
                    double angle = 2 * Math.PI / 5 * i - Math.PI / 2; // Ángulo girado 90 grados en sentido contrario para la punta hacia arriba
                    int x = (int)(radius * Math.Cos(angle)) + (int)radius; // Ajustar para centrar el pentágono
                    int y = (int)(radius * Math.Sin(angle)) + (int)radius; // Ajustar para centrar el pentágono
                    vertices[i] = new Point(x, y);
                }

                using (Pen pen = new Pen(Color.DarkTurquoise, 2))
                {
                    graphics.DrawPolygon(pen, vertices);
                }
            }

        }
    }
}
