using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_De_Abasto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock Stock = new Stock();
            Stock.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clientes Cliente = new Clientes();
            Cliente.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta Venta = new Venta();
            Venta.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form2 imprimirDatos = new Form2();
            imprimirDatos.Show();
        }
    }
}
