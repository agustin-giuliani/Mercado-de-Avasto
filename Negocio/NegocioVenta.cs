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
        public int abmVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.abmVenta(accion, objVenta);

        }
        public DataSet listadoVenta(string cual)
        {
            return objDatVenta.listadoVenta(cual);
        }

        public int DeleteVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.DeleteVenta(accion, objVenta);
        }

        public int ModVenta(string accion, Ventax objVenta)
        {
            return objDatVenta.ModVenta(accion, objVenta);
        }
    }
}
