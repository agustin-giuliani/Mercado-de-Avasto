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
    public partial class DetVenta_Factura_tPago : Form
    {
        public DetVenta_Factura_tPago()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].HeaderText = "ID Detalle Venta";
            dataGridView1.Columns[1].HeaderText = "ID Stock";
            dataGridView1.Columns[2].HeaderText = "Cantidad";
            dataGridView1.Columns[3].HeaderText = "ID Venta";
            dataGridView1.Columns[4].HeaderText = "Precio";

            dataGridView1.Columns[0].Width = 125;
            dataGridView1.Columns[1].Width = 125;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 125;
            dataGridView1.Columns[4].Width = 125;
            llenarDvg();

            dataGridView2.ColumnCount = 8;
            dataGridView2.Columns[0].HeaderText = "ID Factura";
            dataGridView2.Columns[1].HeaderText = "N° Factura";
            dataGridView2.Columns[2].HeaderText = "Tipo de Cuit";
            dataGridView2.Columns[3].HeaderText = "Total";
            dataGridView2.Columns[4].HeaderText = "Saldo";
            dataGridView2.Columns[5].HeaderText = "Fecha de la factura";
            dataGridView2.Columns[6].HeaderText = "ID del cliente";
            dataGridView2.Columns[7].HeaderText = "ID de la Venta";

            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 110;
            dataGridView1.Columns[2].Width = 110;
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[4].Width = 110;
            dataGridView2.Columns[4].Width = 110;
            dataGridView2.Columns[5].Width = 110;
            dataGridView2.Columns[6].Width = 110;
            dataGridView2.Columns[7].Width = 110;
            llenarDvgF();

            dataGridView3.ColumnCount = 5;
            dataGridView3.Columns[0].HeaderText = "ID tipo de pago";
            dataGridView3.Columns[1].HeaderText = "tipo de pago ";
            dataGridView3.Columns[2].HeaderText = "Fecha de pago";
            dataGridView3.Columns[3].HeaderText = "Importe";
            dataGridView3.Columns[4].HeaderText = "ID de la factura";

            dataGridView3.Columns[0].Width = 125;
            dataGridView3.Columns[1].Width = 125;
            dataGridView3.Columns[2].Width = 125;
            dataGridView3.Columns[3].Width = 125;
            dataGridView3.Columns[4].Width = 125;
            llenarDvgt();
        }
        public Cliente objEntCliente = new Cliente();
        public Ventax objEntVenta = new Ventax();
        public NegocioVenta objNegVenta = new NegocioVenta();

        private void llenarDvg()
        {
            dataGridView1.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegVenta.listadodetVenta("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4]);
                }
            }
            else
                MessageBox.Show("No existe tal Detalle de la Venta");
        }
        private void llenarDvgF()
        {
            dataGridView2.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegVenta.listadoFactura("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView2.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }
            }
            else
                MessageBox.Show("No existe tal Factura");
        }
        private void llenarDvgt()
        {
            dataGridView3.Rows.Clear();

            DataSet ds = new DataSet();

            ds = objNegVenta.listadoTipoPago("Todos");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dataGridView3.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4]);
                }
            }
            else
                MessageBox.Show("No existe tal Factura");
        }
        private void TxtBox_a_obj()
        {
            //recive los valores de los texbox
            objEntVenta.IDdetVenta = int.Parse(textBox1.Text);
            objEntVenta.IDStock = int.Parse(textBox2.Text);
            objEntVenta.Cantidad = textBox3.Text;
            objEntVenta.IDVenta = int.Parse(textBox4.Text);
            objEntVenta.Precio = int.Parse(textBox5.Text);

        }
        private void TxtBox_F_obj()
        {
            //recive los valores de los texbox
            objEntVenta.IDfac = int.Parse(textBox6.Text);
            objEntVenta.NrFactura = int.Parse(textBox7.Text);
            objEntVenta.TipoCuit = int.Parse(textBox8.Text);
            objEntVenta.Total = int.Parse(textBox9.Text);
            objEntVenta.Saldo = int.Parse(textBox10.Text);
            objEntVenta.FechaFac = dateTimePicker1.Value;
            objEntVenta.IDCliente = int.Parse(textBox11.Text);
            objEntVenta.IDventa = int.Parse(textBox12.Text);
        }

        private void TxtBox_t_obj()
        {
            //recive los valores de los texbox
            objEntVenta.IDTipoPago = int.Parse(textBox13.Text);
            objEntVenta.TipodePago = textBox14.Text;
            objEntVenta.FechaPago = dateTimePicker2.Value;
            objEntVenta.Importe= int.Parse(textBox16.Text);
            objEntVenta.IDfac = int.Parse(textBox15.Text);

        }
        private void Limpiar()
        {
            //limpia los texbox
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;
            textBox13.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox16.Text = string.Empty;

        }
        
        private void ds_a_TxtBox(DataSet ds)
        {
            //selecciona los valores de detalles de venta
            textBox5.Text = ds.Tables[0].Rows[0]["Precio"].ToString();
            textBox4.Text = ds.Tables[0].Rows[0]["IDVenta"].ToString();
            textBox3.Text = ds.Tables[0].Rows[0]["Cantidad"].ToString();
            textBox2.Text = ds.Tables[0].Rows[0]["IDStock"].ToString();
            textBox1.Text = ds.Tables[0].Rows[0]["IDdetVenta"].ToString();
        }
        private void ds_f_TxtBox(DataSet ds)
        {
            //selecciona los valores de detalles de factura
            textBox12.Text = ds.Tables[0].Rows[0]["IDventa"].ToString();
            textBox11.Text = ds.Tables[0].Rows[0]["IDCliente"].ToString();
            textBox10.Text = ds.Tables[0].Rows[0]["Saldo"].ToString();
            textBox9.Text = ds.Tables[0].Rows[0]["Total"].ToString();
            textBox8.Text = ds.Tables[0].Rows[0]["TipoCuit"].ToString();
            textBox7.Text = ds.Tables[0].Rows[0]["NrFactura"].ToString();
            textBox6.Text = ds.Tables[0].Rows[0]["IDfac"].ToString();
        }
        private void ds_t_TxtBox(DataSet ds)
        {
            //selecciona los valores de detalles de factura
            textBox16.Text = ds.Tables[0].Rows[0]["IDfac"].ToString();
            textBox15.Text = ds.Tables[0].Rows[0]["Importe"].ToString();
            textBox14.Text = ds.Tables[0].Rows[0]["TipodePago"].ToString();
            textBox13.Text = ds.Tables[0].Rows[0]["IDTipoPago"].ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta venta = new Venta();
            venta.Show();

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            //carga detalles venta
            try
            {
                int nGrabado = -1;
                TxtBox_a_obj();
                nGrabado = objNegVenta.abmVenta("Agregar-detVenta", objEntVenta);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el detalle de la venta en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito el detalle de la venta");
                    llenarDvg();
                    Limpiar();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Detalle de la venta:" +
                    "NO EXISTE EL DETALLE DE LA VENTA O INGRESO MAL ALGUNA INFORMACION.");
            }
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //vuelve a llenar los texbox con los datos de la DB
            DataSet ds = new DataSet();
            objEntVenta.IDdetVenta = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegVenta.listadodetVenta(objEntVenta.IDdetVenta.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_a_TxtBox(ds);
             
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            //borra los datos del detalle venta
            try
            {
                int resultado = -1;
                TxtBox_a_obj();
                resultado = objNegVenta.DeletedetVenta("Delet-detVenta", objEntVenta);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el detalle de la venta en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el detalle de la venta");
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

        private void button3_Click(object sender, EventArgs e)
        {
            //carga detalles Facturas
            try
            {
                int nGrabado = -1;
                TxtBox_F_obj();
                nGrabado = objNegVenta.abmVenta("Agregar-Factura", objEntVenta);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el detalle de la venta en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito el detalle de la venta");
                    llenarDvgF();
                    Limpiar();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Detalle de la venta:" +
                    "NO EXISTE EL DETALLE DE LA VENTA O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_F_obj();
                resultado = objNegVenta.DeleteFactura("Delet-factura", objEntVenta);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el detalle de la venta en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el detalle de la venta");
                    llenarDvgF();
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //vuelve a llenar los texbox con los datos de la DB
            DataSet ds = new DataSet();
            objEntVenta.IDfac = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ds = objNegVenta.listadoFactura(objEntVenta.IDfac.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_f_TxtBox(ds);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //carga detalles Facturas
            try
            {
                int nGrabado = -1;
                TxtBox_t_obj();
                nGrabado = objNegVenta.abmVenta("Agregar-Tipopago", objEntVenta);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el detalle de la venta en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito el detalle de la venta");
                    llenarDvgt();
                    Limpiar();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Detalle de la venta:" +
                    "NO EXISTE EL DETALLE DE LA VENTA O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //vuelve a llenar los texbox con los datos de la DB
            DataSet ds = new DataSet();
            objEntVenta.IDTipoPago = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            ds = objNegVenta.listadoTipoPago(objEntVenta.IDTipoPago.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_t_TxtBox(ds);

            }
        }
    }
}
