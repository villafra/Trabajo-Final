
namespace Trabajo_Final
{
    partial class frmNuevaReceta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaReceta));
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.grpReceta = new System.Windows.Forms.GroupBox();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtBebida = new System.Windows.Forms.TextBox();
            this.txtAlternativa = new System.Windows.Forms.TextBox();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.comboIngrediente = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpIngredientes = new System.Windows.Forms.GroupBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantReceta = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSacar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            this.grpReceta.SuspendLayout();
            this.grpIngredientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvReceta
            // 
            this.dgvReceta.AllowUserToAddRows = false;
            this.dgvReceta.AllowUserToDeleteRows = false;
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Location = new System.Drawing.Point(344, 90);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.ReadOnly = true;
            this.dgvReceta.RowHeadersWidth = 51;
            this.dgvReceta.RowTemplate.Height = 24;
            this.dgvReceta.Size = new System.Drawing.Size(49, 263);
            this.dgvReceta.TabIndex = 3;
            this.dgvReceta.TabStop = false;
            // 
            // grpReceta
            // 
            this.grpReceta.Controls.Add(this.txtLote);
            this.grpReceta.Controls.Add(this.lblLote);
            this.grpReceta.Controls.Add(this.txtBebida);
            this.grpReceta.Controls.Add(this.txtAlternativa);
            this.grpReceta.Controls.Add(this.lbl2);
            this.grpReceta.Controls.Add(this.lbl1);
            this.grpReceta.Location = new System.Drawing.Point(26, 12);
            this.grpReceta.Name = "grpReceta";
            this.grpReceta.Size = new System.Drawing.Size(706, 168);
            this.grpReceta.TabIndex = 0;
            this.grpReceta.TabStop = false;
            this.grpReceta.Text = "Datos de La Receta";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(434, 52);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(216, 22);
            this.txtLote.TabIndex = 9;
            this.txtLote.TabStop = false;
            this.txtLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(431, 27);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(169, 17);
            this.lblLote.TabIndex = 0;
            this.lblLote.Text = "Tamaño Lote Por defecto";
            // 
            // txtBebida
            // 
            this.txtBebida.Location = new System.Drawing.Point(19, 52);
            this.txtBebida.Name = "txtBebida";
            this.txtBebida.Size = new System.Drawing.Size(216, 22);
            this.txtBebida.TabIndex = 7;
            this.txtBebida.TabStop = false;
            this.txtBebida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAlternativa
            // 
            this.txtAlternativa.Location = new System.Drawing.Point(19, 120);
            this.txtAlternativa.Name = "txtAlternativa";
            this.txtAlternativa.Size = new System.Drawing.Size(393, 22);
            this.txtAlternativa.TabIndex = 1;
            this.txtAlternativa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(16, 96);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(75, 17);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Alternativa";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(16, 27);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(52, 17);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Bebida";
            // 
            // Listado
            // 
            this.Listado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listado.ImageStream")));
            this.Listado.TransparentColor = System.Drawing.Color.Transparent;
            this.Listado.Images.SetKeyName(0, "aprobado.png");
            this.Listado.Images.SetKeyName(1, "rechazado.png");
            this.Listado.Images.SetKeyName(2, "mas.png");
            this.Listado.Images.SetKeyName(3, "menos (2).png");
            this.Listado.Images.SetKeyName(4, "lapiz (3).png");
            // 
            // comboIngrediente
            // 
            this.comboIngrediente.FormattingEnabled = true;
            this.comboIngrediente.Location = new System.Drawing.Point(13, 50);
            this.comboIngrediente.Name = "comboIngrediente";
            this.comboIngrediente.Size = new System.Drawing.Size(353, 24);
            this.comboIngrediente.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(385, 50);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(149, 22);
            this.txtCantidad.TabIndex = 10;
            this.txtCantidad.Text = "3";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
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
            this.btnConfirmar.Location = new System.Drawing.Point(450, 603);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(594, 603);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpIngredientes
            // 
            this.grpIngredientes.BackColor = System.Drawing.SystemColors.Control;
            this.grpIngredientes.Controls.Add(this.btnModificar);
            this.grpIngredientes.Controls.Add(this.label3);
            this.grpIngredientes.Controls.Add(this.label2);
            this.grpIngredientes.Controls.Add(this.txtCantReceta);
            this.grpIngredientes.Controls.Add(this.btnAgregar);
            this.grpIngredientes.Controls.Add(this.btnSacar);
            this.grpIngredientes.Controls.Add(this.label1);
            this.grpIngredientes.Controls.Add(this.dgvReceta);
            this.grpIngredientes.Controls.Add(this.comboIngrediente);
            this.grpIngredientes.Controls.Add(this.txtCantidad);
            this.grpIngredientes.Location = new System.Drawing.Point(27, 186);
            this.grpIngredientes.Name = "grpIngredientes";
            this.grpIngredientes.Size = new System.Drawing.Size(705, 411);
            this.grpIngredientes.TabIndex = 0;
            this.grpIngredientes.TabStop = false;
            this.grpIngredientes.Text = "Ingredientes";
            // 
            // btnModificar
            // 
            this.btnModificar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.ImageIndex = 4;
            this.btnModificar.ImageList = this.Listado;
            this.btnModificar.Location = new System.Drawing.Point(623, 34);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(43, 40);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Ingredientes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lts";
            // 
            // txtCantReceta
            // 
            this.txtCantReceta.Location = new System.Drawing.Point(165, 357);
            this.txtCantReceta.Name = "txtCantReceta";
            this.txtCantReceta.ReadOnly = true;
            this.txtCantReceta.Size = new System.Drawing.Size(149, 22);
            this.txtCantReceta.TabIndex = 18;
            this.txtCantReceta.TabStop = false;
            this.txtCantReceta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAgregar
            // 
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.ImageIndex = 2;
            this.btnAgregar.ImageList = this.Listado;
            this.btnAgregar.Location = new System.Drawing.Point(604, 34);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(40, 40);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSacar
            // 
            this.btnSacar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSacar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSacar.FlatAppearance.BorderSize = 0;
            this.btnSacar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSacar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSacar.ImageIndex = 3;
            this.btnSacar.ImageList = this.Listado;
            this.btnSacar.Location = new System.Drawing.Point(650, 34);
            this.btnSacar.Name = "btnSacar";
            this.btnSacar.Size = new System.Drawing.Size(40, 40);
            this.btnSacar.TabIndex = 5;
            this.btnSacar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSacar.UseVisualStyleBackColor = true;
            this.btnSacar.Click += new System.EventHandler(this.btnSacar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lts";
            // 
            // frmNuevaReceta
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(758, 661);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpReceta);
            this.Controls.Add(this.grpIngredientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevaReceta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNuevaReceta_FormClosed);
            this.Load += new System.EventHandler(this.frmNuevaReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            this.grpReceta.ResumeLayout(false);
            this.grpReceta.PerformLayout();
            this.grpIngredientes.ResumeLayout(false);
            this.grpIngredientes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.GroupBox grpReceta;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.TextBox txtBebida;
        private System.Windows.Forms.TextBox txtAlternativa;
        private System.Windows.Forms.ComboBox comboIngrediente;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpIngredientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantReceta;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSacar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
    }
}