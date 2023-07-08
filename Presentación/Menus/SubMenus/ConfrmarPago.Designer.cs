
namespace Trabajo_Final
{
    partial class frmConfirmarPago
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
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.flowPago = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPagar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.btnIzquierda);
            this.grpNuevoLogin.Controls.Add(this.btnDerecha);
            this.grpNuevoLogin.Controls.Add(this.lblCosto);
            this.grpNuevoLogin.Controls.Add(this.lblMonto);
            this.grpNuevoLogin.Controls.Add(this.flowPago);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(900, 296);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Resumen de Pedido";
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.BackColor = System.Drawing.Color.Transparent;
            this.btnIzquierda.BackgroundImage = global::Trabajo_Final.Properties.Resources.Izquierda;
            this.btnIzquierda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierda.FlatAppearance.BorderSize = 0;
            this.btnIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierda.Location = new System.Drawing.Point(6, 68);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(45, 64);
            this.btnIzquierda.TabIndex = 6;
            this.btnIzquierda.UseVisualStyleBackColor = false;
            this.btnIzquierda.Visible = false;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierdaBebidas_Click);
            // 
            // btnDerecha
            // 
            this.btnDerecha.BackColor = System.Drawing.Color.Transparent;
            this.btnDerecha.BackgroundImage = global::Trabajo_Final.Properties.Resources.derecha;
            this.btnDerecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerecha.FlatAppearance.BorderSize = 0;
            this.btnDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerecha.Location = new System.Drawing.Point(855, 68);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(45, 64);
            this.btnDerecha.TabIndex = 4;
            this.btnDerecha.UseVisualStyleBackColor = false;
            this.btnDerecha.Visible = false;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerechaBebidas_Click);
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(426, 251);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(48, 17);
            this.lblCosto.TabIndex = 3;
            this.lblCosto.Text = "$1000";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(407, 214);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(87, 17);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto Total:";
            // 
            // flowPago
            // 
            this.flowPago.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowPago.AutoScroll = true;
            this.flowPago.AutoSize = true;
            this.flowPago.Location = new System.Drawing.Point(445, 39);
            this.flowPago.Name = "flowPago";
            this.flowPago.Size = new System.Drawing.Size(10, 152);
            this.flowPago.TabIndex = 0;
            // 
            // btnPagar
            // 
            this.btnPagar.BackgroundImage = global::Trabajo_Final.Properties.Resources.caja_registradora;
            this.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Location = new System.Drawing.Point(426, 339);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(85, 63);
            this.btnPagar.TabIndex = 1;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // frmConfirmarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 414);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfirmarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.FlowLayoutPanel flowPago;
        private System.Windows.Forms.Button btnDerecha;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnPagar;
    }
}