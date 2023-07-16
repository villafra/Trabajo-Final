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
using Service_Layer;

namespace Trabajo_Final
{
    public partial class frmBitacora : Form
    {
        public BE_Login UsuarioActivo;
        private List<BE_Bitacora> listado;
        Reemplazos rm;
        public frmBitacora(BE_Login user)
        {
            InitializeComponent();
            UsuarioActivo = user;
            Aspecto.FormatearGRP(grpBitacora);
            Aspecto.FormatearDGV(dgvBitacora);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvBitacora, Bitacora.ListarBitacora(UsuarioActivo));
        }

        public void Centrar()
        {
            VistasDGV.DGVBitacora(dgvBitacora);
            Aspecto.CentrarDGV(this, dgvBitacora);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Usuario", "Empleado"},
                {"Tipo de Acción", "Acción" },
                {"Fecha y Hora", "FechaHora" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Bitacora>)dgvBitacora.DataSource;
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (txtFiltro.Text.Length > 0 && comboFiltro.SelectedIndex != -1)
            {
                Cálculos.RefreshGrilla(dgvBitacora, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Bitacora> filtrada = ((List<BE_Bitacora>)dgvBitacora.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvBitacora, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvBitacora, listado);
            Centrar();
        }

        private void frmBitacora_Shown(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmBitacora_Activated(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
