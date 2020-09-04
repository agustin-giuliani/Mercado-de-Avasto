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
    public partial class Clientes : Form
    {
        
        public Clientes()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Compra";
            dataGridView1.Columns[3].HeaderText = "Deve o Pago";
            dataGridView1.Columns[4].HeaderText = "Fecha de compra";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            dataGridView1.Columns[4].Width = 125;
            llenarDvg();
        }

        public Cliente objEntCliente = new Cliente();
        public NegocioCliente objNegCliente = new NegocioCliente();
        private void llenarDvg()
        {
            dataGridView1.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegCliente.listadoCliente("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4]);
                }
            }
            else
                MessageBox.Show("No existe tal Cliente");
        }

        private void TxtBox_a_obj()
        {

            objEntCliente.ID = int.Parse(textBox1.Text);
            objEntCliente.Nombre = textBox2.Text;
            objEntCliente.DevePago = textBox3.Text;
            objEntCliente.FechaCOM = dateTimePicker1.Value;
            objEntCliente.Compra = textBox5.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();

        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_a_obj();
                nGrabado = objNegCliente.abmCliente("Agregar", objEntCliente);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el cliente en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito el cliente");
                    llenarDvg();
                    Limpiar();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void Limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;         
            textBox5.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      

        }

        private void ds_a_TxtBox(DataSet ds)
        {
            //dateTimePicker1.Value = ds.Tables[0].Rows[0]["FechaCOM"].GetType();
            textBox5.Text = ds.Tables[0].Rows[0]["COMPRA"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["DevePago"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["ID"].ToString();

            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_a_obj();
                resultado = objNegCliente.abmCliente("Modificar", objEntCliente);
                if (resultado != -1)
                    MessageBox.Show("No se Modifico el cliente en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se Modifico con exito el cliente");
                    llenarDvg();
                    Limpiar();
                    textBox1.Enabled = true;
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL Modificar Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntCliente.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegCliente.listadoCliente(objEntCliente.ID.ToString());
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
                resultado = objNegCliente.DeleteCliente("Delet", objEntCliente);
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
