using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service_Layer;
using Business_Entities;
using Automate_Layer;
using Business_Logic_Layer;

namespace Trabajo_Final
{
    public partial class frmMenu : Form
    {
        private List<Form> formulariosHijos = new List<Form>();
        private static Timer inactivityTimer;
        public Form Contenedor { get; set; }
        public BE_Login UsuarioActivo { get; set; }
        public frmMenu()
        {
            InitializeComponent();
            //Notificaciones.IniciarFileWatcher();
            //Notificaciones.IniciarNotificaciones();
        }
        private void Iniciar()
        {
            inactivityTimer = new Timer();
            inactivityTimer.Interval = 300000;
            inactivityTimer.Tick += InactivityTimer_Tick;

            this.MouseMove += frmMenu_MouseMove;
        }
        private void ResetInactivityTimer()
        {
            MessageBox.Show(inactivityTimer.ToString());
            inactivityTimer.Stop();
            inactivityTimer.Start();

        }
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            

            inactivityTimer.Stop();
        }
        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.UsuarioActivo is null)
                {
                    frmLogin frmlog = new frmLogin();
                    frmlog.Owner = this;
                    frmlog.ShowDialog();
                    if (this.UsuarioActivo is null)
                    {
                        Cálculos.Salir();
                        return;
                    }
                    UIComposite.CambiarVisibilidadMenu(menuStrip.Items, UsuarioActivo.Permiso.ListaPermisos());
                    if (UsuarioActivo.Usuario == "admin") txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Usuario;
                    else txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Empleado;
                    Iniciar();
                }
                
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
            Aspecto.FormatearForm(this, pnlMenu, this.Width, this.Height);
            UIComposite.MostrarBotonesPanel(flowPanel, pnlMenu, UsuarioActivo.Permiso.ListaPermisos());
            frmBienvenida frm = new frmBienvenida();
            frm.Owner = this;
            Aspecto.AbrirNuevoForm(this, frm);

        }

        private void frmMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void picboxPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Aspecto.ReleaseCapture();
            Aspecto.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void menuPrincipalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBienvenida);
            if (frm != null)
            {
                
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmBienvenida();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
               
            }
        }

        private void loguearseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmLogin);
            if (frm != null)
            {
                
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmLogin();
                frm.Owner = this;
                frm.ShowDialog();

                CambiarUsuario();
                if (UsuarioActivo.Usuario == "admin") txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Usuario;
                else txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Empleado;
                UIComposite.CambiarVisibilidadMenu(menuStrip.Items, UsuarioActivo.Permiso.ListaPermisos());
                UIComposite.MostrarBotonesPanel(flowPanel, pnlMenu, UsuarioActivo.Permiso.ListaPermisos());
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cálculos.Salir();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Cálculos.Salir();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            Cálculos.Minimizar(this);
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCambioPass frm = new frmCambioPass();
            frm.Usuario(UsuarioActivo.Usuario);
            frm.ShowDialog();
        }

        private void empleadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUsuarios);
            if (frm != null)
            {
                ((frmUsuarios)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmUsuarios();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEmpleados);
            if (frm != null)
            {
                ((frmEmpleados)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmEmpleados();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }
        private void rotacionDePersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRotacion);
            if (frm != null)
            {
                ((frmRotacion)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmRotacion();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void generarComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCompras);
            if (frm != null)
            {
                ((frmCompras)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmCompras();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void ingresarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmIngresarCompra);
            if (frm != null)
            {
                ((frmIngresarCompra)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmIngresarCompra();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void devolverPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDevolverCompra);
            if (frm != null)
            {
                ((frmDevolverCompra)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmDevolverCompra();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPermisos);
            if (frm != null)
            {
                ((frmPermisos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmPermisos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void gestionarIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmIngredientes);
            if (frm != null)
            {
                ((frmIngredientes)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmIngredientes();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void listadoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoIngredientes);
            if (frm != null)
            {
                ((frmListadoIngredientes)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoIngredientes();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void costosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCostos);
            if (frm != null)
            {
                ((frmCostos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmCostos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void frmMenu_MouseMove(object sender, MouseEventArgs e)
        {
            ResetInactivityTimer();
        }

        private void listadoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoMesas);
            if (frm != null)
            {
                ((frmListadoMesas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoMesas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void combinarMesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCombinarMesas);
            if (frm != null)
            {
                ((frmCombinarMesas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmCombinarMesas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBackUp);
            if (frm != null)
            {
                ((frmBackUp)frm).UsuarioActivo = UsuarioActivo;
                ((frmBackUp)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmBackUp();
                formulariosHijos.Add(frm);
                ((frmBackUp)frm).UsuarioActivo = UsuarioActivo;
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void gestionarMesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMesas);
            if (frm != null)
            {
                ((frmMesas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmMesas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }
        private void CambiarUsuario()
        {
            foreach (Form formulario in formulariosHijos)
            {
                formulario.Close();
            }
            formulariosHijos.Clear();
        }

        private void cargarNovedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmNovedades);
            if (frm != null)
            {
                ((frmNovedades)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmNovedades();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void listadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoBebidas);
            if (frm != null)
            {
                ((frmListadoBebidas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoBebidas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void listadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoPlatos);
            if (frm != null)
            {
                ((frmListadoPlatos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoPlatos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void gestionarbebidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmBebidas);
            if (frm != null)
            {
                ((frmBebidas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmBebidas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void bebidasPreparadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRecetaBebidas);
            if (frm != null)
            {
                ((frmRecetaBebidas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmRecetaBebidas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void platosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRecetaPlatos);
            if (frm != null)
            {
                ((frmRecetaPlatos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmRecetaPlatos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void gestionarPlatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPlatos);
            if (frm != null)
            {
                ((frmPlatos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmPlatos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void gestionarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTomarPedido);
            if (frm != null)
            {
                //((frmTomarPedido)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmTomarPedido(UsuarioActivo);
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void listadoToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoPedidos);
            if (frm != null)
            {
                ((frmListadoPedidos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoPedidos(UsuarioActivo);
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void btnDashEmpleados_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmDashEmpleados);
            if (frm != null)
            {
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmDashEmpleados();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void btnMesasLibres_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoMesas);
            if (frm != null)
            {
                ((frmListadoMesas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoMesas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void btnBebidas_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoBebidas);
            if (frm != null)
            {
                ((frmListadoBebidas)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoBebidas();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void btnPlatos_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoPlatos);
            if (frm != null)
            {
                ((frmListadoPlatos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoPlatos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }
        private void métodosDePagoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMetodoPagos);
            if (frm != null)
            {
                ((frmMetodoPagos)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmMetodoPagos();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void listadoToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmListadoOrdenes);
            if (frm != null)
            {
                ((frmListadoOrdenes)frm).ActualizarListado();
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmListadoOrdenes();
                formulariosHijos.Add(frm);
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }
    }
}
