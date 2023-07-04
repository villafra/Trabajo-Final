using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Entities;
using Automate_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmRecetaBebidas : Form
    {
        BLL_Bebida oBLL_Bebida;
        BLL_BebidaReceta oBLL_Receta;
        BE_Bebida_Preparada oBE_Bebida;
        BE_BebidaReceta oBE_Receta;
        public frmRecetaBebidas()
        {
            InitializeComponent();
            oBLL_Bebida = new BLL_Bebida();
            oBE_Bebida = new BE_Bebida_Preparada();
            oBLL_Receta = new BLL_BebidaReceta();
            oBE_Receta = new BE_BebidaReceta();
            Aspecto.FormatearGRP(grpBebidas);
            Aspecto.FormatearDGV(dgvReceta);
            Aspecto.FormatearGRPAccion(grpAcciones);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.DataSourceCombo(comboBebida, oBLL_Bebida.ListarPreparadas(), "Bebidas Preparadas");
        }

        private void comboBebida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Bebida = (BE_Bebida_Preparada)comboBebida.SelectedItem;
                Cálculos.DataSourceCombo(comboAlt, oBLL_Receta.ListarAlternativasDataSource(oBE_Bebida),"Alternativas Vigentes");
            }
            catch { }
        }

        private void comboAlt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oBE_Receta = (BE_BebidaReceta)comboAlt.SelectedItem;
                if (oBE_Receta != null)
                Cálculos.RefreshGrilla(dgvReceta, oBLL_Receta.ListarObjeto(oBE_Bebida, oBE_Receta));
            }
            catch { }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevaReceta frm = new frmNuevaReceta();
            frm.oBE_Bebida = oBE_Bebida;
            frm.ShowDialog();
            ActualizarListado();
        }
    }
}
