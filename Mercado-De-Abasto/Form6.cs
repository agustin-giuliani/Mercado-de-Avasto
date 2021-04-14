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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            //tabla compra
        }
        public Stocks objEntStock = new Stocks();
        public NegocioStock objNegStock = new NegocioStock();

        //llena el datagridview compra
        //private void llenarDvgC()
        //{
          //  dataGridView1.Rows.Clear();

            //DataSet ds = new DataSet();

            //ds = objNegStock.listadoCompra("Todos");

            //if (ds.Tables[0].Rows.Count > 0)
            //{
              //  foreach (DataRow dr in ds.Tables[0].Rows)
                //{
                  //  dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                //}
            //}
            //else
              //  MessageBox.Show("No existe tal Compra");
        //}


        private void Limpiar()
        {
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
        }
        private void ds_b_TxtBox(DataSet ds)
        {
            //balores compra
            textBox7.Text = ds.Tables[0].Rows[0]["FactCOM"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["IDProvedores"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["IDcompraSt"].ToString();
            textBox5.Enabled = false;
        }
        private void TxtBox_b_obj()
        {
            //Datos Compra
            objEntStock.IDcompraSt = int.Parse(textBox5.Text);
            objEntStock.IDProvedores = int.Parse(textBox6.Text);
            objEntStock.FechaCOM = dateTimePicker1.Value;
            objEntStock.FactCOM = textBox7.Text;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_b_obj();
                nGrabado = objNegStock.abmStock("Agregar-Compra", objEntStock);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo la Compra en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en la tabla Compra");
                    //llenarDvgC();
                    Limpiar();
                    this.Hide();
                    Form7 form7 = new Form7();
                    form7.Show();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Compra:" +
                    "NO EXISTE la Compra O INGRESO MAL ALGUNA INFORMACION.");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PARA BORRAR Compra:" +
                   "tiene que borrar los datos del detalle de la compra");
            try
            {
                int resultado = -1;
                TxtBox_b_obj();
                resultado = objNegStock.DeleteCompra("Delet-Compra", objEntStock);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el Provedor en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito la Compra");
                    //llenarDvgC();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    textBox5.Enabled = true;
                    this.Hide();
                }
            }
            catch
            {
            
                Form7 form7 = new Form7();
                form7.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_b_obj();
                resultado = objNegStock.ModComst("Modificar-Com", objEntStock);
                if (resultado == -1)
                    MessageBox.Show("No se Modifico el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se Modifico con exito el producto");
                    //llenarDvg();
                    Limpiar();
                    //textBox1.Enabled = true;
                    button1.Visible = true;
                    this.Hide();
                    Form7 form7 = new Form7();
                    form7.Show();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL Modificar Stock:" +
                    "NO EXISTE EL STOCK O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //  DataSet ds = new DataSet();
        //objEntStock.IDcompraSt = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        //ds = objNegStock.listadoCompra(objEntStock.IDcompraSt.ToString());
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //   ds_b_TxtBox(ds);
        //  button3.Visible = false;

        //}
        //}
    }
}
