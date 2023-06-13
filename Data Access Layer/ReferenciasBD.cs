using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public static class ReferenciasBD
    {
        private static string CarpetaBD = "Base de Datos";
        private static string CarpetaBackUp = "BackUp";
        private static string BasedeDatos = "Restaurant.xml";
        private static string BaseDatosLog = "Logs.xml";
        private static string BaseDatosBackup = "Backups.xml";
        private static string Agenda = "Agenda.xml";
        private static string CarpetaRollBack = $"C:\\Users\\Public\\Documents";
        private static string RollBack = "Rollback.xml";
        private static string NodoRoot = "Restaurant";
        
        private static List<string> Leafs = new List<string>
        {
            "Bebidas",
            "Clientes",
            "Compras",
            "Empleados",
            "Ingredientes",
            "Mesas",
            "Ordenes",
            "Pagos",
            "Pedidos",
            "Platos",
            "Reservas",
            "Bebidas-Ingredientes",
            "Bebidas-Clientes",
            "Platos-Clientes",
            "Reservas-Clientes",
            "Mozo-Pedidos",
            "Ordenes-Pendientes",
            "Platos-Pedidos",
            "Bebidas-Pedidos",
            "Ingredientes-Platos",
            "Calendarios"
        };

        public static string BaseDatosRestaurant
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBD))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, BasedeDatos);
                }
                else return BasedeDatos;
            }
        }

        public static string BaseDatosBackups
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBackUps))
                {
                    if (!Directory.Exists(CarpetaBackUps)) Directory.CreateDirectory(CarpetaBackUps);
                    return Path.Combine(CarpetaBackUps, BaseDatosBackup);
                }
                else return BasedeDatos;
            }
        }

        public static string CarpetaBackUps
        {
            get
            {
                if (!Directory.Exists(CarpetaBackUp)) Directory.CreateDirectory(CarpetaBackUp);
                return CarpetaBackUp;
            }
        }
        public static string DirectorioBD
        {
            get
            {
                if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                return CarpetaBD;
            }
        }

        public static string BaseDatosLogs
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(CarpetaBD))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, BaseDatosLog);
                }
                else return BaseDatosLog;
            }
        }

        public static string Calendario
        {
            get
            {
                if (!string.IsNullOrEmpty(Agenda))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, Agenda);
                }
                else return Agenda;
            }
        }

        public static List<string> ArmaBD { get { return Leafs; } }
        public static string ArchivoRollBack { get { return Path.Combine(CarpetaRollBack, RollBack); } }
        public static string DirectorioRollBack { get { return CarpetaRollBack; } }
        public static string Root { get { return NodoRoot; } }
    }
}
