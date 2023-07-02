using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction_Layer;

namespace Business_Entities
{
    public abstract class BE_Empleado : IEntidable
    {
        public int Codigo { get; set; }
        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Antiguedad { get; set; }
        public Category Categoria { get; set; }
        public bool Activo { get; set; } = true;
        public int CalcularAños(DateTime fecha)
        {
            int Año = DateTime.Now.Year - fecha.Year;
            if (DateTime.Now.Month < fecha.Month)
            {
                Año -= 1;
            }
            if (fecha.Month == DateTime.Now.Month && DateTime.Now.Day < fecha.Day)
            {
                Año -= 1;
            }
            return Año;
        }
        public override string ToString()
        {
            return this.Nombre + " " + this.Apellido;
        }
        public string DevolverNombre()
        {
            string clase = this.GetType().Name;
            return clase.Substring(clase.IndexOf("_") + 1, clase.Length - clase.IndexOf("_") - 1);
        }

        
    }
    public enum Category
    {
        Gerente_Sucursal = 1,
        Chef_Ejecutivo = 2,
        Sous_Chef = 3,
        Cocinero = 4,
        Bachero = 5,
        Mozo = 6,
        Busboy = 7,
        Bartender = 8

    }

}
