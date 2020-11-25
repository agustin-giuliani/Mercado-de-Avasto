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
        private int idvent;
        private string nombre;
        private string Pagodeve;
        private DateTime fechaPago;
        private int tel;
        private string tipodepago;
        #endregion

        #region constructor
        public void Clientes()
        {
            id = 0;
            tel = 0;
            nombre = string.Empty;
            idvent = 0;
            fechaPago = DateTime.MinValue;
            Pagodeve = string.Empty;
            tipodepago = string.Empty;

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

       

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }

        public string PagoDeve
        {
            get { return Pagodeve; }
            set { Pagodeve = value; }
        }

        public int Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string TipodePago
        {
            get { return tipodepago; }
            set { tipodepago = value; }
        }

        public int IDVent
        {
            get { return idvent; }
            set { idvent = value; }
        }
        #endregion
    }
}
