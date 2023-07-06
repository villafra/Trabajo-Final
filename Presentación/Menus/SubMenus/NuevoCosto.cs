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
using Abstraction_Layer;

namespace Trabajo_Final
{
    public partial class frmNuevoCosto : Form
    {
        
        public BE_Costo oBE_Costo;
        BLL_Costo oBLL_Costo;
        BLL_Ingrediente oBLL_Ingrediente;
        BLL_Bebida oBLL_Bebida;
        BLL_Plato oBLL_Plato;
        List<int> Ingrediente = new List<int> { 1 };
        List<int> Bebida = new List<int> { 2, 3 };
        List<int> Plato = new List<int> { 4 };
        private bool status;
        public frmNuevoCosto()
        {
            InitializeComponent();
            oBLL_Costo = new BLL_Costo();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(ComboTipo,Enum.GetNames(typeof(TipoMaterial)),"Tipo Materiales");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_ = oBE_Costo != null ? Viejo() : Nuevo())
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
            oBE_Costo.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Costo.Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial),ComboTipo.SelectedItem.ToString());
            oBE_Costo.DíaCosteo = dtpFechaCosteo.Value;
            oBE_Costo.TamañoLoteCosteo = numTamaño.Value;
            oBE_Costo.MateriaPrima = numMP.Value;
            oBE_Costo.HorasHombre = numHH.Value;
            oBE_Costo.Energía = numNRG.Value;
            oBE_Costo.OtrosGastos = numOtros.Value;
            return oBLL_Costo.Modificar(oBE_Costo);
        }

        private bool Nuevo()
        {
            int tipo = (int)(TipoMaterial)Enum.Parse(typeof(TipoMaterial), ComboTipo.SelectedItem.ToString());
            if (Ingrediente.Contains(tipo))
            {
                oBE_Costo = new BE_CostoIngrediente();
                ((BE_CostoIngrediente)oBE_Costo).Material = (BE_Ingrediente)comboMaterial.SelectedItem;
                oBE_Costo.DíaCosteo = dtpFechaCosteo.Value;
                oBE_Costo.TamañoLoteCosteo = numTamaño.Value;
                oBE_Costo.MateriaPrima = numMP.Value;
                oBE_Costo.HorasHombre = numHH.Value;
                oBE_Costo.OtrosGastos = numOtros.Value;
                oBE_Costo.Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), ComboTipo.SelectedItem.ToString());

            }
            else if (Bebida.Contains(tipo))
            {
                oBE_Costo = new BE_CostoBebida();
                ((BE_CostoBebida)oBE_Costo).Material = (BE_Bebida)comboMaterial.SelectedItem;
                oBE_Costo.DíaCosteo = dtpFechaCosteo.Value;
                oBE_Costo.TamañoLoteCosteo = numTamaño.Value;
                oBE_Costo.MateriaPrima = numMP.Value;
                oBE_Costo.HorasHombre = numHH.Value;
                oBE_Costo.OtrosGastos = numOtros.Value;
                oBE_Costo.Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), ComboTipo.SelectedItem.ToString());
            }
            else
            {
                oBE_Costo = new BE_CostoPlato();
                ((BE_CostoPlato)oBE_Costo).Material = (BE_Plato)comboMaterial.SelectedItem;
                oBE_Costo.DíaCosteo = dtpFechaCosteo.Value;
                oBE_Costo.TamañoLoteCosteo = numTamaño.Value;
                oBE_Costo.MateriaPrima = numMP.Value;
                oBE_Costo.HorasHombre = numHH.Value;
                oBE_Costo.OtrosGastos = numOtros.Value;
                oBE_Costo.Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), ComboTipo.SelectedItem.ToString());
            }

            return oBLL_Costo.Guardar(oBE_Costo);
        }
        private void ImportarCosto()
        {
            if (oBE_Costo != null)
            {
                txtCodigo.Text = oBE_Costo.Codigo.ToString();
                ComboTipo.Text = oBE_Costo.Tipo.ToString();
                dtpFechaCosteo.Value = oBE_Costo.DíaCosteo;
                numTamaño.Value = oBE_Costo.TamañoLoteCosteo;
                numMP.Value = oBE_Costo.MateriaPrima;
                numHH.Value = oBE_Costo.HorasHombre;
                numNRG.Value = oBE_Costo.Energía;
                numOtros.Value = oBE_Costo.OtrosGastos;
                int tipo = (int)oBE_Costo.Tipo;
                if (Ingrediente.Contains(tipo)) comboMaterial.Text = TipoMaterial.Ingrediente.ToString();
                else if (Bebida.Contains(tipo)) comboMaterial.Text = TipoMaterial.Bebida.ToString();
                else comboMaterial.Text = TipoMaterial.Plato.ToString();
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarCosto();
        }

        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboMaterial.DataSource = null;
                if (ComboTipo.SelectedItem != null)
                {
                    if (ComboTipo.SelectedItem.ToString() == "Ingrediente")
                    {
                        oBLL_Ingrediente = new BLL_Ingrediente();
                        Cálculos.DataSourceCombo(comboMaterial, oBLL_Ingrediente.Listar(), "Ingredientes");
                    }
                    else if (ComboTipo.SelectedItem.ToString() == "Bebida")
                    {
                        oBLL_Bebida = new BLL_Bebida();
                        Cálculos.DataSourceCombo(comboMaterial, oBLL_Bebida.Listar(), "Bebidas");
                    }
                    else
                    {
                        oBLL_Plato = new BLL_Plato();
                        Cálculos.DataSourceCombo(comboMaterial, oBLL_Plato.Listar(), "Platos");
                    }
                }
            }
            catch { }
        }

    }
}
