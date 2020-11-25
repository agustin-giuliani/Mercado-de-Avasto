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
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Producto";
            dataGridView1.Columns[2].HeaderText = "Cantidad";
            dataGridView1.Columns[3].HeaderText = "Precio";
            dataGridView1.Columns[4].HeaderText = "Fecha Venta";
            

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            dataGridView1.Columns[4].Width = 125;
            
            llenarDvg();
        }
        public Cliente objEntCliente = new Cliente();
        public Ventax objEntVenta = new Ventax();
        public NegocioVenta objNegVenta = new NegocioVenta();
        private void llenarDvg()
        {
            dataGridView1.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegVenta.listadoVenta("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4]);
                }
            }
            else
                MessageBox.Show("No existe tal Venta");
        }

        private void TxtBox_a_obj()
        {

            objEntVenta.ID = int.Parse(textBox1.Text);
            objEntVenta.Producto = textBox2.Text;
            objEntVenta.Cantidad = textBox4.Text;
            objEntVenta.FechaVen = dateTimePicker1.Value;
            objEntVenta.Precio = int.Parse(textBox3.Text);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }

        private void Venta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_a_obj();
                nGrabado = objNegVenta.abmVenta("Agregar", objEntVenta);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en el stock");
                    llenarDvg();
                    Limpiar();
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
            textBox4.Text = string.Empty;
        }

        private void ds_a_TxtBox(DataSet ds)
        {
            
            //dateTimePicker1.Value = ds.Tables[0].Rows[0]["FechaCOM"].GetType();
            textBox4.Text = ds.Tables[0].Rows[0]["Cantidad"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
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
                resultado = objNegVenta.ModVenta("Modificar", objEntVenta);
                if (resultado == -1)
                    MessageBox.Show("No se Modifico el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se Modifico con exito el producto");
                    llenarDvg();
                    Limpiar();
                    textBox1.Enabled = true;
                    button1.Visible = true;
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
            objEntVenta.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegVenta.listadoVenta(objEntVenta.ID.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_a_TxtBox(ds);
                button1.Visible = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_a_obj();
                resultado = objNegVenta.DeleteVenta("Delet", objEntVenta);
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
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
            }
        }
    }
}
