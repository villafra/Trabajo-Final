using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;
using System.Data;

namespace Business_Logic_Layer
{
    public class BLL_Compra : IGestionable<BE_Compra>
    {
       
        public bool Baja(BE_Compra compra)
        {
            return MPP_Compra.DevolverInstancia().Baja(compra);
        }

        public bool Guardar(BE_Compra compra)
        {
            return MPP_Compra.DevolverInstancia().Guardar(compra);
        }

        public List<BE_Compra> Listar()
        {
            return MPP_Compra.DevolverInstancia().Listar();
        }

        public BE_Compra ListarObjeto(BE_Compra compra, DataSet ds = null)
        {
            return MPP_Compra.DevolverInstancia().ListarObjeto(compra);
        }

        public bool recepcionarCompra(long nroCompra)
        {
            throw new NotImplementedException();
        }

        public object ListarFiltro(StausComp status)
        {
            return MPP_Compra.DevolverInstancia().ListarFiltro(status);
        }

        public BE_Compra devolverCompra(long nroCompra)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Compra compra)
        {
            return MPP_Compra.DevolverInstancia().Modificar(compra);
        }
        public decimal CalcularCostoNeto(BE_Compra compra)
        {
            decimal costo;
            if (compra is BE_CompraIngrediente)
            {
                costo = MPP_Costo.DevolverInstancia().DevolverCosto(((BE_CompraIngrediente)compra).ID_Material, compra.CantidadRecibida);
            }
            else
            {
                costo = MPP_Costo.DevolverInstancia().DevolverCosto(((BE_CompraBebida)compra).ID_Material, compra.CantidadRecibida);
            } 
            return costo;
        }
        public decimal CalcularCostoTeorico(BE_Compra compra)
        {
            decimal costo;
            if (compra is BE_CompraIngrediente)
            {
                costo = MPP_Costo.DevolverInstancia().DevolverCosto(((BE_CompraIngrediente)compra).ID_Material, compra.Cantidad);
            }
            else
            {
                costo = MPP_Costo.DevolverInstancia().DevolverCosto(((BE_CompraBebida)compra).ID_Material, compra.Cantidad);
            }
            return costo;
        }
    }
}
