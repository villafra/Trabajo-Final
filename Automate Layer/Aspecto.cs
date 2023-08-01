using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Automate_Layer
{
    public static class Aspecto
    {
        #region Formatear Formulario


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(IntPtr puntero, int dibujo, int width, int left);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
           int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

      );
        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(IntPtr hObject);

        public static Action<Form, Panel, int, int> FormatearForm = (formulario, panel, Width, Height) =>
        {
            formulario.FormBorderStyle = new FormBorderStyle();
            formulario.BackColor = Color.FromArgb(46, 51, 73);
            formulario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            formulario.AutoScroll = true;
            formulario.IsMdiContainer = true;
            panel.BackColor = Color.FromArgb(24, 30, 54);
            panel.Dock = DockStyle.Left;
            foreach (Control c in formulario.Controls)
            {
                if (c.Name == "txtUsuarioActivo")
                {
                    c.BackColor = Color.FromArgb(24, 30, 54);
                    c.Font = new Font("Nirmala UI", 8, FontStyle.Bold);
                    c.ForeColor = Color.FromArgb(0, 126, 249);
                    (c as TextBox).BorderStyle = BorderStyle.None;

                }
                if (c is Button) FormatearBoton(c as Button);
            }
            FormatearPanel(panel);
            FormatearMenuStrip(formulario);
        };


        public static Action<Form, GroupBox, int, int> FormatearLogin = (formulario, grp, Width, Height) =>
        {
            formulario.FormBorderStyle = new FormBorderStyle();
            formulario.BackColor = Color.FromArgb(46, 51, 73);
            formulario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            formulario.AutoScroll = true;
            FormatearGRP(grp);
        };

        public static Action<Form, GroupBox, int, int> FormatearSubMenu = (formulario, grp, Width, Height) =>
        {
            formulario.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            formulario.AutoScroll = true;
            formulario.Text = "Restó";
            FormatearGRPSubMenu(grp);

        };
        public static Action<Form, int, int> FormatearCambioPass = (formulario, Width, Height) =>
        {
            formulario.FormBorderStyle = new FormBorderStyle();
            formulario.BackColor = Color.FromArgb(46, 51, 73);
            formulario.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
            formulario.AutoScroll = true;

        };

        public static Action<Form> FormatearFormHijo = (formulario) =>
        {
            formulario.BackColor = Color.FromArgb(46, 51, 73);
            formulario.AutoScroll = true;
        };

        public static Action<Form, Form> AbrirNuevoForm = (formPadre, FormHijo) =>
        {
            FormHijo.MdiParent = formPadre;
            FormHijo.TopLevel = false;
            FormHijo.Dock = DockStyle.Fill;
            FormHijo.Show();
            FormatearFormHijo(FormHijo);
            FormHijo.Show();
        };
        public static Action<Panel> FormatearPanel = (panel) =>
        {

            foreach (Control control in panel.Controls)
            {
                if (control is Button) FormatearBoton(control as Button);
            }
        };
        public static Action<Panel> FormatearPanelFlotante = (panel) =>
        {
            panel.BackColor = Color.FromArgb(24, 30, 54);
            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 30, 30));
            foreach (Control control in panel.Controls)
            {
                if (control is Button) FormatearBoton(control as Button);
            }
        };
        public static Action<Button> FormatearBoton = (boton) =>
        {
            boton.BackColor = Color.FromArgb(24, 30, 54);
            boton.ForeColor = Color.FromArgb(0, 126, 249);
            boton.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            boton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, boton.Width, boton.Height, 30, 30));
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatStyle = FlatStyle.Flat;
            boton.TextAlign = ContentAlignment.MiddleRight;
            boton.ImageAlign = ContentAlignment.MiddleLeft;
        };

        public static Action<Button> FormatearBotonInterno = (boton) =>
        {
            boton.BackColor = Color.FromArgb(46, 51, 73);
            boton.ForeColor = Color.FromArgb(0, 126, 249);
            boton.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            boton.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, boton.Width, boton.Height, 30, 30));
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatStyle = FlatStyle.Flat;
            boton.TextAlign = ContentAlignment.MiddleRight;
            boton.ImageAlign = ContentAlignment.MiddleLeft;
        };



        #endregion

        public static Action<Form> FormatearMenuStrip = (form) =>
        {
            foreach (Control control in form.Controls)
            {
                if (control is MenuStrip)
                {
                    control.BackColor = Color.FromArgb(24, 30, 54);
                    control.ForeColor = Color.FromArgb(0, 126, 249);
                    control.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
                }

            }

        };
        public static Action<TabControl> FormatearTab = (tab) =>
        {
            tab.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            foreach (TabPage page in tab.TabPages)
            {
                FormatearControlExterno(page);
            }
        };
        public static Action<GroupBox> FormatearGRP = (grp) =>
        {
            FormatearControlExterno(grp);

            foreach (Control c in grp.Controls)
            {
                if (c is TextBox) FormatearControlInterno(c as TextBox);
                else if (c is NumericUpDown) FormatearControlInterno(c as NumericUpDown);
                else if (c is ComboBox) FormatearControlInterno(c as ComboBox);
                else if (c is RadioButton) FormatearControlInterno(c as RadioButton);
                else if (c is CheckBox) FormatearControlInterno(c as CheckBox);
                else if (c is ProgressBar) FormatearControlInterno(c as ProgressBar);
            }
        };
        public static Action<GroupBox> FormatearGRPSubMenu = (grp) =>
        {
            grp.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            grp.ForeColor = Color.Black;

            foreach (Control c in grp.Controls)
            {
                c.ForeColor = Color.Black;
                if (c is DateTimePicker && c.Name != "dtpHoraIngreso" && c.Name != "dtpHoraEgreso") (c as DateTimePicker).Value = DateTime.Now;
                if (c is TextBox) (c as TextBox).TextAlign = HorizontalAlignment.Center;
            }
        };
        public static Action<GroupBox> FormatearGRPPedido = (grp) =>
        {
            grp.Font = new Font("Nirmala UI", 16, FontStyle.Regular);
            grp.ForeColor = Color.Black;

            foreach (Control c in grp.Controls)
            {
                c.ForeColor = Color.Black;
            }
        };
        public static Action<GroupBox> FormatearGRPAccion = (grp) =>
        {
            FormatearControlExterno(grp);
            foreach (Control btn in grp.Controls)
            {
                if (btn is Button)
                    FormatearBoton(btn as Button);
            }
        };
        public static Action<GroupBox> FormatearGRPREcetas = (grp) =>
        {
            FormatearControlExterno(grp);
        };
        public static Action<GroupBox> FormatearGRPPermisos = (grp) =>
        {
            FormatearControlExterno(grp);

            foreach (Control c in grp.Controls)
            {
                if (c is TextBox) FormatearControlInterno(c as TextBox);
                else if (c is NumericUpDown) FormatearControlInterno(c as NumericUpDown);
                else if (c is ComboBox) FormatearControlInterno(c as ComboBox);
                else if (c is RadioButton) FormatearControlInterno(c as RadioButton);
                else if (c is CheckBox) FormatearControlInterno(c as CheckBox);
                else if (c is ProgressBar) FormatearControlInterno(c as ProgressBar);
                else if (c is Button) FormatearBoton(c as Button);
            }
        };
        public static Action<Control> FormatearControlExterno = (obj) =>
        {
            obj.BackColor = Color.FromArgb(46, 51, 73);
            obj.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            obj.ForeColor = Color.FromArgb(0, 126, 249);
        };
        public static Action<Control> FormatearControlInterno = (obj) =>
        {
            obj.BackColor = Color.FromArgb(46, 51, 73);
            obj.ForeColor = Color.White;
            if (obj is TextBox) (obj as TextBox).TextAlign = HorizontalAlignment.Center;
        };
        public static Action<TreeView> FormatearTreeView = (tv) =>
        {
            tv.BackColor = Color.FromArgb(46, 51, 73);
            tv.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            tv.ForeColor = Color.FromArgb(0, 126, 249);
            tv.Indent = 35;
            tv.ItemHeight = 20;
        };
        public static Action<TreeView> FormatearTreeViewPermXUsu = (tv) =>
        {
            tv.BackColor = SystemColors.Window;
            tv.ForeColor = SystemColors.WindowText;
            tv.LineColor = SystemColors.ControlDark;
            tv.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            tv.Indent = 20;
            tv.ItemHeight = 20;
        };
        public static Action<DataGridView> FormatearDGV = (dgv) =>
        {
            dgv.BackgroundColor = Color.FromArgb(46, 51, 73); //(44, 68, 101);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.AutoGenerateColumns = true;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(56, 62, 131);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 126, 249);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(150, 86, 192);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(120, 86, 192);
            dgv.DefaultCellStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(51, 137, 166);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(44, 68, 101);
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.AutoSize = true;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.MaximumSize = new Size(1120, 495);

        };
        public static Action<DataGridView> FormatearDGVRecetas = (dgv) =>
        {
            dgv.BackgroundColor = SystemColors.Control;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.AutoGenerateColumns = true;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.ControlText;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dgv.DefaultCellStyle.Font = new Font("Nirmala UI", 10, FontStyle.Regular);
            dgv.DefaultCellStyle.BackColor = SystemColors.Window;
            dgv.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgv.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgv.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(44, 68, 101);
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.AutoSize = true;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.MaximumSize = new Size(1120, 495);


        };
        public static Action<FlowLayoutPanel> FormatearFLowPanel = (fp) =>
        {
            //fp.Dock = DockStyle.Fill;
            fp.AutoScroll = true;
            fp.BackColor = Color.Transparent;
            fp.BorderStyle = BorderStyle.None;
            fp.Anchor = AnchorStyles.None;
            fp.AutoSize = true;
        };
        public static Action<Chart> FormatearChartAsist = (chart) =>
        {
            chart.BackColor = Color.FromArgb(46, 51, 73);
            chart.ChartAreas[0].BackColor = Color.Transparent;
            chart.ChartAreas[0].BackSecondaryColor = Color.Transparent;
            chart.ChartAreas[0].BackGradientStyle = GradientStyle.None;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LineColor = Color.White;
            chart.ChartAreas[0].AxisY.LineColor = Color.White;
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].ForeColor = Color.White;
            chart.Series[0].LabelBackColor = Color.Transparent;
            chart.Series[0].LabelForeColor = Color.White;
            chart.Series[0].IsValueShownAsLabel = true;
            Series serie = chart.Series[0];
            double maxValor = double.MinValue;
            double minValor = 0;
            foreach (DataPoint point in serie.Points)
            {
                if (point.YValues[0] > maxValor)
                {
                    maxValor = point.YValues[0];
                }
            }
            double margen = chart.Titles[0].Text == "Asistencias" ? 10 : 5;
            chart.ChartAreas[0].AxisY.Maximum = maxValor + margen;
            chart.ChartAreas[0].AxisY.Minimum = minValor;
            chart.ChartAreas[0].AxisY.Interval = margen;
            chart.Series[0].Font = new Font("Nirmala UI", 8, FontStyle.Bold);
        };
        public static Action<Chart> FormatearChartVentas = (chart) =>
        {
            chart.BackColor = Color.FromArgb(46, 51, 73);
            chart.ChartAreas[0].BackColor = Color.Transparent;
            chart.ChartAreas[0].BackSecondaryColor = Color.Transparent;
            chart.ChartAreas[0].BackGradientStyle = GradientStyle.None;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LineColor = Color.White;
            chart.ChartAreas[0].AxisY.LineColor = Color.White;
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].ForeColor = Color.White;
            chart.Series[0].LabelBackColor = Color.Transparent;
            chart.Series[0].LabelForeColor = Color.White;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].Font = new Font("Nirmala UI", 8, FontStyle.Bold);
            chart.Series[0].ChartType = SeriesChartType.Doughnut;
        };
        public static Action<Chart> FormatearChartCompras = (chart) =>
        {
            chart.BackColor = Color.FromArgb(46, 51, 73);
            chart.ChartAreas[0].BackColor = Color.Transparent;
            chart.ChartAreas[0].BackSecondaryColor = Color.Transparent;
            chart.ChartAreas[0].BackGradientStyle = GradientStyle.None;
            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas[0].AxisX.LineColor = Color.White;
            chart.ChartAreas[0].AxisY.LineColor = Color.White;
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Nirmala UI", 10, FontStyle.Bold);
            chart.Legends[0].BackColor = Color.Transparent;
            chart.Legends[0].ForeColor = Color.White;
            chart.Series[0].LabelBackColor = Color.Transparent;
            chart.Series[0].LabelForeColor = Color.White;
            chart.Series[0].IsValueShownAsLabel = true;
            chart.Series[0].Font = new Font("Nirmala UI", 8, FontStyle.Bold);
            chart.Series[0].ChartType = SeriesChartType.Pie;
        };

        public static Action<Panel> FormatearPanelMenu = (panel) =>
        {
            panel.BackColor = Color.FromArgb(46, 51, 73);
            panel.Visible = true;

        };
        public static Action<Panel, Button> CambiarColoresBtn = (panel, boton) =>
        {
            panel.Height = boton.Height;
            panel.Top = boton.Top;
            panel.Left = boton.Left;
            boton.BackColor = Color.FromArgb(46, 51, 73);
        };
        public static Action<Button> DevolverColorBtn = (boton) =>
        {
            boton.BackColor = Color.FromArgb(24, 30, 54);
        };
        public static Action<Panel, Label> CentrarLabel = (panel, lbl) =>
        {
            int x = (panel.Width - lbl.Width) / 2;
            int y = lbl.Location.Y;
            lbl.Location = new Point(x, y);
        };
        public static Action<GroupBox, Label> CentrarLabelenGRP = (grp, lbl) =>
        {
            int x = (grp.Width - lbl.Width) / 2;
            int y = lbl.Location.Y;
            lbl.Location = new Point(x, y);
        };
        public static Action<Panel, Button> CentrarBoton = (panel, btn) =>
        {
            int x = btn.Location.X;
            //int y = (panel.Height - btn.Height) / 2;
            //btn.Location = new Point(x, y);
            int y = (panel.Height - btn.Height) / 2;
            btn.Padding = new Padding(x, y, 0, 0);
        };
        public static Action<Form, DataGridView> CentrarDGV = (frm, dgv) =>
        {
            int anchoTotal = 0;
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                if (columna.Visible)
                {
                    anchoTotal += columna.Width;
                }
            }
            dgv.Width = anchoTotal;
            int x = (frm.Width - dgv.Width ) / 2;
            int y = dgv.Location.Y;
            dgv.Location = new Point(x, y);
        };

        public static void CentrarDGVSubMenu(GroupBox grp, DataGridView dgv)
        {
            int anchoTotal = 0;
            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                if (columna.Visible)
                {
                    anchoTotal += columna.Width;
                }
            }
            dgv.Width = anchoTotal;
            int x = (grp.Width - dgv.Width) / 2;
            int y = dgv.Location.Y;
            dgv.Location = new Point(x, y);
        }
        public static Action<GroupBox, FlowLayoutPanel, Button, Button> CentrarPanel = (grp, panel, btnizq, btnder) =>
        {
            if (panel.Width > grp.Width) { DesplazarPanel(grp, panel,btnizq, btnder);return; }
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.WrapContents = false;
            panel.Anchor = AnchorStyles.None;
            panel.AutoScroll = true;
            int x = (grp.Width - panel.Width) / 2;
            int y = panel.Location.Y;
            panel.Location = new Point(x, y);
            btnizq.Visible = false;
            btnder.Visible = false;
        };
        public static Action<GroupBox, FlowLayoutPanel,Button,Button> DesplazarPanel = (grp, panel, btnizq, btnder) =>
        {
            panel.FlowDirection = FlowDirection.LeftToRight;
            panel.AutoSize = false;
            panel.AutoScroll = true;
            panel.WrapContents = false;
            panel.Width = grp.Width - btnizq.Width - btnder.Width - btnder.Width;
            panel.Location = new Point(grp.Location.X+btnizq.Width, panel.Location.Y);
            panel.HorizontalScroll.Visible = false;
            panel.HorizontalScroll.Value = panel.VerticalScroll.Maximum;
            int horizontalScroll = SystemInformation.HorizontalScrollBarHeight;
            btnder.Visible = true;
            btnizq.Visible = true;
            panel.Padding = new Padding(0,horizontalScroll, 0, 0);
            CentrarBoton(panel, btnder);
            CentrarBoton(panel, btnizq);
        };
        public static Action<Panel,FlowLayoutPanel, Button> MostrarSubMenuDash = (panel, flowPanel, btn) =>
        {
            FormatearPanelFlotante(panel);
            panel.Visible = true;
            int x = flowPanel.Location.X + flowPanel.Width;
            int y = btn.PointToScreen(Point.Empty).Y;
            panel.Location = new Point(x, y);
        };
        public static Action<Panel, bool> OcultarSubMenuDash = (panel, click) =>
        {
            Point point = panel.PointToClient(System.Windows.Forms.Cursor.Position);
            Control btn = panel.GetChildAtPoint(point);
            if (btn != null && btn is Button)
            {
                if(btn.Name == "btnCompras" || btn.Name == "btnVentas" && !click)
                    return;
            }
            panel.Visible = false;
        };

    }
}
