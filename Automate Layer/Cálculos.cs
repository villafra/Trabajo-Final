using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using System;

namespace Automate_Layer
{
    public static class Cálculos
    {
       public static string IDPadleft(int codigo)
        {
            return codigo.ToString().PadLeft(4, '0');
        }
        public static string Capitalize (string texto)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string Capitalizacion = textInfo.ToTitleCase(texto);
            return Capitalizacion;
        }
        public static string Descapitalize(string texto)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string Capitalizacion = textInfo.ToLower(texto);
            return Capitalizacion;
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
            return Regex.IsMatch(dni, "^([0-9]{8})");
        }
        public static bool ValidarNombrePersonal(string nombre)
        {
            return Regex.IsMatch(nombre, @"^[a-zA-Z0-9 ]+$");
        }
        public static bool ValidarApellido(string apellido)
        {
            return Regex.IsMatch(apellido, @"^[\w\d°]+$");

        }
        public static bool ValidarEdad(DateTime nac)
        {
            DateTime fechaActual = DateTime.Today;
            DateTime fechaMayorEdad = nac.AddYears(18);

            return fechaMayorEdad <= fechaActual;
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
                if (c.Visible)
                {

                    if (c is TextBox)
                    {
                        TextBox text = c as TextBox;
                        if (text.Name != "txtCodigo")
                        {
                            if (text.Text == "")
                            {
                                sino = 1;
                            }
                        }
                    }
                    else if (c is NumericUpDown)
                    {
                        NumericUpDown num = c as NumericUpDown;
                        if (num.Name != "numABV")
                        {
                            if (num.Value == 0)
                            {
                                sino = 1;
                            }
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
            RecursivaTreeView(tv.Nodes);
            foreach(TreeNode nodo in tv.Nodes)
            {
                nodo.Expand();
            }
        }
  
        public static object GetPropertyValue(object obj, string propertyName)
        {
            PropertyInfo propertyInfo;
            if (propertyName != "")
            {
                propertyInfo = obj.GetType().GetProperty(propertyName);
            }
            else
            {
                propertyInfo = obj.GetType().GetProperty("Codigo");
            }
            return propertyInfo.GetValue(obj);
        }
        private static void RecursivaTreeView(TreeNodeCollection nodos)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (nodo.Nodes.Count > 0) RecursivaTreeView(nodo.Nodes);
                else nodo.ForeColor = nodo.Checked ? Color.ForestGreen : Color.IndianRed;
            }
        }
        public static void MsgBox(string mensaje)
        {
            MessageBox.Show(mensaje, "Restó", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void Minimizar(Form formulario)
        {
            formulario.WindowState = FormWindowState.Minimized;
        }
        public static void Salir()
        {
            System.Windows.Forms.Application.Exit();
        }
        public static bool EstaSeguroA(string v1, string v2)
        {
            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro que desea modificar el status de la alternativa: " + v2 + "\npara " + v1 + "?" , "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) return true;
            else return false;
        }

        public static bool EstaSeguroM(string objeto)
        {
            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro que desea modificar a: " + objeto + "?","Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) return true;
            else return false;
        }
        public static bool EstaSeguroE(string objeto)
        {
            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro que desea eliminar a: " + objeto + "?", "Eliminar", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) return true;
            else return false;
        }
        public static bool EstaSeguroBackUp(string accion)
        {
            DialogResult resultado = MessageBox.Show(@"Esta seguro que desea realizar un " + accion + "?","Gestion BackUp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) return true;
            else return false;
        }
        public static bool EstaSeguroBackUp()
        {
            DialogResult resultado = MessageBox.Show(@"Esta seguro que desea importar una base de datos?", "Gestion BackUp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) return true;
            else return false;
        }
        public static bool CambiarPass(string pass)
        {
            DialogResult resultado = MessageBox.Show(@"La nueva contraseña será: " + pass + ". Tome nota.", "Restó", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK) return true;
            else return false;
        }
        public static bool CargarFoto(string nombre)
        {
            DialogResult resultado = MessageBox.Show(@"Esta seguro de agregar una imágen a " + nombre +"?", "Restó", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultado == DialogResult.OK) return true;
            else return false;
        }
    }
}

