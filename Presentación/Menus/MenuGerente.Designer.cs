
namespace Trabajo_Final
{
    partial class frmMenuGerente
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
            this.grpEmpleados = new System.Windows.Forms.GroupBox();
            this.txtAntiguedad = new System.Windows.Forms.TextBox();
            this.lblAntiguedad = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblEdad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.comboCateg = new System.Windows.Forms.ComboBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.btnNuevoEmpleado = new System.Windows.Forms.Button();
            this.grpEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEmpleados
            // 
            this.grpEmpleados.Controls.Add(this.txtAntiguedad);
            this.grpEmpleados.Controls.Add(this.lblAntiguedad);
            this.grpEmpleados.Controls.Add(this.txtEdad);
            this.grpEmpleados.Controls.Add(this.lblEdad);
            this.grpEmpleados.Controls.Add(this.label1);
            this.grpEmpleados.Controls.Add(this.dtpFechaIngreso);
            this.grpEmpleados.Controls.Add(this.lblFechaNacimiento);
            this.grpEmpleados.Controls.Add(this.dtpFechaNacimiento);
            this.grpEmpleados.Controls.Add(this.comboCateg);
            this.grpEmpleados.Controls.Add(this.lblCategoria);
            this.grpEmpleados.Controls.Add(this.txtApellido);
            this.grpEmpleados.Controls.Add(this.lblApellido);
            this.grpEmpleados.Controls.Add(this.txtNombre);
            this.grpEmpleados.Controls.Add(this.lblNombre);
            this.grpEmpleados.Controls.Add(this.txtDNI);
            this.grpEmpleados.Controls.Add(this.lblDNI);
            this.grpEmpleados.Controls.Add(this.txtLegajo);
            this.grpEmpleados.Controls.Add(this.lblLegajo);
            this.grpEmpleados.Location = new System.Drawing.Point(12, 337);
            this.grpEmpleados.Name = "grpEmpleados";
            this.grpEmpleados.Size = new System.Drawing.Size(973, 256);
            this.grpEmpleados.TabIndex = 6;
            this.grpEmpleados.TabStop = false;
            this.grpEmpleados.Text = "Empleados";
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Location = new System.Drawing.Point(579, 183);
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.Size = new System.Drawing.Size(102, 22);
            this.txtAntiguedad.TabIndex = 32;
            this.txtAntiguedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAntiguedad
            // 
            this.lblAntiguedad.AutoSize = true;
            this.lblAntiguedad.Location = new System.Drawing.Point(576, 150);
            this.lblAntiguedad.Name = "lblAntiguedad";
            this.lblAntiguedad.Size = new System.Drawing.Size(80, 17);
            this.lblAntiguedad.TabIndex = 31;
            this.lblAntiguedad.Text = "Antiguedad";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(214, 185);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(102, 22);
            this.txtEdad.TabIndex = 30;
            this.txtEdad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Location = new System.Drawing.Point(211, 150);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(41, 17);
            this.lblEdad.TabIndex = 29;
            this.lblEdad.Text = "Edad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fecha de Ingreso";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(387, 183);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(121, 22);
            this.dtpFechaIngreso.TabIndex = 27;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(19, 150);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(100, 17);
            this.lblFechaNacimiento.TabIndex = 26;
            this.lblFechaNacimiento.Text = "Fecha de Nac.";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(22, 183);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(121, 22);
            this.dtpFechaNacimiento.TabIndex = 25;
            // 
            // comboCateg
            // 
            this.comboCateg.FormattingEnabled = true;
            this.comboCateg.Location = new System.Drawing.Point(758, 181);
            this.comboCateg.Name = "comboCateg";
            this.comboCateg.Size = new System.Drawing.Size(170, 24);
            this.comboCateg.TabIndex = 24;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(755, 150);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(69, 17);
            this.lblCategoria.TabIndex = 23;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(706, 79);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(222, 22);
            this.txtApellido.TabIndex = 18;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(703, 50);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 17;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(405, 79);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(221, 22);
            this.txtNombre.TabIndex = 16;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(402, 50);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(223, 79);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(102, 22);
            this.txtDNI.TabIndex = 14;
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(220, 50);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(31, 17);
            this.lblDNI.TabIndex = 13;
            this.lblDNI.Text = "DNI";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Enabled = false;
            this.txtLegajo.Location = new System.Drawing.Point(44, 79);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(99, 22);
            this.txtLegajo.TabIndex = 12;
            this.txtLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(41, 50);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(51, 17);
            this.lblLegajo.TabIndex = 11;
            this.lblLegajo.Text = "Legajo";
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 27);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.RowTemplate.Height = 24;
            this.dgvEmpleados.Size = new System.Drawing.Size(973, 254);
            this.dgvEmpleados.TabIndex = 5;
            // 
            // btnNuevoEmpleado
            // 
            this.btnNuevoEmpleado.Location = new System.Drawing.Point(439, 620);
            this.btnNuevoEmpleado.Name = "btnNuevoEmpleado";
            this.btnNuevoEmpleado.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoEmpleado.TabIndex = 7;
            this.btnNuevoEmpleado.Text = "button1";
            this.btnNuevoEmpleado.UseVisualStyleBackColor = true;
            // 
            // frmMenuGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 958);
            this.Controls.Add(this.btnNuevoEmpleado);
            this.Controls.Add(this.grpEmpleados);
            this.Controls.Add(this.dgvEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenuGerente";
            this.Text = "MenuGerente";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMenuGerente_MouseDown);
            this.grpEmpleados.ResumeLayout(false);
            this.grpEmpleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.ComboBox comboCateg;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.TextBox txtAntiguedad;
        private System.Windows.Forms.Label lblAntiguedad;
        private System.Windows.Forms.Button btnNuevoEmpleado;
    }
}