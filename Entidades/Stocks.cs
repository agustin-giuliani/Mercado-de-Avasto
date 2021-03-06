﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Stocks
    {
        #region atributos
        //Tabla Stock
        private int id;
        private int precio;
        private string producto;
        private string cantidad;
        private DateTime fechaEN;
        private string nomProvedor;
        //tabla Probedores
        private int idProv;
        private string nomProvedores;
        private string tel;
        private string domicilio;
        //Tabla compra
        private int idCompraSt;
        private int idProvedores;
        private DateTime fechaCOM;
        private string factCOM;
        //Tabla detalle compra
        private int idDetCOM;
        private int idCompraST;

        #endregion
        #region constructor
        public void Stockx()
        {
            //tabla stock
            id = 0;
            producto = string.Empty;
            cantidad = string.Empty;
            fechaEN = DateTime.MinValue;
            precio = 0;
            nomProvedor = string.Empty;
            //tabla provedores
            idProv = 0;
            nomProvedores = string.Empty;
            tel = string.Empty;
            domicilio = string.Empty;
            //tabla compra
            idCompraSt = 0;
            idProvedores = 0;
            fechaCOM = DateTime.MinValue;
            factCOM = string.Empty;
            //tabala detalle compra
            idDetCOM = 0;
            idCompraST = 0;


        }
        #endregion

        #region
        //Tabla Stock
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
            get { return cantidad; }
            set { cantidad = value; }
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
        //Tabla provedores
        public int IDProv
        {
            get { return idProv; }
            set { idProv = value; }
        }
        public string NomProvedores
        {
            get { return nomProvedores; }
            set { nomProvedores = value; }
        }
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }
        //tabla compra
        public int IDcompraSt 
        {
            get { return idCompraSt; }
            set { idCompraSt = value; }
        }
        public int IDProvedores 
        {
            get { return idProvedores; }
            set { idProvedores = value; }
        }
        public DateTime FechaCOM 
        {
            get { return fechaCOM; }
            set { fechaCOM = value; }
        }
        public string FactCOM 
        {
            get { return factCOM; }
            set { factCOM = value; }
        }
        //tabla detalle compra
        public int IDDetCOM 
        {
            get { return idDetCOM; }
            set { idDetCOM = value; }
        }
        public string Cantidad 
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public int IDCST
        {
            get { return idCompraST; }
            set { idCompraST = value; }
        }
        #endregion
    }
}
