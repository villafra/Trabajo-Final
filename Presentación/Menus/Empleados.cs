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
    public partial class frmEmpleados : Form
    {
        BLL_Chef_Principal oBLL_Chef;
        BLL_Gerente_Sucursal OBLL_Gerente;
        BLL_Mozo oBLL_Mozo;
      
        BE_ChefPrincipal oBE_Chef;
        BE_GerenteSucursal OBE_Gerente;
        BE_Mozo oBE_Mozo;

        BE_Empleado oBE_Empleado;

        public frmEmpleados()
        {
            InitializeComponent();
            oBLL_Chef = new BLL_Chef_Principal();
            OBLL_Gerente = new BLL_Gerente_Sucursal();
            oBLL_Mozo = new BLL_Mozo();

            Aspecto.FormatearGRP(grpEmpleados);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvEmpleados);
            ActualizarListado();
        }
        private void ActualizarListado()
        {
            Cálculos.RefreshGrilla(dgvEmpleados, oBLL_Mozo.Listar());
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoEmpleado frm = new frmNuevoEmpleado();
            frm.ShowDialog();
            ActualizarListado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoEmpleado frm = new frmNuevoEmpleado();
            frm.oBE_Empleado = oBE_Empleado;
            frm.ShowDialog();
            ActualizarListado();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //oBE_Login = (BE_Login)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                BE_Empleado.Category categoria = ((BE_Empleado)dgvEmpleados.SelectedRows[0].DataBoundItem).Categoria;
                if ((int)categoria == 1)
                {
                    oBE_Empleado = (BE_GerenteSucursal)dgvEmpleados.SelectedRows[0].DataBoundItem;
                }
                else if ((int)categoria > 1 && (int)categoria < 6)
                {
                    oBE_Empleado = (BE_ChefPrincipal)dgvEmpleados.SelectedRows[0].DataBoundItem;
                }
                else
                {
                    oBE_Empleado = (BE_Mozo)dgvEmpleados.SelectedRows[0].DataBoundItem;
                }
            }
            catch { }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
