using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Data_Access_Layer;
using System.Xml.Linq;
using System.Data;
using Automate_Layer;

namespace Mapper
{
    public class MPP_Costo : IGestionable<BE_Costo>
    {
        Xml_Database Acceso;
        List<BE_TuplaXML> ListadoXML;

        public MPP_Costo()
        {
            ListadoXML = new List<BE_TuplaXML>();
        }

        public bool Baja(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Acceso.Baja(ListadoXML);
        }

        public bool Guardar(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Acceso.Escribir(ListadoXML);
        }

        public List<BE_Costo> Listar()
        {
            Acceso = new Xml_Database();
            DataSet ds = new DataSet();
            ds = Acceso.Listar();

            List<BE_Costo> listado = ds.Tables.Contains("Costo") ? (from cos in ds.Tables["Costo"].AsEnumerable()
                                                                    select cos[7].ToString() == TipoMaterial.Ingrediente.ToString() ?
                                                                        new BE_CostoIngrediente
                                                                        {
                                                                            Codigo = Convert.ToInt32(cos[0]),
                                                                            DíaCosteo = Convert.ToDateTime(cos[1]),
                                                                            TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                                                                            MateriaPrima = Convert.ToDecimal(cos[3]),
                                                                            HorasHombre = Convert.ToDecimal(cos[4]),
                                                                            Energía = Convert.ToDecimal(cos[5]),
                                                                            OtrosGastos = Convert.ToDecimal(cos[6]),
                                                                            Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                                                                            ID_Ingrediente = ds.Tables.Contains("Ingrediente") ? (from ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                  where Convert.ToInt32(cos[8]) == Convert.ToInt32(ing[0])
                                                                                                                                  select new BE_Ingrediente
                                                                                                                                  {
                                                                                                                                      Codigo = Convert.ToInt32(ing[0]),
                                                                                                                                      Nombre = Convert.ToString(ing[1]),
                                                                                                                                      Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                                                                                                                                      Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                                      UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                                                                                                                                      Activo = Convert.ToBoolean(ing[5]),
                                                                                                                                      VidaUtil = Convert.ToInt32(ing[6]),
                                                                                                                                      Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[7])),
                                                                                                                                      GestionLote = Convert.ToBoolean(ing[8])

                                                                                                                                  }).FirstOrDefault() : null
                                                                        } : cos[7].ToString() == TipoMaterial.Plato.ToString() ?
                                                                        (BE_Costo)new BE_CostoPlato
                                                                        {
                                                                            Codigo = Convert.ToInt32(cos[0]),
                                                                            DíaCosteo = Convert.ToDateTime(cos[1]),
                                                                            TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                                                                            MateriaPrima = Convert.ToDecimal(cos[3]),
                                                                            HorasHombre = Convert.ToDecimal(cos[4]),
                                                                            Energía = Convert.ToDecimal(cos[5]),
                                                                            OtrosGastos = Convert.ToDecimal(cos[6]),
                                                                            Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                                                                            ID_Plato = ds.Tables.Contains("Plato") ? (from platos in ds.Tables["Plato"].AsEnumerable()
                                                                                                                      where cos[8].ToString() == platos[0].ToString()
                                                                                                                      select new BE_Plato
                                                                                                                      {
                                                                                                                          Codigo = Convert.ToInt32(platos[0]),
                                                                                                                          Nombre = Convert.ToString(platos[1]),
                                                                                                                          Tipo = (BE_Plato.Tipo_Plato)Enum.Parse(typeof(BE_Plato.Tipo_Plato), Convert.ToString(platos[2])),
                                                                                                                          Clase = (BE_Plato.Clasificación)Enum.Parse(typeof(BE_Plato.Clasificación), Convert.ToString(platos[3])),
                                                                                                                          Status = Convert.ToString(platos[4]),
                                                                                                                          CostoUnitario = Convert.ToDecimal(platos[5]),
                                                                                                                          Activo = Convert.ToBoolean(platos[6]),
                                                                                                                          ListaIngredientes = ds.Tables.Contains("Ingrediente-Plato") && ds.Tables.Contains("Plato") ? (from obj in ds.Tables["Ingrediente-Plato"].AsEnumerable()
                                                                                                                                                                                                                        join ing in ds.Tables["Ingrediente"].AsEnumerable()
                                                                                                                                                                                                           on Convert.ToInt32(obj[1]) equals Convert.ToInt32(platos[0])
                                                                                                                                                                                                                        select new BE_Ingrediente
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            Codigo = Convert.ToInt32(ing[0]),
                                                                                                                                                                                                                            Nombre = Convert.ToString(ing[1]),
                                                                                                                                                                                                                            Tipo = (TipoIng)Enum.Parse(typeof(TipoIng), Convert.ToString(ing[2])),
                                                                                                                                                                                                                            Refrigeracion = Convert.ToBoolean(ing[3]),
                                                                                                                                                                                                                            UnidadMedida = (UM)Enum.Parse(typeof(UM), Convert.ToString(ing[4])),
                                                                                                                                                                                                                            Activo = Convert.ToBoolean(ing[5]),
                                                                                                                                                                                                                            VidaUtil = Convert.ToInt32(ing[6]),
                                                                                                                                                                                                                            Status = (StatusIng)Enum.Parse(typeof(StatusIng), Convert.ToString(ing[8])),
                                                                                                                                                                                                                            CostoUnitario = Convert.ToDecimal(ing[7])
                                                                                                                                                                                                                        }).ToList() : null
                                                                                                                      }).FirstOrDefault() : null
                                                                        } : new BE_CostoBebida
                                                                        {
                                                                            Codigo = Convert.ToInt32(cos[0]),
                                                                            DíaCosteo = Convert.ToDateTime(cos[1]),
                                                                            TamañoLoteCosteo = Convert.ToDecimal(cos[2]),
                                                                            MateriaPrima = Convert.ToDecimal(cos[3]),
                                                                            HorasHombre = Convert.ToDecimal(cos[4]),
                                                                            Energía = Convert.ToDecimal(cos[5]),
                                                                            OtrosGastos = Convert.ToDecimal(cos[6]),
                                                                            Tipo = (TipoMaterial)Enum.Parse(typeof(TipoMaterial), cos[7].ToString()),
                                                                            ID_Bebida = ds.Tables.Contains("Bebida") ? (from beb in ds.Tables["Bebida"].AsEnumerable()
                                                                                                                        where cos[8].ToString() == beb[0].ToString()
                                                                                                                        select new BE_Bebida
                                                                                                                        {
                                                                                                                            
                                                                                                                        }).FirstOrDefault() : null
                                                                        }).ToList() : null;

            return listado;

        }

        public BE_Costo ListarObjeto(BE_Costo Costo)
        {
            throw new NotImplementedException();
        }
        public decimal DevolverCosto(object tipo, decimal cantidad = 1)
        {
            List<BE_Costo> listado = Listar();
            BE_Costo cost;
            decimal costo;
            if (tipo is BE_Ingrediente)
            {
                cost = listado.FindLast(x => ((BE_CostoIngrediente)x).ID_Ingrediente.Codigo == ((BE_Ingrediente)tipo).Codigo);
                costo = cost != null ? cost.DevolverCosto(cantidad) : 0; 
            }
            else if (tipo is BE_Plato)
            {
                cost = listado.FindLast(x => ((BE_CostoPlato)x).ID_Plato.Codigo == ((BE_Plato)tipo).Codigo);
                costo = cost != null ? cost.DevolverCosto(cantidad) : 0;
            }
            else
            {
                cost = listado.FindLast(x => ((BE_CostoBebida)x).ID_Bebida.Codigo == ((BE_Bebida)tipo).Codigo);
                costo = cost != null ? cost.DevolverCosto(cantidad) : 0;
            }
        
            return costo;
        }

        public bool Modificar(BE_Costo Costo)
        {
            Acceso = new Xml_Database();
            ListadoXML.Add(CrearCostoXML(Costo));
            return Acceso.Modificar(ListadoXML);
        }
        private BE_TuplaXML CrearCostoXML(BE_Costo Costo)
        {
            BE_TuplaXML nuevaTupla = new BE_TuplaXML();
            nuevaTupla.NodoRoot = "Costos";
            nuevaTupla.NodoLeaf = "Costo";
            XElement nuevoCosto = new XElement("Costo",
                new XElement("ID", Costo.Codigo.ToString()),
                new XElement("Fecha_Costeo", Costo.DíaCosteo.ToString("dd/MM/yyyy")),
                new XElement("Tamaño_Lote_Costeo", Costo.TamañoLoteCosteo.ToString()),
                new XElement("Materia_Prima", Costo.MateriaPrima.ToString()),
                new XElement("Horas_Hombre", Costo.HorasHombre.ToString()),
                new XElement("Energía", Costo.Energía.ToString()),
                new XElement("Otros_Gastos", Costo.OtrosGastos.ToString()),
                new XElement("Tipo_Material", Costo is BE_CostoIngrediente ? ((BE_CostoIngrediente)Costo).Tipo.ToString(): Costo is BE_CostoBebida ? ((BE_CostoBebida)Costo).Tipo.ToString(): ((BE_CostoPlato)Costo).Tipo.ToString()),
                new XElement("ID_Material", Costo is BE_CostoIngrediente ? ((BE_CostoIngrediente)Costo).ID_Ingrediente.Codigo.ToString() : Costo is BE_CostoBebida ? ((BE_CostoBebida)Costo).ID_Bebida.Codigo.ToString() : ((BE_CostoPlato)Costo).ID_Plato.Codigo.ToString())
                );
            nuevaTupla.Xelement = nuevoCosto;
            return nuevaTupla;
        }
    }
}
