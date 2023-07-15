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
    public partial class frmPermisos : Form
    {
        BLL_Permiso oBLL_Permiso;
        BE_PermisoPadre oBE_Padre;
        BE_PermisoPadre oBE_PHijo;
        BE_PermisoHijo oBE_Hijo;
        public frmPermisos()
        {
            InitializeComponent();
            oBLL_Permiso = new BLL_Permiso();
            oBE_Padre = new BE_PermisoPadre();
            oBE_PHijo = new BE_PermisoPadre();
            oBE_Hijo = new BE_PermisoHijo();
            Aspecto.FormatearGRPPermisos(grpPermisos);
            Aspecto.FormatearGRPPermisos(grpPerfiles);
            Aspecto.FormatearTreeView(tvPermisos);
            ActualizarListado();
        }
        public void ActualizarListado()
        {
            ArmarTreeView(oBLL_Permiso.ListarPadre());
            Cálculos.RefreshTreeView(tvPermisos);
            Cálculos.DataSourceCombo(comboPermiso, oBLL_Permiso.Listar(), "Permisos");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.Camposvacios(grpPerfiles))
                {
                    oBE_Padre = new BE_PermisoPadre();
                    Nuevo();
                    if (oBLL_Permiso.ExistePerfil(oBE_Padre))
                    {
                        if (oBLL_Permiso.Guardar(oBE_Padre))
                        {
                            Cálculos.MsgBox("El nuevo perfil se ha creado con éxito");
                        }
                        else { throw new Exception(); }
                    }
                    else { throw new RestaurantException("Ya existe el perfil que intenta crear."); }
                }
                else { throw new RestaurantException("Por favor, complete los campos obligatorios"); }
                Cálculos.BorrarCampos(grpPerfiles);
                ActualizarListado();
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Viejo();
                if (Cálculos.EstaSeguroM(oBE_Padre.ToString()))
                {
                    if (oBLL_Permiso.Modificar(oBE_Padre))
                    {
                        Cálculos.MsgBox("El perfil se ha modificado con exito.");
                    }
                    else { throw new Exception(); }
                   
                }
                else { return; }
                Cálculos.BorrarCampos(grpPerfiles);
                ActualizarListado();
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Nuevo();
                if (Cálculos.EstaSeguroE(oBE_Padre.ToString()))
                {
                    if (oBLL_Permiso.EliminarPerfil(oBE_Padre))
                    {
                        Cálculos.MsgBox("El perfil se ha eliminado de la base de datos.");
                    }
                    else { throw new Exception(); }
                }
                else { return; }
                Cálculos.BorrarCampos(grpPerfiles);
                ActualizarListado();
            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
        }

        private void ArmarTreeView(List<BE_PermisoPadre> perfiles)
        {
            tvPermisos.Nodes.Clear();
            TreeNode nodoPadre;
            foreach (BE_PermisoPadre padre in perfiles)
            {
                nodoPadre = tvPermisos.Nodes.Add(padre.Codigo, padre.Descripción);
                nodoPadre.Tag = padre;
                EnramarTreeView(padre.ListaPermisos(), nodoPadre);
            }
        }
        private void EnramarTreeView(List<BE_Permiso> listado, TreeNode nodoroot)
        {
            foreach (BE_Permiso hijo in listado)
            {
                if (hijo is BE_PermisoPadre)
                {
                    TreeNode nodoPHijo = nodoroot.Nodes.Add(hijo.Codigo, hijo.Descripción);
                    nodoPHijo.Tag = hijo;
                    nodoPHijo.Checked = hijo.Otorgado;
                    EnramarTreeView(hijo.ListaPermisos(), nodoPHijo);
                }
                else
                {
                    TreeNode nodoHijo = nodoroot.Nodes.Add(hijo.Codigo, hijo.Descripción);
                    nodoHijo.Tag = hijo;
                    nodoHijo.Checked = hijo.Otorgado;
                }
            }
        }

        private void Nuevo()
        {
            oBE_Padre.Codigo = txtCodigo.Text;
            oBE_Padre.Descripción = txtDescripción.Text;
        }
        private void Viejo()
        {
            oBE_Padre.Descripción = txtDescripción.Text;
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
                    if (e.Node.Parent != null)
                    {
                        oBE_Padre = (BE_PermisoPadre)e.Node.Parent.Tag;
                        txtCodigo.Text = oBE_Padre.Codigo;
                        txtDescripción.Text = oBE_Padre.Descripción;
                        oBE_PHijo = (BE_PermisoPadre)e.Node.Tag;
                        comboPermiso.Text = oBE_PHijo.ToString();
                        chkActivo.Checked = oBE_PHijo.Otorgado;
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

            }
            catch { }

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cálculos.Camposvacios(grpPerfiles) & Cálculos.Camposvacios(grpPermisos))
                {
                    if (comboPermiso.SelectedItem is BE_PermisoPadre)
                    {
                        if (oBLL_Permiso.ExisteCircular(oBE_Padre, comboPermiso.SelectedItem as BE_PermisoPadre))
                        {
                            if (oBLL_Permiso.ExistePermiso(oBE_Padre, comboPermiso.SelectedItem as BE_PermisoPadre))
                            {
                                oBE_PHijo = comboPermiso.SelectedItem as BE_PermisoPadre;
                                oBE_PHijo.Otorgado = true;
                                if (oBE_Padre.ToString() != oBE_PHijo.ToString())
                                {
                                    oBLL_Permiso.AsignarPermiso(oBE_Padre, oBE_PHijo);
                                }
                                else
                                {
                                    MessageBox.Show("NO");
                                }
                            }
                            else { throw new ExisteEnBDException("Ya existe una referencia entre ambos Perfiles"); }
                        }
                        else { throw new ExisteEnBDException("No se puede asignar Perfil en Perfil porque resultaría en una referencia circular."); }
                    }
                    else
                    {
                        if (oBLL_Permiso.ExistePermiso(oBE_Padre, comboPermiso.SelectedItem as BE_PermisoHijo))
                        {
                            oBE_Hijo = comboPermiso.SelectedItem as BE_PermisoHijo;
                            oBE_Hijo.Otorgado = true;
                            oBLL_Permiso.AsignarPermiso(oBE_Padre, oBE_Hijo);
                        }
                        else { throw new ExisteEnBDException("El permiso ya existe dentro del perfil."); }
                    }
                    ActualizarListado();
                }
                else { throw new RestaurantException("Por favor, Complete los campos obligatorios."); }

            }
            catch (Exception ex)
            {
                Cálculos.MsgBox(ex.Message);
            }
           
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            if (comboPermiso.SelectedItem is BE_PermisoPadre)
            {
                oBE_PHijo = comboPermiso.SelectedItem as BE_PermisoPadre;
                oBE_PHijo.Otorgado = true;
                if (oBE_Padre.ToString() != oBE_PHijo.ToString())
                {
                    oBLL_Permiso.DesasignarPermiso(oBE_Padre, oBE_PHijo);
                }
                else
                {
                    MessageBox.Show("NO");
                }

            }
            else
            {
                oBE_Hijo = comboPermiso.SelectedItem as BE_PermisoHijo;
                oBE_Hijo.Otorgado = true;
                oBLL_Permiso.DesasignarPermiso(oBE_Padre, oBE_Hijo);
            }
            ActualizarListado();
        }
        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (comboPermiso.SelectedItem is BE_PermisoPadre)
            {
                oBE_PHijo = comboPermiso.SelectedItem as BE_PermisoPadre;
                oBE_PHijo.Otorgado = chkActivo.Checked;
                if (oBE_Padre.ToString() != oBE_PHijo.ToString())
                {
                    oBLL_Permiso.CambiarStatusPermiso(oBE_Padre, oBE_PHijo);
                }
            }
            else
            {
                oBE_Hijo = comboPermiso.SelectedItem as BE_PermisoHijo;
                oBE_Hijo.Otorgado = chkActivo.Checked;
                oBLL_Permiso.CambiarStatusPermiso(oBE_Padre, oBE_Hijo);
            }
            ActualizarListado();
        }

    }
}
