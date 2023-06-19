
namespace Trabajo_Final
{
    partial class frmNuevaCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaCompra));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.blFechaComp = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.ComboIngrediente = new System.Windows.Forms.ComboBox();
            this.lblIngrediente = new System.Windows.Forms.Label();
            this.dtpFechaCompra = new System.Windows.Forms.DateTimePicker();
            this.numCosto = new System.Windows.Forms.NumericUpDown();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.numCantRecibida = new System.Windows.Forms.NumericUpDown();
            this.lblCantRecibida = new System.Windows.Forms.Label();
            this.dtpFechaArribo = new System.Windows.Forms.DateTimePicker();
            this.lblFechaArribo = new System.Windows.Forms.Label();
            this.grpNuevoLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantRecibida)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.dtpFechaArribo);
            this.grpNuevoLogin.Controls.Add(this.lblFechaArribo);
            this.grpNuevoLogin.Controls.Add(this.numCantRecibida);
            this.grpNuevoLogin.Controls.Add(this.lblCantRecibida);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaEntrega);
            this.grpNuevoLogin.Controls.Add(this.numCosto);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaCompra);
            this.grpNuevoLogin.Controls.Add(this.ComboIngrediente);
            this.grpNuevoLogin.Controls.Add(this.lblIngrediente);
            this.grpNuevoLogin.Controls.Add(this.numCantidad);
            this.grpNuevoLogin.Controls.Add(this.lblCosto);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.lblCantidad);
            this.grpNuevoLogin.Controls.Add(this.lblFechaEntrega);
            this.grpNuevoLogin.Controls.Add(this.blFechaComp);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 498);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // numCantidad
            // 
            this.numCantidad.DecimalPlaces = 2;
            this.numCantidad.Location = new System.Drawing.Point(174, 158);
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
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(20, 277);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(44, 17);
            this.lblCosto.TabIndex = 19;
            this.lblCosto.Text = "Costo";
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
            this.lblCantidad.Location = new System.Drawing.Point(20, 163);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(64, 17);
            this.lblCantidad.TabIndex = 7;
            this.lblCantidad.Text = "Cantidad";
            // 
            // blFechaComp
            // 
            this.blFechaComp.AutoSize = true;
            this.blFechaComp.Location = new System.Drawing.Point(20, 220);
            this.blFechaComp.Name = "blFechaComp";
            this.blFechaComp.Size = new System.Drawing.Size(120, 17);
            this.blFechaComp.TabIndex = 4;
            this.blFechaComp.Text = "Fecha de Compra";
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
            this.btnCancelar.Location = new System.Drawing.Point(323, 528);
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 528);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // ComboIngrediente
            // 
            this.ComboIngrediente.FormattingEnabled = true;
            this.ComboIngrediente.Location = new System.Drawing.Point(174, 99);
            this.ComboIngrediente.Name = "ComboIngrediente";
            this.ComboIngrediente.Size = new System.Drawing.Size(257, 24);
            this.ComboIngrediente.TabIndex = 25;
            // 
            // lblIngrediente
            // 
            this.lblIngrediente.AutoSize = true;
            this.lblIngrediente.Location = new System.Drawing.Point(20, 106);
            this.lblIngrediente.Name = "lblIngrediente";
            this.lblIngrediente.Size = new System.Drawing.Size(79, 17);
            this.lblIngrediente.TabIndex = 24;
            this.lblIngrediente.Text = "Ingrediente";
            // 
            // dtpFechaCompra
            // 
            this.dtpFechaCompra.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCompra.Location = new System.Drawing.Point(174, 215);
            this.dtpFechaCompra.Name = "dtpFechaCompra";
            this.dtpFechaCompra.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaCompra.TabIndex = 26;
            // 
            // numCosto
            // 
            this.numCosto.DecimalPlaces = 2;
            this.numCosto.Location = new System.Drawing.Point(174, 272);
            this.numCosto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCosto.Name = "numCosto";
            this.numCosto.Size = new System.Drawing.Size(257, 22);
            this.numCosto.TabIndex = 27;
            this.numCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Location = new System.Drawing.Point(20, 331);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(121, 17);
            this.lblFechaEntrega.TabIndex = 5;
            this.lblFechaEntrega.Text = "Fecha de Entrega";
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(174, 331);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaEntrega.TabIndex = 28;
            // 
            // numCantRecibida
            // 
            this.numCantRecibida.DecimalPlaces = 2;
            this.numCantRecibida.Location = new System.Drawing.Point(174, 455);
            this.numCantRecibida.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numCantRecibida.Name = "numCantRecibida";
            this.numCantRecibida.Size = new System.Drawing.Size(257, 22);
            this.numCantRecibida.TabIndex = 30;
            this.numCantRecibida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCantRecibida
            // 
            this.lblCantRecibida.AutoSize = true;
            this.lblCantRecibida.Location = new System.Drawing.Point(20, 460);
            this.lblCantRecibida.Name = "lblCantRecibida";
            this.lblCantRecibida.Size = new System.Drawing.Size(123, 17);
            this.lblCantRecibida.TabIndex = 29;
            this.lblCantRecibida.Text = "Cantidad Recibida";
            // 
            // dtpFechaArribo
            // 
            this.dtpFechaArribo.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaArribo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaArribo.Location = new System.Drawing.Point(174, 394);
            this.dtpFechaArribo.Name = "dtpFechaArribo";
            this.dtpFechaArribo.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaArribo.TabIndex = 32;
            // 
            // lblFechaArribo
            // 
            this.lblFechaArribo.AutoSize = true;
            this.lblFechaArribo.Location = new System.Drawing.Point(20, 394);
            this.lblFechaArribo.Name = "lblFechaArribo";
            this.lblFechaArribo.Size = new System.Drawing.Size(118, 17);
            this.lblFechaArribo.TabIndex = 31;
            this.lblFechaArribo.Text = "Fecha de Ingreso";
            // 
            // frmNuevaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 596);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantRecibida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label blFechaComp;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.ComboBox ComboIngrediente;
        private System.Windows.Forms.Label lblIngrediente;
        private System.Windows.Forms.DateTimePicker dtpFechaCompra;
        private System.Windows.Forms.NumericUpDown numCosto;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaArribo;
        private System.Windows.Forms.Label lblFechaArribo;
        private System.Windows.Forms.NumericUpDown numCantRecibida;
        private System.Windows.Forms.Label lblCantRecibida;
    }
}