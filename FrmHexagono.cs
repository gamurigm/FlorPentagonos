using Conjunta1.Conjunta1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conjunta1
{
    public partial class FrmHexagono : Form
    {
        private CHexagono hexagono; // Instancia de la clase CHexagono
        private int scaleFactor = 1; // Factor de escalamiento inicial

        public FrmHexagono()
        {
            InitializeComponent();
            picCanvas.Paint += new PaintEventHandler(this.PicCanvas_Paint);
            btnCalcular.Click += new EventHandler(this.btnCalcular_Click);

            // Crear una instancia de CHexagono con el factor de escalamiento
            hexagono = new CHexagono(scaleFactor);
        }

        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (int.TryParse(txtLado.Text, out int sideLength) && sideLength > 0)
            {
                // Llamar al método DrawHexagon de CHexagono, pasando e.Graphics y el lado del hexágono
                hexagono.DrawHexagon(e.Graphics, sideLength);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el lado del hexágono.");
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            picCanvas.Invalidate(); // Invalidar el área de dibujo para forzar un repintado
        }



private void groupBox3_Enter(object sender, EventArgs e)
            {

            }

         

            private void FrmHexagono_Load(object sender, EventArgs e)
            {

            }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtLado.Clear();
            picCanvas.Refresh();
        }
    }
    }
