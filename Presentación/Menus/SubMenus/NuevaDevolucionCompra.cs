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
    public partial class frmNuevaDevolucionCompra : Form
    {

        public BE_Compra oBE_Compra;
        BLL_Compra oBLL_Compra;
        BE_Material_Stock oBE_Material;
        BE_Bebida_Stock oBE_Bebida;
        BLL_Bebida_Stock oBLL_Bebida;
        BLL_Material_Stock oBLL_Material;
        public frmNuevaDevolucionCompra()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            oBLL_Material = new BLL_Material_Stock();
            oBLL_Bebida = new BLL_Bebida_Stock();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Nuevo();

        }

        private bool Nuevo()
        {
            if (Cálculos.Camposvacios(grpNuevoLogin))
            {
                if (oBE_Compra is BE_CompraIngrediente)
                {
                    oBE_Material = new BE_Material_Stock();
                    oBE_Material.Material = ((BE_CompraIngrediente)oBE_Compra).ID_Material;
                    oBE_Material.Stock = numCantidad.Value;
                    oBLL_Material.RestarStock(oBE_Material);
                    oBE_Material.FechaCreacion = dtpFechaLote.Value;
                    oBE_Material.Lote = txtLote.Text;
                    oBE_Compra.FechaIngreso = dtpFechaArribo.Value;
                    oBE_Compra.CantidadRecibida += oBE_Material.Stock;
                    oBE_Compra.Costo = oBLL_Compra.CalcularCostoNeto(oBE_Compra);
                    oBE_Compra.NroFactura = txtNroFac.Text;
                    oBE_Compra.Status = StausComp.Devolucion;
                    return oBLL_Compra.Modificar(oBE_Compra) & oBLL_Material.AgregarStock(oBE_Material, oBE_Compra);
                }
                else
                {
                    oBE_Bebida = new BE_Bebida_Stock();
                    oBE_Bebida.Material = ((BE_CompraBebida)oBE_Compra).ID_Material;
                    oBE_Bebida.Stock = numCantidad.Value;
                    oBLL_Bebida.RestarStock(oBE_Bebida);
                    oBE_Bebida.FechaCreacion = dtpFechaLote.Value;
                    oBE_Bebida.Lote = txtLote.Text;
                    oBE_Compra.FechaIngreso = dtpFechaArribo.Value;
                    oBE_Compra.CantidadRecibida += oBE_Material.Stock;
                    oBE_Compra.Costo = oBLL_Compra.CalcularCostoNeto(oBE_Compra);
                    oBE_Compra.NroFactura = txtNroFac.Text;
                    oBE_Compra.Status = StausComp.Devolucion;
                    return oBLL_Compra.Modificar(oBE_Compra) & oBLL_Bebida.AgregarStock(oBE_Bebida, oBE_Compra);
                }
            }
            else throw new RestaurantException("Por favor, complete los campos obligatorios.");
        }
        private void ImportarCompra()
        {
            if (oBE_Compra != null)
            {
                BE_Material_Stock ms = oBLL_Material.ListarXCompra(oBE_Compra);
                if (oBE_Compra is BE_CompraIngrediente)
                {
                    txtCodigo.Text = oBE_Compra.Codigo.ToString();
                    txtIngrediente.Text = ((BE_CompraIngrediente)oBE_Compra).ID_Material.ToString();
                    numCantidad.Value = oBE_Compra.Cantidad;
                    dtpFechaArribo.Value = oBE_Compra.Status != StausComp.En_Curso ? oBE_Compra.FechaIngreso.Value : DateTime.Now;
                    numCantidad.Value = oBE_Compra.CantidadRecibida;
                    txtNroFac.Text = oBE_Compra.NroFactura;
                    txtLote.Text = ms != null ? oBLL_Material.ListarXCompra(oBE_Compra).Lote : "";
                    txtLote.Enabled = false;
                    dtpFechaArribo.Enabled = false;
                    dtpFechaLote.Enabled = false;
                    txtLote.Enabled = false;
                }
                else
                {
                    txtCodigo.Text = oBE_Compra.Codigo.ToString();
                    txtIngrediente.Text = ((BE_CompraBebida)oBE_Compra).ID_Material.ToString();
                    numCantidad.Value = oBE_Compra.Cantidad;
                    dtpFechaArribo.Value = oBE_Compra.Status != StausComp.En_Curso ? oBE_Compra.FechaIngreso.Value : DateTime.Now;
                    numCantidad.Value = oBE_Compra.CantidadRecibida;
                    txtNroFac.Text = oBE_Compra.NroFactura;
                    txtLote.Text = ms != null ? oBLL_Material.ListarXCompra(oBE_Compra).Lote : "";
                    txtLote.Enabled = false;
                    dtpFechaArribo.Enabled = false;
                    dtpFechaLote.Enabled = false;
                    txtLote.Enabled = false;
                }

            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarCompra();
            
        }
    }
}
