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
    public partial class frmNuevaCombMesa : Form
    {

        public BE_Mesa oBE_Mesa;
        BE_Mesa oBE_Mesa1;
        BLL_Mesa oBLL_Mesa;
        private bool status;
        public frmNuevaCombMesa()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboUbicacion, Enum.GetNames(typeof(Ubicacion)), "Ubicación");
            Cálculos.DataSourceCombo(comboMesaComb, oBLL_Mesa.ListarLibres(), "Mesas Libres");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CombinarMesa())
                {
                    Cálculos.MsgBox("Los datos se han guardado correctamente");
                }
                else { throw new RestaurantException("Los datos no se han guardado correctamente. Por favor, intente nuevamente"); }
                
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }

        }
        private bool CombinarMesa()
        {
            Viejo();
            return oBLL_Mesa.CombinarMesa(oBE_Mesa, oBE_Mesa1); 
        }
        private void Viejo()
        {
            oBE_Mesa1 = new BE_Mesa();
            oBE_Mesa1 = (BE_Mesa)comboMesaComb.SelectedItem;
        }
        private void ImportarMesa()
        {
            if (oBE_Mesa != null)
            {
                txtCodigo.Text = oBE_Mesa.Codigo.ToString();
                txtCapacidad.Text = oBE_Mesa.Capacidad.ToString();
                comboUbicacion.Text = oBE_Mesa.Ubicación.ToString();
                status = oBE_Mesa.Activo;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarMesa();
        }

        private void comboMesaComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtCapacidad2.Text = ((BE_Mesa)comboMesaComb.SelectedItem).Capacidad.ToString();
            }
            catch { }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
