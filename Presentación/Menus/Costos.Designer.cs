﻿
namespace Trabajo_Final
{
    partial class frmCostos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostos));
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.dgvCostos = new System.Windows.Forms.DataGridView();
            this.grpCostos = new System.Windows.Forms.GroupBox();
            this.chkOcultar = new System.Windows.Forms.CheckBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btBuscar = new System.Windows.Forms.Button();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).BeginInit();
            this.grpCostos.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(303, 85);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(471, 22);
            this.txtFiltro.TabIndex = 0;
            // 
            // comboFiltro
            // 
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Items.AddRange(new object[] {
            "Tipo"});
            this.comboFiltro.Location = new System.Drawing.Point(20, 83);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(233, 24);
            this.comboFiltro.TabIndex = 1;
            // 
            // dgvCostos
            // 
            this.dgvCostos.AllowUserToAddRows = false;
            this.dgvCostos.AllowUserToDeleteRows = false;
            this.dgvCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCostos.Location = new System.Drawing.Point(600, 249);
            this.dgvCostos.Name = "dgvCostos";
            this.dgvCostos.ReadOnly = true;
            this.dgvCostos.RowHeadersWidth = 51;
            this.dgvCostos.RowTemplate.Height = 24;
            this.dgvCostos.Size = new System.Drawing.Size(124, 254);
            this.dgvCostos.TabIndex = 3;
            this.dgvCostos.SelectionChanged += new System.EventHandler(this.dgvCostos_SelectionChanged);
            // 
            // grpCostos
            // 
            this.grpCostos.Controls.Add(this.chkOcultar);
            this.grpCostos.Controls.Add(this.lbl2);
            this.grpCostos.Controls.Add(this.lbl1);
            this.grpCostos.Controls.Add(this.btnReset);
            this.grpCostos.Controls.Add(this.txtFiltro);
            this.grpCostos.Controls.Add(this.comboFiltro);
            this.grpCostos.Controls.Add(this.btBuscar);
            this.grpCostos.Location = new System.Drawing.Point(102, 57);
            this.grpCostos.Name = "grpCostos";
            this.grpCostos.Size = new System.Drawing.Size(1120, 168);
            this.grpCostos.TabIndex = 4;
            this.grpCostos.TabStop = false;
            this.grpCostos.Text = "Listado de Compras";
            // 
            // chkOcultar
            // 
            this.chkOcultar.AutoSize = true;
            this.chkOcultar.Location = new System.Drawing.Point(23, 130);
            this.chkOcultar.Name = "chkOcultar";
            this.chkOcultar.Size = new System.Drawing.Size(135, 21);
            this.chkOcultar.TabIndex = 7;
            this.chkOcultar.Text = "Ocultar Inactivos";
            this.chkOcultar.UseVisualStyleBackColor = true;
            this.chkOcultar.CheckedChanged += new System.EventHandler(this.chkOcultar_CheckedChanged);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(300, 60);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(178, 17);
            this.lbl2.TabIndex = 5;
            this.lbl2.Text = "Ingrese Filtro de Busqueda";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(21, 60);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(78, 17);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Buscar Por";
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.ImageIndex = 1;
            this.btnReset.ImageList = this.Listado;
            this.btnReset.Location = new System.Drawing.Point(964, 71);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(149, 36);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Restablecer";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btBuscar.Location = new System.Drawing.Point(809, 71);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(149, 36);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnModificar);
            this.grpAcciones.Controls.Add(this.btnAgregar);
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
            // frmCostos
            // 
            this.AcceptButton = this.btBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(1324, 918);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpCostos);
            this.Controls.Add(this.dgvCostos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCostos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.Activated += new System.EventHandler(this.frmCostos_Activated);
            this.Load += new System.EventHandler(this.frmCostos_Load);
            this.Shown += new System.EventHandler(this.frmCostos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCostos)).EndInit();
            this.grpCostos.ResumeLayout(false);
            this.grpCostos.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox comboFiltro;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dgvCostos;
        private System.Windows.Forms.GroupBox grpCostos;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.CheckBox chkOcultar;
    }
}