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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

        private void Clear_Control()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                try
                {
                    string sqlupdate;
                    sqlupdate = "update OrderDetails set paymentStatus = '" + label3.Text + "' where orderID = '" + textBox5.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlupdate, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment Sucsessfull!!");
                    Clear_Control();
                    
                    ViewOrderStatus vos = new ViewOrderStatus();
                    this.Hide();
                    vos.Show();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Fields can't be empty!", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OrderCar oc = new OrderCar();
            this.Hide();
            oc.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            textBox5.Text = Class1.orderID;
        }
    }
}
