
namespace Trabajo_Final
{
    partial class frmPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermisos));
            this.Listado = new System.Windows.Forms.ImageList(this.components);
            this.grpPerfiles = new System.Windows.Forms.GroupBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtDescripción = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tvPermisos = new System.Windows.Forms.TreeView();
            this.grpPermisos = new System.Windows.Forms.GroupBox();
            this.comboPermiso = new System.Windows.Forms.ComboBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblDescPerm = new System.Windows.Forms.Label();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.grpPerfiles.SuspendLayout();
            this.grpPermisos.SuspendLayout();
            this.SuspendLayout();
            // 
            // Listado
            // 
            this.Listado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Listado.ImageStream")));
            this.Listado.TransparentColor = System.Drawing.Color.Transparent;
            this.Listado.Images.SetKeyName(0, "buscar.png");
            this.Listado.Images.SetKeyName(1, "reiniciar.png");
            this.Listado.Images.SetKeyName(2, "agregar.png");
            this.Listado.Images.SetKeyName(3, "lapiz.png");
            this.Listado.Images.SetKeyName(4, "basura.png");
            this.Listado.Images.SetKeyName(5, "girar.png");
            this.Listado.Images.SetKeyName(6, "bloqueado.png");
            // 
            // grpPerfiles
            // 
            this.grpPerfiles.Controls.Add(this.lblDescripcion);
            this.grpPerfiles.Controls.Add(this.lblCodigo);
            this.grpPerfiles.Controls.Add(this.txtDescripción);
            this.grpPerfiles.Controls.Add(this.txtCodigo);
            this.grpPerfiles.Controls.Add(this.btnModificar);
            this.grpPerfiles.Controls.Add(this.btnAgregar);
            this.grpPerfiles.Controls.Add(this.btnEliminar);
            this.grpPerfiles.Location = new System.Drawing.Point(531, 12);
            this.grpPerfiles.Name = "grpPerfiles";
            this.grpPerfiles.Size = new System.Drawing.Size(759, 254);
            this.grpPerfiles.TabIndex = 10;
            this.grpPerfiles.TabStop = false;
            this.grpPerfiles.Text = "Perfiles";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(295, 76);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(82, 17);
            this.lblDescripcion.TabIndex = 11;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(30, 76);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código";
            // 
            // txtDescripción
            // 
            this.txtDescripción.Location = new System.Drawing.Point(298, 99);
            this.txtDescripción.Name = "txtDescripción";
            this.txtDescripción.Size = new System.Drawing.Size(411, 22);
            this.txtDescripción.TabIndex = 9;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(30, 99);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(204, 22);
            this.txtCodigo.TabIndex = 8;
            // 
            // btnModificar
            // 
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.ImageIndex = 3;
            this.btnModificar.ImageList = this.Listado;
            this.btnModificar.Location = new System.Drawing.Point(274, 187);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(210, 50);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar Perfil";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.ImageIndex = 2;
            this.btnAgregar.ImageList = this.Listado;
            this.btnAgregar.Location = new System.Drawing.Point(6, 187);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(210, 50);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Crear Nuevo Perfil";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageIndex = 4;
            this.btnEliminar.ImageList = this.Listado;
            this.btnEliminar.Location = new System.Drawing.Point(543, 187);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(210, 50);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar Perfil";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tvPermisos
            // 
            this.tvPermisos.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvPermisos.Location = new System.Drawing.Point(0, 0);
            this.tvPermisos.Name = "tvPermisos";
            this.tvPermisos.Size = new System.Drawing.Size(478, 918);
            this.tvPermisos.TabIndex = 11;
            this.tvPermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPermisos_AfterSelect);
            // 
            // grpPermisos
            // 
            this.grpPermisos.Controls.Add(this.comboPermiso);
            this.grpPermisos.Controls.Add(this.chkActivo);
            this.grpPermisos.Controls.Add(this.lblDescPerm);
            this.grpPermisos.Controls.Add(this.btnDesasignar);
            this.grpPermisos.Controls.Add(this.btnAsignar);
            this.grpPermisos.Location = new System.Drawing.Point(531, 373);
            this.grpPermisos.Name = "grpPermisos";
            this.grpPermisos.Size = new System.Drawing.Size(759, 254);
            this.grpPermisos.TabIndex = 12;
            this.grpPermisos.TabStop = false;
            this.grpPermisos.Text = "Permisos";
            // 
            // comboPermiso
            // 
            this.comboPermiso.FormattingEnabled = true;
            this.comboPermiso.Location = new System.Drawing.Point(30, 95);
            this.comboPermiso.Name = "comboPermiso";
            this.comboPermiso.Size = new System.Drawing.Size(457, 24);
            this.comboPermiso.TabIndex = 13;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(552, 95);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(123, 21);
            this.chkActivo.TabIndex = 12;
            this.chkActivo.Text = "Permiso Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblDescPerm
            // 
            this.lblDescPerm.AutoSize = true;
            this.lblDescPerm.Location = new System.Drawing.Point(27, 72);
            this.lblDescPerm.Name = "lblDescPerm";
            this.lblDescPerm.Size = new System.Drawing.Size(82, 17);
            this.lblDescPerm.TabIndex = 11;
            this.lblDescPerm.Text = "Descripción";
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDesasignar.FlatAppearance.BorderSize = 0;
            this.btnDesasignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesasignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesasignar.ImageIndex = 3;
            this.btnDesasignar.ImageList = this.Listado;
            this.btnDesasignar.Location = new System.Drawing.Point(473, 187);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(210, 50);
            this.btnDesasignar.TabIndex = 6;
            this.btnDesasignar.Text = "Desasignar Permiso";
            this.btnDesasignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDesasignar.UseVisualStyleBackColor = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignar.ImageIndex = 2;
            this.btnAsignar.ImageList = this.Listado;
            this.btnAsignar.Location = new System.Drawing.Point(75, 187);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(210, 50);
            this.btnAsignar.TabIndex = 5;
            this.btnAsignar.Text = "Asignar Permiso";
            this.btnAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // frmPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 918);
            this.Controls.Add(this.grpPermisos);
            this.Controls.Add(this.tvPermisos);
            this.Controls.Add(this.grpPerfiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuarios";
            this.grpPerfiles.ResumeLayout(false);
            this.grpPerfiles.PerformLayout();
            this.grpPermisos.ResumeLayout(false);
            this.grpPermisos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList Listado;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox grpPerfiles;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TreeView tvPermisos;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtDescripción;
        private System.Windows.Forms.GroupBox grpPermisos;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblDescPerm;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.ComboBox comboPermiso;
    }
}