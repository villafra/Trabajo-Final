using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;
using Abstraction_Layer;
using System.Data;

namespace Business_Logic_Layer
{
    public class BLL_PlatoReceta 
    {
        public bool Baja(List<BE_PlatoReceta> PlatoReceta)
        {
            return MPP_PlatoReceta.DevolverInstancia().Baja(PlatoReceta); 
        }

        public bool Guardar(List<BE_PlatoReceta> PlatoReceta)
        {
            return MPP_PlatoReceta.DevolverInstancia().Guardar(PlatoReceta);
        }

        public List<BE_PlatoReceta> Listar()
        {
            return MPP_PlatoReceta.DevolverInstancia().Listar();
        }

        public List<BE_PlatoReceta> ListarObjeto(BE_Plato Plato, BE_PlatoReceta alternativa, DataSet ds = null)
        {
            return MPP_PlatoReceta.DevolverInstancia().ListarObjeto(Plato, alternativa);
        }
        public List<BE_PlatoReceta> ListarAlternativasDataSource(BE_Plato Plato)
        {
            return MPP_PlatoReceta.DevolverInstancia().ListarAlternativasDataSource(Plato);
        }
        public bool Modificar(List<BE_PlatoReceta> PlatoReceta)
        {
            return MPP_PlatoReceta.DevolverInstancia().Modificar(PlatoReceta);
        }
    }
}
