using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion
    {

        private int _idpresentacion;
        private string _nombre;
        private string _descripcion;
        private string _textobuscar;

        public int Idpresentacion
        {
            get { return _idpresentacion; }
            set { _idpresentacion = value; }
        }
        

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _textobuscar; }
            set { _textobuscar = value; }
        }


        public DPresentacion()
        {
 
        }

        public DPresentacion(int idpresentacion, string nombre, string descripcion)
        {
            this._idpresentacion = idpresentacion;
            this._nombre = nombre;
            this._descripcion = descripcion;
        }

        public string Insertar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter ParIdPresentacion = new SqlParameter("@idpresentacion", SqlDbType.Int);
                ParIdPresentacion.Direction = ParameterDirection.Output;

                SqlParameter ParNombrePresentacion = new SqlParameter("@nombre", SqlDbType.VarChar, 50);
                ParNombrePresentacion.Value = Presentacion.Nombre;

                SqlParameter ParDescripcionPresentacion = new SqlParameter("@descripcion", SqlDbType.VarChar, 256);
                ParDescripcionPresentacion.Value = Presentacion.Descripcion;

                SqlCmd.Parameters.Add(ParIdPresentacion);
                SqlCmd.Parameters.Add(ParNombrePresentacion);
                SqlCmd.Parameters.Add(ParDescripcionPresentacion);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string Editar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter ParIdPresentacion = new SqlParameter("idpresentacion", SqlDbType.Int);
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);
            

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string Eliminar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // parametros

                SqlParameter ParIdPresentacion = new SqlParameter("idpresentacion", SqlDbType.Int);
                ParIdPresentacion.Value = Presentacion.Idpresentacion;

                SqlCmd.Parameters.Add(ParIdPresentacion);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el registro";



            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_presentacion";

                SqlDataAdapter da = new SqlDataAdapter(SqlCmd);

                da.Fill(DtResultado);



            }
            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter("@textobuscar", SqlDbType.VarChar);
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Presentacion._textobuscar;


                SqlCmd.Parameters.Add(ParTextoBuscar);

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
