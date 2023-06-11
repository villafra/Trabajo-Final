using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Mapper;
using Abstraction_Layer;


namespace Business_Logic_Layer
{
    public class BLL_Horario : IGestionable<BE_Horario>
    {
        MPP_Horario oMPP_Horario;

        public BLL_Horario()
        {
            oMPP_Horario = new MPP_Horario();
        }

        public bool Baja(BE_Horario horario)
        {
            return oMPP_Horario.Baja(horario);
        }

        public void CrearAgenda()
        {

            List<BE_Horario> agenda = new List<BE_Horario>();

            DateTime hoy = DateTime.Now.AddDays(-1);
            DateTime fin = DateTime.Now.AddYears(2);
            int codigo = 1;

            for (DateTime dia = hoy; dia <= fin; dia = dia.AddHours(1))
            {
                BE_Horario nuevaHora = new BE_Horario
                {
                    Codigo = codigo,
                    Día = dia,
                    Hora = dia.Hour,
                    Disponible = true
                };
                agenda.Add(nuevaHora);
                codigo++;
            }
            oMPP_Horario.CrearAgenda(agenda);

        }

        public bool Guardar(BE_Horario horario)
        {
            throw new NotImplementedException();
        }

        public List<BE_Horario> Listar()
        {
            return oMPP_Horario.Listar();
        }

        public BE_Horario ListarObjeto(BE_Horario horario)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(BE_Horario horario)
        {
            return oMPP_Horario.Modificar(horario);
        }
    }
}
