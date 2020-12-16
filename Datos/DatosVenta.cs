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
            //carga la tabla venta
            if (accion == "Agregar")
                orden = "insert into Venta values ('" + objVenta.ID + "', '" + objVenta.Producto +
                    "', '" + objVenta.Cantidad + "', '" + objVenta.Precio + "', '" + objVenta.FechaVen.ToString("yyy/MM/dd") + "' );";
            //carga la tabla detalle venta
            if (accion == "Agregar-detVenta")
                orden = "insert into DetVenta values ('" + objVenta.IDdetVenta + "','" + objVenta.IDStock + "','" + objVenta.Cantidad + "','" + objVenta.IDVenta + "','" + objVenta.Precio + "');";
            //Carga la tabla Factura
            if (accion == "Agregar-Factura")
                orden = "insert into Facturas values ('" + objVenta.IDfac + "','" + objVenta.NrFactura + "','" + objVenta.TipoCuit + "','" + objVenta.Total + "','" + objVenta.Saldo + "','" + objVenta.FechaFac.ToString("yyy/MM/dd") + "','" + objVenta.IDCliente + "','" + objVenta.IDventa + "');";
            //carga la tabla tipo de pago
            if (accion == "Agregar-Tipopago")
                orden = "insert into TipodePago values ('" + objVenta.IDTipoPago + "','" + objVenta.TipodePago + "','" + objVenta.FechaPago.ToString("yyy/MM/dd") + "','" + objVenta.Importe + "','" + objVenta.IDfac + "');";
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

        #region metodo de Listados
        //trae los datos de venta
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
        #region
        // trae las listas de detalle de venta
        public DataSet listadodetVenta(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from DetVenta where IDdetVenta = " + int.Parse(cual) + ";";
            else
                orden = "select * from DetVenta;";

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
        #region
        //trae la lista factura
        public DataSet listadoFactura(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from Facturas where IDfac = " + int.Parse(cual) + ";";
            else
                orden = "select * from Facturas;";

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
        public DataSet listadoTipoPago(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from TipodePago where IDTipoPago = " + int.Parse(cual) + ";";
            else
                orden = "select * from TipodePago;";

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

        #region
        //borra los datos de venta
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
        #endregion
        #region
        //borra los datos de detalle venta
        public int DeletedetVenta(string accion, Ventax objVenta)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet-detVenta")
                orden = "DELETE from DetVenta where IDdetVenta=" + objVenta.IDdetVenta;

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
        #endregion
        #region
        public int DeleteFactura(string accion, Ventax objVenta)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet-factura")
                orden = "DELETE from Facturas where IDfac=" + objVenta.IDfac;

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
        #endregion
        #region
        public int DeleteTipoPago(string accion, Ventax objVenta)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet-Tpago")
                orden = "DELETE from TipodePago where IDTipoPago=" + objVenta.IDTipoPago;

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
        #endregion
        public int ModVenta(string accion, Ventax objVenta)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Modificar")
                orden = "update Venta set Producto= '" + objVenta.Producto + "' , Cantidad='" +
                   objVenta.Cantidad + "', Precio='" + objVenta.Precio + "', FechaVen='" + objVenta.FechaVen.ToString("yyy/MM/dd") + "'Where ID='" + objVenta.ID + "';";

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
