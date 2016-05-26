using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NPresentacion
    {
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;

            return obj.Insertar(obj);
            
        }

        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Idpresentacion = idpresentacion;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;

            return obj.Editar(obj);

        }

        public static string eliminar(int idpresentacion)
        {
            DPresentacion obj = new DPresentacion();
            obj.Idpresentacion = idpresentacion;
        
            return obj.Eliminar(obj);

        }


        public static DataTable Mostrar()
        {
            DPresentacion obj = new DPresentacion();

            return obj.Mostrar();
        }

        public static DataTable BuscarNombre(String TextoBuscar)
        {
            DPresentacion obj = new DPresentacion();
            obj.TextoBuscar = TextoBuscar;
            return obj.BuscarNombre(obj);
        }
    }
}
