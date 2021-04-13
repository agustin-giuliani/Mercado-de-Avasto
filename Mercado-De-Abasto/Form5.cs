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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
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
        private void TxtBox_t_obj()
        {
            //recive los valores de los texbox
            objEntVenta.IDTipoPago = int.Parse(textBox13.Text);
            objEntVenta.TipodePago = textBox14.Text;
            objEntVenta.FechaPago = dateTimePicker2.Value;
            objEntVenta.Importe = int.Parse(textBox16.Text);
            objEntVenta.IDfacturas = int.Parse(textBox15.Text);

        }

        private void Limpiar()
        {
            textBox13.Text = string.Empty;
            textBox14.Text = string.Empty;
            textBox15.Text = string.Empty;
            textBox16.Text = string.Empty;
        }
        private void ds_t_TxtBox(DataSet ds)
        {
            //selecciona los valores de detalles de factura
            textBox16.Text = ds.Tables[0].Rows[0]["IDfacturas"].ToString();
            textBox15.Text = ds.Tables[0].Rows[0]["Importe"].ToString();
            textBox14.Text = ds.Tables[0].Rows[0]["TipodePago"].ToString();
            textBox13.Text = ds.Tables[0].Rows[0]["IDTipoPago"].ToString();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            //carga detalles Tipo de pagos
            try
            {
                int nGrabado = -1;
                TxtBox_t_obj();
                nGrabado = objNegVenta.abmVenta("Agregar-Tipopago", objEntVenta);
                if (nGrabado == -1)
                    MessageBox.Show("No se grabo el tipo de pago en el sistema" + "INTENTE NUEVAMENTE");
                else
                {
                    MessageBox.Show("Se grabo con exito el tipo de pago");
                    llenarDvgt();
                    Limpiar();
                    this.Hide();
                    Venta venta = new Venta();
                    venta.Show();
                }


            }
            catch
            {
                MessageBox.Show("ERROR AL CARGAR Detalle de la venta:" +
                    "NO EXISTE EL DETALLE DE LA VENTA O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                int resultado = -1;
                TxtBox_t_obj();
                resultado = objNegVenta.DeleteTipoPago("Delet-Tpago", objEntVenta);
                if (resultado == -1)
                {
                    MessageBox.Show("No se Borro el tipo de pago en el sistema" + "INTENTE NUEVAMENTE");
                }
                else
                {
                    MessageBox.Show("Se Borro con exito el tipo de pago");
                    llenarDvgt();
                    Limpiar();
                    //dataGridView1.Columns.Clear();
                    this.Hide();

                }
            }
            catch
            {
                MessageBox.Show("ERROR AL borrar Cliente:" +
                    "NO EXISTE EL CLIENTE O INGRESO MAL ALGUNA INFORMACION.");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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
