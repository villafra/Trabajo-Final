
namespace Trabajo_Final
{
    partial class frmNuevoIngresoCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoIngresoCompra));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.lblNroFac = new System.Windows.Forms.Label();
            this.txtNroFac = new System.Windows.Forms.TextBox();
            this.dtpFechaLote = new System.Windows.Forms.DateTimePicker();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.txtIngrediente = new System.Windows.Forms.TextBox();
            this.dtpFechaArribo = new System.Windows.Forms.DateTimePicker();
            this.lblFechaArribo = new System.Windows.Forms.Label();
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.lblNroFac);
            this.grpNuevoLogin.Controls.Add(this.txtNroFac);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaLote);
            this.grpNuevoLogin.Controls.Add(this.lblFechaCreacion);
            this.grpNuevoLogin.Controls.Add(this.lblLote);
            this.grpNuevoLogin.Controls.Add(this.txtLote);
            this.grpNuevoLogin.Controls.Add(this.txtIngrediente);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaArribo);
            this.grpNuevoLogin.Controls.Add(this.lblFechaArribo);
            this.grpNuevoLogin.Controls.Add(this.lblIngrediente);
            this.grpNuevoLogin.Controls.Add(this.numCantidad);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.lblCantidad);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 486);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // lblNroFac
            // 
            this.lblNroFac.AutoSize = true;
            this.lblNroFac.Location = new System.Drawing.Point(20, 173);
            this.lblNroFac.Name = "lblNroFac";
            this.lblNroFac.Size = new System.Drawing.Size(83, 17);
            this.lblNroFac.TabIndex = 39;
            this.lblNroFac.Text = "Nro Factura";
            // 
            // txtNroFac
            // 
            this.txtNroFac.Location = new System.Drawing.Point(174, 170);
            this.txtNroFac.Name = "txtNroFac";
            this.txtNroFac.Size = new System.Drawing.Size(257, 22);
            this.txtNroFac.TabIndex = 38;
            // 
            // dtpFechaLote
            // 
            this.dtpFechaLote.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaLote.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLote.Location = new System.Drawing.Point(174, 422);
            this.dtpFechaLote.Name = "dtpFechaLote";
            this.dtpFechaLote.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaLote.TabIndex = 37;
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Location = new System.Drawing.Point(20, 421);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(127, 17);
            this.lblFechaCreacion.TabIndex = 36;
            this.lblFechaCreacion.Text = "Fecha de Creación";
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(20, 359);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(36, 17);
            this.lblLote.TabIndex = 35;
            this.lblLote.Text = "Lote";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(174, 359);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(257, 22);
            this.txtLote.TabIndex = 34;
            this.txtLote.Leave += new System.EventHandler(this.txtLote_Leave);
            // 
            // txtIngrediente
            // 
            this.txtIngrediente.Location = new System.Drawing.Point(174, 107);
            this.txtIngrediente.Name = "txtIngrediente";
            this.txtIngrediente.ReadOnly = true;
            this.txtIngrediente.Size = new System.Drawing.Size(257, 22);
            this.txtIngrediente.TabIndex = 33;
            // 
            // dtpFechaArribo
            // 
            this.dtpFechaArribo.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaArribo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaArribo.Location = new System.Drawing.Point(174, 296);
            this.dtpFechaArribo.Name = "dtpFechaArribo";
            this.dtpFechaArribo.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaArribo.TabIndex = 32;
            // 
            // lblFechaArribo
            // 
            this.lblFechaArribo.AutoSize = true;
            this.lblFechaArribo.Location = new System.Drawing.Point(20, 297);
            this.lblFechaArribo.Name = "lblFechaArribo";
            this.lblFechaArribo.Size = new System.Drawing.Size(118, 17);
            this.lblFechaArribo.TabIndex = 31;
            this.lblFechaArribo.Text = "Fecha de Ingreso";
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.Location = new System.Drawing.Point(20, 111);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(79, 17);
            this.lblIngrediente.TabIndex = 24;
            this.lblIngrediente.Text = "Ingrediente";
            // 
            // numCantidad
            // 
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Location = new System.Drawing.Point(174, 233);
            this.numCantidad.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(257, 22);
            this.numCantidad.TabIndex = 20;
            this.numCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(174, 44);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(20, 235);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 17);
            this.lblCantidad.TabIndex = 7;
            this.lblCantidad.Text = "Cantidad";
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
            this.btnCancelar.Location = new System.Drawing.Point(323, 516);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 2;
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 516);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevoIngresoCompra
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 575);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoIngresoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.DateTimePicker dtpFechaArribo;
        private System.Windows.Forms.Label lblFechaArribo;
        private System.Windows.Forms.TextBox txtIngrediente;
        private System.Windows.Forms.DateTimePicker dtpFechaLote;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Label lblNroFac;
        private System.Windows.Forms.TextBox txtNroFac;
    }
}