
namespace Trabajo_Final
{
    partial class frmBebidasEnOrden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBebidasEnOrden));
            this.dgvBebidas = new System.Windows.Forms.DataGridView();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grpIngredientes = new System.Windows.Forms.GroupBox();
            this.lblCantIngred = new System.Windows.Forms.Label();
            this.txtCantiIngred = new System.Windows.Forms.TextBox();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.lblCantiBeb = new System.Windows.Forms.Label();
            this.txtCantBebidas = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBebidas)).BeginInit();
            this.grpIngredientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBebidas
            // 
            this.dgvBebidas.AllowUserToAddRows = false;
            this.dgvBebidas.AllowUserToDeleteRows = false;
            this.dgvBebidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBebidas.Location = new System.Drawing.Point(6, 36);
            this.dgvBebidas.Name = "dgvBebidas";
            this.dgvBebidas.ReadOnly = true;
            this.dgvBebidas.RowHeadersWidth = 51;
            this.dgvBebidas.RowTemplate.Height = 24;
            this.dgvBebidas.Size = new System.Drawing.Size(511, 263);
            this.dgvBebidas.TabIndex = 3;
            this.dgvBebidas.SelectionChanged += new System.EventHandler(this.dgvBebidas_SelectionChanged);
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
            // btnConfirmar
            // 
            this.btnConfirmar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmar.ImageIndex = 0;
            this.btnConfirmar.ImageList = this.Listado;
            this.btnConfirmar.Location = new System.Drawing.Point(408, 418);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 12;
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
            this.btnCancelar.Location = new System.Drawing.Point(552, 418);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grpIngredientes
            // 
            this.grpIngredientes.BackColor = System.Drawing.SystemColors.Control;
            this.grpIngredientes.Controls.Add(this.lblCantIngred);
            this.grpIngredientes.Controls.Add(this.txtCantiIngred);
            this.grpIngredientes.Controls.Add(this.dgvReceta);
            this.grpIngredientes.Controls.Add(this.lblCantiBeb);
            this.grpIngredientes.Controls.Add(this.txtCantBebidas);
            this.grpIngredientes.Controls.Add(this.dgvBebidas);
            this.grpIngredientes.Location = new System.Drawing.Point(27, 12);
            this.grpIngredientes.Name = "grpIngredientes";
            this.grpIngredientes.Size = new System.Drawing.Size(1059, 380);
            this.grpIngredientes.TabIndex = 14;
            this.grpIngredientes.TabStop = false;
            this.grpIngredientes.Text = "Ingredientes";
            // 
            // lblCantIngred
            // 
            this.lblCantIngred.AutoSize = true;
            this.lblCantIngred.Location = new System.Drawing.Point(539, 311);
            this.lblCantIngred.Name = "lblCantIngred";
            this.lblCantIngred.Size = new System.Drawing.Size(166, 17);
            this.lblCantIngred.TabIndex = 22;
            this.lblCantIngred.Text = "Cantidad de Ingredientes";
            // 
            // txtCantiIngred
            // 
            this.txtCantiIngred.Location = new System.Drawing.Point(764, 306);
            this.txtCantiIngred.Name = "txtCantiIngred";
            this.txtCantiIngred.ReadOnly = true;
            this.txtCantiIngred.Size = new System.Drawing.Size(149, 22);
            this.txtCantiIngred.TabIndex = 21;
            this.txtCantiIngred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvReceta
            // 
            this.dgvReceta.AllowUserToAddRows = false;
            this.dgvReceta.AllowUserToDeleteRows = false;
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Location = new System.Drawing.Point(542, 36);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.ReadOnly = true;
            this.dgvReceta.RowHeadersWidth = 51;
            this.dgvReceta.RowTemplate.Height = 24;
            this.dgvReceta.Size = new System.Drawing.Size(511, 263);
            this.dgvReceta.TabIndex = 20;
            // 
            // lblCantiBeb
            // 
            this.lblCantiBeb.AutoSize = true;
            this.lblCantiBeb.Location = new System.Drawing.Point(6, 316);
            this.lblCantiBeb.Name = "lblCantiBeb";
            this.lblCantiBeb.Size = new System.Drawing.Size(155, 17);
            this.lblCantiBeb.TabIndex = 19;
            this.lblCantiBeb.Text = "Cantidad Total Bebidas";
            // 
            // txtCantBebidas
            // 
            this.txtCantBebidas.Location = new System.Drawing.Point(231, 311);
            this.txtCantBebidas.Name = "txtCantBebidas";
            this.txtCantBebidas.ReadOnly = true;
            this.txtCantBebidas.Size = new System.Drawing.Size(149, 22);
            this.txtCantBebidas.TabIndex = 18;
            this.txtCantBebidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmBebidasEnOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 478);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpIngredientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBebidasEnOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.Load += new System.EventHandler(this.frmNuevaReceta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBebidas)).EndInit();
            this.grpIngredientes.ResumeLayout(false);
            this.grpIngredientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvBebidas;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpIngredientes;
        private System.Windows.Forms.Label lblCantiBeb;
        private System.Windows.Forms.TextBox txtCantBebidas;
        private System.Windows.Forms.Label lblCantIngred;
        private System.Windows.Forms.TextBox txtCantiIngred;
        private System.Windows.Forms.DataGridView dgvReceta;
    }
}