using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Business_Entities;

namespace Service_Layer
{
    public class BackUp
    {
        public static bool CrearBackUp(BE_Login usuario)
        {
            DateTime fecha = DateTime.Now;
            string path = @"restaurant";
            string pathzip = @".backups/" + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss") + ".zip";
            ZipFile.CreateFromDirectory(path, pathzip);
            BE_BackUp oBE_BackUp = new BE_BackUp();
            oBE_BackUp.NombreArchivo = pathzip.Substring(10);
            oBE_BackUp.NombreUsuario = usuario.ToString();
            return  Guardar(oBE_BackUp);
        }

        public static void Restore(string nombreArchivo)
        {
            DateTime fecha = DateTime.Now;
            string path = @"restaurant";
            string pathzip = @"/backups/" + nombreArchivo + "";
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            foreach(System.IO.FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            ZipFile.ExtractToDirectory(pathzip, path);
            Restaurar(nombreArchivo);
        }
        private static bool Guardar(BE_BackUp bkp)
        {
            try
            {
                XmlSerializer serial = new XmlSerializer(typeof(BE_BackUp));
                using (StreamWriter writer = new StreamWriter(@".backups/" + bkp.NombreArchivo))
                {
                    serial.Serialize(writer, bkp);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        private static  BE_BackUp Restaurar(string nombreArchivo)
        {
            BE_BackUp Usuario = new BE_BackUp();
            XmlSerializer serial = new XmlSerializer(typeof(BE_BackUp));
            using (StreamReader reader = new StreamReader(@".backups/" + nombreArchivo))
            {
                Usuario = (BE_BackUp)serial.Deserialize(reader);
            }
            return Usuario;
        }
    }
}
