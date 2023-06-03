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
                if (!string.IsNullOrWhiteSpace(CarpetaBD))
                {
                    if (!Directory.Exists(CarpetaBD)) Directory.CreateDirectory(CarpetaBD);
                    return Path.Combine(CarpetaBD, BaseDatosBackup);
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
    }
}
