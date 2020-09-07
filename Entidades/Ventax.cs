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
        private string nombre;
        private string cantidad;
        private DateTime fechaVEN;
        #endregion

        #region constructor
        public void Ventas()
        {
            id = 0;
            nombre = string.Empty;
            cantidad = string.Empty;
            fechaVEN = DateTime.MinValue;
            precio = 0;
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

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public DateTime FechaVEN
        {
            get { return fechaVEN; }
            set { fechaVEN = value; }
        }

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        #endregion
    }
}
