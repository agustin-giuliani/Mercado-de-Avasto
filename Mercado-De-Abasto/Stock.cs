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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Cantidad";
            dataGridView1.Columns[3].HeaderText = "Fecha de entrada";
            dataGridView1.Columns[4].HeaderText = "Precio";
            dataGridView1.Columns[5].HeaderText = "Nombre Provedores";
            dataGridView1.Columns[6].HeaderText = "ID Provedores";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            dataGridView1.Columns[4].Width = 125;
            dataGridView1.Columns[5].Width = 125;
            dataGridView1.Columns[5].Width = 125;
            llenarDvg();
        }

        public Stocks objEntStock = new Stocks();
        public NegocioStock objNegStock = new NegocioStock();
        private void llenarDvg()
        {
            dataGridView1.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegStock.listadoStock("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
            }
            else
                MessageBox.Show("No existe tal Stock");
        }

        private void TxtBox_a_obj()
        {

            objEntStock.ID = int.Parse(textBox1.Text);
            objEntStock.Producto = textBox2.Text;
            objEntStock.Cantida = textBox3.Text;
            objEntStock.FechaEN = dateTimePicker1.Value;
            objEntStock.Precio = int.Parse(textBox5.Text);
            objEntStock.NomProvedor = textBox4.Text;
            objEntStock.IDProv = int.Parse(textBox6.Text);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_a_obj();
                nGrabado = objNegStock.abmStock("Agregar", objEntStock);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en el stock");
                    llenarDvg();
                    Limpiar();
                    Provedores_y_detalle_de_la_compra provedores_Y_Detalle_De_La_Compra = new Provedores_y_detalle_de_la_compra();
                    provedores_Y_Detalle_De_La_Compra.Show(); ;
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR STOCK:" +
                    "NO EXISTE EL Stock O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void Limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox6.Text = string.Empty;
        }

        private void ds_a_TxtBox(DataSet ds)
        {
            textBox6.Text = ds.Tables[0].Rows[0]["IDProv"].ToString();
            //dateTimePicker1.Value = ds.Tables[0].Rows[0]["FechaCOM"].GetType();
            textBox5.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["NomProvedor"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["Cantidad"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["Producto"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["ID"].ToString();

            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_a_obj();
                resultado = objNegStock.ModStock("Modificar", objEntStock);
                if (resultado == -1)
                    MessageBox.Show("No se Modifico el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se Modifico con exito el producto");
                    llenarDvg();
                    Limpiar();
                    textBox1.Enabled = true;
                    button1.Visible = true;
                    this.Hide();
                    Provedores_y_detalle_de_la_compra provedores_Y_Detalle_De_La_Compra = new Provedores_y_detalle_de_la_compra();
                    provedores_Y_Detalle_De_La_Compra.Show(); ;
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL Modificar Stock:" +
                    "NO EXISTE EL STOCK O INGRESO MAL ALGUNA INFORMACION.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntStock.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegStock.listadoStock(objEntStock.ID.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_a_TxtBox(ds);
                button1.Visible = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Si no a borrado el stock tiene que borrar los datos de provedores:");
            try
            {
                int resultado = -1;
                TxtBox_a_obj();
                resultado = objNegStock.DeleteStock("Delet", objEntStock);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el cliente en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el cliente");
                    llenarDvg();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    button1.Visible = true;
                    this.Hide();
                }
            }
            catch
            {
              
                Provedores_y_detalle_de_la_compra provedores_Y_Detalle_De_La_Compra = new Provedores_y_detalle_de_la_compra();
                provedores_Y_Detalle_De_La_Compra.Show(); ;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Provedores_y_detalle_de_la_compra provedores_Y_Detalle_De_La_Compra = new Provedores_y_detalle_de_la_compra();
            provedores_Y_Detalle_De_La_Compra.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
