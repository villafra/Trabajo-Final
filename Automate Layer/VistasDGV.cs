using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automate_Layer
{
    public static class VistasDGV
    {
        public static void DGVLogs(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Nombre del Archivo";
            dgv.Columns[2].HeaderText = "Usuario";
            dgv.Columns[3].HeaderText = "Tipo de Acción";
            dgv.Columns[4].HeaderText = "Fecha y Hora";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public static void DGVBitacora (DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Usuario";
            dgv.Columns[2].HeaderText = "Tipo de Acción";
            dgv.Columns[3].HeaderText = "Fecha y Hora";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        public static void DGVEmpleados(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo Empleado";
            dgv.Columns[1].HeaderText = "DNI";
            dgv.Columns[2].HeaderText = "Nombres";
            dgv.Columns[3].HeaderText = "Apellido";
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].HeaderText = "Edad";
            dgv.Columns[6].HeaderText = "Fecha de Ingreso";
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].HeaderText = "Categoria";
            dgv.Columns[9].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
