using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;

namespace Service_Layer
{
    public static class GuardaFotos
    {
        public static string AbrirImágen()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.png;*.jpg;*.jpeg;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return string.Empty;
        }

        public static bool GuardarImagen(string rutaFoto, string nombre)
        {
            try
            {
            string nombreArchivo = Path.Combine(ReferenciasBD.CarpetaFotos, nombre + Path.GetExtension(rutaFoto));
            File.Copy(rutaFoto, nombreArchivo, true);
                return true;
            }
            catch { return false; throw new Exception(); }
        }
        public static void CargarImagen(string nombre, Button btn)
        {
            string[] archivos = Directory.GetFiles(ReferenciasBD.CarpetaFotos, nombre + ".*");
            if (archivos.Length > 0)
            {
                btn.BackgroundImage = Image.FromFile(archivos[0]);
            }
        }
    }
}
