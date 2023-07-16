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
            dgv.Columns[4].DisplayIndex = 0;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
           
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
            
        }

        public static void dgvOrdenBebida(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].HeaderText = "Pedido";
            dgv.Columns[3].HeaderText = "Mesa";
            dgv.Columns[4].HeaderText = "Mozo";
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvPedidosLib(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nro de Pedido";
            dgv.Columns[1].HeaderText = "Horario Pedido";
            dgv.Columns[1].DefaultCellStyle.Format = "HH:mm";
            dgv.Columns[2].HeaderText = "Customizado";
            dgv.Columns[3].HeaderText = "Aclaraciones";
            dgv.Columns[4].HeaderText = "Status";
            dgv.Columns[5].Visible = false; 
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvMesas(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nro de Mesa";
            dgv.Columns[1].HeaderText = "Capacidad";
            dgv.Columns[2].HeaderText = "Ubicación";
            dgv.Columns[3].HeaderText = "Ocupación Actual";
            dgv.Columns[4].HeaderText = "Status";
            dgv.Columns[5].HeaderText = "Empleado";
            dgv.Columns[6].HeaderText = "Activa";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvMesasLibres(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nro de Mesa";
            dgv.Columns[1].HeaderText = "Capacidad";
            dgv.Columns[2].HeaderText = "Ubicación";
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvPlatos(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Nombre";
            dgv.Columns[2].HeaderText = "Tipo";
            dgv.Columns[3].HeaderText = "Clase";
            dgv.Columns[4].HeaderText = "Presentación";
            dgv.Columns[4].DefaultCellStyle.Format = "0.00";
            dgv.Columns[5].HeaderText = "Costo Unitario";
            dgv.Columns[5].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[6].HeaderText = "Activo";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvPlatStock(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Material";
            dgv.Columns[2].HeaderText = "Stock";
            dgv.Columns[3].HeaderText = "Fecha de Creación";
            dgv.Columns[4].HeaderText = "Lote";
            dgv.Columns[4].DisplayIndex = 2;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvBebidas(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Nombre";
            dgv.Columns[2].HeaderText = "Tipo";
            dgv.Columns[3].HeaderText = "Presentación";
            dgv.Columns[4].HeaderText = "Costo Unitario";
            dgv.Columns[4].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[5].HeaderText = "UM";
            dgv.Columns[6].HeaderText = "Vida Util";
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].HeaderText = "Activo";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvBebStock(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Material";
            dgv.Columns[2].HeaderText = "Stock";
            dgv.Columns[3].HeaderText = "Fecha de Creación";
            dgv.Columns[4].HeaderText = "Lote";
            dgv.Columns[4].DisplayIndex = 2;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvIngredientes(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Nombre";
            dgv.Columns[2].HeaderText = "Tipo";
            dgv.Columns[3].HeaderText = "Requiere Refrigeración";
            dgv.Columns[4].HeaderText = "UM";
            dgv.Columns[5].HeaderText = "Activo";
            dgv.Columns[5].DisplayIndex = 9;
            dgv.Columns[6].HeaderText = "Vida Util";
            dgv.Columns[7].HeaderText = "Status";
            dgv.Columns[8].HeaderText = "Costo Unitario";
            dgv.Columns[8].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[9].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvIngStock(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Material";
            dgv.Columns[2].HeaderText = "Stock";
            dgv.Columns[3].HeaderText = "Fecha de Creación";
            dgv.Columns[4].HeaderText = "Lote";
            dgv.Columns[4].DisplayIndex = 2;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvBackUP(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nombre de Archivo";
            dgv.Columns[1].HeaderText = "Usuario";
            dgv.Columns[2].HeaderText = "Tipo de Acción";
            dgv.Columns[3].HeaderText = "Fecha y Hora";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvMetPagos(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Método de Pago";
            dgv.Columns[2].HeaderText = "Activo";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvHistOrdenes(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Status";
            dgv.Columns[2].HeaderText = "Pedido";
            dgv.Columns[3].HeaderText = "Mesa";
            dgv.Columns[4].HeaderText = "Mozo";
            dgv.Columns[5].HeaderText = "Orden Cerrada";
            dgv.Columns[6].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvCostos(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Día de Costeo";
            dgv.Columns[2].HeaderText = "Cantidad Base";
            dgv.Columns[3].HeaderText = "Materias Primas";
            dgv.Columns[3].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[4].HeaderText = "Horas/Hombre";
            dgv.Columns[4].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[5].HeaderText = "Energía";
            dgv.Columns[5].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[6].HeaderText = "Otros Gastos";
            dgv.Columns[6].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].HeaderText = "Tipo Material";
            dgv.Columns[8].DisplayIndex = 0;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
           
        }

        public static void dgvHistPedidos(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Codigo";
            dgv.Columns[1].HeaderText = "Fecha";
            dgv.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "Status";
            dgv.Columns[5].HeaderText = "Monto Total";
            dgv.Columns[5].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[6].HeaderText = "Método de Pago";
            dgv.Columns[7].HeaderText = "Mozo";
            dgv.Columns[8].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvReceta(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].HeaderText = "Ingrediente";
            dgv.Columns[3].HeaderText = "Cantidad";
            dgv.Columns[4].HeaderText = "Alternativa";
            dgv.Columns[4].DisplayIndex = 0;
            dgv.Columns[5].HeaderText = "Activo";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
           
        }

        public static void dgvCompras(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nro de Compra";
            dgv.Columns[1].HeaderText = "Tipo de Material";
            dgv.Columns[2].HeaderText = "Cantidad";
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].HeaderText = "Fecha de Ingreso";
            dgv.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns[6].HeaderText = "Cantidad Recibida";
            dgv.Columns[7].HeaderText = "Nro de Factura";
            dgv.Columns[8].HeaderText = "Costo";
            dgv.Columns[8].DefaultCellStyle.Format = "$0.00";
            dgv.Columns[9].HeaderText = "Status";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        public static void dgvInCompras(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nro de Compra";
            dgv.Columns[1].HeaderText = "Tipo de Material";
            dgv.Columns[2].HeaderText = "Cantidad";
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "Fecha de Entrega";
            dgv.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns[5].Visible = false;
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].HeaderText = "Status";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvOutCompras(DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Nro de Compra";
            dgv.Columns[1].HeaderText = "Tipo de Material";
            dgv.Columns[2].HeaderText = "Cantidad";
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].Visible = false;
            dgv.Columns[5].HeaderText = "Fecha de Entrega";
            dgv.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns[6].HeaderText = "Cantidad Recibida";
            dgv.Columns[7].HeaderText = "Nro de Factura";
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].HeaderText = "Status";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public static void dgvAsistencias(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].HeaderText = "Fecha";
            dgv.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns[3].HeaderText = "Asistencia";
            dgv.Columns[4].HeaderText = "Hora de Ingreso";
            dgv.Columns[5].HeaderText = "Hora de Egreso";
            dgv.Columns[6].HeaderText = "Motivo";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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
        }

        public static void dgvUsuarios(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Empleado";
            dgv.Columns[2].HeaderText = "Nombre Usuario";
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "Cant. Intentos Login";
            dgv.Columns[5].HeaderText = "Permiso";
            dgv.Columns[6].Visible = false;
            dgv.Columns[7].HeaderText = "Usuario Bloqueado";
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        public static void dgvNovedades(DataGridView dgv)
        {
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Empleado";
            dgv.Columns[2].HeaderText = "Vacaciones Disponibles";
            dgv.Columns[3].Visible = false;
            foreach (DataGridViewColumn columns in dgv.Columns)
            {
                columns.SortMode = DataGridViewColumnSortMode.NotSortable;
                columns.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
}
