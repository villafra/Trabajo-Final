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
    public partial class frmEmpleados : Form
    {
        BE_Empleado oBE_Empleado;
        BLL_Empleado oBLL_Empleado;
        private List<BE_Empleado> listado;
        Reemplazos rm;
        public frmEmpleados()
        {
            InitializeComponent();
            Aspecto.FormatearGRP(grpEmpleados);
            Aspecto.FormatearGRPAccion(grpAcciones);
            Aspecto.FormatearDGV(dgvEmpleados);
            CargarComboFiltro();
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            oBLL_Empleado = new BLL_Gerente_Sucursal();
            Cálculos.RefreshGrilla(dgvEmpleados, oBLL_Empleado.Listar());
        }
        public void Centrar()
        {
            VistasDGV.DGVEmpleados(dgvEmpleados);
            Aspecto.CentrarDGV(this, dgvEmpleados);
        }
        private void CargarComboFiltro()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"Documento de Identidad", "DNI"},
                {"Nombres", "Nombre" },
                {"Apellidos", "Apellido" },
                {"Categoria", "Categoria" },
                {"Fecha de Ingreso", "FechaIngreso" }
            };
            rm = new Reemplazos(dict);
            Cálculos.DataSourceCombo(comboFiltro, rm.ListadoClaves(), "Filtros");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmNuevoEmpleado frm = new frmNuevoEmpleado();
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmNuevoEmpleado frm = new frmNuevoEmpleado();
            frm.oBE_Empleado = oBE_Empleado;
            frm.ShowDialog();
            ActualizarListado();
            Centrar();
        }
        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Category categoria = ((BE_Empleado)dgvEmpleados.SelectedRows[0].DataBoundItem).Categoria;
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
            try
            {
                if (Cálculos.EstaSeguroE(oBE_Empleado.ToString()))
                {
                    Category categoria = oBE_Empleado.Categoria;
                    if ((int)categoria == 1)
                    {
                        oBLL_Empleado = new BLL_Gerente_Sucursal();
                        if (oBLL_Empleado.Baja(oBE_Empleado))
                        {
                            Cálculos.MsgBox("El empleado se ha borrado satisfactoriamente");
                        }
                        else { throw new RestaurantException("La baja ha fallado, por favor , intente nuevamente"); }
                    }
                    else if ((int)categoria > 1 && (int)categoria < 6)
                    {
                        oBLL_Empleado = new BLL_Chef_Principal();
                        if (oBLL_Empleado.Baja(oBE_Empleado))
                        {
                            Cálculos.MsgBox("El empleado se ha borrado satisfactoriamente");
                        }
                        else
                        {
                            throw new RestaurantException("La baja ha fallado, por favor , intente nuevamente");
                        }
                    }
                    else
                    {
                        oBLL_Empleado = new BLL_Mozo();
                        if (oBLL_Empleado.Baja(oBE_Empleado))
                        {
                            Cálculos.MsgBox("El empleado se ha borrado satisfactoriamente");
                        }
                        else
                        {
                            throw new RestaurantException("La baja ha fallado, por favor , intente nuevamente");
                        }
                    }
                    ActualizarListado();
                    Centrar();
                }
                else { throw new RestaurantException("La baja del empleado se ha cancelado."); }
            }
            catch(Exception ex) { Cálculos.MsgBox(ex.Message); }
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            if (comboFiltro.SelectedIndex != -1 && txtFiltro.Text.Length > 0)
            {
                Cálculos.RefreshGrilla(dgvEmpleados, listado);
                string filtro = txtFiltro.Text;
                string Variable = rm.Reemplazar(comboFiltro.Text);
                List<BE_Empleado> filtrada = ((List<BE_Empleado>)dgvEmpleados.DataSource).Where(x => Cálculos.GetPropertyValue(x, Variable).ToString().Contains(Cálculos.Capitalize(filtro))).ToList();
                Cálculos.RefreshGrilla(dgvEmpleados, filtrada);
                Centrar();
                comboFiltro.Text = "";
                txtFiltro.Text = "";
            }  
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Cálculos.RefreshGrilla(dgvEmpleados, listado);
            Centrar();
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            listado = (List<BE_Empleado>)dgvEmpleados.DataSource;
        }

        private void frmEmpleados_Activated(object sender, EventArgs e)
        {
            Centrar();
        }

        private void frmEmpleados_Shown(object sender, EventArgs e)
        {
            Centrar();
        }
    }
}
