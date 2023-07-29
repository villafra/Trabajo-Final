namespace Trabajo_Final
{
    partial class frmDashVentas
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
            this.lblPromedioXMesa = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.panelMasBebida = new System.Windows.Forms.Panel();
            this.lblNombreBebida = new System.Windows.Forms.Label();
            this.lblBebidaMasConsumida = new System.Windows.Forms.Label();
            this.lblMasBebida = new System.Windows.Forms.Label();
            this.panelMasPlato = new System.Windows.Forms.Panel();
            this.lblNombrePlato = new System.Windows.Forms.Label();
            this.lblMasPlato = new System.Windows.Forms.Label();
            this.lblPlatoMasConsumido = new System.Windows.Forms.Label();
            this.btnAño = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn7dias = new System.Windows.Forms.Button();
            this.btnRango = new System.Windows.Forms.Button();
            this.chartPlatos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBebidas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpDashBoard.SuspendLayout();
            this.panelMotivo.SuspendLayout();
            this.panelMasBebida.SuspendLayout();
            this.panelMasPlato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBebidas)).BeginInit();
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
            this.grpDashBoard.Controls.Add(this.panelMasBebida);
            this.grpDashBoard.Controls.Add(this.panelMasPlato);
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
            this.panelMotivo.Controls.Add(this.lblPromedioXMesa);
            this.panelMotivo.Controls.Add(this.lblPromedio);
            this.panelMotivo.Location = new System.Drawing.Point(945, 125);
            this.panelMotivo.Name = "panelMotivo";
            this.panelMotivo.Size = new System.Drawing.Size(391, 161);
            this.panelMotivo.TabIndex = 8;
            // 
            // lblPromedioXMesa
            // 
            this.lblPromedioXMesa.AutoSize = true;
            this.lblPromedioXMesa.Location = new System.Drawing.Point(11, 10);
            this.lblPromedioXMesa.Name = "lblPromedioXMesa";
            this.lblPromedioXMesa.Size = new System.Drawing.Size(142, 17);
            this.lblPromedioXMesa.TabIndex = 6;
            this.lblPromedioXMesa.Text = "Promedio Por Pedido";
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPromedio.Location = new System.Drawing.Point(146, 108);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(95, 32);
            this.lblPromedio.TabIndex = 7;
            this.lblPromedio.Text = "10000";
            // 
            // panelMasBebida
            // 
            this.panelMasBebida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMasBebida.Controls.Add(this.lblNombreBebida);
            this.panelMasBebida.Controls.Add(this.lblBebidaMasConsumida);
            this.panelMasBebida.Controls.Add(this.lblMasBebida);
            this.panelMasBebida.Location = new System.Drawing.Point(476, 125);
            this.panelMasBebida.Name = "panelMasBebida";
            this.panelMasBebida.Size = new System.Drawing.Size(391, 161);
            this.panelMasBebida.TabIndex = 8;
            // 
            // lblNombreBebida
            // 
            this.lblNombreBebida.AutoSize = true;
            this.lblNombreBebida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreBebida.Location = new System.Drawing.Point(138, 46);
            this.lblNombreBebida.Name = "lblNombreBebida";
            this.lblNombreBebida.Size = new System.Drawing.Size(115, 32);
            this.lblNombreBebida.TabIndex = 5;
            this.lblNombreBebida.Text = "Nombre";
            // 
            // lblBebidaMasConsumida
            // 
            this.lblBebidaMasConsumida.AutoSize = true;
            this.lblBebidaMasConsumida.Location = new System.Drawing.Point(9, 10);
            this.lblBebidaMasConsumida.Name = "lblBebidaMasConsumida";
            this.lblBebidaMasConsumida.Size = new System.Drawing.Size(156, 17);
            this.lblBebidaMasConsumida.TabIndex = 3;
            this.lblBebidaMasConsumida.Text = "Bebida más Consumida";
            // 
            // lblMasBebida
            // 
            this.lblMasBebida.AutoSize = true;
            this.lblMasBebida.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasBebida.Location = new System.Drawing.Point(138, 108);
            this.lblMasBebida.Name = "lblMasBebida";
            this.lblMasBebida.Size = new System.Drawing.Size(95, 32);
            this.lblMasBebida.TabIndex = 4;
            this.lblMasBebida.Text = "10000";
            // 
            // panelMasPlato
            // 
            this.panelMasPlato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMasPlato.Controls.Add(this.lblNombrePlato);
            this.panelMasPlato.Controls.Add(this.lblMasPlato);
            this.panelMasPlato.Controls.Add(this.lblPlatoMasConsumido);
            this.panelMasPlato.Location = new System.Drawing.Point(12, 125);
            this.panelMasPlato.Name = "panelMasPlato";
            this.panelMasPlato.Size = new System.Drawing.Size(391, 161);
            this.panelMasPlato.TabIndex = 7;
            // 
            // lblNombrePlato
            // 
            this.lblNombrePlato.AutoSize = true;
            this.lblNombrePlato.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePlato.Location = new System.Drawing.Point(148, 46);
            this.lblNombrePlato.Name = "lblNombrePlato";
            this.lblNombrePlato.Size = new System.Drawing.Size(115, 32);
            this.lblNombrePlato.TabIndex = 2;
            this.lblNombrePlato.Text = "Nombre";
            // 
            // lblMasPlato
            // 
            this.lblMasPlato.AutoSize = true;
            this.lblMasPlato.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasPlato.Location = new System.Drawing.Point(148, 108);
            this.lblMasPlato.Name = "lblMasPlato";
            this.lblMasPlato.Size = new System.Drawing.Size(95, 32);
            this.lblMasPlato.TabIndex = 1;
            this.lblMasPlato.Text = "10000";
            // 
            // lblPlatoMasConsumido
            // 
            this.lblPlatoMasConsumido.AutoSize = true;
            this.lblPlatoMasConsumido.Location = new System.Drawing.Point(3, 10);
            this.lblPlatoMasConsumido.Name = "lblPlatoMasConsumido";
            this.lblPlatoMasConsumido.Size = new System.Drawing.Size(148, 17);
            this.lblPlatoMasConsumido.TabIndex = 0;
            this.lblPlatoMasConsumido.Text = "Plato más Consumido.";
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
            // chartPlatos
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPlatos.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartPlatos.Legends.Add(legend1);
            this.chartPlatos.Location = new System.Drawing.Point(12, 300);
            this.chartPlatos.Name = "chartPlatos";
            this.chartPlatos.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartPlatos.Size = new System.Drawing.Size(830, 639);
            this.chartPlatos.TabIndex = 3;
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "Platos";
            this.chartPlatos.Titles.Add(title1);
            // 
            // chartBebidas
            // 
            chartArea2.Name = "ChartArea1";
            this.chartBebidas.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chartBebidas.Legends.Add(legend2);
            this.chartBebidas.Location = new System.Drawing.Point(848, 300);
            this.chartBebidas.Name = "chartBebidas";
            this.chartBebidas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            this.chartBebidas.Size = new System.Drawing.Size(482, 639);
            this.chartBebidas.TabIndex = 4;
            this.chartBebidas.Text = "Asistencias";
            title2.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.White;
            title2.Name = "Title1";
            title2.Text = "Bebidas";
            this.chartBebidas.Titles.Add(title2);
            // 
            // frmDashVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1342, 965);
            this.Controls.Add(this.chartBebidas);
            this.Controls.Add(this.chartPlatos);
            this.Controls.Add(this.grpDashBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashVentas";
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
            this.panelMasBebida.ResumeLayout(false);
            this.panelMasBebida.PerformLayout();
            this.panelMasPlato.ResumeLayout(false);
            this.panelMasPlato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPlatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBebidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.GroupBox grpDashBoard;
        private System.Windows.Forms.Panel panelMotivo;
        private System.Windows.Forms.Panel panelMasBebida;
        private System.Windows.Forms.Panel panelMasPlato;
        private System.Windows.Forms.Button btnAño;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn7dias;
        private System.Windows.Forms.Button btnRango;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlatos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBebidas;
        private System.Windows.Forms.Label lblMasPlato;
        private System.Windows.Forms.Label lblPlatoMasConsumido;
        private System.Windows.Forms.Label lblNombrePlato;
        private System.Windows.Forms.Label lblNombreBebida;
        private System.Windows.Forms.Label lblBebidaMasConsumida;
        private System.Windows.Forms.Label lblMasBebida;
        private System.Windows.Forms.Label lblPromedioXMesa;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Button btnRefresh;
    }
}