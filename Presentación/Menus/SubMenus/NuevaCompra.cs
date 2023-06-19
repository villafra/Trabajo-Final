using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automate_Layer;
using Business_Entities;
using Service_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmNuevaCompra : Form
    {

        public BE_Compra oBE_Compra;
        BLL_Compra oBLL_Compra;
        BLL_Ingrediente oBLL_Ingrediente;
        private bool status;
        public frmNuevaCompra()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            oBLL_Ingrediente = new BLL_Ingrediente();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(ComboIngrediente,oBLL_Ingrediente.Listar(),"Ingrediente");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Compra != null ? Viejo() : Nuevo())
            {
                Cálculos.MsgBoxAlta("Los datos se han guardado correctamente");
            }
            else
            {
                Cálculos.MsgBoxNoAlta("Los datos no se han guardado correctamente. Por favor, intente nuevamente");
            }

        }

        private bool Viejo()
        {
            oBE_Compra.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Compra.ID_Ingrediente = (BE_Ingrediente)ComboIngrediente.SelectedItem;
            oBE_Compra.Cantidad = numCantidad.Value;
            oBE_Compra.FechaCompra = dtpFechaCompra.Value;
            oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
            oBE_Compra.FechaIngreso = dtpFechaArribo.Value;
            oBE_Compra.CantidadRecibida = numCantRecibida.Value;
            oBE_Compra.Costo = oBE_Compra.Status == StausComp.Entregada ? oBLL_Compra.CalcularCostoNeto(oBE_Compra) : oBLL_Compra.CalcularCostoTeorico(oBE_Compra);
            oBE_Compra.Activo = status;
            return oBLL_Compra.Modificar(oBE_Compra);
        }

        private bool Nuevo()
        {
            oBE_Compra = new BE_Compra();
            oBE_Compra.ID_Ingrediente = (BE_Ingrediente)ComboIngrediente.SelectedItem;
            oBE_Compra.Cantidad = numCantidad.Value;
            oBE_Compra.FechaCompra = dtpFechaCompra.Value;
            oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
            oBE_Compra.FechaIngreso = dtpFechaArribo.Value;
            oBE_Compra.Costo = oBLL_Compra.CalcularCostoTeorico(oBE_Compra);
            return oBLL_Compra.Guardar(oBE_Compra);
        }
        private void ImportarEmpleado()
        {
            if (oBE_Compra != null)
            {
                txtCodigo.Text = oBE_Compra.Codigo.ToString();
                ComboIngrediente.Text = oBE_Compra.ID_Ingrediente.ToString();
                numCantidad.Value = oBE_Compra.Cantidad;
                dtpFechaCompra.Value = oBE_Compra.FechaCompra;
                dtpFechaEntrega.Value = oBE_Compra.FechaEntrega;
                dtpFechaArribo.Value = oBE_Compra.Status != StausComp.En_Curso ? oBE_Compra.FechaIngreso : DateTime.Now;
                numCantidad.Value = oBE_Compra.CantidadRecibida;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }
    }
}
