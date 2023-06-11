using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Business_Entities;
using Data_Access_Layer;


namespace Service_Layer
{
    public class BackUp
    {
        public static bool CrearBackUp(BE_Login usuario)
        {
            DateTime fecha = DateTime.Now;
            string path = ReferenciasBD.DirectorioBD;
            string pathzip = Path.Combine(ReferenciasBD.CarpetaBackUps,DateTime.Now.ToString("dd-MM-yyy HH-mm-ss")+ ".zip");
            ZipFile.CreateFromDirectory(path, pathzip);
            BE_BackUp oBE_BackUp = new BE_BackUp();
            oBE_BackUp.NombreArchivo = pathzip.Substring(7);
            oBE_BackUp.NombreUsuario = usuario.ToString();
            return  Guardar(oBE_BackUp);
        }

        public static void Restore(string nombreArchivo)
        {
            DateTime fecha = DateTime.Now;
            string path = ReferenciasBD.DirectorioBD;
            string pathzip = Path.Combine(ReferenciasBD.CarpetaBackUps, nombreArchivo);
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
                using (StreamWriter writer = new StreamWriter(ReferenciasBD.BaseDatosBackups))
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
            XDocument logs = XDocument.Load(ReferenciasBD.BaseDatosBackups);
            XElement bkp = logs.Element("BE_BackUp").Descendants("NombreArchivo").FirstOrDefault(x => x.Value == nombreArchivo).AncestorsAndSelf("BE_BackUp").FirstOrDefault();
            XmlSerializer serial = new XmlSerializer(typeof(BE_BackUp));
            using (XmlReader reader = bkp.CreateReader())
            {
                Usuario = (BE_BackUp)serial.Deserialize(reader);
            }
            return Usuario;
        }
    }
}
