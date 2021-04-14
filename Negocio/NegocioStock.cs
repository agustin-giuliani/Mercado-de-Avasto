using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidades;
using System.Threading.Tasks;

namespace Negocio
{
    public  class NegocioStock
    {
        DatosStock objDatStock = new DatosStock();
        public int abmStock(string accion, Stocks objStock)
        {
            return objDatStock.abmStock(accion, objStock);
            //Carga todas las tablas
        }
        public DataSet listadoStock(string cual)
        {
            return objDatStock.listadoStock(cual);
            //trae todos los balores de la tabla estock
        }
        public DataSet listadoProvedor(string cual)
        {
            return objDatStock.listadoProvedor(cual);
            //trae todos los balores de la tabla Provedor
        }

        public DataSet listadoCompra(string cual)
        {
            return objDatStock.listadoCompra(cual);
            //trae todos los balores de la tabla Compra
        }

        public DataSet listadoDetCompra(string cual)
        {
            return objDatStock.listadoDetCompra(cual);
            //trae todos los balores de la tabla detalle Compra
        }
        public int DeleteStock(string accion, Stocks objStock)
        {
            return objDatStock.DeleteStock(accion, objStock);
            //Borra todos los balores de la tabla stock
        }
        public int DeleteProvedor(string accion, Stocks objStock)
        {
            return objDatStock.DeleteProvedor(accion, objStock);
            //Borra todos los balores de la tabla provedor
        }
        public int DeleteCompra(string accion, Stocks objStock)
        {
            return objDatStock.DeleteCompra(accion, objStock);
            //Borra todos los balores de la tabla Compra
        }
        public int DeleteDetCompra(string accion, Stocks objStock)
        {
            return objDatStock.DeleteDetCompra(accion, objStock);
            //Borra todos los balores de la tabla detalle Compra
        }
        public int ModStock(string accion, Stocks objStock)
        {
            return objDatStock.ModStock(accion, objStock);
        }
        public int ModProvedor(string accion, Stocks objStock)
        {
            return objDatStock.ModProvedor(accion, objStock);
        }

        public int ModComst(string accion, Stocks objStock)
        {
            return objDatStock.ModComst(accion, objStock);
        }
        public int ModDetCom(string accion, Stocks objStock)
        {
            return objDatStock.ModDetCom(accion, objStock);
        }
    }
}
