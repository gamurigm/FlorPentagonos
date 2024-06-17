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

            public int ScaleFactor
            {
                get { return scaleFactor; }
                set { scaleFactor = value; }
            }

            public CHexagono(int scaleFactor)
            {
                this.scaleFactor = scaleFactor;
            }

            public void DrawHexagon(Graphics graphics, int sideLength)
            {
                double apotema = Math.Sqrt(3) / 2 * sideLength * scaleFactor;

                // Calcular el primer vértice del hexágono
                int x1 = (int)Math.Round(Math.Sqrt(sideLength * sideLength - apotema * apotema)) * scaleFactor;
                int y1 = 0;  
                Point firstVertex = new Point(x1, y1);

                // vertices hexagono:
                Point[] vertices = new Point[6];
                vertices[0] = firstVertex;
                for (int i = 1; i < 6; i++)
                {
                    double angle = Math.PI / 3 * (i - 1);  //Representan las coordenadas X e Y del vértice anterior en el arreglo 
                    int x = vertices[i - 1].X + (int)(sideLength * Math.Cos(angle)) * scaleFactor;
                    int y = vertices[i - 1].Y + (int)(sideLength * Math.Sin(angle)) * scaleFactor;
                    vertices[i] = new Point(x, y);
                }

                Point center = new Point(
                    (vertices[0].X + vertices[3].X) / 2,
                    (vertices[0].Y + vertices[3].Y) / 2
                );

             
                Color[] colors = { Color.Red, Color.Green, Color.Blue, Color.Yellow, Color.Cyan, Color.Magenta };
                for (int i = 0; i < 6; i++)
                {
                    Point[] triangle = { vertices[i], center, vertices[(i + 1) % 6] };
                    using (SolidBrush brush = new SolidBrush(colors[i]))
                    {
                        graphics.FillPolygon(brush, triangle);
                    }
                }

                using (Pen pen = new Pen(Color.Black, 2))
                {
                    graphics.DrawPolygon(pen, vertices);
                }
            }
        }
    }
}
