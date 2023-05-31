using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using System.Xml.Serialization;
using System.IO;

namespace Business_Logic_Layer
{
    public class BLL_BackUp : IGestionable<BE_BackUp>
    {
        public bool Baja(BE_BackUp bkp)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_BackUp bkp)
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

        public BE_BackUp ListarObjeto(string nombreArchivo)
        {
            BE_BackUp Usuario = new BE_BackUp();
            XmlSerializer serial = new XmlSerializer(typeof(BE_BackUp));
            using (StreamReader reader = new StreamReader(@".backups/" + nombreArchivo))
            {
                Usuario = (BE_BackUp)serial.Deserialize(reader);
            }
            return Usuario;
        }

        public List<BE_BackUp> Listar()
        {
            throw new NotImplementedException();
        }

        public BE_BackUp ListarObjeto(BE_BackUp bkp)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_BackUp bkp)
        {
            throw new NotImplementedException();
        }
    }
}
