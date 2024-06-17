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
    public partial class FrmMargarita : Form
    {
        private CHexagono hexagono; 
        private int SF = 1; 

        public FrmMargarita()
        {
            InitializeComponent();
            picCanvas.Paint += new PaintEventHandler(this.PicCanvas_Paint);
            btnCalcular.Click += new EventHandler(this.btnCalcular_Click);
            hexagono = new CHexagono(SF);
        }
        private void FrmHexagono_Load(object sender, EventArgs e) { }
        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (int.TryParse(txtLado.Text, out int sideLength) && sideLength > 0)
                {
                    hexagono.DrawPentagon(e.Graphics, sideLength);
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un valor válido para el lado del pentágono.");
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error al dibujar el pentágono.");
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e) {picCanvas.Invalidate();}
        private void groupBox3_Enter(object sender, EventArgs e) {}
        private void btnSalir_Click(object sender, EventArgs e) {Application.Exit();}
        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtLado.Clear();
            picCanvas.Refresh();
        }
    }
 }
