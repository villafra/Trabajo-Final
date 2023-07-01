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
                Cálculos.MsgBox("Los datos se han guardado correctamente");
            }
            else
            {
                Cálculos.MsgBox("Los datos no se han guardado correctamente. Por favor, intente nuevamente");
            }

        }

        private bool Viejo()
        {
            oBE_Compra.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Compra.ID_Ingrediente = (BE_Ingrediente)ComboIngrediente.SelectedItem;
            oBE_Compra.Cantidad = numCantidad.Value;
            oBE_Compra.FechaCompra = dtpFechaCompra.Value;
            oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
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
                numCosto.Value = oBE_Compra.Status == StausComp.Entregada ? oBE_Compra.Costo : oBLL_Compra.CalcularCostoTeorico(oBE_Compra);
                status = oBE_Compra.Activo;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }

        private void numCantidad_Leave(object sender, EventArgs e)
        {
            numCosto.Value = oBLL_Compra.CalcularCostoTeorico(new BE_Compra { ID_Ingrediente = (BE_Ingrediente)ComboIngrediente.SelectedItem, Cantidad = numCantidad.Value });
        }
        
    }
}
