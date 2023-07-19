
namespace Trabajo_Final
{
    partial class frmNuevoCosto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoCosto));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.numOtros = new System.Windows.Forms.NumericUpDown();
            this.numNRG = new System.Windows.Forms.NumericUpDown();
            this.lblOtros = new System.Windows.Forms.Label();
            this.numHH = new System.Windows.Forms.NumericUpDown();
            this.lblHH = new System.Windows.Forms.Label();
            this.comboMaterial = new System.Windows.Forms.ComboBox();
            this.numMP = new System.Windows.Forms.NumericUpDown();
            this.lblNRG = new System.Windows.Forms.Label();
            this.numTamaño = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaCosteo = new System.Windows.Forms.DateTimePicker();
            this.ComboTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.lblMP = new System.Windows.Forms.Label();
            this.blFechaCosteo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOtros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNRG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamaño)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.numOtros);
            this.grpNuevoLogin.Controls.Add(this.numNRG);
            this.grpNuevoLogin.Controls.Add(this.lblOtros);
            this.grpNuevoLogin.Controls.Add(this.numHH);
            this.grpNuevoLogin.Controls.Add(this.lblHH);
            this.grpNuevoLogin.Controls.Add(this.comboMaterial);
            this.grpNuevoLogin.Controls.Add(this.numMP);
            this.grpNuevoLogin.Controls.Add(this.lblNRG);
            this.grpNuevoLogin.Controls.Add(this.numTamaño);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaCosteo);
            this.grpNuevoLogin.Controls.Add(this.ComboTipo);
            this.grpNuevoLogin.Controls.Add(this.lblTipo);
            this.grpNuevoLogin.Controls.Add(this.lblTamaño);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.lblMaterial);
            this.grpNuevoLogin.Controls.Add(this.lblMP);
            this.grpNuevoLogin.Controls.Add(this.blFechaCosteo);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 570);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // numOtros
            // 
            this.numOtros.DecimalPlaces = 2;
            this.numOtros.Location = new System.Drawing.Point(174, 501);
            this.numOtros.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numOtros.Name = "numOtros";
            this.numOtros.Size = new System.Drawing.Size(257, 22);
            this.numOtros.TabIndex = 8;
            this.numOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numNRG
            // 
            this.numNRG.DecimalPlaces = 2;
            this.numNRG.Location = new System.Drawing.Point(174, 445);
            this.numNRG.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numNRG.Name = "numNRG";
            this.numNRG.Size = new System.Drawing.Size(257, 22);
            this.numNRG.TabIndex = 7;
            this.numNRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblOtros
            // 
            this.lblOtros.AutoSize = true;
            this.lblOtros.Location = new System.Drawing.Point(20, 502);
            this.lblOtros.Name = "lblOtros";
            this.lblOtros.Size = new System.Drawing.Size(92, 17);
            this.lblOtros.TabIndex = 36;
            this.lblOtros.Text = "Otros Gastos";
            // 
            // numHH
            // 
            this.numHH.DecimalPlaces = 2;
            this.numHH.Location = new System.Drawing.Point(174, 389);
            this.numHH.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numHH.Name = "numHH";
            this.numHH.Size = new System.Drawing.Size(257, 22);
            this.numHH.TabIndex = 6;
            this.numHH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblHH
            // 
            this.lblHH.AutoSize = true;
            this.lblHH.Location = new System.Drawing.Point(20, 390);
            this.lblHH.Name = "lblHH";
            this.lblHH.Size = new System.Drawing.Size(100, 17);
            this.lblHH.TabIndex = 0;
            this.lblHH.Text = "Horas Hombre";
            // 
            // comboMaterial
            // 
            this.comboMaterial.FormattingEnabled = true;
            this.comboMaterial.Location = new System.Drawing.Point(174, 163);
            this.comboMaterial.Name = "comboMaterial";
            this.comboMaterial.Size = new System.Drawing.Size(257, 24);
            this.comboMaterial.TabIndex = 2;
            // 
            // numMP
            // 
            this.numMP.DecimalPlaces = 2;
            this.numMP.Location = new System.Drawing.Point(174, 333);
            this.numMP.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMP.Name = "numMP";
            this.numMP.Size = new System.Drawing.Size(257, 22);
            this.numMP.TabIndex = 5;
            this.numMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNRG
            // 
            this.lblNRG.AutoSize = true;
            this.lblNRG.Location = new System.Drawing.Point(20, 446);
            this.lblNRG.Name = "lblNRG";
            this.lblNRG.Size = new System.Drawing.Size(57, 17);
            this.lblNRG.TabIndex = 0;
            this.lblNRG.Text = "Energia";
            // 
            // numTamaño
            // 
            this.numTamaño.DecimalPlaces = 2;
            this.numTamaño.Location = new System.Drawing.Point(174, 277);
            this.numTamaño.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTamaño.Name = "numTamaño";
            this.numTamaño.Size = new System.Drawing.Size(257, 22);
            this.numTamaño.TabIndex = 4;
            this.numTamaño.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpFechaCosteo
            // 
            this.dtpFechaCosteo.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCosteo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCosteo.Location = new System.Drawing.Point(174, 221);
            this.dtpFechaCosteo.Name = "dtpFechaCosteo";
            this.dtpFechaCosteo.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaCosteo.TabIndex = 3;
            // 
            // ComboTipo
            // 
            this.ComboTipo.FormattingEnabled = true;
            this.ComboTipo.Location = new System.Drawing.Point(174, 105);
            this.ComboTipo.Name = "ComboTipo";
            this.ComboTipo.Size = new System.Drawing.Size(257, 24);
            this.ComboTipo.TabIndex = 1;
            this.ComboTipo.SelectedIndexChanged += new System.EventHandler(this.ComboTipo_SelectedIndexChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 110);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(90, 17);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo Material";
            // 
            // lblTamaño
            // 
            this.lblTamaño.AutoSize = true;
            this.lblTamaño.Location = new System.Drawing.Point(20, 278);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(140, 17);
            this.lblTamaño.TabIndex = 0;
            this.lblTamaño.Text = "Tamaño Lote Costeo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(174, 49);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.TabStop = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(20, 166);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(58, 17);
            this.lblMaterial.TabIndex = 0;
            this.lblMaterial.Text = "Material";
            // 
            // lblMP
            // 
            this.lblMP.AutoSize = true;
            this.lblMP.Location = new System.Drawing.Point(20, 334);
            this.lblMP.Name = "lblMP";
            this.lblMP.Size = new System.Drawing.Size(109, 17);
            this.lblMP.TabIndex = 0;
            this.lblMP.Text = "Materias Primas";
            // 
            // blFechaCosteo
            // 
            this.blFechaCosteo.AutoSize = true;
            this.blFechaCosteo.Location = new System.Drawing.Point(20, 222);
            this.blFechaCosteo.Name = "blFechaCosteo";
            this.blFechaCosteo.Size = new System.Drawing.Size(115, 17);
            this.blFechaCosteo.TabIndex = 0;
            this.blFechaCosteo.Text = "Fecha de Costeo";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 54);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 0;
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
            this.btnCancelar.Location = new System.Drawing.Point(317, 600);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 10;
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 600);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 9;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevoCosto
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 668);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoCosto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOtros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNRG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamaño)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label blFechaCosteo;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.ComboBox ComboTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.DateTimePicker dtpFechaCosteo;
        private System.Windows.Forms.NumericUpDown numTamaño;
        private System.Windows.Forms.Label lblMP;
        private System.Windows.Forms.NumericUpDown numMP;
        private System.Windows.Forms.Label lblNRG;
        private System.Windows.Forms.ComboBox comboMaterial;
        private System.Windows.Forms.NumericUpDown numHH;
        private System.Windows.Forms.Label lblHH;
        private System.Windows.Forms.NumericUpDown numOtros;
        private System.Windows.Forms.NumericUpDown numNRG;
        private System.Windows.Forms.Label lblOtros;
    }
}