using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventax
    {
        #region atributos
        private int id;
        private int precio;
        private string producto;
        private string cantidad;
        private DateTime fechaVen;
        
        #endregion

        #region constructor
        public void Ventas()
        {
            id = 0;
            producto = string.Empty;
            cantidad = string.Empty;
            fechaVen = DateTime.MinValue;
            precio = 0;
            
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

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public DateTime FechaVen
        {
            get { return fechaVen; }
            set { fechaVen = value; }
        }

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }


        #endregion
    }
}
