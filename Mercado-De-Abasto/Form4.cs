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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBMercadoDataSet2.Venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.dBMercadoDataSet2.Venta);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta Venta = new Venta();
            Venta.Show();
        }
    }
}
