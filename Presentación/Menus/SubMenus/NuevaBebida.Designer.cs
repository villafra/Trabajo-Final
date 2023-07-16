
namespace Trabajo_Final
{
    partial class frmNuevaBebida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaBebida));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.txtVidaUtil = new System.Windows.Forms.TextBox();
            this.comboIngredientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numABV = new System.Windows.Forms.NumericUpDown();
            this.lblABV = new System.Windows.Forms.Label();
            this.chkLote = new System.Windows.Forms.CheckBox();
            this.comboUM = new System.Windows.Forms.ComboBox();
            this.lblUM = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.numPresentacion = new System.Windows.Forms.NumericUpDown();
            this.lblVidaUtil = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblPresentación = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numABV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPresentacion)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.txtVidaUtil);
            this.grpNuevoLogin.Controls.Add(this.comboIngredientes);
            this.grpNuevoLogin.Controls.Add(this.label1);
            this.grpNuevoLogin.Controls.Add(this.numABV);
            this.grpNuevoLogin.Controls.Add(this.lblABV);
            this.grpNuevoLogin.Controls.Add(this.chkLote);
            this.grpNuevoLogin.Controls.Add(this.comboUM);
            this.grpNuevoLogin.Controls.Add(this.lblUM);
            this.grpNuevoLogin.Controls.Add(this.txtNombre);
            this.grpNuevoLogin.Controls.Add(this.lblNombre);
            this.grpNuevoLogin.Controls.Add(this.comboTipo);
            this.grpNuevoLogin.Controls.Add(this.lblTipo);
            this.grpNuevoLogin.Controls.Add(this.numPresentacion);
            this.grpNuevoLogin.Controls.Add(this.lblVidaUtil);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.lblPresentación);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 572);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // txtVidaUtil
            // 
            this.txtVidaUtil.Location = new System.Drawing.Point(174, 349);
            this.txtVidaUtil.Name = "txtVidaUtil";
            this.txtVidaUtil.Size = new System.Drawing.Size(257, 22);
            this.txtVidaUtil.TabIndex = 38;
            // 
            // comboIngredientes
            // 
            this.comboIngredientes.FormattingEnabled = true;
            this.comboIngredientes.Location = new System.Drawing.Point(175, 481);
            this.comboIngredientes.Name = "comboIngredientes";
            this.comboIngredientes.Size = new System.Drawing.Size(257, 24);
            this.comboIngredientes.TabIndex = 37;
            this.comboIngredientes.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Lista Ingredientes";
            this.label1.Visible = false;
            // 
            // numABV
            // 
            this.numABV.DecimalPlaces = 2;
            this.numABV.Location = new System.Drawing.Point(174, 418);
            this.numABV.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numABV.Name = "numABV";
            this.numABV.Size = new System.Drawing.Size(257, 22);
            this.numABV.TabIndex = 35;
            this.numABV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numABV.Visible = false;
            // 
            // lblABV
            // 
            this.lblABV.AutoSize = true;
            this.lblABV.Location = new System.Drawing.Point(20, 421);
            this.lblABV.Name = "lblABV";
            this.lblABV.Size = new System.Drawing.Size(35, 17);
            this.lblABV.TabIndex = 34;
            this.lblABV.Text = "ABV";
            this.lblABV.Visible = false;
            // 
            // chkLote
            // 
            this.chkLote.AutoSize = true;
            this.chkLote.Location = new System.Drawing.Point(246, 534);
            this.chkLote.Name = "chkLote";
            this.chkLote.Size = new System.Drawing.Size(135, 21);
            this.chkLote.TabIndex = 33;
            this.chkLote.Text = "Gestionado Lote";
            this.chkLote.UseVisualStyleBackColor = true;
            // 
            // comboUM
            // 
            this.comboUM.FormattingEnabled = true;
            this.comboUM.Location = new System.Drawing.Point(174, 290);
            this.comboUM.Name = "comboUM";
            this.comboUM.Size = new System.Drawing.Size(257, 24);
            this.comboUM.TabIndex = 32;
            // 
            // lblUM
            // 
            this.lblUM.AutoSize = true;
            this.lblUM.Location = new System.Drawing.Point(20, 293);
            this.lblUM.Name = "lblUM";
            this.lblUM.Size = new System.Drawing.Size(123, 17);
            this.lblUM.TabIndex = 31;
            this.lblUM.Text = "Unidad de Medida";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(174, 105);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(257, 22);
            this.txtNombre.TabIndex = 30;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 110);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 29;
            this.lblNombre.Text = "Nombre";
            // 
            // comboTipo
            // 
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Location = new System.Drawing.Point(174, 166);
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.Size = new System.Drawing.Size(257, 24);
            this.comboTipo.TabIndex = 25;
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboTipo_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 171);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(84, 17);
            this.lblTipo.TabIndex = 24;
            this.lblTipo.Text = "Tipo Bebida";
            // 
            // numPresentacion
            // 
            this.numPresentacion.DecimalPlaces = 2;
            this.numPresentacion.Location = new System.Drawing.Point(174, 229);
            this.numPresentacion.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPresentacion.Name = "numPresentacion";
            this.numPresentacion.Size = new System.Drawing.Size(257, 22);
            this.numPresentacion.TabIndex = 20;
            this.numPresentacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVidaUtil
            // 
            this.lblVidaUtil.AutoSize = true;
            this.lblVidaUtil.Location = new System.Drawing.Point(20, 354);
            this.lblVidaUtil.Name = "lblVidaUtil";
            this.lblVidaUtil.Size = new System.Drawing.Size(60, 17);
            this.lblVidaUtil.TabIndex = 19;
            this.lblVidaUtil.Text = "Vida Util";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(174, 44);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            // 
            // lblPresentación
            // 
            this.lblPresentación.AutoSize = true;
            this.lblPresentación.Location = new System.Drawing.Point(20, 232);
            this.lblPresentación.Name = "lblPresentación";
            this.lblPresentación.Size = new System.Drawing.Size(91, 17);
            this.lblPresentación.TabIndex = 7;
            this.lblPresentación.Text = "Presentación";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 49);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Código";
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
            this.btnCancelar.Location = new System.Drawing.Point(323, 602);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnConfirmar.Location = new System.Drawing.Point(30, 602);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevaBebida
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevaBebida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numABV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPresentacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPresentación;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblVidaUtil;
        private System.Windows.Forms.NumericUpDown numPresentacion;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox comboUM;
        private System.Windows.Forms.Label lblUM;
        private System.Windows.Forms.CheckBox chkLote;
        private System.Windows.Forms.NumericUpDown numABV;
        private System.Windows.Forms.Label lblABV;
        private System.Windows.Forms.ComboBox comboIngredientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVidaUtil;
    }
}