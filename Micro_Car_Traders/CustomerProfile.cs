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
    public partial class CustomerProfile : Form
    {
        public CustomerProfile()
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
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCar sc = new SearchCar();
            this.Hide();
            sc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchCarPartsDetails spc = new SearchCarPartsDetails();
            this.Hide();
            spc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderCar oc = new OrderCar();
            this.Hide();
            oc.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderCarParts ocp = new OrderCarParts();
            this.Hide();
            ocp.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewOrderStatus vos = new ViewOrderStatus();
            this.Hide();
            vos.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to signout", "Logout Conformation Message", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from CustomerDetails where customerID= '"+textBox7.Text+"'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["name"].ToString();
                textBox4.Text = dr["email"].ToString();
                textBox2.Text = dr["phone"].ToString();
                textBox5.Text = dr["address"].ToString();
                textBox3.Text = dr["username"].ToString();
                textBox6.Text = dr["password"].ToString();
            }
            else
            {

            }
            con.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void CustomerProfile_Load(object sender, EventArgs e)
        {
            textBox7.Text = Class1.customerID;
            label1.Text = Class1.name;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update CustomerDetails set name = '" + textBox1.Text + "', phone = '" + textBox2.Text + "', username = '" + textBox3.Text + "', email = '"+textBox4.Text+"', address = '"+textBox5.Text+"', password = '"+textBox6.Text+"' where customerID = '"+textBox7.Text+"'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Admin Password Updated Sucsessfully!!");
                Clear_Control();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
