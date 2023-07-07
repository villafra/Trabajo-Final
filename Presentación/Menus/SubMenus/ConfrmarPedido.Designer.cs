
namespace Trabajo_Final
{
    partial class frmConfirmarPedido
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmarPedido));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.flowPlatos = new System.Windows.Forms.FlowLayoutPanel();
            this.flowBebidas = new System.Windows.Forms.FlowLayoutPanel();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnIzquierdaPlatos = new System.Windows.Forms.Button();
            this.btnIzquierdaBebidas = new System.Windows.Forms.Button();
            this.btnDerechaPlatos = new System.Windows.Forms.Button();
            this.btnDerechaBebidas = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.btnIzquierdaPlatos);
            this.grpNuevoLogin.Controls.Add(this.btnIzquierdaBebidas);
            this.grpNuevoLogin.Controls.Add(this.btnDerechaPlatos);
            this.grpNuevoLogin.Controls.Add(this.btnDerechaBebidas);
            this.grpNuevoLogin.Controls.Add(this.lblCosto);
            this.grpNuevoLogin.Controls.Add(this.lblMonto);
            this.grpNuevoLogin.Controls.Add(this.flowPlatos);
            this.grpNuevoLogin.Controls.Add(this.flowBebidas);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(900, 430);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Resumen de Pedido";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(428, 389);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(48, 17);
            this.lblCosto.TabIndex = 3;
            this.lblCosto.Text = "$1000";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(407, 347);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(87, 17);
            this.lblMonto.TabIndex = 2;
            this.lblMonto.Text = "Monto Total:";
            // 
            // flowPlatos
            // 
            this.flowPlatos.AutoScroll = true;
            this.flowPlatos.Location = new System.Drawing.Point(410, 183);
            this.flowPlatos.Name = "flowPlatos";
            this.flowPlatos.Size = new System.Drawing.Size(10, 152);
            this.flowPlatos.TabIndex = 1;
            this.flowPlatos.WrapContents = false;
            // 
            // flowBebidas
            // 
            this.flowBebidas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowBebidas.AutoScroll = true;
            this.flowBebidas.AutoSize = true;
            this.flowBebidas.Location = new System.Drawing.Point(410, 35);
            this.flowBebidas.Name = "flowBebidas";
            this.flowBebidas.Size = new System.Drawing.Size(10, 152);
            this.flowBebidas.TabIndex = 0;
            // 
            // Listado
            // 
            this.Listado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listado.ImageStream")));
            this.Listado.TransparentColor = System.Drawing.Color.Transparent;
            this.Listado.Images.SetKeyName(0, "aprobado.png");
            this.Listado.Images.SetKeyName(1, "rechazado.png");
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageIndex = 1;
            this.btnCancelar.ImageList = this.Listado;
            this.btnCancelar.Location = new System.Drawing.Point(786, 460);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.ImageIndex = 0;
            this.btnConfirmar.ImageList = this.Listado;
            this.btnConfirmar.Location = new System.Drawing.Point(24, 460);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnIzquierdaPlatos
            // 
            this.btnIzquierdaPlatos.BackColor = System.Drawing.Color.Transparent;
            this.btnIzquierdaPlatos.BackgroundImage = global::Trabajo_Final.Properties.Resources.Izquierda;
            this.btnIzquierdaPlatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierdaPlatos.FlatAppearance.BorderSize = 0;
            this.btnIzquierdaPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierdaPlatos.Location = new System.Drawing.Point(6, 235);
            this.btnIzquierdaPlatos.Name = "btnIzquierdaPlatos";
            this.btnIzquierdaPlatos.Size = new System.Drawing.Size(45, 64);
            this.btnIzquierdaPlatos.TabIndex = 7;
            this.btnIzquierdaPlatos.UseVisualStyleBackColor = false;
            this.btnIzquierdaPlatos.Visible = false;
            this.btnIzquierdaPlatos.Click += new System.EventHandler(this.btnIzquierdaPlatos_Click);
            // 
            // btnIzquierdaBebidas
            // 
            this.btnIzquierdaBebidas.BackColor = System.Drawing.Color.Transparent;
            this.btnIzquierdaBebidas.BackgroundImage = global::Trabajo_Final.Properties.Resources.Izquierda;
            this.btnIzquierdaBebidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierdaBebidas.FlatAppearance.BorderSize = 0;
            this.btnIzquierdaBebidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierdaBebidas.Location = new System.Drawing.Point(6, 68);
            this.btnIzquierdaBebidas.Name = "btnIzquierdaBebidas";
            this.btnIzquierdaBebidas.Size = new System.Drawing.Size(45, 64);
            this.btnIzquierdaBebidas.TabIndex = 6;
            this.btnIzquierdaBebidas.UseVisualStyleBackColor = false;
            this.btnIzquierdaBebidas.Visible = false;
            this.btnIzquierdaBebidas.Click += new System.EventHandler(this.btnIzquierdaBebidas_Click);
            // 
            // btnDerechaPlatos
            // 
            this.btnDerechaPlatos.BackColor = System.Drawing.Color.Transparent;
            this.btnDerechaPlatos.BackgroundImage = global::Trabajo_Final.Properties.Resources.derecha;
            this.btnDerechaPlatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerechaPlatos.FlatAppearance.BorderSize = 0;
            this.btnDerechaPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerechaPlatos.Location = new System.Drawing.Point(855, 235);
            this.btnDerechaPlatos.Name = "btnDerechaPlatos";
            this.btnDerechaPlatos.Size = new System.Drawing.Size(45, 64);
            this.btnDerechaPlatos.TabIndex = 5;
            this.btnDerechaPlatos.UseVisualStyleBackColor = false;
            this.btnDerechaPlatos.Visible = false;
            this.btnDerechaPlatos.Click += new System.EventHandler(this.btnDerechaPlatos_Click);
            // 
            // btnDerechaBebidas
            // 
            this.btnDerechaBebidas.BackColor = System.Drawing.Color.Transparent;
            this.btnDerechaBebidas.BackgroundImage = global::Trabajo_Final.Properties.Resources.derecha;
            this.btnDerechaBebidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerechaBebidas.FlatAppearance.BorderSize = 0;
            this.btnDerechaBebidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerechaBebidas.Location = new System.Drawing.Point(855, 68);
            this.btnDerechaBebidas.Name = "btnDerechaBebidas";
            this.btnDerechaBebidas.Size = new System.Drawing.Size(45, 64);
            this.btnDerechaBebidas.TabIndex = 4;
            this.btnDerechaBebidas.UseVisualStyleBackColor = false;
            this.btnDerechaBebidas.Visible = false;
            this.btnDerechaBebidas.Click += new System.EventHandler(this.btnDerechaBebidas_Click);
            // 
            // frmConfirmarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(936, 519);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfirmarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.FlowLayoutPanel flowPlatos;
        private System.Windows.Forms.FlowLayoutPanel flowBebidas;
        private System.Windows.Forms.Button btnDerechaBebidas;
        private System.Windows.Forms.Button btnDerechaPlatos;
        private System.Windows.Forms.Button btnIzquierdaPlatos;
        private System.Windows.Forms.Button btnIzquierdaBebidas;
    }
}