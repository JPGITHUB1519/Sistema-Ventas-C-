using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// para trabajar con los datos
using System.Data;
using System.Data.SqlClient;

// aqui se almacenaran todos los procedimientos para acceder a los datos de la categoria

namespace CapaDatos
{
    public class DCategoria
    {
        // _ para diferencias con su metodo get y set

        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        // constructor vacio

        public DCategoria()
        {
 
        }

        // constructor con todos los parametros

        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;

        }

        // metodo insertar

        public string Insertar(DCategoria categoria)
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
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                
                // parametros

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                // pasar el valor del nombre
                ParNombre.Value = categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                // pasar el valor del nombre
                ParDescripcion.Value = categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // ejecutar comando

                // si se inserto valor -> ok else no se ingreso                
                rpta = SqlCmd.ExecuteNonQuery() == 1? "OK" : "No se Actualizo el registro";

            }
            catch(Exception ex)
            {
                // en caso de error asignar a la variable el error devuelto
                rpta = ex.Message;

            }
            finally
            {
                // si la conexion esta abierta, cierrala
                if(SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return rpta;
        }

        // metodo editar
        public string Editar(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // comandos

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                // pasar el valor del nombre
                ParNombre.Value = categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                // ejecutar comando

                // si se inserto valor -> ok else no se ingreso                
                rpta = SqlCmd.ExecuteNonQuery() == 1? "OK" : "No se ingreso el registro";

            }
            catch(Exception ex)
            {
                // en caso de error asignar a la variable el error devuelto
                rpta = ex.Message;

            }
            finally
            {
                // si la conexion esta abierta, cierrala
                if(SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return rpta;
 
        }

        // metodo eliminar

        public string Eliminar(DCategoria categoria)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                // conexion
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                // comandos

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.Value = categoria.Idcategoria;
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                SqlCmd.Parameters.Add(ParIdCategoria);

                // ejecutar comando

                // si se inserto valor -> ok else no se ingreso                
                rpta = SqlCmd.ExecuteNonQuery() == 1? "OK" : "No se Eliminó el registro";

            }
            catch(Exception ex)
            {
                // en caso de error asignar a la variable el error devuelto
                rpta = ex.Message;

            }
            finally
            {
                // si la conexion esta abierta, cierrala
                if(SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }

            return rpta;
 
 
        }

        // metodo mostrar

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // ejecutar comando y llenar el datatable

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);


            }
            catch(Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;
 
        }

        // metodo buscar por nombre

        public DataTable BuscarNombre(DCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;

                SqlCmd.Parameters.Add(ParTextoBuscar);

                // ejecutar comando y llenar el datatable

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);



            }
            catch(Exception ex)
            {
                DtResultado = null;

            }

            return DtResultado;

        }
      

    }
}
