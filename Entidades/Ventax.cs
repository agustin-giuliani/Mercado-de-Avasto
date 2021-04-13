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
        // datos venta
        private int id;
        private int precio;
        private string producto;
        private string cantidad;
        private DateTime fechaVen;
        //datos detalle de la venta
        private int iddetVenta;
        private int idStock;
        private int idVenta;
        //datos de la factura
        private int idfac;
        private int nrfactura;
        private int tipocuit;
        private int total;
        private int saldo;
        private DateTime fechaFac;
        private int idCliente;
        private int idventa;
        // datos tipo de pago
        private int idtipopago;
        private string tipodePago;
        private DateTime fechaPago;
        private int importe;
        private int idfacturas;
        #endregion

        #region constructor
        public void Ventas()
        {
            //datos venta
            id = 0;
            producto = string.Empty;
            cantidad = string.Empty;
            fechaVen = DateTime.MinValue;
            precio = 0;
            //datos detalle venta
            iddetVenta = 0;
            idStock = 0;
            idVenta = 0;
            //datos de la factura
            idfac = 0;
            nrfactura = 0;
            tipocuit = 0;
            total = 0;
            saldo = 0;
            fechaFac = DateTime.MinValue;
            idCliente = 0;
            idventa = 0;
            //datos tipo de pago
            idtipopago = 0;
            tipodePago = string.Empty;
            fechaPago = DateTime.MinValue;
            importe = 0;
            idfacturas = 0;
        }
        #endregion

        #region
        //datos venta
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
        //datos detalle venta
        public int IDdetVenta
        {
            get { return iddetVenta; }
            set { iddetVenta = value; }
        }
        public int IDStock
        {
            get { return idStock; }
            set { idStock = value; }
        } 
        public int IDVenta 
        {
            get { return idVenta; }
            set { idVenta = value; }
        }
        //datos factura
        public int IDfac 
        {
            get { return idfac; }
            set { idfac = value; }
        }
        public int NrFactura 
        {
            get { return nrfactura; }
            set { nrfactura = value; }
        }
        public int TipoCuit
        {
            get { return tipocuit; }
            set { tipocuit = value; }
        }
        public int Total 
        {
            get { return total; }
            set { total = value; }
        }
        public int Saldo 
        {
            get { return saldo; }
            set { saldo = value; }
        }
        public DateTime FechaFac 
        {
            get { return fechaFac; }
            set { fechaFac = value; }
        }
        public int IDCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        public int IDventa 
        {
            get { return idventa; }
            set { idventa = value; }
        }
        //datos tipo de pago
        public int IDTipoPago
        {
            get { return idtipopago; }
            set { idtipopago = value; }
        }
        public string TipodePago
        {
            get { return tipodePago; }
            set { tipodePago = value; }
        }
        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }
        public int Importe
        {
            get { return importe; }
            set { importe = value; }
        }
        public int IDfacturas
        {
            get { return idfacturas; }
            set { idfacturas = value; }
        }
        #endregion
    }
}
