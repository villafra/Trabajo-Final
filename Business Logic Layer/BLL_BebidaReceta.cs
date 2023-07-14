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
    public class BLL_BebidaReceta 
    {
        public bool Baja(List<BE_BebidaReceta> BebidaReceta)
        {
            return MPP_BebidaReceta.DevolverInstancia().Baja(BebidaReceta); 
        }

        public bool Guardar(List<BE_BebidaReceta> BebidaReceta)
        {
            return MPP_BebidaReceta.DevolverInstancia().Guardar(BebidaReceta);
        }

        public List<BE_BebidaReceta> Listar()
        {
            return MPP_BebidaReceta.DevolverInstancia().Listar();
        }

        public List<BE_BebidaReceta> ListarObjeto(BE_Bebida Bebida, BE_BebidaReceta alternativa, DataSet ds = null)
        {
            return MPP_BebidaReceta.DevolverInstancia().ListarObjeto(Bebida, alternativa);
        }
        public List<BE_BebidaReceta> ListarAlternativasDataSource(BE_Bebida bebida)
        {
            return MPP_BebidaReceta.DevolverInstancia().ListarAlternativasDataSource(bebida);
        }
        public BE_BebidaReceta ListarAlternativaVigente(BE_Bebida bebida)
        {
            return MPP_BebidaReceta.DevolverInstancia().ListarAlternativaVigente(bebida);
        }
        public List<BE_BebidaReceta> BebidaEnOrden(BE_Bebida bebida)
        {
            return MPP_BebidaReceta.DevolverInstancia().BebidaEnOrden(bebida);
        }
        public bool Modificar(List<BE_BebidaReceta> BebidaReceta)
        {
            return MPP_BebidaReceta.DevolverInstancia().Modificar(BebidaReceta);
        }
        public bool Consumir(List<BE_BebidaReceta> bebidas, decimal cantidad)
        {
            foreach (BE_BebidaReceta bebida in bebidas)
            {
                decimal descontar = cantidad * bebida.Cantidad / 100;
                List<BE_Material_Stock> listado = MPP_Material_Stock.DevolverInstancia().ListarConStock(bebida.Ingrediente);
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
