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
        public BE_PlatoReceta ListarAlternativaVigente(BE_Plato plato)
        {
            return MPP_PlatoReceta.DevolverInstancia().ListarAlternativaVigente(plato);
        }
        public List<BE_PlatoReceta> PlatoEnOrden(BE_Plato plato)
        {
            return MPP_PlatoReceta.DevolverInstancia().PlatoEnOrden(plato);
        }
        public bool Modificar(List<BE_PlatoReceta> PlatoReceta)
        {
            return MPP_PlatoReceta.DevolverInstancia().Modificar(PlatoReceta);
        }
        public bool Consumir(List<BE_PlatoReceta> platos, decimal cantidad)
        {
            foreach (BE_PlatoReceta plato in platos)
            {
                decimal descontar = cantidad * plato.Cantidad / 100;
                List<BE_Material_Stock> listado = MPP_Material_Stock.DevolverInstancia().ListarConStock(plato.Ingrediente);
                foreach (BE_Material_Stock ing in listado)
                {
                    if (descontar <= 0) break;
                    if (ing.Stock >= descontar)
                    {
                        ing.Stock -= descontar;
                        descontar = 0;
                    }
                    else
                    {
                        descontar -= ing.Stock;
                        ing.Stock = 0;
                    }
                }
                MPP_Material_Stock.DevolverInstancia().Modificar(listado);
            }
            return true;
        }
    }
}
