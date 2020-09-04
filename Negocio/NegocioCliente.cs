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
    public class NegocioCliente
    {
        DatosCliente objDatCliente = new DatosCliente();
        public int abmCliente(string accion, Cliente objCliente)
        {
            return objDatCliente.abmCliente(accion, objCliente);

        }
        public DataSet listadoCliente(string cual)
        {
            return objDatCliente.listadoCliente(cual);
        }

        public int DeleteCliente(string accion,Cliente objCliente)
        {
            return objDatCliente.DeleteCliente(accion, objCliente);
        }
    }
}
