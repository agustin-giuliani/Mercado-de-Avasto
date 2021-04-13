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
                //Carga el stock
                orden = "insert into Stock values ('" + objStock.ID + "', '" + objStock.Producto +
                    "', '" + objStock.Cantida + "', '" + objStock.FechaEN.ToString("yyy/MM/dd") + "', '" + objStock.Precio + "','" + objStock.NomProvedor + "',"+objStock.IDProv+" ) ;";
            //carga el provedor
            if (accion == "Agregar-Provedor")
                orden = "insert into Provedores values('" + objStock.IDProv + "','" + objStock.NomProvedores + "','" + objStock.Tel + "','" + objStock.Domicilio + "');";
            //Carga la compra del estock
            if (accion == "Agregar-Compra")
                orden = "insert into CompraStock values('" + objStock.IDcompraSt + "','" + objStock.IDProvedores + "','" + objStock.FechaCOM.ToString("yyy/MM/dd") + "','" + objStock.FactCOM + "');";
            //carga el detalle de la compra
                if (accion == "Agregar-DetCompra")
                orden = "insert into DETCompra values('" + objStock.IDDetCOM + "','" + objStock.IDCST + "','" + objStock.Cantidad + "','" + objStock.Precio + "');";

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
        //Trae todo los datos de la tabla stock
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

        //Trae todos los datos de la tabla provedor
        public DataSet listadoProvedor(string cual)
        {
            string orden = string.Empty;
            if (cual == "Todos")
                orden = " select * from Provedores inner join (CompraStock inner join  DETCompra on IDcompraSt = IDCST)  on IDProv = IDProvedores order by IDProv ;";
            else
                orden = "select distinct IDProvedores, IDCST from Provedores inner join (CompraStock inner join  DETCompra on IDcompraSt = IDCST) on IDProv = IDProvedores;";


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

                throw new Exception("Error al listar Provedor", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        //Trae todos los datos de la tabla
        public DataSet listadoCompra(string cual)
        {
            string orden = string.Empty;
            if (cual == "Todos")
                orden = " select *from CompraStock inner join DETCompra on IDcompraSt = IDCST order by IDcompraST;";
            else
                orden = "select * from CompraStock;";


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

                throw new Exception("Error al listar Compra", e);
            }
            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return ds;
        }

        //Trae todo los datos de la tabla detalle stock
        public DataSet listadoDetCompra(string cual)
        {
            string orden = string.Empty;
            if (cual != "Todos")
                orden = " select *from DETCompra where IDDetCOM = " + int.Parse(cual) + ";";
            else
                orden = "select * from DETCompra;";


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

        //Borra los datos del stock
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

        //borra los datos del Provedor
        public int DeleteProvedor(string accion, Stocks objStock)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet-Provedor")
                orden = "DELETE from Provedores where IDProv=" + objStock.IDProv;

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

        //Borra los datos de la compra
        public int DeleteCompra(string accion, Stocks objStock)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet-Compra")
                orden = "DELETE from CompraStock where IDcompraSt=" + objStock.IDcompraSt;

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar borrar la compra", e);
            }

            finally
            {
                Cerrarconexion();
                cmd.Dispose();
            }
            return resultado;
        }
        //borra los datos de detalle de la compra
        public int DeleteDetCompra(string accion, Stocks objStock)
        {

            int resultado = -1;
            string orden = string.Empty;
            if (accion == "Delet-DetCompra")
                orden = "DELETE from DETCompra where IDDetCOM=" + objStock.IDDetCOM;

            SqlCommand cmd = new SqlCommand(orden, conexion);

            try
            {
                Abrirconexion();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al tratar borrar el detalle de la compra", e);
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
            //Modifica los datos del stock
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Modificar")
                orden = "update Stock set Producto= '" + objStock.Producto + "', Cantidad= '" +
                   objStock.Cantidad + "', Precio='" + objStock.Precio + "', NomProvedor= '"+objStock.NomProvedor+"', FechaEN='" + objStock.FechaEN.ToString("yyy/MM/dd") +"'Where ID='"+ objStock.ID+"';";

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
