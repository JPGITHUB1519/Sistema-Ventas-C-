using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// importar capadatos

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NArticulo
    {
        // metodo insertar que llama al metodo insertar de la clase DArticulo de la capa datos

        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.Idcategoria = idcategoria;
            obj.Idpresentacion = idpresentacion;

            return obj.Insertar(obj);
        }

        // metodo editar que llama al metodo editar de la clase DArticulo de la capa datos

        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo obj = new DArticulo();
            obj.Idarticulo = idpresentacion;
            obj.Codigo = codigo;
            obj.Nombre = nombre;
            obj.Descripcion = descripcion;
            obj.Imagen = imagen;
            obj.Idcategoria = idcategoria;
            obj.Idpresentacion = idpresentacion;

            return obj.Editar(obj);
        }

        // metodo eliminar que llama al metodo eliminar de la clase DArticulo de la capa datos

        public static string Eliminar(int idarticulo)
        {
            DArticulo obj = new DArticulo();
            obj.Idarticulo = idarticulo;
            return obj.Eliminar(obj);
        }

        // metodo mostrar que llama al metodo mostrar de la clase DArticulo de la capa datos

        public static DataTable Mostrar()
        {
            return new DArticulo().Mostrar();
        }

        // metodo BuscarNombre  que llama al metodo BuscarNombre de la clase DArticulo de la capa datos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo obj = new DArticulo();
            obj.TextoBuscar = textobuscar;

            return obj.BuscarNombre(obj);

        }



    }
}
