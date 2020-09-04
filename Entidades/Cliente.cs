using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Cliente
    {
        #region atributos
        private int id;
        private string compra;
        private string nombre;
        private string devePago;
        private DateTime fechaCOM;
        #endregion

        #region constructor
        public void Clientes()
        {
            id = 0;
            nombre = string.Empty;
            compra = string.Empty;
            fechaCOM = DateTime.MinValue;
            devePago = string.Empty;
        }
        #endregion

        #region
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Compra
        {
            get { return compra; }
            set { compra = value; }
        }

        public DateTime FechaCOM
        {
            get { return fechaCOM; }
            set { fechaCOM = value; }
        }

        public string DevePago
        {
            get { return devePago; }
            set { devePago = value; }
        }
        #endregion
    }
}
