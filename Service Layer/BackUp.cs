using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Business_Logic_Layer;

namespace Service_Layer
{
    public class BackUp
    {
        public static void CrearBackUp(BE_Login usuario)
        {
            DateTime fecha = DateTime.Now;
            string path = @"restaurant";
            string pathzip = @".backups/" + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss") + ".zip";
            ZipFile.CreateFromDirectory(path, pathzip);
            BE_BackUp oBE_BackUp = new BE_BackUp();
            oBE_BackUp.NombreArchivo = pathzip.Substring(10);
            oBE_BackUp.NombreUsuario = usuario.ToString();
            BLL_BackUp oBLL_Backup = new BLL_BackUp();
            oBLL_Backup.Guardar(oBE_BackUp);
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
        }
    }
}
