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
            this.Hide();
            Clientes Cliente = new Clientes();
            Cliente.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBMercadoDataSet3.Cliente' Puede moverla o quitarla según sea necesario.
            this.clienteTableAdapter1.Fill(this.dBMercadoDataSet3.Cliente);
          
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


        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
