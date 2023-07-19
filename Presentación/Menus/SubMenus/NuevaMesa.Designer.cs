
namespace Trabajo_Final
{
    partial class frmNuevaMesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaMesa));
            this.grpNuevoLogin = new System.Windows.Forms.GroupBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.comboUbicacion = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpNuevoLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNuevoLogin
            // 
            this.grpNuevoLogin.Controls.Add(this.chkActivo);
            this.grpNuevoLogin.Controls.Add(this.lblUbicacion);
            this.grpNuevoLogin.Controls.Add(this.txtCodigo);
            this.grpNuevoLogin.Controls.Add(this.comboUbicacion);
            this.grpNuevoLogin.Controls.Add(this.lblCantidad);
            this.grpNuevoLogin.Controls.Add(this.lblCodigo);
            this.grpNuevoLogin.Controls.Add(this.txtCapacidad);
            this.grpNuevoLogin.Location = new System.Drawing.Point(24, 24);
            this.grpNuevoLogin.Name = "grpNuevoLogin";
            this.grpNuevoLogin.Size = new System.Drawing.Size(437, 271);
            this.grpNuevoLogin.TabIndex = 0;
            this.grpNuevoLogin.TabStop = false;
            this.grpNuevoLogin.Text = "Complete El formulario";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(306, 222);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(68, 21);
            this.chkActivo.TabIndex = 3;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(20, 169);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(70, 17);
            this.lblUbicacion.TabIndex = 0;
            this.lblUbicacion.Text = "Ubicación";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(147, 46);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(257, 22);
            this.txtCodigo.TabIndex = 9;
            this.txtCodigo.TabStop = false;
            // 
            // comboUbicacion
            // 
            this.comboUbicacion.FormattingEnabled = true;
            this.comboUbicacion.Location = new System.Drawing.Point(147, 166);
            this.comboUbicacion.Name = "comboUbicacion";
            this.comboUbicacion.Size = new System.Drawing.Size(257, 24);
            this.comboUbicacion.TabIndex = 2;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(20, 105);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(75, 17);
            this.lblCantidad.TabIndex = 0;
            this.lblCantidad.Text = "Capacidad";
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
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(147, 102);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(257, 22);
            this.txtCapacidad.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(323, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 47);
            this.btnCancelar.TabIndex = 4;
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
            this.btnConfirmar.Location = new System.Drawing.Point(24, 315);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(138, 47);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmNuevaMesa
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 379);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grpNuevoLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNuevaMesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNuevoLogin";
            this.Load += new System.EventHandler(this.frmNuevoLogin_Load);
            this.grpNuevoLogin.ResumeLayout(false);
            this.grpNuevoLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNuevoLogin;
        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox comboUbicacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.CheckBox chkActivo;
    }
}