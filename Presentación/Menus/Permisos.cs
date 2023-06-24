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
    public partial class frmPermisos : Form
    {
        BLL_Permiso oBLL_Permiso;
        BE_PermisoPadre oBE_Padre;
        BE_PermisoHijo oBE_Hijo;
        public frmPermisos()
        {
            InitializeComponent();
            oBLL_Permiso = new BLL_Permiso();
            oBE_Padre = new BE_PermisoPadre();
            oBE_Hijo = new BE_PermisoHijo();

            Aspecto.FormatearGRPPermisos(grpPermisos);
            Aspecto.FormatearGRPPermisos(grpPerfiles);
            Aspecto.FormatearTreeView(tvPermisos);
            Cálculos.DataSourceCombo(comboPermiso, oBLL_Permiso.Listar(), "Permisos");
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            ArmarTreeView(oBLL_Permiso.ListarPadre());
            Cálculos.RefreshTreeView(tvPermisos);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Viejo();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oBLL_Permiso.Baja(oBE_Padre);
        }

        private void ArmarTreeView(List<BE_PermisoPadre> perfiles)
        {
            tvPermisos.Nodes.Clear();
            foreach(BE_PermisoPadre padre in perfiles)
            {
                TreeNode nodoPadre = tvPermisos.Nodes.Add(padre.Codigo, padre.Descripción);
                nodoPadre.Tag = padre;
                foreach (BE_PermisoHijo hijo in padre._permisos)
                {
                    TreeNode nodoHijo = nodoPadre.Nodes.Add(hijo.Codigo, hijo.Descripción);
                    nodoHijo.Tag = hijo;
                    nodoHijo.Checked = hijo.Otorgado;
                }
            }
        }

        private void Nuevo()
        {
            oBE_Padre.Codigo = txtCodigo.Text;
            oBE_Padre.Descripción = txtDescripción.Text;
            oBLL_Permiso.Guardar(oBE_Padre);
            Cálculos.BorrarCampos(grpPerfiles);
            ActualizarListado();
        }
        private void Viejo()
        {
            oBE_Padre.Codigo = txtCodigo.Text;
            oBE_Padre.Descripción = txtDescripción.Text;
            oBLL_Permiso.Modificar(oBE_Padre);
            Cálculos.BorrarCampos(grpPerfiles);
            ActualizarListado();
        }

        private void tvPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            oBE_Padre = null;
            oBE_Hijo = null;
            try
            {

                if (e.Node.Tag as BE_Permiso is BE_PermisoHijo)
                {
                    oBE_Padre = (BE_PermisoPadre)e.Node.Parent.Tag;
                    oBE_Hijo = (BE_PermisoHijo)e.Node.Tag;
                    txtCodigo.Text = oBE_Padre.Codigo;
                    txtDescripción.Text = oBE_Padre.Descripción;
                    comboPermiso.Text = oBE_Hijo.ToString();
                    chkActivo.Checked = oBE_Hijo.Otorgado;
                }
                else
                {
                    oBE_Padre = (BE_PermisoPadre)e.Node.Tag;
                    txtCodigo.Text = oBE_Padre.Codigo;
                    txtDescripción.Text = oBE_Padre.Descripción;
                    comboPermiso.Text = "";
                    chkActivo.Checked = false;
                }

            }
            catch { }

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            oBE_Hijo = comboPermiso.SelectedItem as BE_PermisoHijo;
            oBE_Hijo.Otorgado = true;
            oBLL_Permiso.AsignarPermiso(oBE_Padre,oBE_Hijo);
            ActualizarListado();
        }
    }
}
