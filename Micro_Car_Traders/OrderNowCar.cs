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
    public partial class OrderNowCar : Form
    {
        public OrderNowCar()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderNowCar_Load(object sender, EventArgs e)
        {
            label8.Text = Class1.name;
            textBox6.Text = Class1.customerID;
            label9.Text = DateTime.Now.ToLongDateString();
            textBox1.Text = Class1.carID;
            textBox7.Text = Class1.orderID;

            string sqlsearch;
            sqlsearch = "select * from CarDetails where carID ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["model"].ToString();
                textBox3.Text = dr["brand"].ToString();
                textBox5.Text = dr["year"].ToString();
                textBox4.Text = dr["price"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Car ID", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlinsert;
                sqlinsert = "insert into OrderDetails (orderID, customerID, customerName, carID, brand, model, item, orderDate, paymentStatus) values ('" + textBox7.Text + "','" + textBox6.Text + "','" + label8.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + label10.Text + "','" + label9.Text + "','" + label11.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Do you want to order the car?", "Order Conformation Message", MessageBoxButtons.YesNo);

                Payment p = new Payment();
                p.Show();
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

        private void label2_Click(object sender, EventArgs e)
        {
            OrderCar oc = new OrderCar();
            this.Hide();
            oc.Show();
        }
    }
}
