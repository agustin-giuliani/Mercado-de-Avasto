using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Stocks
    {
        #region atributos
        private int id;
        private int precio;
        private string producto;
        private string cantida;
        private DateTime fechaEN;
        private string nomProvedor;
        #endregion
        #region constructor
        public void Stockx()
        {
            id = 0;
            producto = string.Empty;
            cantida = string.Empty;
            fechaEN = DateTime.MinValue;
            precio = 0;
            nomProvedor = string.Empty;
        }
        #endregion

        #region
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public string Cantida
        {
            get { return cantida; }
            set { cantida = value; }
        }

        public DateTime FechaEN
        {
            get { return fechaEN; }
            set { fechaEN = value; }
        }

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public string NomProvedor
        {
            get { return nomProvedor; }
            set { nomProvedor = value; }
        }
        #endregion
    }
}
