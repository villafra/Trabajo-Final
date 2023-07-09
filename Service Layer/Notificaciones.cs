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
    //public static class Notificaciones
    //{
    //    private static NotifyIcon notificacion = new NotifyIcon();
    //    private static FileSystemWatcher fileWatcher = new FileSystemWatcher();
    //    private static List<Pedido> CantLiberados;
    //    public static void IniciarNotificaciones()
    //    {
    //        notificacion.Icon = SystemIcons.Information;
    //        notificacion.Visible = true;
    //        notificacion.Click += NotifyIcon_Click;
    //    }
    //    public static void IniciarFileWatcher()
    //    {
    //        fileWatcher.Path = Path.GetDirectoryName(ReferenciasBD.BaseDatosRestaurant);
    //        fileWatcher.Filter = Path.GetFileName(ReferenciasBD.BaseDatosRestaurant);
    //        fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime;
    //        fileWatcher.Created += FileWatcher_Created;
    //        fileWatcher.Changed += FileWatcher_Changed;
    //        fileWatcher.EnableRaisingEvents = true;
    //        RecolectarDatos();
    //    }

    //    private static void FileWatcher_Changed(object sender, FileSystemEventArgs e)
    //    {
    //        VerLiberados();
    //    }

    //    private static void FileWatcher_Created(object sender, FileSystemEventArgs e)
    //    {
    //        VerLiberados();
    //    }

    //    private static void NotifyIcon_Click(object sender, EventArgs e)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    private static void VerLiberados()
    //    {
    //        DataSet ds = Xml_Database.DevolverInstancia().Listar();
    //        List<Pedido> Actualizacion = (from ped in ds.Tables["Pedido"].AsEnumerable()
    //                                      where ped[4].ToString() == "Liberado"
    //                                      select new Pedido
    //                                      {
    //                                          Codigo = Convert.ToInt32(ped[0]),
    //                                          Status = ped[4].ToString()

    //                                      }).ToList();
    //        List<Pedido> Comparacion = CantLiberados.Except(Actualizacion).ToList();
    //        if (Comparacion.Count > 0 && Comparacion.Count < 2)
    //        {
    //            notificacion.BalloonTipTitle = "Pedido Liberado";
    //            notificacion.BalloonTipText = "Se ha creado un nuevo pedido.";
    //            notificacion.ShowBalloonTip(3000);
    //        }
    //        else if (Comparacion.Count > 2)
    //        {
    //            notificacion.BalloonTipTitle = "Pedidos Liberados";
    //            notificacion.BalloonTipText = "Hay nuevos pedidos liberados.";
    //            notificacion.ShowBalloonTip(3000);
    //        }

    //    }
    //    private static void RecolectarDatos()
    //    {
    //        DataSet ds = Xml_Database.DevolverInstancia().Listar();

    //        CantLiberados = (from ped in ds.Tables["Pedido"].AsEnumerable()
    //                         where ped[4].ToString() == "Liberado"
    //                         select new Pedido
    //                         {
    //                             Codigo = Convert.ToInt32(ped[0]),
    //                             Status = ped[4].ToString()

    //                         }).ToList();   
    //    }
    //    protected class Pedido
    //    {
    //        public int Codigo { get; set; }
    //        public string Status;

    //    }

    //}
   
}
