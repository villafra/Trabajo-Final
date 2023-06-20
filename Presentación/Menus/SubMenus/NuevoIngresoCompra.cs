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
    public partial class frmNuevoIngresoCompra : Form
    {

        public BE_Compra oBE_Compra;
        BLL_Compra oBLL_Compra;
        BE_Material_Stock oBE_Material;
        BLL_Material_Stock oBLL_Material;
        public frmNuevoIngresoCompra()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            oBLL_Material = new BLL_Material_Stock();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Nuevo();

        }

        private bool Nuevo()
        {
            oBE_Material = new BE_Material_Stock();
            oBE_Material.Material = oBE_Compra.ID_Ingrediente;
            oBE_Material.Stock = numCantidad.Value;
            oBE_Material.FechaCreacion = dtpFechaLote.Value;
            oBE_Material.Lote = txtLote.Text;
            oBE_Compra.FechaIngreso = dtpFechaArribo.Value;
            oBE_Compra.CantidadRecibida = numCantidad.Value;
            oBE_Compra.Costo = oBLL_Compra.CalcularCostoNeto(oBE_Compra);
            oBE_Compra.Status = StausComp.Entregada;
            return oBLL_Compra.Modificar(oBE_Compra) & oBLL_Material.AgregarStock(oBE_Material, oBE_Compra);
        }
        private void ImportarCompra()
        {
            if (oBE_Compra != null)
            {
                txtCodigo.Text = oBE_Compra.Codigo.ToString();
                txtIngrediente.Text = oBE_Compra.ID_Ingrediente.ToString();
                numCantidad.Value = oBE_Compra.Cantidad;
                dtpFechaArribo.Value = oBE_Compra.Status != StausComp.En_Curso ? oBE_Compra.FechaIngreso.Value : DateTime.Now;
                numCantidad.Value = oBE_Compra.CantidadRecibida;
                if (!oBE_Compra.ID_Ingrediente.GestionLote)
                {
                    txtLote.Enabled = false;
                }
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarCompra();
            
        }

        private void txtLote_Leave(object sender, EventArgs e)
        {
            try
            {
                dtpFechaLote.Value = oBLL_Material.ListarXCompra(oBE_Compra).FechaCreacion.Value;
            }
            catch { }
        }
    }
}
