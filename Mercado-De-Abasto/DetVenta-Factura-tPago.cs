using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Negocio;
using System.Windows.Forms;

namespace Mercado_De_Abasto
{
    public partial class DetVenta_Factura_tPago : Form
    {
        public DetVenta_Factura_tPago()
        {
            InitializeComponent();
        }
        public Cliente objEntCliente = new Cliente();
        public Ventax objEntVenta = new Ventax();
        public NegocioVenta objNegVenta = new NegocioVenta();

  
        private void TxtBox_F_obj()
        {
            //recive los valores de los texbox
            objEntVenta.IDfac = int.Parse(textBox6.Text);
            objEntVenta.NrFactura = int.Parse(textBox7.Text);
            objEntVenta.TipoCuit = int.Parse(textBox8.Text);
            objEntVenta.Total = int.Parse(textBox9.Text);
            objEntVenta.Saldo = int.Parse(textBox10.Text);
            objEntVenta.FechaFac = dateTimePicker1.Value;
            objEntVenta.IDCliente = int.Parse(textBox11.Text);
            objEntVenta.IDventa = int.Parse(textBox12.Text);
        }

        private void Limpiar()
        {
            //limpia los texbox
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;

        }
        

        private void ds_f_TxtBox(DataSet ds)
        {
            //selecciona los valores de detalles de factura
            textBox12.Text = ds.Tables[0].Rows[0]["IDventa"].ToString();
            textBox11.Text = ds.Tables[0].Rows[0]["IDCliente"].ToString();
            textBox10.Text = ds.Tables[0].Rows[0]["Saldo"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["Total"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["TipoCuit"].ToString();
            textBox7.Text = ds.Tables[0].Rows[0]["NrFactura"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["IDfac"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //carga  Facturas
            try
            {
                int nGrabado = -1;
                TxtBox_F_obj();
                nGrabado = objNegVenta.abmVenta("Agregar-Factura", objEntVenta);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo factura en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito la factura");
                    Limpiar();
                    this.Hide();
                    Form5 form5 = new Form5();
                    form5.Show();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR LA FACTURA:" +
                    "NO EXISTE LA FACTURA O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
           
            try
            {
                int resultado = -1;
                TxtBox_F_obj();
                resultado = objNegVenta.DeleteFactura("Delet-factura", objEntVenta);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el detalle de la factura en el sistema" + "INTENTE NUEVAMENTE");
                   
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el detalle de la factura");
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    this.Hide();

                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar la factura:" +
                    "NO EXISTE LA FACTURA O INGRESO MAL ALGUNA INFORMACION.");
                Form5 form5 = new Form5();
                form5.Show();
            }
        }



        private void DetVenta_Factura_tPago_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
