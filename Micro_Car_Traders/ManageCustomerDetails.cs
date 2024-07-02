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
    public partial class ManageCustomerDetails : Form
    {
        public ManageCustomerDetails()
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
        }


        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to cancel this page?", "Cancel Conformation Message", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Admin_Dashboard ad = new Admin_Dashboard();
                ad.Show();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void ManageCustomerDetails_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.adname;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from CustomerDetails where customerID ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["name"].ToString();
                textBox4.Text = dr["email"].ToString();
                textBox3.Text = dr["phone"].ToString();
                textBox5.Text = dr["address"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Customer ID", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string sqldelete;
                    sqldelete = "delete from CustomerDetails where customerID='" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Details Deleted sucsessfully!!");
                    Clear_Control();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update CustomerDetails set name = '" + textBox2.Text + "', email = '" + textBox4.Text + "',phone = '" + textBox3.Text + "', address = '" + textBox5.Text + "' where customerID = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Details Updated Sucsessfully!!");
                Clear_Control();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to signout", "Logout Conformation Message", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "SELECT customerID, name, email, phone, address FROM CustomerDetails";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCarDetailsForm mcdf = new ManageCarDetailsForm();
            mcdf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarParts cp = new CarParts();
            cp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomerDetails mcd = new ManageCustomerDetails();
            mcd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomerOrderDetails md = new ManageCustomerOrderDetails();
            md.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminProfile ap = new AdminProfile();
            this.Hide();
            ap.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenerateReport gr = new GenerateReport();
            this.Hide();
            gr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
