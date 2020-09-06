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

        }
        public DataSet listadoStock(string cual)
        {
            return objDatStock.listadoStock(cual);
        }

        public int DeleteStock(string accion, Stocks objStock)
        {
            return objDatStock.DeleteStock(accion, objStock);
        }

        public int ModStock(string accion, Stocks objStock)
        {
            return objDatStock.ModStock(accion, objStock);
        }
    }
}
