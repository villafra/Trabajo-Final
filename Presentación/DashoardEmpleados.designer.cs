namespace Trabajo_Final
{
    partial class frmDashEmpleados
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.grpDashBoard = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panelMotivo = new System.Windows.Forms.Panel();
            this.lblNombreMotivo = new System.Windows.Forms.Label();
            this.lblMasMotivo = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.panelMenos = new System.Windows.Forms.Panel();
            this.lblNombreInasistencia = new System.Windows.Forms.Label();
            this.lblMenosAsistencia = new System.Windows.Forms.Label();
            this.lblInasistencia = new System.Windows.Forms.Label();
            this.panelMas = new System.Windows.Forms.Panel();
            this.lblNombreAsistencia = new System.Windows.Forms.Label();
            this.lblAsistencia = new System.Windows.Forms.Label();
            this.lblMasAsistencia = new System.Windows.Forms.Label();
            this.btnAño = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn7dias = new System.Windows.Forms.Button();
            this.btnRango = new System.Windows.Forms.Button();
            this.chartAsist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartInasist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpDashBoard.SuspendLayout();
            this.panelMotivo.SuspendLayout();
            this.panelMenos.SuspendLayout();
            this.panelMas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAsist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInasist)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpInicio
            // 
            this.dtpInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInicio.Location = new System.Drawing.Point(223, 21);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(134, 22);
            this.dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            this.dtpFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(375, 21);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(134, 22);
            this.dtpFin.TabIndex = 1;
            // 
            // grpDashBoard
            // 
            this.grpDashBoard.Controls.Add(this.btnRefresh);
            this.grpDashBoard.Controls.Add(this.panelMotivo);
            this.grpDashBoard.Controls.Add(this.panelMenos);
            this.grpDashBoard.Controls.Add(this.panelMas);
            this.grpDashBoard.Controls.Add(this.btnAño);
            this.grpDashBoard.Controls.Add(this.btnMes);
            this.grpDashBoard.Controls.Add(this.btn15);
            this.grpDashBoard.Controls.Add(this.btn7dias);
            this.grpDashBoard.Controls.Add(this.btnRango);
            this.grpDashBoard.Controls.Add(this.dtpInicio);
            this.grpDashBoard.Controls.Add(this.dtpFin);
            this.grpDashBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDashBoard.Location = new System.Drawing.Point(0, 0);
            this.grpDashBoard.Name = "grpDashBoard";
            this.grpDashBoard.Size = new System.Drawing.Size(1342, 294);
            this.grpDashBoard.TabIndex = 2;
            this.grpDashBoard.TabStop = false;
            this.grpDashBoard.Text = "Dashboard";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Trabajo_Final.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(12, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(77, 70);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelMotivo
            // 
            this.panelMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMotivo.Controls.Add(this.lblNombreMotivo);
            this.panelMotivo.Controls.Add(this.lblMasMotivo);
            this.panelMotivo.Controls.Add(this.lblMotivo);
            this.panelMotivo.Location = new System.Drawing.Point(945, 125);
            this.panelMotivo.Name = "panelMotivo";
            this.panelMotivo.Size = new System.Drawing.Size(391, 161);
            this.panelMotivo.TabIndex = 8;
            // 
            // lblNombreMotivo
            // 
            this.lblNombreMotivo.AutoSize = true;
            this.lblNombreMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreMotivo.Location = new System.Drawing.Point(146, 46);
            this.lblNombreMotivo.Name = "lblNombreMotivo";
            this.lblNombreMotivo.Size = new System.Drawing.Size(99, 32);
            this.lblNombreMotivo.TabIndex = 8;
            this.lblNombreMotivo.Text = "Motivo";
            // 
            // lblMasMotivo
            // 
            this.lblMasMotivo.AutoSize = true;
            this.lblMasMotivo.Location = new System.Drawing.Point(11, 10);
            this.lblMasMotivo.Name = "lblMasMotivo";
            this.lblMasMotivo.Size = new System.Drawing.Size(245, 17);
            this.lblMasMotivo.TabIndex = 6;
            this.lblMasMotivo.Text = "Motivo Más Frecuente de Inasistencia";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.Location = new System.Drawing.Point(146, 108);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(95, 32);
            this.lblMotivo.TabIndex = 7;
            this.lblMotivo.Text = "10000";
            // 
            // panelMenos
            // 
            this.panelMenos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenos.Controls.Add(this.lblNombreInasistencia);
            this.panelMenos.Controls.Add(this.lblMenosAsistencia);
            this.panelMenos.Controls.Add(this.lblInasistencia);
            this.panelMenos.Location = new System.Drawing.Point(476, 125);
            this.panelMenos.Name = "panelMenos";
            this.panelMenos.Size = new System.Drawing.Size(391, 161);
            this.panelMenos.TabIndex = 8;
            // 
            // lblNombreInasistencia
            // 
            this.lblNombreInasistencia.AutoSize = true;
            this.lblNombreInasistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreInasistencia.Location = new System.Drawing.Point(138, 46);
            this.lblNombreInasistencia.Name = "lblNombreInasistencia";
            this.lblNombreInasistencia.Size = new System.Drawing.Size(115, 32);
            this.lblNombreInasistencia.TabIndex = 5;
            this.lblNombreInasistencia.Text = "Nombre";
            // 
            // lblMenosAsistencia
            // 
            this.lblMenosAsistencia.AutoSize = true;
            this.lblMenosAsistencia.Location = new System.Drawing.Point(9, 10);
            this.lblMenosAsistencia.Name = "lblMenosAsistencia";
            this.lblMenosAsistencia.Size = new System.Drawing.Size(219, 17);
            this.lblMenosAsistencia.TabIndex = 3;
            this.lblMenosAsistencia.Text = "Empleado con Mayor Inasistencia";
            // 
            // lblInasistencia
            // 
            this.lblInasistencia.AutoSize = true;
            this.lblInasistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInasistencia.Location = new System.Drawing.Point(138, 108);
            this.lblInasistencia.Name = "lblInasistencia";
            this.lblInasistencia.Size = new System.Drawing.Size(95, 32);
            this.lblInasistencia.TabIndex = 4;
            this.lblInasistencia.Text = "10000";
            // 
            // panelMas
            // 
            this.panelMas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMas.Controls.Add(this.lblNombreAsistencia);
            this.panelMas.Controls.Add(this.lblAsistencia);
            this.panelMas.Controls.Add(this.lblMasAsistencia);
            this.panelMas.Location = new System.Drawing.Point(12, 125);
            this.panelMas.Name = "panelMas";
            this.panelMas.Size = new System.Drawing.Size(391, 161);
            this.panelMas.TabIndex = 7;
            // 
            // lblNombreAsistencia
            // 
            this.lblNombreAsistencia.AutoSize = true;
            this.lblNombreAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreAsistencia.Location = new System.Drawing.Point(148, 46);
            this.lblNombreAsistencia.Name = "lblNombreAsistencia";
            this.lblNombreAsistencia.Size = new System.Drawing.Size(115, 32);
            this.lblNombreAsistencia.TabIndex = 2;
            this.lblNombreAsistencia.Text = "Nombre";
            // 
            // lblAsistencia
            // 
            this.lblAsistencia.AutoSize = true;
            this.lblAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsistencia.Location = new System.Drawing.Point(148, 108);
            this.lblAsistencia.Name = "lblAsistencia";
            this.lblAsistencia.Size = new System.Drawing.Size(95, 32);
            this.lblAsistencia.TabIndex = 1;
            this.lblAsistencia.Text = "10000";
            // 
            // lblMasAsistencia
            // 
            this.lblMasAsistencia.AutoSize = true;
            this.lblMasAsistencia.Location = new System.Drawing.Point(3, 10);
            this.lblMasAsistencia.Name = "lblMasAsistencia";
            this.lblMasAsistencia.Size = new System.Drawing.Size(219, 17);
            this.lblMasAsistencia.TabIndex = 0;
            this.lblMasAsistencia.Text = "Empleado con Mejor Presentismo";
            // 
            // btnAño
            // 
            this.btnAño.BackgroundImage = global::Trabajo_Final.Properties.Resources._365;
            this.btnAño.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAño.FlatAppearance.BorderSize = 0;
            this.btnAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAño.Location = new System.Drawing.Point(1120, 21);
            this.btnAño.Name = "btnAño";
            this.btnAño.Size = new System.Drawing.Size(89, 70);
            this.btnAño.TabIndex = 6;
            this.btnAño.UseVisualStyleBackColor = true;
            this.btnAño.Click += new System.EventHandler(this.btnAño_Click);
            // 
            // btnMes
            // 
            this.btnMes.BackgroundImage = global::Trabajo_Final.Properties.Resources.numero_30;
            this.btnMes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMes.FlatAppearance.BorderSize = 0;
            this.btnMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMes.Location = new System.Drawing.Point(984, 21);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(85, 70);
            this.btnMes.TabIndex = 5;
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btn15
            // 
            this.btn15.BackgroundImage = global::Trabajo_Final.Properties.Resources.numero_15;
            this.btn15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn15.FlatAppearance.BorderSize = 0;
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn15.Location = new System.Drawing.Point(844, 21);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(89, 70);
            this.btn15.TabIndex = 4;
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn15_Click);
            // 
            // btn7dias
            // 
            this.btn7dias.BackgroundImage = global::Trabajo_Final.Properties.Resources.numero_7__1_;
            this.btn7dias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn7dias.FlatAppearance.BorderSize = 0;
            this.btn7dias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7dias.Location = new System.Drawing.Point(720, 21);
            this.btn7dias.Name = "btn7dias";
            this.btn7dias.Size = new System.Drawing.Size(73, 70);
            this.btn7dias.TabIndex = 3;
            this.btn7dias.UseVisualStyleBackColor = true;
            this.btn7dias.Click += new System.EventHandler(this.btn7dias_Click);
            // 
            // btnRango
            // 
            this.btnRango.BackgroundImage = global::Trabajo_Final.Properties.Resources.calendario;
            this.btnRango.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRango.FlatAppearance.BorderSize = 0;
            this.btnRango.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRango.Location = new System.Drawing.Point(582, 21);
            this.btnRango.Name = "btnRango";
            this.btnRango.Size = new System.Drawing.Size(87, 70);
            this.btnRango.TabIndex = 2;
            this.btnRango.UseVisualStyleBackColor = true;
            this.btnRango.Click += new System.EventHandler(this.btnRango_Click);
            // 
            // chartAsist
            // 
            chartArea1.Name = "ChartArea1";
            this.chartAsist.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartAsist.Legends.Add(legend1);
            this.chartAsist.Location = new System.Drawing.Point(12, 300);
            this.chartAsist.Name = "chartAsist";
            this.chartAsist.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartAsist.Size = new System.Drawing.Size(830, 639);
            this.chartAsist.TabIndex = 3;
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "Asistencias";
            this.chartAsist.Titles.Add(title1);
            // 
            // chartInasist
            // 
            chartArea2.Name = "ChartArea1";
            this.chartInasist.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chartInasist.Legends.Add(legend2);
            this.chartInasist.Location = new System.Drawing.Point(848, 300);
            this.chartInasist.Name = "chartInasist";
            this.chartInasist.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartInasist.Size = new System.Drawing.Size(482, 639);
            this.chartInasist.TabIndex = 4;
            this.chartInasist.Text = "Asistencias";
            title2.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            title2.Text = "Motivo Inasistencias";
            this.chartInasist.Titles.Add(title2);
            // 
            // frmDashEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1342, 965);
            this.Controls.Add(this.chartInasist);
            this.Controls.Add(this.chartAsist);
            this.Controls.Add(this.grpDashBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashEmpleados";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bienvenida";
            this.Load += new System.EventHandler(this.frmDashEmpleados_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmBienvenida_MouseDown);
            this.grpDashBoard.ResumeLayout(false);
            this.panelMotivo.ResumeLayout(false);
            this.panelMotivo.PerformLayout();
            this.panelMenos.ResumeLayout(false);
            this.panelMenos.PerformLayout();
            this.panelMas.ResumeLayout(false);
            this.panelMas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAsist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInasist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.GroupBox grpDashBoard;
        private System.Windows.Forms.Panel panelMotivo;
        private System.Windows.Forms.Panel panelMenos;
        private System.Windows.Forms.Panel panelMas;
        private System.Windows.Forms.Button btnAño;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn7dias;
        private System.Windows.Forms.Button btnRango;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAsist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInasist;
        private System.Windows.Forms.Label lblAsistencia;
        private System.Windows.Forms.Label lblMasAsistencia;
        private System.Windows.Forms.Label lblNombreAsistencia;
        private System.Windows.Forms.Label lblNombreInasistencia;
        private System.Windows.Forms.Label lblMenosAsistencia;
        private System.Windows.Forms.Label lblInasistencia;
        private System.Windows.Forms.Label lblNombreMotivo;
        private System.Windows.Forms.Label lblMasMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.Button btnRefresh;
    }
}