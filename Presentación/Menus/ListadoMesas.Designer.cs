﻿
namespace Trabajo_Final
{
    partial class frmListadoMesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoMesas));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvMesas = new System.Windows.Forms.DataGridView();
            this.grpMesas = new System.Windows.Forms.GroupBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesas)).BeginInit();
            this.grpMesas.SuspendLayout();
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
            // dgvMesas
            // 
            this.dgvMesas.AllowUserToAddRows = false;
            this.dgvMesas.AllowUserToDeleteRows = false;
            this.dgvMesas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMesas.Location = new System.Drawing.Point(102, 249);
            this.dgvMesas.Name = "dgvMesas";
            this.dgvMesas.ReadOnly = true;
            this.dgvMesas.RowHeadersWidth = 51;
            this.dgvMesas.RowTemplate.Height = 24;
            this.dgvMesas.Size = new System.Drawing.Size(1120, 254);
            this.dgvMesas.TabIndex = 3;
            // 
            // grpMesas
            // 
            this.grpMesas.Controls.Add(this.lbl2);
            this.grpMesas.Controls.Add(this.lbl1);
            this.grpMesas.Controls.Add(this.btnReset);
            this.grpMesas.Controls.Add(this.textBox1);
            this.grpMesas.Controls.Add(this.comboBox1);
            this.grpMesas.Controls.Add(this.btBuscar);
            this.grpMesas.Location = new System.Drawing.Point(102, 57);
            this.grpMesas.Name = "grpMesas";
            this.grpMesas.Size = new System.Drawing.Size(1120, 168);
            this.grpMesas.TabIndex = 4;
            this.grpMesas.TabStop = false;
            this.grpMesas.Text = "Listado de Usuarios";
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
            this.btBuscar.Location = new System.Drawing.Point(810, 82);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(149, 36);
            this.btBuscar.TabIndex = 2;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBuscar.UseVisualStyleBackColor = true;
            // 
            // frmListadoMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 918);
            this.Controls.Add(this.grpMesas);
            this.Controls.Add(this.dgvMesas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListadoMesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMesas)).EndInit();
            this.grpMesas.ResumeLayout(false);
            this.grpMesas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dgvMesas;
        private System.Windows.Forms.GroupBox grpMesas;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
    }
}