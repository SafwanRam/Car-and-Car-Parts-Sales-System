using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Micro_Car_Traders
{
    public partial class OrderNowCarPart : Form
    {
        public OrderNowCarPart()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlinsert;
                sqlinsert = "insert into OrderDetails (orderID, customerID, customerName, part_ID, brand, model, item, orderDate, paymentStatus) values ('" + textBox6.Text + "','" + textBox7.Text + "','" + label10.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox8.Text + "','" + label9.Text + "','" + label11.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Do you want to order the car part?", "Order Conformation Message", MessageBoxButtons.YesNo);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();

            Payment pay = new Payment();
            this.Hide();
            pay.Show();
        }

        private void OrderNowCarPart_Load(object sender, EventArgs e)
        {
            label10.Text = Class1.name;
            textBox7.Text = Class1.customerID;
            label9.Text = DateTime.Now.ToLongDateString();
            textBox2.Text = Class1.partID;
            textBox6.Text = Class1.orderID;

            string sqlsearch;
            sqlsearch = "select * from CarPartsDetails where part_ID ='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox8.Text = dr["partName"].ToString();
                textBox4.Text = dr["carBrand"].ToString();
                textBox3.Text = dr["carModel"].ToString();
                textBox5.Text = dr["year"].ToString();
                textBox1.Text = dr["price"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Car Part ID", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }
    }
}
