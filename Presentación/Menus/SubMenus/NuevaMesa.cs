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
    public partial class frmNuevaMesa : Form
    {

        public BE_Mesa oBE_Mesa;
        BLL_Mesa oBLL_Mesa;
        private bool status;
        public frmNuevaMesa()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            Aspecto.FormatearSubMenu(this, grpNuevoLogin, this.Width, this.Height);
            Cálculos.DataSourceCombo(comboUbicacion, Enum.GetNames(typeof(Ubicacion)), "Ubicación");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_ = oBE_Mesa != null ? Viejo() : Nuevo())
                {
                    Cálculos.MsgBox("Los datos se han guardado correctamente");
                }
                else { throw new RestaurantException("Los datos no se han guardado correctamente. Por favor, intente nuevamente"); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private bool Viejo()
        {
            oBE_Mesa.Codigo = Convert.ToInt32(txtCodigo.Text);
            oBE_Mesa.Capacidad = Convert.ToInt32(txtCapacidad.Text);
            oBE_Mesa.Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), comboUbicacion.SelectedItem.ToString());
            oBE_Mesa.Activo = chkActivo.Checked;
            return oBLL_Mesa.Modificar(oBE_Mesa);
        }

        private bool Nuevo()
        {
            oBE_Mesa = new BE_Mesa();
            oBE_Mesa.Capacidad = Convert.ToInt32(txtCapacidad.Text);
            oBE_Mesa.Ubicación = (Ubicacion)Enum.Parse(typeof(Ubicacion), comboUbicacion.SelectedItem.ToString());
            return oBLL_Mesa.Guardar(oBE_Mesa);

        }
        private void ImportarEmpleado()
        {
            if (oBE_Mesa != null)
            {
                txtCodigo.Text = oBE_Mesa.Codigo.ToString();
                txtCapacidad.Text = oBE_Mesa.Capacidad.ToString();
                comboUbicacion.Text = oBE_Mesa.Ubicación.ToString();
                status = oBE_Mesa.Activo;
                chkActivo.Checked = status;
            }
        }

        private void frmNuevoLogin_Load(object sender, EventArgs e)
        {
            ImportarEmpleado();
        }
    }
}
