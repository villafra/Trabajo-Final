using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Abstraction_Layer;

namespace Automate_Layer
{
    public static class Cálculos
    {
       public static string IDPadleft(int codigo)
        {
            return codigo.ToString().PadLeft(4, '0');
        }
        public static void ValidarNumeros(KeyPressEventArgs e)
        {
            string s = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            if (Regex.IsMatch(e.KeyChar.ToString(), "^([\\d]|[\\b])$"))
            {
                e.Handled = false;
            }
            else if (char.IsPunctuation(e.KeyChar))
            {
                e.KeyChar = char.Parse(s);
            }
            else
            {
                e.Handled = true;
            }

        }
        public static bool ValidarDecimal(string numero)
        {
            return Regex.IsMatch(numero, "^(0*[1-9]\\d{0,15}|0+)(\\.\\d\\d)|(\\.\\d)?$");
        }
        public static void ValidarLetras(KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), "^([\\w]|[\\b]|[\\s])$"))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
        public static void ValidarEntero(KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), "^([0-9]|[\\b])"))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static bool ValidarMail(string mail)
        {
            return Regex.IsMatch(mail, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
        }
        public static bool LargoDNI(string dni)
        {
            return Regex.IsMatch(dni, "^([0-9]{8,8})");
        }
        public static bool ValidarNombrePersonal(string nombre)
        {
            return Regex.IsMatch(nombre, "([a-zA-Z]|[0-9])$");
        }
        public static bool ValidarApellido(string apellido)
        {
            return Regex.IsMatch(apellido, "([\\w0-9'°\\s])$");
        }
        public static void BorrarCampos(Control grp)
        {
            foreach (Control c in grp.Controls)
            {
                if (c is TextBox)
                {
                    TextBox text = c as TextBox;
                    text.Text = null;
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown num = c as NumericUpDown;
                    num.Value = 0;
                }
                else if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    combo.Text = null;
                }
                else if (c is CheckBox)
                {
                    CheckBox check = c as CheckBox;
                    check.Checked = false;
                }
            }
        }
        public static bool Camposvacios(Control grp)
        {
            int sino = 0;
            foreach (Control c in grp.Controls)
            {
                if (c is TextBox)
                {
                    TextBox text = c as TextBox;
                    if (text.Text == "")
                    {
                        sino = 1;
                    }
                }
                else if (c is NumericUpDown)
                {
                    NumericUpDown num = c as NumericUpDown;
                    if (num.Value == 0)
                    {
                        sino = 1;
                    }
                }
                else if (c is ComboBox)
                {
                    ComboBox combo = c as ComboBox;
                    if (combo.Text == "")
                    {
                        sino = 1;
                    }
                }
            }
            return sino == 0;
        }
        public static void RefreshGrilla(DataGridView dgv, object refObject)
        {
            dgv.DataSource = null;
            dgv.DataSource = refObject;
        }
        public static void GrillaEnBlanco(DataGridView dgv)
        {
            dgv.DataSource = null;
        }
        public static void DataSourceCombo(ComboBox combo, object refObject, string DisplayMember)
        {
            combo.DataSource = null;
            combo.DataSource = refObject;
            combo.DisplayMember = DisplayMember;
            combo.SelectedIndex = -1;
            combo.Refresh();

        }
        public static void RefreshTreeView(TreeView tv)
        {
            foreach (TreeNode padre in tv.Nodes)
            {
                foreach (TreeNode hijo in padre.Nodes)
                {
                    if (hijo.Nodes.Count > 0)
                    {
                        foreach(TreeNode nieto in hijo.Nodes)
                        {
                            nieto.ForeColor = nieto.Checked ? Color.ForestGreen : Color.IndianRed;
                        }
                        hijo.Collapse();
                    }
                    else
                    {
                        hijo.ForeColor = hijo.Checked ? Color.ForestGreen : Color.IndianRed;
                    }
                }
                padre.Expand();
            }
        }
        public static void MsgBoxSiExiste(string nombre)
        {
            MessageBox.Show(nombre + " ya existe en la base de datos.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxSiExisteDNI(string nombre)
        {
            MessageBox.Show("El DNI ya existe en la base de datos y no perteneces a " + nombre + ".", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxNoAlta(string nombre)
        {
            MessageBox.Show("No se pudo dar de alta el objeto (" + nombre + "). Intente nuevamente.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxNoMod(string nombre)
        {
            MessageBox.Show("No se pudo modificar el objeto (" + nombre + "). Intente nuevamente.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxNoBaja(string nombre)
        {
            MessageBox.Show("No se pudo dar de baja el objeto (" + nombre + "). Intente nuevamente.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBox(string mensaje)
        {
            MessageBox.Show(mensaje, "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxAlta(string nombre)
        {
            MessageBox.Show(nombre + " ha sido agregado a la base de datos.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxMod(string nombre)
        {
            MessageBox.Show(nombre + " se ha modificado con exito.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxBaja(string nombre)
        {
            MessageBox.Show(nombre + " ha sido eliminado de la base de datos.", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxBajaNegativa(string nombre)
        {
            MessageBox.Show("No se puede dar de baja un objeto activo (" + nombre + ").", "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void Minimizar(Form formulario)
        {
            formulario.WindowState = FormWindowState.Minimized;
        }
        public static void Salir()
        {
            System.Windows.Forms.Application.Exit();
        }
        public static bool EstaSeguro(string objeto, int codigo, string nombre)
        {
            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro que desea " + objeto + ": " + nombre + "\n Numero: " + codigo.ToString() + "?", objeto, MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

