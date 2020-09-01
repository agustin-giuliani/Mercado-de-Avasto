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
    class DatosVenta : DatosConexionDB
    {
        public int abmVenta(string accion, Venta objVenta)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Agregar")
                orden = "insert into Venta values ('" + objVenta.Nombre + "', '" + objVenta.ID +
                    "', '" + objVenta.Precio + "', '" + objVenta.FechaVEN + ") ;";
            if (accion == "Modificar")
                orden = "update Venta set ID= '" + objVenta.Nombre + "', '" + objVenta.Cantidad + "', '" +
                   objVenta.ID + "', '" + objVenta.Precio + "', " + objVenta.FechaVEN + ";";

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar de Venta", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        #region metodoListadoSTOCK
        public DataSet listadoVenta(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from Venta where Nombre = " + int.Parse(cual) + ";";
            else
                orden = "select * from Venta;";

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

                /// throw new Exception("Error al listar Venta", e);
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
