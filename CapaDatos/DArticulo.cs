using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// para trabajar con los datos
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulo
    {
        private int _Idarticulo;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;
        private string _TextoBuscar;

      

        public int Idarticulo
        {
            get { return _Idarticulo; }
            set { _Idarticulo = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public byte[] Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
        }

        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        // constructor vacio
        public DArticulo()
        {
 
        }

        // constructor con todos las propiedades
        public DArticulo(int idarticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion )
        {
            this.Idarticulo = idarticulo;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
 
        }

        // metodos

        public string Insertar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // comandos
                // agregamos el nombre del metodo y sus parametros

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                // parametros

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                // ejecutar comando

                // si se inserto valor -> ok else no se ingreso                
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";

               

            }
            catch (Exception ex)
            {
                // en caso de error asignar a la variable el error devuelto
                rpta = ex.Message;

            }
            finally
            {
                // si la conexion esta abierta, cierrala
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return rpta;
        }

        public string Editar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // comandos
                // agregamos el nombre del metodo y sus parametros

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                // parametros

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                // ejecutar comando

                // si se inserto valor -> ok else no se ingreso                
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";



            }
            catch (Exception ex)
            {
                // en caso de error asignar a la variable el error devuelto
                rpta = ex.Message;

            }
            finally
            {
                // si la conexion esta abierta, cierrala
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return rpta;
        }

        public string Eliminar(DArticulo Articulo)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // comandos
                // agregamos el nombre del metodo y sus parametros

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_articulo";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                // parametros

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idarticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdArticulo);

                // ejecutar comando

                // si se inserto valor -> ok else no se ingreso                
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el registro";



            }
            catch (Exception ex)
            {
                // en caso de error asignar a la variable el error devuelto
                rpta = ex.Message;

            }
            finally
            {
                // si la conexion esta abierta, cierrala
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return rpta;
        }

        // metodo mostrar

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // ejecutar comando y llenar el datatable

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch (Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;

        }

        // metodo buscar por nombre

        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_presentacion_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;

                SqlCmd.Parameters.Add(ParTextoBuscar);

                // ejecutar comando y llenar el datatable

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch (Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;

        }




    }
}
