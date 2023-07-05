namespace Trabajo_Final
{
    partial class frmTomarPedido
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
            this.flowPlatos = new System.Windows.Forms.FlowLayoutPanel();
            this.flowBebidas = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPedido = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCrearOrden = new System.Windows.Forms.Button();
            this.picboxPrincipal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // flowPlatos
            // 
            this.flowPlatos.BackColor = System.Drawing.SystemColors.Control;
            this.flowPlatos.Location = new System.Drawing.Point(55, 284);
            this.flowPlatos.Name = "flowPlatos";
            this.flowPlatos.Size = new System.Drawing.Size(1232, 260);
            this.flowPlatos.TabIndex = 14;
            // 
            // flowBebidas
            // 
            this.flowBebidas.BackColor = System.Drawing.SystemColors.Control;
            this.flowBebidas.Location = new System.Drawing.Point(55, 11);
            this.flowBebidas.Name = "flowBebidas";
            this.flowBebidas.Size = new System.Drawing.Size(1232, 260);
            this.flowBebidas.TabIndex = 12;
            // 
            // flowPedido
            // 
            this.flowPedido.BackColor = System.Drawing.SystemColors.Control;
            this.flowPedido.Location = new System.Drawing.Point(55, 563);
            this.flowPedido.Name = "flowPedido";
            this.flowPedido.Size = new System.Drawing.Size(1232, 260);
            this.flowPedido.TabIndex = 14;
            // 
            // btnPagar
            // 
            this.btnPagar.BackgroundImage = global::Trabajo_Final.Properties.Resources.pago_con_tarjeta;
            this.btnPagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Location = new System.Drawing.Point(1076, 833);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(120, 120);
            this.btnPagar.TabIndex = 16;
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // btnCrearOrden
            // 
            this.btnCrearOrden.BackgroundImage = global::Trabajo_Final.Properties.Resources.orden;
            this.btnCrearOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearOrden.FlatAppearance.BorderSize = 0;
            this.btnCrearOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearOrden.Location = new System.Drawing.Point(918, 843);
            this.btnCrearOrden.Name = "btnCrearOrden";
            this.btnCrearOrden.Size = new System.Drawing.Size(120, 120);
            this.btnCrearOrden.TabIndex = 15;
            this.btnCrearOrden.UseVisualStyleBackColor = true;
            // 
            // picboxPrincipal
            // 
            this.picboxPrincipal.Image = global::Trabajo_Final.Properties.Resources.Picture3;
            this.picboxPrincipal.Location = new System.Drawing.Point(421, 232);
            this.picboxPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.picboxPrincipal.Name = "picboxPrincipal";
            this.picboxPrincipal.Size = new System.Drawing.Size(500, 500);
            this.picboxPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxPrincipal.TabIndex = 11;
            this.picboxPrincipal.TabStop = false;
            this.picboxPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picboxPrincipal_MouseDown);
            // 
            // frmTomarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1342, 965);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnCrearOrden);
            this.Controls.Add(this.flowPedido);
            this.Controls.Add(this.flowBebidas);
            this.Controls.Add(this.flowPlatos);
            this.Controls.Add(this.picboxPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTomarPedido";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.frmTomarPedido_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBienvenida_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxPrincipal;
        private System.Windows.Forms.FlowLayoutPanel flowPlatos;
        private System.Windows.Forms.FlowLayoutPanel flowBebidas;
        private System.Windows.Forms.FlowLayoutPanel flowPedido;
        private System.Windows.Forms.Button btnCrearOrden;
        private System.Windows.Forms.Button btnPagar;
    }
}