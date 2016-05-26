using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// importar capadatos

using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NCategoria
    {
        // metodo insertar que llama al metodo insertar de la clase DCategoria de la capa datos

        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;

            return obj.Insertar(obj);
        }

        // metodo editar que llama al metodo editar de la clase DCategoria de la capa datos
        
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;

            return obj.Editar(obj);
        }

        // metodo eliminar que llama al metodo eliminar de la clase DCategoria de la capa datos

        public static string Eliminar(int idcategoria)
        {
            DCategoria obj = new DCategoria();
            obj.Idcategoria = idcategoria;
            return obj.Eliminar(obj);
        }

        // metodo mostrar que llama al metodo mostrar de la clase DCategoria de la capa datos

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        // metodo BuscarNombre  que llama al metodo BuscarNombre de la clase DCategoria de la capa datos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria obj = new DCategoria();
            obj.TextoBuscar = textobuscar;

            return obj.BuscarNombre(obj);
            
        }
    }

}
