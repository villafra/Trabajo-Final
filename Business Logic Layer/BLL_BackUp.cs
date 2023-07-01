using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;
using Business_Entities;
using System.Xml.Serialization;
using System.IO;
using Service_Layer;

namespace Business_Logic_Layer
{
    public class BLL_BackUp
    {

        public bool CrearBackUp(BE_Login UsuarioActivo)
        {
            return BackUp.CrearBackUp(UsuarioActivo);
        }
        public bool RestaurarBackUp(BE_Login UsuarioActivo, string nombreArchivo)
        {
            return BackUp.Restore(UsuarioActivo, nombreArchivo);
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

    }
}
