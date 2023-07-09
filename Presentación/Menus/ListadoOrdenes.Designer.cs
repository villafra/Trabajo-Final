
namespace Trabajo_Final
{
    partial class frmListadoOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoPedidos));
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.grpPedidos = new System.Windows.Forms.GroupBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btBuscar = new System.Windows.Forms.Button();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.grpPedidos.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(342, 120);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(529, 26);
            this.txtFiltro.TabIndex = 0;
            // 
            // comboFiltro
            // 
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Location = new System.Drawing.Point(24, 118);
            this.comboFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(262, 28);
            this.comboFiltro.TabIndex = 1;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(115, 311);
            this.dgvPedidos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.RowTemplate.Height = 24;
            this.dgvPedidos.Size = new System.Drawing.Size(1260, 425);
            this.dgvPedidos.TabIndex = 3;
            this.dgvPedidos.SelectionChanged += new System.EventHandler(this.dgvPedidos_SelectionChanged);
            // 
            // grpPedidos
            // 
            this.grpPedidos.Controls.Add(this.lbl2);
            this.grpPedidos.Controls.Add(this.lbl1);
            this.grpPedidos.Controls.Add(this.btnReset);
            this.grpPedidos.Controls.Add(this.txtFiltro);
            this.grpPedidos.Controls.Add(this.comboFiltro);
            this.grpPedidos.Controls.Add(this.btBuscar);
            this.grpPedidos.Location = new System.Drawing.Point(115, 71);
            this.grpPedidos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPedidos.Name = "grpPedidos";
            this.grpPedidos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpPedidos.Size = new System.Drawing.Size(1260, 210);
            this.grpPedidos.TabIndex = 4;
            this.grpPedidos.TabStop = false;
            this.grpPedidos.Text = "Listado de Pedidos Liberados";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(339, 89);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(210, 20);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Ingrese Filtro de Busqueda";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(24, 89);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(94, 20);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Buscar Por";
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.ImageIndex = 1;
            this.btnReset.ImageList = this.Listado;
            this.btnReset.Location = new System.Drawing.Point(1086, 102);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(168, 45);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Restablecer";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // Listado
            // 
            this.Listado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listado.ImageStream")));
            this.Listado.TransparentColor = System.Drawing.Color.Transparent;
            this.Listado.Images.SetKeyName(0, "buscar.png");
            this.Listado.Images.SetKeyName(1, "reiniciar.png");
            this.Listado.Images.SetKeyName(2, "agregar.png");
            this.Listado.Images.SetKeyName(3, "lapiz.png");
            this.Listado.Images.SetKeyName(4, "basura.png");
            this.Listado.Images.SetKeyName(5, "girar.png");
            this.Listado.Images.SetKeyName(6, "bloqueado.png");
            // 
            // btBuscar
            // 
            this.btBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBuscar.FlatAppearance.BorderSize = 0;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.ImageIndex = 0;
            this.btBuscar.ImageList = this.Listado;
            this.btBuscar.Location = new System.Drawing.Point(911, 102);
            this.btBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(168, 45);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnAgregar);
            this.grpAcciones.Location = new System.Drawing.Point(115, 960);
            this.grpAcciones.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpAcciones.Size = new System.Drawing.Size(1260, 125);
            this.grpAcciones.TabIndex = 11;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Elija Una Acción";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.ImageIndex = 2;
            this.btnAgregar.ImageList = this.Listado;
            this.btnAgregar.Location = new System.Drawing.Point(546, 42);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(168, 62);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Tratar Pedido";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // frmListadoPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 1102);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpPedidos);
            this.Controls.Add(this.dgvPedidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListadoPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.grpPedidos.ResumeLayout(false);
            this.grpPedidos.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox comboFiltro;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.GroupBox grpPedidos;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnAgregar;
    }
}