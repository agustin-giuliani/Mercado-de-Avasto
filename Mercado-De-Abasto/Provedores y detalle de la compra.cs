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
            dataGridViewPROV.ColumnCount = 4;
            dataGridViewPROV.Columns[0].HeaderText = "ID Provedores";
            dataGridViewPROV.Columns[1].HeaderText = "Nombre provedores";
            dataGridViewPROV.Columns[2].HeaderText = "telefono";
            dataGridViewPROV.Columns[3].HeaderText = "domicilio";

            dataGridViewPROV.Columns[0].Width = 125;
            dataGridViewPROV.Columns[1].Width = 125;
            dataGridViewPROV.Columns[2].Width = 125;
            dataGridViewPROV.Columns[3].Width = 125;
            llenarDvg();
            //tabla compra
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].HeaderText = "ID COMPRA";
            dataGridView1.Columns[1].HeaderText = "ID Provedores";
            dataGridView1.Columns[2].HeaderText = "Fecha de la compra";
            dataGridView1.Columns[3].HeaderText = "Tipo de factura Compra";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            llenarDvgC();

            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].HeaderText = "ID Detalle Compra";
            dataGridView2.Columns[1].HeaderText = "ID de de la Compra";
            dataGridView2.Columns[2].HeaderText = "Cantidad";
            dataGridView2.Columns[3].HeaderText = "Precio";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            llenarDvgDC();
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
                    dataGridViewPROV.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3]);
                }
            }
            else
                MessageBox.Show("No existe tal Stock");
        }
        //llena el datagridview compra
        private void llenarDvgC()
        {
            dataGridView1.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegStock.listadoCompra("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3]);
                }
            }
            else
                MessageBox.Show("No existe tal Compra");
        }
        
        //llena el datagridview detalle compra
        private void llenarDvgDC()
        {
            dataGridView2.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegStock.listadoDetCompra("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3]);
                }
            }
            else
                MessageBox.Show("No existe tal detalle de la Compra");
        }

        private void ds_a_TxtBox(DataSet ds)
        {
          //balores provedor
            textBox4.Text = ds.Tables[0].Rows[0]["Domicilio"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["NomProvedores"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["IDProv"].ToString();

            textBox1.Enabled = false;
        }

        private void ds_b_TxtBox(DataSet ds) 
        {
            //balores compra
            textBox7.Text = ds.Tables[0].Rows[0]["FactCOM"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["IDProvedores"].ToString();
            textBox5.Text = ds.Tables[0].Rows[0]["IDcompraSt"].ToString();
            textBox5.Enabled = false;
        }

        private void ds_c_TxtBox(DataSet ds) 
        {
            textBox11.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
            textBox10.Text = ds.Tables[0].Rows[0]["Cantidad"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["IDCompraSt"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["IDDetCOM"].ToString();
            textBox8.Enabled = false;
        }
        private void TxtBox_a_obj_p() 
        {
            //Datos Provedores
            objEntStock.IDProv= int.Parse(textBox1.Text);
            objEntStock.NombreProvedores = textBox2.Text;
            objEntStock.Tel = textBox3.Text;
            objEntStock.Domicilio = textBox4.Text;
           
        }
        private void TxtBox_b_obj() 
        {
            //Datos Compra
            objEntStock.IDcompraSt = int.Parse(textBox5.Text);
            objEntStock.IDProvedores = int.Parse(textBox6.Text);
            objEntStock.FechaCOM = dateTimePicker1.Value;
            objEntStock.FactCOM = textBox7.Text;

        }

        private void TxtBox_DC_obj() 
        {
            //datos detalle de la compra
            objEntStock.IDDetCOM = int.Parse(textBox8.Text);
            objEntStock.IDcompraSt = int.Parse(textBox9.Text);
            objEntStock.Cantidad = textBox10.Text;
            objEntStock.Precio = int.Parse(textBox11.Text);
        }
        private void Limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
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
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_b_obj();
                nGrabado = objNegStock.abmStock("Agregar-Compra", objEntStock);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo la Compra en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en la tabla Compra");
                    llenarDvgC();
                    Limpiar();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Compra:" +
                    "NO EXISTE la Compra O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_b_obj();
                resultado = objNegStock.DeleteCompra("Delet-Compra", objEntStock);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el Provedor en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito la Compra");
                    llenarDvgC();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    textBox5.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar Compra:" +
                    "NO EXISTE la compra O INGRESO MAL ALGUNA INFORMACION.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataSet ds = new DataSet();
            objEntStock.IDcompraSt = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegStock.listadoCompra(objEntStock.IDcompraSt.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_b_TxtBox(ds);
                button3.Visible = false;

            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntStock.IDDetCOM = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegStock.listadoDetCompra(objEntStock.IDDetCOM.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_c_TxtBox(ds);
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int nGrabado = -1;
                TxtBox_DC_obj();
                nGrabado = objNegStock.abmStock("Agregar-DetCompra", objEntStock);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo la Compra en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito en la tabla Compra");
                    llenarDvgDC();
                    Limpiar();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Compra:" +
                    "NO EXISTE la Compra O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_DC_obj();
                resultado = objNegStock.DeleteDetCompra("Delet-DetCompra", objEntStock);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el detalle de la compra en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el detalle de la compra Compra");
                    llenarDvgDC();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    textBox8.Enabled = true;
                   
                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar el detalle Compra:" +
                    "NO EXISTE el detalle de la compra O INGRESO MAL ALGUNA INFORMACION.");
            }

        }
    }
}
