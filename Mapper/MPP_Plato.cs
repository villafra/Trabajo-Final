using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Data;

namespace Mapper
{
    public class MPP_Plato : IGestionable<BE_Plato>
    {
        Xml_Database Acceso;
        public bool Baja(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BE_Plato plato)
        {
            throw new NotImplementedException();
        }

        public List<BE_Plato> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Plato> listaPlatos = (from platos in ds.Tables["Plato"].AsEnumerable()
                                          select new BE_Plato
                                          {
                                              Codigo = Convert.ToInt32(platos[0]),
                                              Nombre = Convert.ToString(platos[1]),
                                              Tipo = Convert.ToString(platos[2]),
                                              Clase = Convert.ToString(platos[3]),
                                              Status = Convert.ToString(platos[4]),
                                              CostoUnitario = Convert.ToDecimal(platos[5]),
                                              Activo = Convert.ToBoolean(platos[6])
                                          }).ToList<BE_Plato>();
            return listaPlatos;
        }

        public BE_Plato ListarObjeto(BE_Plato plato)
        {
            throw new NotImplementedException();
        }
    }
}
