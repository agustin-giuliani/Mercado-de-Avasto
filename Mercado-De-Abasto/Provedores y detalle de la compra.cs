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
    public partial class Provedores_y_detalle_de_la_compra : Form
    {
        public Provedores_y_detalle_de_la_compra()
        {
            InitializeComponent();
            //tabla provedor
            dataGridViewPROV.ColumnCount = 12;
            dataGridViewPROV.Columns[0].HeaderText = "ID Provedores";
            dataGridViewPROV.Columns[1].HeaderText = "Nombre provedores";
            dataGridViewPROV.Columns[2].HeaderText = "telefono";
            dataGridViewPROV.Columns[3].HeaderText = "domicilio";
            dataGridViewPROV.Columns[4].HeaderText = "ID COMPRA";
            dataGridViewPROV.Columns[5].HeaderText = "ID Provedores";
            dataGridViewPROV.Columns[6].HeaderText = "Fecha de la compra";
            dataGridViewPROV.Columns[7].HeaderText = "Tipo de factura Compra";
            dataGridViewPROV.Columns[8].HeaderText = "ID Detalle Compra";
            dataGridViewPROV.Columns[9].HeaderText = "ID de de la Compra";
            dataGridViewPROV.Columns[10].HeaderText = "Cantidad";
            dataGridViewPROV.Columns[11].HeaderText = "Precio";

            dataGridViewPROV.Columns[0].Width = 125;
            dataGridViewPROV.Columns[1].Width = 125;
            dataGridViewPROV.Columns[2].Width = 125;
            dataGridViewPROV.Columns[3].Width = 125;
            dataGridViewPROV.Columns[4].Width = 125;
            dataGridViewPROV.Columns[5].Width = 125;
            dataGridViewPROV.Columns[6].Width = 125;
            dataGridViewPROV.Columns[7].Width = 125;
            dataGridViewPROV.Columns[8].Width = 125;
            dataGridViewPROV.Columns[9].Width = 125;
            dataGridViewPROV.Columns[10].Width = 125;
            dataGridViewPROV.Columns[11].Width = 125;
            llenarDvg();
            //tabla compra
 
        }

        public Stocks objEntStock = new Stocks();
        public NegocioStock objNegStock = new NegocioStock();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock Stock = new Stock();
            Stock.Show();
        }
        //llena el datagridview provedores
        private void llenarDvg()
        {
            dataGridViewPROV.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegStock.listadoProvedor("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridViewPROV.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10], dr[11]);
                }
            }
            else
                MessageBox.Show("No existe tal Stock");
        }
        
        //llena el datagridview detalle compra
        //private void llenarDvgDC()
        //{
            //dataGridView2.Rows.Clear();

            //DataSet ds = new DataSet();

            //ds = objNegStock.listadoDetCompra("Todos");

            //if (ds.Tables[0].Rows.Count > 0)
            //{
                //foreach (DataRow dr in ds.Tables[0].Rows)
                //{
               //     dataGridView2.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3]);
              //  }
            //}
            //else
          //      MessageBox.Show("No existe tal detalle de la Compra");
        //}

        private void ds_a_TxtBox(DataSet ds)
        {
          //balores provedor
            textBox4.Text = ds.Tables[0].Rows[0]["Domicilio"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["NomProvedores"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["IDProv"].ToString();

            textBox1.Enabled = false;
        }

        private void TxtBox_a_obj_p() 
        {
            //Datos Provedores
            objEntStock.IDProv= int.Parse(textBox1.Text);
            objEntStock.NomProvedores = textBox2.Text;
            objEntStock.Tel = textBox3.Text;
            objEntStock.Domicilio = textBox4.Text;
           
        }
        private void Limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_a_obj_p();
                nGrabado = objNegStock.abmStock("Agregar-Provedor", objEntStock);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el producto en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en la tabla Provedor");
                    llenarDvg();
                    Limpiar();
                    this.Hide();
                    Form6 form6 = new Form6();
                    form6.Show();

                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Provedores:" +
                    "NO EXISTE EL Provedor O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            try
            {
                int resultado = -1;
                TxtBox_a_obj_p();
                resultado = objNegStock.DeleteProvedor("Delet-Provedor", objEntStock);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el Provedor en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el Provedor");
                    llenarDvg();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    textBox1.Enabled = true;
                    this.Hide();

                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
                Form6 form6 = new Form6();
                form6.Show();
            }
        }

       
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridViewPROV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntStock.IDProv = Convert.ToInt32(dataGridViewPROV.CurrentRow.Cells[0].Value);
            ds = objNegStock.listadoProvedor(objEntStock.IDProv.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_a_TxtBox(ds);
                button2.Visible = false;

            }
        }

    }
}
