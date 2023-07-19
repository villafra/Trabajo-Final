
namespace Trabajo_Final
{
    partial class frmNuevoEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoEmpleado));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.dtpFechaIng = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblFechaIng = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.comboCategoria = new System.Windows.Forms.ComboBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.dtpFechaIng);
            this.grpNuevoLogin.Controls.Add(this.dtpFechaNac);
            this.grpNuevoLogin.Controls.Add(this.txtApellido);
            this.grpNuevoLogin.Controls.Add(this.lblContacto);
            this.grpNuevoLogin.Controls.Add(this.txtContacto);
            this.grpNuevoLogin.Controls.Add(this.lblCategoria);
            this.grpNuevoLogin.Controls.Add(this.lblFechaIng);
            this.grpNuevoLogin.Controls.Add(this.lblFechaNac);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.comboCategoria);
            this.grpNuevoLogin.Controls.Add(this.lblApellido);
            this.grpNuevoLogin.Controls.Add(this.lblNombre);
            this.grpNuevoLogin.Controls.Add(this.lblDNI);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Controls.Add(this.txtNombre);
            this.grpNuevoLogin.Controls.Add(this.txtDNI);
            this.grpNuevoLogin.Location = new System.Drawing.Point(23, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(498, 502);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // dtpFechaIng
            // 
            this.dtpFechaIng.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaIng.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIng.Location = new System.Drawing.Point(186, 326);
            this.dtpFechaIng.Name = "dtpFechaIng";
            this.dtpFechaIng.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaIng.TabIndex = 5;
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNac.Location = new System.Drawing.Point(186, 270);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(257, 22);
            this.dtpFechaNac.TabIndex = 4;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(186, 214);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(257, 22);
            this.txtApellido.TabIndex = 3;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(20, 441);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(64, 17);
            this.lblContacto.TabIndex = 0;
            this.lblContacto.Text = "Contacto";
            this.lblContacto.Visible = false;
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(186, 440);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(257, 22);
            this.txtContacto.TabIndex = 7;
            this.txtContacto.Visible = false;
            this.txtContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContacto_KeyPress);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(20, 385);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(69, 17);
            this.lblCategoria.TabIndex = 0;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblFechaIng
            // 
            this.lblFechaIng.AutoSize = true;
            this.lblFechaIng.Location = new System.Drawing.Point(20, 329);
            this.lblFechaIng.Name = "lblFechaIng";
            this.lblFechaIng.Size = new System.Drawing.Size(98, 17);
            this.lblFechaIng.TabIndex = 0;
            this.lblFechaIng.Text = "Fecha Ingreso";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(20, 273);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(121, 17);
            this.lblFechaNac.TabIndex = 0;
            this.lblFechaNac.Text = "Fecha Nacimiento";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(186, 46);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.TabStop = false;
            // 
            // comboCategoria
            // 
            this.comboCategoria.FormattingEnabled = true;
            this.comboCategoria.Location = new System.Drawing.Point(186, 382);
            this.comboCategoria.Name = "comboCategoria";
            this.comboCategoria.Size = new System.Drawing.Size(257, 24);
            this.comboCategoria.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(20, 217);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 0;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 161);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(20, 105);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(31, 17);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI";
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
            this.txtNombre.Location = new System.Drawing.Point(186, 158);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(257, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(186, 102);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(257, 22);
            this.txtDNI.TabIndex = 1;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
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
            this.btnCancelar.Location = new System.Drawing.Point(383, 541);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 9;
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 541);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevoEmpleado
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(545, 611);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox comboCategoria;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblFechaIng;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.DateTimePicker dtpFechaIng;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtContacto;
    }
}