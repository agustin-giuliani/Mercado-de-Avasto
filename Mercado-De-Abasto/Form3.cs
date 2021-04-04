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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBMercadoDataSet1.Stock' Puede moverla o quitarla según sea necesario.
            this.stockTableAdapter.Fill(this.dBMercadoDataSet1.Stock);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock Stock = new Stock();
            Stock.Show();
        }
    }
}
