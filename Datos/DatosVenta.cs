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
    public class DatosVenta : DatosConexionDB
    {
        public int abmVenta(string accion, Ventax objVenta)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Agregar")
                orden = "insert into Venta values ('" + objVenta.ID + "', '" + objVenta.Nombre +
                    "', '" + objVenta.Cantidad + "', '" + objVenta.Precio + "','" + objVenta.FechaVEN.ToString("yyy/MM/dd") + "') ;";
            

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
                orden = " select *from Venta where ID = " + int.Parse(cual) + ";";
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

        public int DeleteVenta(string accion, Ventax objVenta)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet")
                orden = "DELETE from Venta where ID=" + objVenta.ID;

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


        public int ModVenta(string accion, Ventax objVenta)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Modificar")
                orden = "update Venta set Nombre= '" + objVenta.Nombre + "' where ID='" + objVenta.ID + "' '" +
                   objVenta.Cantidad + "' '" + objVenta.Precio + "' " + objVenta.FechaVEN.ToString("yyy/MM/dd") + ";";

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
