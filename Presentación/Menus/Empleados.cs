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
        BE_Empleado oBE_Empleado;
        BLL_Empleado oBLL_Empleado;

        public frmEmpleados()
        {
            InitializeComponent();
            Aspecto.FormatearGRP(grpEmpleados);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvEmpleados);
            ActualizarListado();
        }
        private void ActualizarListado()
        {
            oBLL_Empleado = new BLL_Gerente_Sucursal();
            Cálculos.RefreshGrilla(dgvEmpleados, oBLL_Empleado.Listar());
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
            BE_Empleado.Category categoria = oBE_Empleado.Categoria;
            if ((int)categoria == 1)
            {
                oBLL_Empleado = new BLL_Gerente_Sucursal();
                oBLL_Empleado.Baja(oBE_Empleado);
            }
            else if ((int)categoria > 1 && (int)categoria < 6)
            {
                oBLL_Empleado = new BLL_Chef_Principal();
                oBLL_Empleado.Baja(oBE_Empleado);
            }
            else
            {
                oBLL_Empleado = new BLL_Mozo();
                oBLL_Empleado.Baja(oBE_Empleado);
            }
            ActualizarListado();
        }
    }
}
