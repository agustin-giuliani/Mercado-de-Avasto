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
using System.Data.SqlClient;

namespace Mercado_De_Abasto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
           
        }
        public SqlConnection conexion;
        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBMercadoDataSet2.Venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.dBMercadoDataSet2.Venta);
            // TODO: esta línea de código carga datos en la tabla 'dBMercadoDataSet1.Stock' Puede moverla o quitarla según sea necesario.
            this.stockTableAdapter.Fill(this.dBMercadoDataSet1.Stock);
            // TODO: esta línea de código carga datos en la tabla 'dBMercadoDataSet.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter.Fill(this.dBMercadoDataSet.Cliente);

        }

        private void button2_Click(object sender, EventArgs e)
        {
        

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
             SqlConnection con = new SqlConnection(Properties.Settings.Default.DBMercadoConnectionString);

            string query = "select * from Cliente where " + comboBox1.Text + " like '%"+ textBox1.Text +"%'";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);
            
            con.Open();
            DataSet data = new DataSet();
            ada.Fill(data, "Cliente");

            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "Cliente";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DBMercadoConnectionString);
            string query = "select * from Stock where " + comboBox2.Text + " like '%" + textBox2.Text + "%'";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            con.Open();
            DataSet data = new DataSet();
            ada.Fill(data, "Stock");

            dataGridView2.DataSource = data;
            dataGridView2.DataMember = "Stock";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DBMercadoConnectionString);
            string query = "select * from Venta where " + comboBox3.Text + " like '%" + textBox3.Text + "%'";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            con.Open();
            DataSet data = new DataSet();
            ada.Fill(data, "Venta");

            dataGridView3.DataSource = data;
            dataGridView3.DataMember = "Venta";
        }
    }
}
