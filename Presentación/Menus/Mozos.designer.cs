namespace Trabajo_Final
{
    partial class frmMozos
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
            this.dgvMozos = new System.Windows.Forms.DataGridView();
            this.grpMozos = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.lblPuntuación = new System.Windows.Forms.Label();
            this.prgBaRanking = new System.Windows.Forms.ProgressBar();
            this.lblRanking = new System.Windows.Forms.Label();
            this.btnEliminarMozo = new System.Windows.Forms.Button();
            this.btnModificarMozo = new System.Windows.Forms.Button();
            this.btnNuevaMozo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMozos)).BeginInit();
            this.grpMozos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMozos
            // 
            this.dgvMozos.AllowUserToAddRows = false;
            this.dgvMozos.AllowUserToDeleteRows = false;
            this.dgvMozos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMozos.Location = new System.Drawing.Point(37, 53);
            this.dgvMozos.Name = "dgvMozos";
            this.dgvMozos.ReadOnly = true;
            this.dgvMozos.RowHeadersWidth = 51;
            this.dgvMozos.RowTemplate.Height = 24;
            this.dgvMozos.Size = new System.Drawing.Size(772, 254);
            this.dgvMozos.TabIndex = 0;
            this.dgvMozos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMozos_CellContentClick);
            // 
            // grpMozos
            // 
            this.grpMozos.Controls.Add(this.label1);
            this.grpMozos.Controls.Add(this.dtpFechaIngreso);
            this.grpMozos.Controls.Add(this.lblFechaNacimiento);
            this.grpMozos.Controls.Add(this.dtpFechaNacimiento);
            this.grpMozos.Controls.Add(this.comboTurno);
            this.grpMozos.Controls.Add(this.lblTurno);
            this.grpMozos.Controls.Add(this.txtApellido);
            this.grpMozos.Controls.Add(this.lblApellido);
            this.grpMozos.Controls.Add(this.txtNombre);
            this.grpMozos.Controls.Add(this.lblNombre);
            this.grpMozos.Controls.Add(this.txtDNI);
            this.grpMozos.Controls.Add(this.lblDNI);
            this.grpMozos.Controls.Add(this.txtLegajo);
            this.grpMozos.Controls.Add(this.lblLegajo);
            this.grpMozos.Controls.Add(this.lblPuntuación);
            this.grpMozos.Controls.Add(this.prgBaRanking);
            this.grpMozos.Controls.Add(this.lblRanking);
            this.grpMozos.Location = new System.Drawing.Point(12, 313);
            this.grpMozos.Name = "grpMozos";
            this.grpMozos.Size = new System.Drawing.Size(826, 185);
            this.grpMozos.TabIndex = 1;
            this.grpMozos.TabStop = false;
            this.grpMozos.Text = "Mozos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fecha de Ingreso";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(470, 63);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(121, 22);
            this.dtpFechaIngreso.TabIndex = 27;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(289, 33);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(100, 17);
            this.lblFechaNacimiento.TabIndex = 26;
            this.lblFechaNacimiento.Text = "Fecha de Nac.";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(287, 63);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(121, 22);
            this.dtpFechaNacimiento.TabIndex = 25;
            // 
            // comboTurno
            // 
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Location = new System.Drawing.Point(433, 141);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(158, 24);
            this.comboTurno.TabIndex = 24;
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(430, 113);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(46, 17);
            this.lblTurno.TabIndex = 23;
            this.lblTurno.Text = "Turno";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(222, 143);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(186, 22);
            this.txtApellido.TabIndex = 18;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(219, 113);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 17);
            this.lblApellido.TabIndex = 17;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(27, 143);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(175, 22);
            this.txtNombre.TabIndex = 16;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(24, 113);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(163, 63);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(102, 22);
            this.txtDNI.TabIndex = 14;
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(160, 33);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(31, 17);
            this.lblDNI.TabIndex = 13;
            this.lblDNI.Text = "DNI";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Enabled = false;
            this.txtLegajo.Location = new System.Drawing.Point(27, 63);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(99, 22);
            this.txtLegajo.TabIndex = 12;
            this.txtLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Location = new System.Drawing.Point(24, 33);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(51, 17);
            this.lblLegajo.TabIndex = 11;
            this.lblLegajo.Text = "Legajo";
            // 
            // lblPuntuación
            // 
            this.lblPuntuación.AutoSize = true;
            this.lblPuntuación.Location = new System.Drawing.Point(739, 65);
            this.lblPuntuación.Name = "lblPuntuación";
            this.lblPuntuación.Size = new System.Drawing.Size(16, 17);
            this.lblPuntuación.TabIndex = 10;
            this.lblPuntuación.Text = "0";
            // 
            // prgBaRanking
            // 
            this.prgBaRanking.BackColor = System.Drawing.SystemColors.HotTrack;
            this.prgBaRanking.Location = new System.Drawing.Point(619, 96);
            this.prgBaRanking.Maximum = 10;
            this.prgBaRanking.Name = "prgBaRanking";
            this.prgBaRanking.Size = new System.Drawing.Size(188, 42);
            this.prgBaRanking.Step = 1;
            this.prgBaRanking.TabIndex = 9;
            // 
            // lblRanking
            // 
            this.lblRanking.AutoSize = true;
            this.lblRanking.Location = new System.Drawing.Point(636, 65);
            this.lblRanking.Name = "lblRanking";
            this.lblRanking.Size = new System.Drawing.Size(79, 17);
            this.lblRanking.TabIndex = 8;
            this.lblRanking.Text = "Puntuación";
            // 
            // btnEliminarMozo
            // 
            this.btnEliminarMozo.BackgroundImage = global::Trabajo_Final.Properties.Resources.BorrarMozo;
            this.btnEliminarMozo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminarMozo.FlatAppearance.BorderSize = 0;
            this.btnEliminarMozo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarMozo.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarMozo.ForeColor = System.Drawing.Color.Gold;
            this.btnEliminarMozo.Location = new System.Drawing.Point(738, 504);
            this.btnEliminarMozo.Name = "btnEliminarMozo";
            this.btnEliminarMozo.Size = new System.Drawing.Size(100, 93);
            this.btnEliminarMozo.TabIndex = 4;
            this.btnEliminarMozo.UseVisualStyleBackColor = true;
            this.btnEliminarMozo.Click += new System.EventHandler(this.btnEliminarMozo_Click);
            // 
            // btnModificarMozo
            // 
            this.btnModificarMozo.BackgroundImage = global::Trabajo_Final.Properties.Resources.ModificarMozo;
            this.btnModificarMozo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarMozo.FlatAppearance.BorderSize = 0;
            this.btnModificarMozo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarMozo.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarMozo.ForeColor = System.Drawing.Color.Gold;
            this.btnModificarMozo.Location = new System.Drawing.Point(373, 504);
            this.btnModificarMozo.Name = "btnModificarMozo";
            this.btnModificarMozo.Size = new System.Drawing.Size(100, 93);
            this.btnModificarMozo.TabIndex = 3;
            this.btnModificarMozo.UseVisualStyleBackColor = true;
            this.btnModificarMozo.Click += new System.EventHandler(this.btnModificarMozo_Click);
            // 
            // btnNuevaMozo
            // 
            this.btnNuevaMozo.BackgroundImage = global::Trabajo_Final.Properties.Resources.camarero;
            this.btnNuevaMozo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevaMozo.FlatAppearance.BorderSize = 0;
            this.btnNuevaMozo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaMozo.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaMozo.ForeColor = System.Drawing.Color.Gold;
            this.btnNuevaMozo.Location = new System.Drawing.Point(12, 504);
            this.btnNuevaMozo.Name = "btnNuevaMozo";
            this.btnNuevaMozo.Size = new System.Drawing.Size(100, 93);
            this.btnNuevaMozo.TabIndex = 2;
            this.btnNuevaMozo.UseVisualStyleBackColor = true;
            this.btnNuevaMozo.Click += new System.EventHandler(this.btnNuevaMozo_Click);
            // 
            // frmMozos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 1005);
            this.Controls.Add(this.btnEliminarMozo);
            this.Controls.Add(this.btnModificarMozo);
            this.Controls.Add(this.btnNuevaMozo);
            this.Controls.Add(this.grpMozos);
            this.Controls.Add(this.dgvMozos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMozos";
            this.Text = "Mesas";
            this.Activated += new System.EventHandler(this.frmMozos_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMozos)).EndInit();
            this.grpMozos.ResumeLayout(false);
            this.grpMozos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMozos;
        private System.Windows.Forms.GroupBox grpMozos;
        private System.Windows.Forms.Label lblRanking;
        private System.Windows.Forms.ProgressBar prgBaRanking;
        private System.Windows.Forms.Label lblPuntuación;
        private System.Windows.Forms.Button btnNuevaMozo;
        private System.Windows.Forms.Button btnModificarMozo;
        private System.Windows.Forms.Button btnEliminarMozo;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
    }
}