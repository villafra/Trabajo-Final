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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.grpDashBoard = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAño = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn7dias = new System.Windows.Forms.Button();
            this.btnRango = new System.Windows.Forms.Button();
            this.chartAsist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartInasist = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpDashBoard.SuspendLayout();
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
            this.grpDashBoard.Controls.Add(this.panel3);
            this.grpDashBoard.Controls.Add(this.panel2);
            this.grpDashBoard.Controls.Add(this.panel1);
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
            this.grpDashBoard.Size = new System.Drawing.Size(1342, 312);
            this.grpDashBoard.TabIndex = 2;
            this.grpDashBoard.TabStop = false;
            this.grpDashBoard.Text = "Dashboard";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(945, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 161);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(476, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 161);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 161);
            this.panel1.TabIndex = 7;
            // 
            // btnAño
            // 
            this.btnAño.Location = new System.Drawing.Point(1207, 21);
            this.btnAño.Name = "btnAño";
            this.btnAño.Size = new System.Drawing.Size(122, 70);
            this.btnAño.TabIndex = 6;
            this.btnAño.Text = "Ultimo Año";
            this.btnAño.UseVisualStyleBackColor = true;
            this.btnAño.Click += new System.EventHandler(this.btnAño_Click);
            // 
            // btnMes
            // 
            this.btnMes.Location = new System.Drawing.Point(1053, 21);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(122, 70);
            this.btnMes.TabIndex = 5;
            this.btnMes.Text = "Ultimo Mes";
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btn15
            // 
            this.btn15.Location = new System.Drawing.Point(899, 21);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(122, 70);
            this.btn15.TabIndex = 4;
            this.btn15.Text = "Ultimos 15 días";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn15_Click);
            // 
            // btn7dias
            // 
            this.btn7dias.Location = new System.Drawing.Point(745, 21);
            this.btn7dias.Name = "btn7dias";
            this.btn7dias.Size = new System.Drawing.Size(122, 70);
            this.btn7dias.TabIndex = 3;
            this.btn7dias.Text = "Ultimos 7 días";
            this.btn7dias.UseVisualStyleBackColor = true;
            this.btn7dias.Click += new System.EventHandler(this.btn7dias_Click);
            // 
            // btnRango
            // 
            this.btnRango.Location = new System.Drawing.Point(582, 21);
            this.btnRango.Name = "btnRango";
            this.btnRango.Size = new System.Drawing.Size(122, 70);
            this.btnRango.TabIndex = 2;
            this.btnRango.Text = "Rango de Fechas";
            this.btnRango.UseVisualStyleBackColor = true;
            this.btnRango.Click += new System.EventHandler(this.btnRango_Click);
            // 
            // chartAsist
            // 
            chartArea3.Name = "ChartArea1";
            this.chartAsist.ChartAreas.Add(chartArea3);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.chartAsist.Legends.Add(legend3);
            this.chartAsist.Location = new System.Drawing.Point(12, 318);
            this.chartAsist.Name = "chartAsist";
            this.chartAsist.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartAsist.Size = new System.Drawing.Size(863, 425);
            this.chartAsist.TabIndex = 3;
            title3.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.ForeColor = System.Drawing.Color.White;
            title3.Name = "Title1";
            title3.Text = "Asistencias";
            this.chartAsist.Titles.Add(title3);
            // 
            // chartInasist
            // 
            chartArea4.Name = "ChartArea1";
            this.chartInasist.ChartAreas.Add(chartArea4);
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend4.Name = "Legend1";
            this.chartInasist.Legends.Add(legend4);
            this.chartInasist.Location = new System.Drawing.Point(953, 318);
            this.chartInasist.Name = "chartInasist";
            this.chartInasist.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartInasist.Size = new System.Drawing.Size(376, 553);
            this.chartInasist.TabIndex = 4;
            this.chartInasist.Text = "Asistencias";
            title4.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.Color.White;
            title4.Name = "Title1";
            title4.Text = "Motivo Inasistencias";
            this.chartInasist.Titles.Add(title4);
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
            ((System.ComponentModel.ISupportInitialize)(this.chartAsist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInasist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.GroupBox grpDashBoard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAño;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn7dias;
        private System.Windows.Forms.Button btnRango;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAsist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInasist;
    }
}