using System;
using System.Collections.Generic;
using System.Data;
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
            string pathzip = Path.Combine(ReferenciasBD.CarpetaBackUps, DateTime.Now.ToString("dd-MM-yyy HH-mm-ss") + ".zip");
            ZipFile.CreateFromDirectory(path, pathzip);
            BE_BackUp oBE_BackUp = new BE_BackUp();
            oBE_BackUp.Codigo = usuario.ToString() + " " + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss");
            oBE_BackUp.NombreArchivo = pathzip.Substring(7);
            oBE_BackUp.NombreUsuario = usuario.ToString();
            oBE_BackUp.Accion = TipoBKP.BackUp.ToString();
            oBE_BackUp.FechaHora = fecha;
            return Guardar(oBE_BackUp);
        }

        public static bool Restore(BE_Login usuario, string nombreArchivo)
        {
            try
            {
                string path = ReferenciasBD.DirectorioBD;
                string pathzip = Path.Combine(ReferenciasBD.CarpetaBackUps, nombreArchivo);
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
                foreach (System.IO.FileInfo file in directory.GetFiles())
                {
                    file.CopyTo(ReferenciasBD.ArchivoRollBack, true);
                    file.Delete();
                }
                ZipFile.ExtractToDirectory(pathzip, path);
                BE_BackUp oBE_BackUp = new BE_BackUp();
                oBE_BackUp.NombreArchivo = pathzip.Substring(7);
                oBE_BackUp.NombreUsuario = usuario.ToString();
                oBE_BackUp.Accion = TipoBKP.Restore.ToString();
                oBE_BackUp.FechaHora = DateTime.Now;
                Guardar(oBE_BackUp);
                Restaurar(nombreArchivo);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }

        public static void RollBack(BE_Login usuario)
        {
            string path = ReferenciasBD.DirectorioRollBack;
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            foreach (System.IO.FileInfo file in directory.GetFiles("RollBack.xml"))
            {
                file.CopyTo(ReferenciasBD.BaseDatosRestaurant, true);
                file.Delete();
            }
            BE_BackUp oBE_BackUp = new BE_BackUp();
            oBE_BackUp.NombreArchivo = "RollBack.xml";
            oBE_BackUp.NombreUsuario = usuario.ToString();
            oBE_BackUp.Accion = TipoBKP.Restore.ToString();
            oBE_BackUp.FechaHora = DateTime.Now;
            Guardar(oBE_BackUp);
        } 
        public static List<BE_BackUp> ListarBackUps()
        {
            DataSet ds = Listar();
            List<BE_BackUp> listado;
            if (ds != null)
            {
                listado = (from bk in ds.Tables["BackUp"].AsEnumerable()
                           select new BE_BackUp
                           {
                               Codigo = bk[0].ToString(),
                               NombreArchivo = bk[1].ToString(),
                               NombreUsuario = bk[2].ToString(),
                               Accion = bk[3].ToString(),
                               FechaHora = Convert.ToDateTime(bk[4])
                           }
                           ).ToList();
            }
            else { listado = null; }
            return listado;
        }
        private static bool Guardar(BE_BackUp bkp)
        {
            try
            {
                if (!File.Exists(ReferenciasBD.BaseDatosBackups))
                {
                    XDocument BDBackUp = new XDocument();
                    XElement Root = new XElement(ReferenciasBD.RootBKP);
                    XElement Leaf = new XElement("BackUp",
                        new XElement("Codigo", bkp.Codigo),
                        new XElement("NombreArchivo", bkp.NombreArchivo),
                        new XElement("NombreUsuario", bkp.NombreUsuario),
                        new XElement("Accion", bkp.Accion),
                        new XElement("FechaHora", bkp.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
                        );
                    Root.Add(Leaf);
                    Root.Save(ReferenciasBD.BaseDatosBackups);
                }
                else
                {
                    XDocument logs = XDocument.Load(ReferenciasBD.BaseDatosBackups);
                    logs.Root.Add(new XElement("BackUp",
                        new XElement("Codigo", bkp.Codigo),
                        new XElement("NombreArchivo", bkp.NombreArchivo),
                        new XElement("NombreUsuario", bkp.NombreUsuario),
                        new XElement("Accion",bkp.Accion),
                        new XElement("FechaHora", bkp.FechaHora.ToString("dd/MM/yyyy HH:mm:ss"))
                        ));
                    logs.Save(ReferenciasBD.BaseDatosBackups);
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
        private static DataSet Listar()
        {
            DataSet ds = new DataSet();
            if (ExisteBD()) ds.ReadXml(ReferenciasBD.BaseDatosBackups, XmlReadMode.Auto);
            else ds = null;
            return ds;
        }
        private static bool ExisteBD()
        {
            return File.Exists(ReferenciasBD.BaseDatosBackups);
           
        }
        private enum TipoBKP
        {
            BackUp,
            Restore,
            RollBack
        }
    }
}
