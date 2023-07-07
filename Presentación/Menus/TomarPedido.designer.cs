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
            this.grpArmaPedido = new System.Windows.Forms.GroupBox();
            this.flowPedido = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCrearOrden = new System.Windows.Forms.Button();
            this.btnIzquierdaPedido = new System.Windows.Forms.Button();
            this.btnIzquierdaPlatos = new System.Windows.Forms.Button();
            this.btnIzquierdaBebidas = new System.Windows.Forms.Button();
            this.btnDerechaPedido = new System.Windows.Forms.Button();
            this.btnDerechaPlatos = new System.Windows.Forms.Button();
            this.btnDerechaBebidas = new System.Windows.Forms.Button();
            this.grpArmaPedido.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPlatos
            // 
            this.flowPlatos.BackColor = System.Drawing.SystemColors.Control;
            this.flowPlatos.Location = new System.Drawing.Point(600, 290);
            this.flowPlatos.Name = "flowPlatos";
            this.flowPlatos.Size = new System.Drawing.Size(54, 260);
            this.flowPlatos.TabIndex = 14;
            // 
            // flowBebidas
            // 
            this.flowBebidas.BackColor = System.Drawing.SystemColors.Control;
            this.flowBebidas.Location = new System.Drawing.Point(605, 21);
            this.flowBebidas.Name = "flowBebidas";
            this.flowBebidas.Size = new System.Drawing.Size(49, 260);
            this.flowBebidas.TabIndex = 12;
            // 
            // grpArmaPedido
            // 
            this.grpArmaPedido.Controls.Add(this.btnIzquierdaPedido);
            this.grpArmaPedido.Controls.Add(this.btnIzquierdaPlatos);
            this.grpArmaPedido.Controls.Add(this.btnIzquierdaBebidas);
            this.grpArmaPedido.Controls.Add(this.btnDerechaPedido);
            this.grpArmaPedido.Controls.Add(this.btnDerechaPlatos);
            this.grpArmaPedido.Controls.Add(this.btnDerechaBebidas);
            this.grpArmaPedido.Controls.Add(this.flowPedido);
            this.grpArmaPedido.Controls.Add(this.flowBebidas);
            this.grpArmaPedido.Controls.Add(this.flowPlatos);
            this.grpArmaPedido.Location = new System.Drawing.Point(33, 12);
            this.grpArmaPedido.Name = "grpArmaPedido";
            this.grpArmaPedido.Size = new System.Drawing.Size(1276, 825);
            this.grpArmaPedido.TabIndex = 17;
            this.grpArmaPedido.TabStop = false;
            this.grpArmaPedido.Text = "Armar Pedido";
            // 
            // flowPedido
            // 
            this.flowPedido.BackColor = System.Drawing.SystemColors.Control;
            this.flowPedido.Location = new System.Drawing.Point(600, 559);
            this.flowPedido.Name = "flowPedido";
            this.flowPedido.Size = new System.Drawing.Size(54, 260);
            this.flowPedido.TabIndex = 18;
            // 
            // btnCrearOrden
            // 
            this.btnCrearOrden.BackgroundImage = global::Trabajo_Final.Properties.Resources.pedido_en_linea__1_;
            this.btnCrearOrden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearOrden.FlatAppearance.BorderSize = 0;
            this.btnCrearOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearOrden.Location = new System.Drawing.Point(1167, 843);
            this.btnCrearOrden.Name = "btnCrearOrden";
            this.btnCrearOrden.Size = new System.Drawing.Size(120, 110);
            this.btnCrearOrden.TabIndex = 15;
            this.btnCrearOrden.UseVisualStyleBackColor = true;
            this.btnCrearOrden.Click += new System.EventHandler(this.btnCrearOrden_Click);
            // 
            // btnIzquierdaPedido
            // 
            this.btnIzquierdaPedido.BackColor = System.Drawing.Color.Transparent;
            this.btnIzquierdaPedido.BackgroundImage = global::Trabajo_Final.Properties.Resources.Izquierda;
            this.btnIzquierdaPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierdaPedido.FlatAppearance.BorderSize = 0;
            this.btnIzquierdaPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierdaPedido.Location = new System.Drawing.Point(6, 629);
            this.btnIzquierdaPedido.Name = "btnIzquierdaPedido";
            this.btnIzquierdaPedido.Size = new System.Drawing.Size(50, 119);
            this.btnIzquierdaPedido.TabIndex = 24;
            this.btnIzquierdaPedido.UseVisualStyleBackColor = false;
            this.btnIzquierdaPedido.Visible = false;
            // 
            // btnIzquierdaPlatos
            // 
            this.btnIzquierdaPlatos.BackColor = System.Drawing.Color.Transparent;
            this.btnIzquierdaPlatos.BackgroundImage = global::Trabajo_Final.Properties.Resources.Izquierda;
            this.btnIzquierdaPlatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierdaPlatos.FlatAppearance.BorderSize = 0;
            this.btnIzquierdaPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierdaPlatos.Location = new System.Drawing.Point(6, 344);
            this.btnIzquierdaPlatos.Name = "btnIzquierdaPlatos";
            this.btnIzquierdaPlatos.Size = new System.Drawing.Size(50, 119);
            this.btnIzquierdaPlatos.TabIndex = 23;
            this.btnIzquierdaPlatos.UseVisualStyleBackColor = false;
            this.btnIzquierdaPlatos.Visible = false;
            // 
            // btnIzquierdaBebidas
            // 
            this.btnIzquierdaBebidas.BackColor = System.Drawing.Color.Transparent;
            this.btnIzquierdaBebidas.BackgroundImage = global::Trabajo_Final.Properties.Resources.Izquierda;
            this.btnIzquierdaBebidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIzquierdaBebidas.FlatAppearance.BorderSize = 0;
            this.btnIzquierdaBebidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierdaBebidas.Location = new System.Drawing.Point(6, 88);
            this.btnIzquierdaBebidas.Name = "btnIzquierdaBebidas";
            this.btnIzquierdaBebidas.Size = new System.Drawing.Size(50, 119);
            this.btnIzquierdaBebidas.TabIndex = 22;
            this.btnIzquierdaBebidas.UseVisualStyleBackColor = false;
            this.btnIzquierdaBebidas.Visible = false;
            // 
            // btnDerechaPedido
            // 
            this.btnDerechaPedido.BackColor = System.Drawing.Color.Transparent;
            this.btnDerechaPedido.BackgroundImage = global::Trabajo_Final.Properties.Resources.derecha;
            this.btnDerechaPedido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerechaPedido.FlatAppearance.BorderSize = 0;
            this.btnDerechaPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerechaPedido.Location = new System.Drawing.Point(1226, 629);
            this.btnDerechaPedido.Name = "btnDerechaPedido";
            this.btnDerechaPedido.Size = new System.Drawing.Size(50, 119);
            this.btnDerechaPedido.TabIndex = 21;
            this.btnDerechaPedido.UseVisualStyleBackColor = false;
            this.btnDerechaPedido.Visible = false;
            // 
            // btnDerechaPlatos
            // 
            this.btnDerechaPlatos.BackColor = System.Drawing.Color.Transparent;
            this.btnDerechaPlatos.BackgroundImage = global::Trabajo_Final.Properties.Resources.derecha;
            this.btnDerechaPlatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerechaPlatos.FlatAppearance.BorderSize = 0;
            this.btnDerechaPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerechaPlatos.Location = new System.Drawing.Point(1226, 344);
            this.btnDerechaPlatos.Name = "btnDerechaPlatos";
            this.btnDerechaPlatos.Size = new System.Drawing.Size(50, 119);
            this.btnDerechaPlatos.TabIndex = 20;
            this.btnDerechaPlatos.UseVisualStyleBackColor = false;
            this.btnDerechaPlatos.Visible = false;
            // 
            // btnDerechaBebidas
            // 
            this.btnDerechaBebidas.BackColor = System.Drawing.Color.Transparent;
            this.btnDerechaBebidas.BackgroundImage = global::Trabajo_Final.Properties.Resources.derecha;
            this.btnDerechaBebidas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDerechaBebidas.FlatAppearance.BorderSize = 0;
            this.btnDerechaBebidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerechaBebidas.Location = new System.Drawing.Point(1226, 88);
            this.btnDerechaBebidas.Name = "btnDerechaBebidas";
            this.btnDerechaBebidas.Size = new System.Drawing.Size(50, 119);
            this.btnDerechaBebidas.TabIndex = 19;
            this.btnDerechaBebidas.UseVisualStyleBackColor = false;
            this.btnDerechaBebidas.Visible = false;
            // 
            // frmTomarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1342, 965);
            this.Controls.Add(this.btnCrearOrden);
            this.Controls.Add(this.grpArmaPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTomarPedido";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.frmTomarPedido_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBienvenida_MouseDown);
            this.grpArmaPedido.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowPlatos;
        private System.Windows.Forms.FlowLayoutPanel flowBebidas;
        private System.Windows.Forms.Button btnCrearOrden;
        private System.Windows.Forms.GroupBox grpArmaPedido;
        private System.Windows.Forms.FlowLayoutPanel flowPedido;
        private System.Windows.Forms.Button btnDerechaPedido;
        private System.Windows.Forms.Button btnDerechaPlatos;
        private System.Windows.Forms.Button btnDerechaBebidas;
        private System.Windows.Forms.Button btnIzquierdaPedido;
        private System.Windows.Forms.Button btnIzquierdaPlatos;
        private System.Windows.Forms.Button btnIzquierdaBebidas;
    }
}