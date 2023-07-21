using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            string[] XMLDB = BuscarXML();
            if (XMLDB.Length > 0)
            {
                using (ZipArchive zip = ZipFile.Open(pathzip, ZipArchiveMode.Create))
                {
                    foreach (string archivo in XMLDB)
                    {
                        zip.CreateEntryFromFile(archivo, Path.GetFileName(archivo));
                    }
                }
            }
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
                bool ok = false;

                string path = ReferenciasBD.DirectorioBD;
                string pathzip = Path.Combine(ReferenciasBD.CarpetaBackUps, nombreArchivo);
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
                foreach (System.IO.FileInfo file in directory.GetFiles())
                {
                    if (file.Name == ReferenciasBD.NombreBD)
                    {
                        file.CopyTo(ReferenciasBD.ArchivoRollBack, true);
                        file.Delete();
                    }
                }
                ZipFile.ExtractToDirectory(pathzip, path);
                BE_BackUp oBE_BackUp = new BE_BackUp();
                oBE_BackUp.Codigo = usuario.ToString() + " " + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss");
                oBE_BackUp.NombreArchivo = pathzip.Substring(7);
                oBE_BackUp.NombreUsuario = usuario.ToString();
                oBE_BackUp.Accion = TipoBKP.Restore.ToString();
                oBE_BackUp.FechaHora = DateTime.Now;
                if (Guardar(oBE_BackUp)) ok = true;
                Restaurar(nombreArchivo);
                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool RollBack(BE_Login usuario)
        {
            try
            {

                string path = ReferenciasBD.DirectorioRollBack;
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
                bool existe = false;
                foreach (System.IO.FileInfo file in directory.GetFiles("RollBack.xml"))
                {
                    file.CopyTo(ReferenciasBD.BaseDatosRestaurant, true);
                    file.Delete();
                    existe = true;
                   
                }
                if (existe)
                {
                    BE_BackUp oBE_BackUp = new BE_BackUp();
                    oBE_BackUp.Codigo = usuario.ToString() + " " + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss");
                    oBE_BackUp.NombreArchivo = "RollBack";
                    oBE_BackUp.NombreUsuario = usuario.ToString();
                    oBE_BackUp.Accion = TipoBKP.RollBack.ToString();
                    oBE_BackUp.FechaHora = DateTime.Now;
                    return Guardar(oBE_BackUp);
                }
                else { throw new RestaurantException("No existe archivo para hacer Rollback"); }
                
            }
            catch (Exception ex) { throw ex; }
        }
        public static bool ImportarArchivo(BE_Login usuario)
        {
            string pathzip = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos ZIP (*.zip)|*.zip";
                openFileDialog.Title = "Seleccionar archivo de respaldo";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pathzip = openFileDialog.FileName;
                }
            }

            if (!string.IsNullOrEmpty(pathzip))
            {
                using (ZipArchive archive = ZipFile.OpenRead(pathzip))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name.Equals("Restaurant.xml", StringComparison.OrdinalIgnoreCase))
                        {
                            DialogResult resultado = MessageBox.Show("Quiere importar esta base de datos?", "Restó", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado.Equals(DialogResult.Yes))
                            {
                                string path = ReferenciasBD.DirectorioBD;
                                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
                                foreach (System.IO.FileInfo file in directory.GetFiles("RollBack.xml"))
                                {
                                    file.CopyTo(ReferenciasBD.BaseDatosRestaurant, true);
                                    file.Delete();
                                }
                                ZipFile.ExtractToDirectory(pathzip, path);
                                BE_BackUp oBE_BackUp = new BE_BackUp();
                                oBE_BackUp.Codigo = usuario.ToString() + " " + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss");
                                oBE_BackUp.NombreArchivo = "Archivo Importado";
                                oBE_BackUp.NombreUsuario = usuario.ToString();
                                oBE_BackUp.Accion = TipoBKP.Restore.ToString();
                                oBE_BackUp.FechaHora = DateTime.Now;
                                return Guardar(oBE_BackUp);
                            }
                            else { throw new Exception("Se ha cancelado la importación"); }
                        }
                    }
                }
            }

            return false;
        }
        public static List<BE_BackUp> ListarBackUps()
        {
            DataSet ds = Listar();
            List<BE_BackUp> listado;
            if (ds != null)
            {
                listado = ds.Tables.Contains("BackUp") != false ? (from bk in ds.Tables["BackUp"].AsEnumerable()
                           select new BE_BackUp
                           {
                               Codigo = bk[0].ToString(),
                               NombreArchivo = bk[1].ToString(),
                               NombreUsuario = bk[2].ToString(),
                               Accion = bk[3].ToString(),
                               FechaHora = Convert.ToDateTime(bk[4])
                           }
                           ).ToList(): null ;
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
                throw ex;
            }

        }
        private static  BE_BackUp Restaurar(string nombreArchivo)
        {
            BE_BackUp Usuario = new BE_BackUp();
            XDocument logs = XDocument.Load(ReferenciasBD.BaseDatosBackups);
            XElement bkp = logs.Root.Elements("BackUp").Descendants("NombreArchivo").FirstOrDefault(x => x.Value == nombreArchivo).AncestorsAndSelf("BackUp").FirstOrDefault();
            Usuario.Codigo = bkp.Element("Codigo").Value;
            Usuario.NombreArchivo = bkp.Element("NombreArchivo").Value;
            Usuario.NombreUsuario = bkp.Element("NombreUsuario").Value;
            Usuario.Accion = ((TipoBKP)Enum.Parse(typeof(TipoBKP), bkp.Element("Accion").Value)).ToString();
            Usuario.FechaHora = Convert.ToDateTime(bkp.Element("FechaHora").Value);
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
        private static string[] BuscarXML()
        {
            string[] archivos = Directory.GetFiles(ReferenciasBD.DirectorioBD, "Restaurant.xml", SearchOption.TopDirectoryOnly);
            return archivos;
        }
        private enum TipoBKP
        {
            BackUp,
            Restore,
            RollBack
        }
    }
}
