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
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "ID del cliente";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "Telefono";
            dataGridView1.Columns[3].HeaderText = "Debe o Pago";
            dataGridView1.Columns[4].HeaderText = "Tipo de pago";
            dataGridView1.Columns[5].HeaderText = "Fecha de pago";
            dataGridView1.Columns[6].HeaderText = "Id de la venta";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            dataGridView1.Columns[4].Width = 125;
            dataGridView1.Columns[5].Width = 125;
            dataGridView1.Columns[6].Width = 125;

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
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
            }
            else
                MessageBox.Show("No existe tal Cliente");
        }

        private void TxtBox_a_obj()
        {

            objEntCliente.ID = int.Parse(textBox1.Text);
            objEntCliente.Nombre = textBox2.Text;
            objEntCliente.Tel = textBox4.Text;
            objEntCliente.PagoDeve = textBox3.Text;
            objEntCliente.TipodePago = textBox5.Text;
            objEntCliente.FechaPago = dateTimePicker1.Value;
            objEntCliente.IDVent = int.Parse(textBox6.Text);
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
            textBox4.Text = string.Empty;
            textBox6.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      

        }

        private void ds_a_TxtBox(DataSet ds)
        {
            textBox6.Text = ds.Tables[0].Rows[0]["IDVent"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
            //dateTimePicker1.Value = ds.Tables[0].Rows[0]["FechaCOM"].GetType();
            textBox5.Text = ds.Tables[0].Rows[0]["TipodePago"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["PagoDeve"].ToString();
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
                if (resultado == -1)
                    MessageBox.Show("No se Modifico el cliente en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se Modifico con exito el cliente");
                    llenarDvg();
                    Limpiar();
                    textBox1.Enabled = true;
                    button1.Visible = true;
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
                    button1.Visible = true;
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 imprimirDatos = new Form2();
            imprimirDatos.Show();
        }
    }
}
