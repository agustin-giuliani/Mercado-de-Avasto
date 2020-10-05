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
    public class DatosCliente : DatosConexionDB
    {
        public int abmCliente(string accion, Cliente objCliente)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Agregar")
                orden = "insert into Cliente values ('" + objCliente.ID + "', '" + objCliente.Nombre +
                    "', '" + objCliente.Compra + "', '" + objCliente.DevePago + "', '" + objCliente.FechaCOM.ToString("yyy/MM/dd") + "') ;";
            if (accion == "Modificar")
            {
                orden = "update Cliente set Nombre= '" + objCliente.Nombre + 
                    "', DevePago= '" + objCliente.DevePago + "', FechaCOM='" + objCliente.FechaCOM.ToString("yyy/MM/dd") + "', Compra='" + objCliente.Compra + "'Where ID='" + objCliente.ID + "';";
            }

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Errror al tratar de guardar,borrar o modificar de Cliente", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }

        #region metodoListadoSTOCK
        public DataSet listadoCliente(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from Cliente where ID = " + int.Parse(cual) + ";";
            else
                orden = "select * from Cliente;";

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

                throw new Exception("Error al listar Cliente", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }
        #endregion

        public int DeleteCliente(string accion, Cliente objCliente)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet")
                orden = "DELETE from Cliente where ID=" + objCliente.ID;

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
    }
}
