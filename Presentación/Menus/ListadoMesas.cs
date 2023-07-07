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
    public partial class frmListadoMesas : Form
    {
        BLL_Mesa oBLL_Mesa;
        BE_Mesa oBE_Mesa;
        public frmListadoMesas()
        {
            InitializeComponent();
            oBLL_Mesa = new BLL_Mesa();
            oBE_Mesa = new BE_Mesa();
            Aspecto.FormatearGRP(grpMesas);
            Aspecto.FormatearDGV(dgvMesas);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvMesas, oBLL_Mesa.ListarLibres());
            dgvMesas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
