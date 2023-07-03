
namespace Trabajo_Final
{
    partial class frmAsistencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistencias));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.comboMotivo = new System.Windows.Forms.ComboBox();
            this.rdInasistencia = new System.Windows.Forms.RadioButton();
            this.rdAsistencia = new System.Windows.Forms.RadioButton();
            this.dtpHoraIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblHoraIngreso = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpHoraEgreso = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.comboEmpleado = new System.Windows.Forms.ComboBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.comboMotivo);
            this.grpNuevoLogin.Controls.Add(this.rdInasistencia);
            this.grpNuevoLogin.Controls.Add(this.rdAsistencia);
            this.grpNuevoLogin.Controls.Add(this.dtpHoraIngreso);
            this.grpNuevoLogin.Controls.Add(this.lblHoraIngreso);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaInicio);
            this.grpNuevoLogin.Controls.Add(this.lblFechaInicio);
            this.grpNuevoLogin.Controls.Add(this.dtpHoraEgreso);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaFin);
            this.grpNuevoLogin.Controls.Add(this.lblMotivo);
            this.grpNuevoLogin.Controls.Add(this.lblEmpleado);
            this.grpNuevoLogin.Controls.Add(this.lblHoraFin);
            this.grpNuevoLogin.Controls.Add(this.lblFechaFin);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.comboEmpleado);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 482);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // comboMotivo
            // 
            this.comboMotivo.FormattingEnabled = true;
            this.comboMotivo.Location = new System.Drawing.Point(147, 331);
            this.comboMotivo.Name = "comboMotivo";
            this.comboMotivo.Size = new System.Drawing.Size(257, 24);
            this.comboMotivo.TabIndex = 24;
            this.comboMotivo.Visible = false;
            // 
            // rdInasistencia
            // 
            this.rdInasistencia.AutoSize = true;
            this.rdInasistencia.Location = new System.Drawing.Point(262, 268);
            this.rdInasistencia.Name = "rdInasistencia";
            this.rdInasistencia.Size = new System.Drawing.Size(103, 21);
            this.rdInasistencia.TabIndex = 23;
            this.rdInasistencia.Text = "Inasistencia";
            this.rdInasistencia.UseVisualStyleBackColor = true;
            this.rdInasistencia.CheckedChanged += new System.EventHandler(this.rdInasistencia_CheckedChanged);
            // 
            // rdAsistencia
            // 
            this.rdAsistencia.AutoSize = true;
            this.rdAsistencia.Checked = true;
            this.rdAsistencia.Location = new System.Drawing.Point(71, 269);
            this.rdAsistencia.Name = "rdAsistencia";
            this.rdAsistencia.Size = new System.Drawing.Size(93, 21);
            this.rdAsistencia.TabIndex = 22;
            this.rdAsistencia.TabStop = true;
            this.rdAsistencia.Text = "Asistencia";
            this.rdAsistencia.UseVisualStyleBackColor = true;
            this.rdAsistencia.CheckedChanged += new System.EventHandler(this.rdAsistencia_CheckedChanged);
            // 
            // dtpHoraIngreso
            // 
            this.dtpHoraIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraIngreso.Location = new System.Drawing.Point(147, 357);
            this.dtpHoraIngreso.Name = "dtpHoraIngreso";
            this.dtpHoraIngreso.ShowUpDown = true;
            this.dtpHoraIngreso.Size = new System.Drawing.Size(257, 22);
            this.dtpHoraIngreso.TabIndex = 21;
            this.dtpHoraIngreso.Value = new System.DateTime(2023, 7, 2, 8, 0, 0, 0);
            // 
            // lblHoraIngreso
            // 
            this.lblHoraIngreso.AutoSize = true;
            this.lblHoraIngreso.Location = new System.Drawing.Point(20, 362);
            this.lblHoraIngreso.Name = "lblHoraIngreso";
            this.lblHoraIngreso.Size = new System.Drawing.Size(98, 17);
            this.lblHoraIngreso.TabIndex = 20;
            this.lblHoraIngreso.Text = "Fecha Ingreso";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(147, 158);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaInicio.TabIndex = 19;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(20, 159);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(83, 17);
            this.lblFechaInicio.TabIndex = 18;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // dtpHoraEgreso
            // 
            this.dtpHoraEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraEgreso.Location = new System.Drawing.Point(147, 408);
            this.dtpHoraEgreso.Name = "dtpHoraEgreso";
            this.dtpHoraEgreso.ShowUpDown = true;
            this.dtpHoraEgreso.Size = new System.Drawing.Size(257, 22);
            this.dtpHoraEgreso.TabIndex = 17;
            this.dtpHoraEgreso.Value = new System.DateTime(2023, 7, 2, 17, 0, 0, 0);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(147, 213);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaFin.TabIndex = 16;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(20, 334);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(49, 17);
            this.lblMotivo.TabIndex = 14;
            this.lblMotivo.Text = "Motivo";
            this.lblMotivo.Visible = false;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(20, 104);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(71, 17);
            this.lblEmpleado.TabIndex = 12;
            this.lblEmpleado.Text = "Empleado";
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(20, 413);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(98, 17);
            this.lblHoraFin.TabIndex = 11;
            this.lblHoraFin.Text = "Fecha Ingreso";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(20, 214);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(70, 17);
            this.lblFechaFin.TabIndex = 10;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(147, 46);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            // 
            // comboEmpleado
            // 
            this.comboEmpleado.FormattingEnabled = true;
            this.comboEmpleado.Location = new System.Drawing.Point(147, 101);
            this.comboEmpleado.Name = "comboEmpleado";
            this.comboEmpleado.Size = new System.Drawing.Size(257, 24);
            this.comboEmpleado.TabIndex = 8;
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
            // Listado
            // 
            this.Listado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listado.ImageStream")));
            this.Listado.TransparentColor = System.Drawing.Color.Transparent;
            this.Listado.Images.SetKeyName(0, "aprobado.png");
            this.Listado.Images.SetKeyName(1, "rechazado.png");
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
            this.btnCancelar.Location = new System.Drawing.Point(323, 527);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 527);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 594);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsistencias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ComboBox comboEmpleado;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.DateTimePicker dtpHoraEgreso;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraIngreso;
        private System.Windows.Forms.Label lblHoraIngreso;
        private System.Windows.Forms.RadioButton rdInasistencia;
        private System.Windows.Forms.RadioButton rdAsistencia;
        private System.Windows.Forms.ComboBox comboMotivo;
    }
}