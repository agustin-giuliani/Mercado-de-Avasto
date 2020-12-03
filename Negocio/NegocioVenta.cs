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
    public class NegocioVenta
    {
        DatosVenta objDatVenta = new DatosVenta();
        //llena todas las tablas
        public int abmVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.abmVenta(accion, objVenta);

        }
        //trae las listas de la venta
        public DataSet listadoVenta(string cual)
        {
            return objDatVenta.listadoVenta(cual);
        }
        //trae la lista detalle venta
        public DataSet listadodetVenta(string cual)
        {
            return objDatVenta.listadodetVenta(cual);
        }
        //trae la lista Factura
        public DataSet listadoFactura(string cual)
        {
            return objDatVenta.listadoFactura(cual);
        }
        public DataSet listadoTipoPago(string cual)
        {
            return objDatVenta.listadoTipoPago(cual);
        }
        //borra los datos de la tabla venta
        public int DeleteVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.DeleteVenta(accion, objVenta);
        }
        //borra detalles venta
        public int DeletedetVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.DeletedetVenta(accion, objVenta);
        }
        public int DeleteFactura(string accion, Ventax objVenta)
        {
            return objDatVenta.DeleteFactura(accion, objVenta);
        }
        public int ModVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.ModVenta(accion, objVenta);
        }
    }
}
