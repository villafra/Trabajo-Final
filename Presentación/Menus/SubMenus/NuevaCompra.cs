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
        BLL_Bebida oBLL_Bebida;
        private bool status;
        public frmNuevaCompra()
        {
            InitializeComponent();
            oBLL_Compra = new BLL_Compra();
            oBLL_Ingrediente = new BLL_Ingrediente();
            oBLL_Bebida = new BLL_Bebida();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboTipoMat, Enum.GetNames(typeof(MaterialCompra)), "Tipo Material");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.Camposvacios(grpNuevoLogin))
                {
                    if (_ = oBE_Compra != null ? Viejo() : Nuevo())
                    {
                        Cálculos.MsgBox("Los datos se han guardado correctamente");
                    }
                    else { throw new RestaurantException("Los datos no se han guardado correctamente. Por favor, intente nuevamente"); }
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios"); }
               
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }

        }

        private bool Viejo()
        {
            if (comboTipoMat.SelectedItem.ToString() == "Ingrediente")
            {
                oBE_Compra.Codigo = Convert.ToInt32(txtCodigo.Text);
                oBE_Compra.Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comboTipoMat.SelectedItem.ToString());
                ((BE_CompraIngrediente)oBE_Compra).ID_Material = (BE_Ingrediente)comboMaterial.SelectedItem;
                oBE_Compra.Cantidad = numCantidad.Value;
                oBE_Compra.FechaCompra = dtpFechaCompra.Value;
                oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
                oBE_Compra.Activo = status;
            }
            else
            {
                oBE_Compra.Codigo = Convert.ToInt32(txtCodigo.Text);
                oBE_Compra.Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comboTipoMat.SelectedItem.ToString());
                ((BE_CompraBebida)oBE_Compra).ID_Material = (BE_Bebida)comboMaterial.SelectedItem;
                oBE_Compra.Cantidad = numCantidad.Value;
                oBE_Compra.FechaCompra = dtpFechaCompra.Value;
                oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
                oBE_Compra.Activo = status;
            }
            
            return oBLL_Compra.Modificar(oBE_Compra);
        }

        private bool Nuevo()
        {
            if (comboTipoMat.SelectedItem.ToString() == "Ingrediente")
            {
                oBE_Compra = new BE_CompraIngrediente();
                oBE_Compra.Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comboTipoMat.SelectedItem.ToString());
                ((BE_CompraIngrediente)oBE_Compra).ID_Material = (BE_Ingrediente)comboMaterial.SelectedItem;
                oBE_Compra.Cantidad = numCantidad.Value;
                oBE_Compra.FechaCompra = dtpFechaCompra.Value;
                oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
            }
            else
            {
                oBE_Compra = new BE_CompraBebida();
                oBE_Compra.Material = (MaterialCompra)Enum.Parse(typeof(MaterialCompra), comboTipoMat.SelectedItem.ToString());
                ((BE_CompraBebida)oBE_Compra).ID_Material = (BE_Bebida)comboMaterial.SelectedItem;
                oBE_Compra.Cantidad = numCantidad.Value;
                oBE_Compra.FechaCompra = dtpFechaCompra.Value;
                oBE_Compra.FechaEntrega = dtpFechaEntrega.Value;
            }
            return oBLL_Compra.Guardar(oBE_Compra);

        }
        private void ImportarEmpleado()
        {
            if (oBE_Compra != null)
            {
                if (oBE_Compra is BE_CompraIngrediente)
                {
                    txtCodigo.Text = oBE_Compra.Codigo.ToString();
                    comboTipoMat.Text = oBE_Compra.Material.ToString();
                    comboMaterial.Text = ((BE_CompraIngrediente)oBE_Compra).ID_Material.ToString();
                    numCantidad.Value = oBE_Compra.Cantidad;
                    dtpFechaCompra.Value = oBE_Compra.FechaCompra;
                    dtpFechaEntrega.Value = oBE_Compra.FechaEntrega;
                    numCosto.Value = oBE_Compra.Status == StausComp.Entregada ? oBE_Compra.Costo : oBLL_Compra.CalcularCostoTeorico(oBE_Compra);
                    status = oBE_Compra.Activo;
                }
                else
                {
                    txtCodigo.Text = oBE_Compra.Codigo.ToString();
                    comboTipoMat.Text = oBE_Compra.Material.ToString();
                    comboMaterial.Text = ((BE_CompraBebida)oBE_Compra).ID_Material.ToString();
                    numCantidad.Value = oBE_Compra.Cantidad;
                    dtpFechaCompra.Value = oBE_Compra.FechaCompra;
                    dtpFechaEntrega.Value = oBE_Compra.FechaEntrega;
                    numCosto.Value = oBE_Compra.Status == StausComp.Entregada ? oBE_Compra.Costo : oBLL_Compra.CalcularCostoTeorico(oBE_Compra);
                    status = oBE_Compra.Activo;
                }

            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }

        private void numCantidad_Leave(object sender, EventArgs e)
        {
            if (comboTipoMat.SelectedItem.ToString() == "Ingrediente")
            {
                numCosto.Value = oBLL_Compra.CalcularCostoTeorico(new BE_CompraIngrediente { ID_Material = (BE_Ingrediente)comboMaterial.SelectedItem, Cantidad = numCantidad.Value });
            }
            else
            {
                numCosto.Value = oBLL_Compra.CalcularCostoTeorico(new BE_CompraBebida { ID_Material = (BE_Bebida)comboMaterial.SelectedItem, Cantidad = numCantidad.Value });
            }
        }

        private void comboTipoMat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                comboMaterial.DataSource = null;

                if (comboTipoMat.SelectedItem != null)
                {
                    if (comboTipoMat.SelectedItem.ToString() == "Ingrediente")
                    {
                        oBLL_Ingrediente = new BLL_Ingrediente();
                        Cálculos.DataSourceCombo(comboMaterial, oBLL_Ingrediente.Listar(), "Ingredientes");
                    }
                    else
                    {
                        oBLL_Bebida = new BLL_Bebida();
                        Cálculos.DataSourceCombo(comboMaterial, oBLL_Bebida.Listar(), "Bebidas");
                    }
                }
            }
            catch { }
        }
    }
}
