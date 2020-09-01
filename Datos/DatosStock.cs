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
    class DatosStock : DatosConexionDB
    {
        public int abmStock(string accion, Stock objStock)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Agregar")
                orden = "insert into Stock values ('" + objStock.Nombre + "', '" + objStock.ID +
                    "', '" + objStock.Precio + "', '" + objStock.FechaEN + "', " + objStock.Cantidad + ") ;";
            if (accion == "Modificar")
                orden = "update Stock set ID= '" + objStock.Nombre + "', '" + objStock.Cantidad + "', '" +
                   objStock.ID + "', '" + objStock.Precio + "', " + objStock.FechaEN + ";";

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
                orden = " select *from Stock where Nombre = " + int.Parse(cual) + ";";
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

    }
}
