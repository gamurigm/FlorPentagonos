namespace Conjunta1
{
    partial class FrmMargarita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLado = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grbProcesos = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbProcesos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(16, 19);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(44, 16);
            this.lblLado.TabIndex = 0;
            this.lblLado.Text = "Lado: ";
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(101, 16);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 22);
            this.txtLado.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLado);
            this.groupBox1.Controls.Add(this.lblLado);
            this.groupBox1.Location = new System.Drawing.Point(81, 652);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 67);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entrada";
            // 
            // grbCanvas
            // 
            this.grbCanvas.Controls.Add(this.picCanvas);
            this.grbCanvas.Location = new System.Drawing.Point(15, 14);
            this.grbCanvas.Name = "grbCanvas";
            this.grbCanvas.Size = new System.Drawing.Size(828, 618);
            this.grbCanvas.TabIndex = 4;
            this.grbCanvas.TabStop = false;
            this.grbCanvas.Text = "Canvas";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(6, 21);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(816, 591);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(6, 21);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(100, 21);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 6;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(195, 21);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // grbProcesos
            // 
            this.grbProcesos.Controls.Add(this.btnSalir);
            this.grbProcesos.Controls.Add(this.btnResetear);
            this.grbProcesos.Controls.Add(this.btnCalcular);
            this.grbProcesos.Location = new System.Drawing.Point(448, 652);
            this.grbProcesos.Name = "grbProcesos";
            this.grbProcesos.Size = new System.Drawing.Size(286, 73);
            this.grbProcesos.TabIndex = 8;
            this.grbProcesos.TabStop = false;
            this.grbProcesos.Text = "Procesos";
            this.grbProcesos.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // FrmMargarita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 746);
            this.Controls.Add(this.grbProcesos);
            this.Controls.Add(this.grbCanvas);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMargarita";
            this.Text = "FrmHexagono";
            this.Load += new System.EventHandler(this.FrmHexagono_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbProcesos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox grbProcesos;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}