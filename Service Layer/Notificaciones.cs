using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Data_Access_Layer;
using System.Data;

namespace Service_Layer
{
    public static class Notificaciones
    {
        private static NotifyIcon notificacion;
        private static FileSystemWatcher fileWatcher;
        private static List<int> notificaciones;
        public static void IniciarNotificaciones()
        {
            notificacion.Icon = SystemIcons.Information;
            notificacion.Visible = true;
            notificacion.Click += NotifyIcon_Click;
        }
        public static void IniciarFileWatcher()
        {
            fileWatcher.Path = Path.GetDirectoryName(ReferenciasBD.BaseDatosRestaurant);
            fileWatcher.Filter = Path.GetFileName(ReferenciasBD.BaseDatosRestaurant);
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
            fileWatcher.Created += FileWatcher_Created;
            fileWatcher.Changed += FileWatcher_Changed;
            fileWatcher.EnableRaisingEvents = true;
        }

        private static void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            VerLiberados();
        }

        private static void FileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            VerLiberados();
        }

        private static void NotifyIcon_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void VerLiberados()
        {
            DataSet ds = Xml_Database.DevolverInstancia().Listar();
            

        }
    }
}
