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
        public bool RollBack(BE_Login UsuarioActivo)
        {
            return BackUp.RollBack(UsuarioActivo);
        }
        public List<BE_BackUp> Listar()
        {
            return BackUp.ListarBackUps();
        }

    }
}
