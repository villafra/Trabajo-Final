
namespace Trabajo_Final
{
    partial class frmNuevoLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevoLogin));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.btnDesencriptar = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.comboPermiso = new System.Windows.Forms.ComboBox();
            this.lblPermiso = new System.Windows.Forms.Label();
            this.comboEmpleado = new System.Windows.Forms.ComboBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.btnDesencriptar);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.comboPermiso);
            this.grpNuevoLogin.Controls.Add(this.lblPermiso);
            this.grpNuevoLogin.Controls.Add(this.comboEmpleado);
            this.grpNuevoLogin.Controls.Add(this.lblPass);
            this.grpNuevoLogin.Controls.Add(this.lblUsuario);
            this.grpNuevoLogin.Controls.Add(this.lblEmpleado);
            this.grpNuevoLogin.Controls.Add(this.txtPass);
            this.grpNuevoLogin.Controls.Add(this.txtUsuario);
            this.grpNuevoLogin.Location = new System.Drawing.Point(21, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(577, 280);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // btnDesencriptar
            // 
            this.btnDesencriptar.BackgroundImage = global::Trabajo_Final.Properties.Resources.eye;
            this.btnDesencriptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDesencriptar.FlatAppearance.BorderSize = 0;
            this.btnDesencriptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesencriptar.Location = new System.Drawing.Point(515, 178);
            this.btnDesencriptar.Name = "btnDesencriptar";
            this.btnDesencriptar.Size = new System.Drawing.Size(47, 42);
            this.btnDesencriptar.TabIndex = 11;
            this.btnDesencriptar.UseVisualStyleBackColor = true;
            this.btnDesencriptar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDesencriptar_MouseDown);
            this.btnDesencriptar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnDesencriptar_MouseUp);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(22, 38);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Codigo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(149, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(347, 22);
            this.txtCodigo.TabIndex = 9;
            // 
            // comboPermiso
            // 
            this.comboPermiso.FormattingEnabled = true;
            this.comboPermiso.Location = new System.Drawing.Point(147, 239);
            this.comboPermiso.Name = "comboPermiso";
            this.comboPermiso.Size = new System.Drawing.Size(349, 24);
            this.comboPermiso.TabIndex = 8;
            // 
            // lblPermiso
            // 
            this.lblPermiso.AutoSize = true;
            this.lblPermiso.Location = new System.Drawing.Point(20, 242);
            this.lblPermiso.Name = "lblPermiso";
            this.lblPermiso.Size = new System.Drawing.Size(59, 17);
            this.lblPermiso.TabIndex = 7;
            this.lblPermiso.Text = "Permiso";
            // 
            // comboEmpleado
            // 
            this.comboEmpleado.FormattingEnabled = true;
            this.comboEmpleado.Location = new System.Drawing.Point(147, 84);
            this.comboEmpleado.Name = "comboEmpleado";
            this.comboEmpleado.Size = new System.Drawing.Size(349, 24);
            this.comboEmpleado.TabIndex = 6;
            this.comboEmpleado.Leave += new System.EventHandler(this.comboEmpleado_Leave);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(20, 191);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(69, 17);
            this.lblPass.TabIndex = 5;
            this.lblPass.Text = "Password";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(20, 140);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(57, 17);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(20, 89);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(71, 17);
            this.lblEmpleado.TabIndex = 3;
            this.lblEmpleado.Text = "Empleado";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(147, 188);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(349, 22);
            this.txtPass.TabIndex = 2;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(147, 137);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(349, 22);
            this.txtUsuario.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(460, 320);
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 320);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(618, 379);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevoLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.ComboBox comboEmpleado;
        private System.Windows.Forms.ComboBox comboPermiso;
        private System.Windows.Forms.Label lblPermiso;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnDesencriptar;
    }
}