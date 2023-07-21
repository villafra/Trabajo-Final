
namespace Trabajo_Final
{
    partial class frmVerPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerPedido));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboPlatos = new System.Windows.Forms.ComboBox();
            this.lblIng = new System.Windows.Forms.Label();
            this.comboBebidas = new System.Windows.Forms.ComboBox();
            this.lblClas = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtMétodoPago = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.txtEmpleado);
            this.grpNuevoLogin.Controls.Add(this.label3);
            this.grpNuevoLogin.Controls.Add(this.txtMétodoPago);
            this.grpNuevoLogin.Controls.Add(this.label2);
            this.grpNuevoLogin.Controls.Add(this.dtpFecha);
            this.grpNuevoLogin.Controls.Add(this.txtMonto);
            this.grpNuevoLogin.Controls.Add(this.label1);
            this.grpNuevoLogin.Controls.Add(this.comboPlatos);
            this.grpNuevoLogin.Controls.Add(this.lblIng);
            this.grpNuevoLogin.Controls.Add(this.comboBebidas);
            this.grpNuevoLogin.Controls.Add(this.lblClas);
            this.grpNuevoLogin.Controls.Add(this.txtStatus);
            this.grpNuevoLogin.Controls.Add(this.lblFechaInicio);
            this.grpNuevoLogin.Controls.Add(this.lblStatus);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 514);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(174, 224);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(257, 22);
            this.txtMonto.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Bebidas";
            // 
            // comboPlatos
            // 
            this.comboPlatos.FormattingEnabled = true;
            this.comboPlatos.Location = new System.Drawing.Point(174, 346);
            this.comboPlatos.Name = "comboPlatos";
            this.comboPlatos.Size = new System.Drawing.Size(257, 24);
            this.comboPlatos.TabIndex = 5;
            // 
            // lblIng
            // 
            this.lblIng.AutoSize = true;
            this.lblIng.Location = new System.Drawing.Point(20, 354);
            this.lblIng.Name = "lblIng";
            this.lblIng.Size = new System.Drawing.Size(101, 17);
            this.lblIng.TabIndex = 0;
            this.lblIng.Text = "Lista de Platos";
            // 
            // comboBebidas
            // 
            this.comboBebidas.FormattingEnabled = true;
            this.comboBebidas.Location = new System.Drawing.Point(174, 284);
            this.comboBebidas.Name = "comboBebidas";
            this.comboBebidas.Size = new System.Drawing.Size(257, 24);
            this.comboBebidas.TabIndex = 3;
            // 
            // lblClas
            // 
            this.lblClas.AutoSize = true;
            this.lblClas.Location = new System.Drawing.Point(20, 232);
            this.lblClas.Name = "lblClas";
            this.lblClas.Size = new System.Drawing.Size(83, 17);
            this.lblClas.TabIndex = 0;
            this.lblClas.Text = "Monto Total";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(174, 164);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(257, 22);
            this.txtStatus.TabIndex = 1;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 110);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(83, 17);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 171);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(96, 17);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status Pedido";
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
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(20, 49);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
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
            this.btnConfirmar.Location = new System.Drawing.Point(323, 544);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Cerrar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(174, 104);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(257, 22);
            this.dtpFecha.TabIndex = 10;
            // 
            // txtMétodoPago
            // 
            this.txtMétodoPago.Location = new System.Drawing.Point(174, 408);
            this.txtMétodoPago.Name = "txtMétodoPago";
            this.txtMétodoPago.ReadOnly = true;
            this.txtMétodoPago.Size = new System.Drawing.Size(257, 22);
            this.txtMétodoPago.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Métdo de Pago";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(171, 468);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(257, 22);
            this.txtEmpleado.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 476);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Empleado";
            // 
            // frmVerPedido
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 603);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmVerPedido_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ComboBox comboBebidas;
        private System.Windows.Forms.Label lblClas;
        private System.Windows.Forms.ComboBox comboPlatos;
        private System.Windows.Forms.Label lblIng;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtMétodoPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Label label3;
    }
}