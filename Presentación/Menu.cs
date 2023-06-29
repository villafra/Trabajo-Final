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
        private static Timer inactivityTimer;
        public Form Contenedor { get; set; }
        public BE_Login UsuarioActivo { get; set; }
        public frmMenu()
        {
            InitializeComponent();
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
                    UIComposite.CambiarVisibilidadMenu(menuStrip.Items, UsuarioActivo.Permiso.ListaPermisos());
                    Iniciar();
                }
                txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Usuario;
            }
            catch (Exception ex)
            {
                throw ex;
                Application.Exit();
            }
            Aspecto.FormatearForm(this, pnlMenu, this.Width, this.Height);
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
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMenuGerente);
            if (frm != null)
            {
                
                frm.BringToFront();
                return;
            }
            else
            {
                frm = new frmMenuGerente();
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
                txtUsuarioActivo.Text = $"Usuario Activo: " + UsuarioActivo.Usuario;
                UIComposite.CambiarVisibilidadMenu(menuStrip.Items, UsuarioActivo.Permiso.ListaPermisos());
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cálculos.Salir();
        }

        private void crearBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackUp.CrearBackUp(UsuarioActivo);
        }

        private void restoreBackUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
            Cálculos.Minimizar(this);
            frm.ShowDialog();
            frm.Activate();
            this.WindowState = FormWindowState.Normal;
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
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }

        private void frmMenu_MouseMove(object sender, MouseEventArgs e)
        {
            ResetInactivityTimer();
        }

        private void listadoToolStripMenuItem4_Click(object sender, EventArgs e)
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
                Aspecto.AbrirNuevoForm(this, frm);
            }
        }
    }
}
