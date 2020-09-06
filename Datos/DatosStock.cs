using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosStock : DatosConexionDB
    {
        public int abmStock(string accion, Stocks objStock)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Agregar")
                orden = "insert into Stock values ('" + objStock.ID + "', '" + objStock.Nombre +
                    "', '" + objStock.Cantidad + "', '" + objStock.FechaEN.ToString("yyy/MM/dd") + "', '" + objStock.Precio + "') ;";
           
            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar de Stock", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        #region metodoListadoSTOCK
        public DataSet listadoStock(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from Stock where ID = " + int.Parse(cual) + ";";
            else
                orden = "select * from Stock;";

            SqlCommand cmd = new SqlCommand(orden, conexion);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                Abrirconexion();
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {

                throw new Exception("Error al listar Stock", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }
        #endregion

        public int DeleteStock(string accion, Stocks objStock)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet")
                orden = "DELETE from Stock where ID=" + objStock.ID;

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar borrar el Cliente", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        public int ModStock(string accion,Stocks objStock)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Modificar")
                orden = "update Stock set Nombre= '" + objStock.Nombre + "' where ID='" + objStock.ID + "' '" +
                   objStock.Cantidad + "' '" + objStock.Precio + "' " + objStock.FechaEN.ToString("yyy/MM/dd") + ";";

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar de Stock", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

    }
}
