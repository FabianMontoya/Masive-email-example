using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasiveEmail
{
    static class ConectorSQL
    {
        static string cadenaConexion = "Data Source=db.grupotci.com.co;Initial Catalog=SASIF;Persist Security Info=True;User ID=SA;Password=/*GrupoTCI2019*/";

        /// <summary>
        /// Función encargada de ejecutar un Query para insert, update o delete, devuelve exito o el mensaje de error generado
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static string Ejecutar_InsertUpdateDelete(string SQL)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand();
            try
            {

                SqlConnection con = new SqlConnection(cadenaConexion);
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                result = "Exito";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return result;
        }

        /// <summary> 
        /// Función que consulta un solo registro.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static string Consultar_Registro(string SQL)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(cadenaConexion);
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = SQL;
            try
            {
                SqlDataReader reader;
                cmd.Connection.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.GetValue(0).ToString();
                    }
                }
                else
                {
                    result = "404";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Función que ejecuta un query y retorna una tabla con todos los resultados
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        public static DataTable Consultar_Registros(string SQL)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(cadenaConexion);
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = SQL;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt = ds.Tables.Add();
            try
            {
                cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                throw;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return dt;
        }
    }
}
