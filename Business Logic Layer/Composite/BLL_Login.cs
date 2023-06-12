using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Entities;
using Abstraction_Layer;
using Mapper;
using Service_Layer;

namespace Business_Logic_Layer
{
    public class BLL_Login : IGestionable<BE_Login>
    {
        MPP_Login oMPP_Login;

        public BLL_Login()
        {
            oMPP_Login = new MPP_Login();
        }

        public bool Baja(BE_Login usuario)
        {
            return oMPP_Login.Baja(usuario);
        }

        public bool Guardar(BE_Login usuario)
        {
            return oMPP_Login.Guardar(usuario);
        }

        public List<BE_Login> Listar()
        {
            return oMPP_Login.Listar();
        }

        public BE_Login ListarObjeto(BE_Login usuario)
        {
            return oMPP_Login.ListarObjeto(usuario);
        }

        public bool Modificar(BE_Login usuario)
        {
            return oMPP_Login.Modificar(usuario);
        }


        public string EncriptarPass(string pass)
        {
            return Encriptacion.EncriptarPass(pass);
        }
        public string DesencriptarPass(string pass)
        {
            return Encriptacion.DesencriptarPass(pass);
        }

        public string GenerarUsuario(BE_Empleado empleado)
        {
            string nombre, apellido;
            if (empleado.Nombre.Length < 3)
            {
                nombre = empleado.Nombre.Substring(0, empleado.Nombre.Length).ToLower();
            }
            else
            {
                nombre = empleado.Nombre.Substring(0, 3).ToLower();
            }
            if (empleado.Apellido.Length < 5)
            {
                apellido = empleado.Apellido.Substring(0, empleado.Apellido.Length).ToLower();
            }
            else
            {
                apellido = empleado.Apellido.Substring(0, 5).ToLower();
            }
            return apellido.PadRight(5, '1') + nombre.PadRight(3, '1');
        }
        public string AutoGenerarPass()
        {
            Random rand = new Random();
            string pass = null;
            for (int i = 0; i < 13; i++)
            {
                pass = pass + rand.Next(0, 9).ToString();
            }
            return EncriptarPass(pass);
        }

        public bool ResetCounter(BE_Login oBE_Login)
        {
            if (oBE_Login != null)
            {
                int aux = oBE_Login.CantidadIntentos;
                oBE_Login.CantidadIntentos = 0;
                if (Guardar(oBE_Login))
                {
                    return true;
                }
                else
                {
                    oBE_Login.CantidadIntentos = aux;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Intentos(BE_Login oBE_Login)
        {
            return oBE_Login.CantidadIntentos < 5;
        }
        private void IntentoFallido(BE_Login oBE_Login)
        {
            oBE_Login.CantidadIntentos += 1;
            if (!Guardar(oBE_Login))
            {
                oBE_Login.CantidadIntentos -= 1;
            }
        }
        public BE_Login Login(string user)
        {
            return oMPP_Login.Login(user);
        }
        public bool CheckPass(BE_Login oBE_Login, string pass)
        {
            if (oBE_Login.Password == EncriptarPass(pass))
            {
                return true;
            }
            else
            {
                //if (oBE_Login.CantidadIntentos < 5) { IntentoFallido(oBE_Login); }
                return false;
            }

        }
    }
}
