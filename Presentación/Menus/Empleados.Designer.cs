
namespace Trabajo_Final
{
    partial class frmEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleados));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.grpEmpleados = new System.Windows.Forms.GroupBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.grpEmpleados.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(304, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(471, 22);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(233, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(102, 249);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.RowTemplate.Height = 24;
            this.dgvEmpleados.Size = new System.Drawing.Size(1120, 254);
            this.dgvEmpleados.TabIndex = 3;
            this.dgvEmpleados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // grpEmpleados
            // 
            this.grpEmpleados.Controls.Add(this.lbl2);
            this.grpEmpleados.Controls.Add(this.lbl1);
            this.grpEmpleados.Controls.Add(this.btnReset);
            this.grpEmpleados.Controls.Add(this.textBox1);
            this.grpEmpleados.Controls.Add(this.comboBox1);
            this.grpEmpleados.Controls.Add(this.btBuscar);
            this.grpEmpleados.Location = new System.Drawing.Point(102, 57);
            this.grpEmpleados.Name = "grpEmpleados";
            this.grpEmpleados.Size = new System.Drawing.Size(1120, 168);
            this.grpEmpleados.TabIndex = 4;
            this.grpEmpleados.TabStop = false;
            this.grpEmpleados.Text = "Listado de Empleados";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(301, 71);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(178, 17);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Ingrese Filtro de Busqueda";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(21, 71);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(78, 17);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Buscar Por";
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
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnDesbloquear);
            this.grpAcciones.Controls.Add(this.btnAgregar);
            this.grpAcciones.Controls.Add(this.btnResetPass);
            this.grpAcciones.Controls.Add(this.btnEliminar);
            this.grpAcciones.Location = new System.Drawing.Point(102, 768);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(1120, 100);
            this.grpAcciones.TabIndex = 10;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Elija Una Acción";
            // 
            // btnModificar
            // 
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.ImageIndex = 3;
            this.btnModificar.ImageList = this.Listado;
            this.btnModificar.Location = new System.Drawing.Point(161, 34);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(149, 50);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDesbloquear.FlatAppearance.BorderSize = 0;
            this.btnDesbloquear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesbloquear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesbloquear.ImageIndex = 6;
            this.btnDesbloquear.ImageList = this.Listado;
            this.btnDesbloquear.Location = new System.Drawing.Point(965, 34);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(149, 50);
            this.btnDesbloquear.TabIndex = 9;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.ImageIndex = 2;
            this.btnAgregar.ImageList = this.Listado;
            this.btnAgregar.Location = new System.Drawing.Point(6, 34);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(149, 50);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResetPass.FlatAppearance.BorderSize = 0;
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetPass.ImageIndex = 5;
            this.btnResetPass.ImageList = this.Listado;
            this.btnResetPass.Location = new System.Drawing.Point(810, 34);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(149, 50);
            this.btnResetPass.TabIndex = 8;
            this.btnResetPass.Text = "Reset Pass";
            this.btnResetPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetPass.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageIndex = 4;
            this.btnEliminar.ImageList = this.Listado;
            this.btnEliminar.Location = new System.Drawing.Point(316, 34);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(149, 50);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.ImageIndex = 1;
            this.btnReset.ImageList = this.Listado;
            this.btnReset.Location = new System.Drawing.Point(965, 82);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(149, 36);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Restablecer";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btBuscar
            // 
            this.btBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btBuscar.FlatAppearance.BorderSize = 0;
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBuscar.ImageIndex = 0;
            this.btBuscar.ImageList = this.Listado;
            this.btBuscar.Location = new System.Drawing.Point(810, 82);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(149, 36);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // frmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 918);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpEmpleados);
            this.Controls.Add(this.dgvEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.grpEmpleados.ResumeLayout(false);
            this.grpEmpleados.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.GroupBox grpEmpleados;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.GroupBox grpAcciones;
    }
}