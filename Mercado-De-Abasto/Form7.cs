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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public Stocks objEntStock = new Stocks();
        public NegocioStock objNegStock = new NegocioStock();

        private void ds_c_TxtBox(DataSet ds)
        {
            textBox11.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
            textBox10.Text = ds.Tables[0].Rows[0]["Cantidad"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["IDCompraSt"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["IDDetCOM"].ToString();
            textBox8.Enabled = false;
        }

        private void TxtBox_DC_obj()
        {
            //datos detalle de la compra
            objEntStock.IDDetCOM = int.Parse(textBox8.Text);
            objEntStock.IDCST = int.Parse(textBox9.Text);
            objEntStock.Cantidad = textBox10.Text;
            objEntStock.Precio = int.Parse(textBox11.Text);
        }
        private void Limpiar()
        {
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_DC_obj();
                nGrabado = objNegStock.abmStock("Agregar-DetCompra", objEntStock);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo la Compra en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en la tabla Compra");
                    //llenarDvgDC();
                    Limpiar();
                    this.Hide();
                    Stock Stock = new Stock();
                    Stock.Show();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Compra:" +
                    "NO EXISTE la Compra O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_DC_obj();
                resultado = objNegStock.DeleteDetCompra("Delet-DetCompra", objEntStock);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el detalle de la compra en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el detalle de la compra Compra");
                    //llenarDvgDC();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    textBox8.Enabled = true;
                    this.Hide();

                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar el detalle Compra:" +
                    "NO EXISTE el detalle de la compra O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_DC_obj();
                resultado = objNegStock.ModDetCom("Modificar-DetCom", objEntStock);
                if (resultado == -1)
                    MessageBox.Show("No se Modifico el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se Modifico con exito el producto");
                    // llenarDvg();
                    Limpiar();
                    //textBox1.Enabled = true;
                    button1.Visible = true;
                    this.Hide();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL Modificar Stock:" +
                    "NO EXISTE EL STOCK O INGRESO MAL ALGUNA INFORMACION.");
            }
        }
    }
}
