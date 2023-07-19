
namespace Trabajo_Final
{
    partial class frmNuevoIngrediente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoIngrediente));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.chkLote = new System.Windows.Forms.CheckBox();
            this.comboUM = new System.Windows.Forms.ComboBox();
            this.chkRefri = new System.Windows.Forms.CheckBox();
            this.numDias = new System.Windows.Forms.NumericUpDown();
            this.lblTipo = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblUM = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.chkLote);
            this.grpNuevoLogin.Controls.Add(this.comboUM);
            this.grpNuevoLogin.Controls.Add(this.chkRefri);
            this.grpNuevoLogin.Controls.Add(this.numDias);
            this.grpNuevoLogin.Controls.Add(this.lblTipo);
            this.grpNuevoLogin.Controls.Add(this.comboTipo);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.lblApellido);
            this.grpNuevoLogin.Controls.Add(this.lblNombre);
            this.grpNuevoLogin.Controls.Add(this.lblUM);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Controls.Add(this.txtNombre);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 376);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // chkLote
            // 
            this.chkLote.AutoSize = true;
            this.chkLote.Location = new System.Drawing.Point(23, 337);
            this.chkLote.Name = "chkLote";
            this.chkLote.Size = new System.Drawing.Size(135, 21);
            this.chkLote.TabIndex = 5;
            this.chkLote.Text = "Gestionado Lote";
            this.chkLote.UseVisualStyleBackColor = true;
            // 
            // comboUM
            // 
            this.comboUM.FormattingEnabled = true;
            this.comboUM.Location = new System.Drawing.Point(174, 213);
            this.comboUM.Name = "comboUM";
            this.comboUM.Size = new System.Drawing.Size(257, 24);
            this.comboUM.TabIndex = 3;
            // 
            // chkRefri
            // 
            this.chkRefri.AutoSize = true;
            this.chkRefri.Location = new System.Drawing.Point(226, 337);
            this.chkRefri.Name = "chkRefri";
            this.chkRefri.Size = new System.Drawing.Size(177, 21);
            this.chkRefri.TabIndex = 6;
            this.chkRefri.Text = "Requiere Refrigeración";
            this.chkRefri.UseVisualStyleBackColor = true;
            // 
            // numDias
            // 
            this.numDias.Location = new System.Drawing.Point(174, 272);
            this.numDias.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numDias.Name = "numDias";
            this.numDias.Size = new System.Drawing.Size(257, 22);
            this.numDias.TabIndex = 4;
            this.numDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 163);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(36, 17);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(174, 156);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(257, 24);
            this.comboTipo.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(174, 44);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.TabStop = false;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(20, 277);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(100, 17);
            this.lblApellido.TabIndex = 0;
            this.lblApellido.Text = "Vida Util (días)";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 106);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblUM
            // 
            this.lblUM.AutoSize = true;
            this.lblUM.Location = new System.Drawing.Point(20, 220);
            this.lblUM.Name = "lblUM";
            this.lblUM.Size = new System.Drawing.Size(123, 17);
            this.lblUM.TabIndex = 0;
            this.lblUM.Text = "Unidad de Medida";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 49);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(174, 103);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(257, 22);
            this.txtNombre.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(323, 406);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Listado
            // 
            this.Listado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listado.ImageStream")));
            this.Listado.TransparentColor = System.Drawing.Color.Transparent;
            this.Listado.Images.SetKeyName(0, "aprobado.png");
            this.Listado.Images.SetKeyName(1, "rechazado.png");
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 406);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 7;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevoIngrediente
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 472);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoIngrediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblUM;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.NumericUpDown numDias;
        private System.Windows.Forms.CheckBox chkRefri;
        private System.Windows.Forms.ComboBox comboUM;
        private System.Windows.Forms.CheckBox chkLote;
    }
}