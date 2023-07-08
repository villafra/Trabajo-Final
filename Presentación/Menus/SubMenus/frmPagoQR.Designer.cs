
namespace Trabajo_Final
{
    partial class frmPagoQR
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
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.lblMensajes = new System.Windows.Forms.Label();
            this.pbpago = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpNuevoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.lblMensajes);
            this.grpNuevoLogin.Controls.Add(this.pbpago);
            this.grpNuevoLogin.Controls.Add(this.pictureBox1);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(900, 530);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Resumen de Pedido";
            // 
            // lblMensajes
            // 
            this.lblMensajes.AutoSize = true;
            this.lblMensajes.Location = new System.Drawing.Point(416, 379);
            this.lblMensajes.Name = "lblMensajes";
            this.lblMensajes.Size = new System.Drawing.Size(129, 17);
            this.lblMensajes.TabIndex = 5;
            this.lblMensajes.Text = "Esperando Lectura";
            // 
            // pbpago
            // 
            this.pbpago.Location = new System.Drawing.Point(45, 420);
            this.pbpago.Maximum = 4000;
            this.pbpago.Name = "pbpago";
            this.pbpago.Size = new System.Drawing.Size(810, 46);
            this.pbpago.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(288, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmPagoQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 566);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPagoQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmPagoTarjeta_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMensajes;
        private System.Windows.Forms.ProgressBar pbpago;
    }
}