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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.customerID = textBox1.Text;
            Class1.name = textBox2.Text;

            string username;
            string password;

            username = txt_username.Text;
            password = txt_password.Text;

            string userType = "";

            if (rdbtn_customer.Checked)
            {
                userType = "Customer";
            }

            string query = "";
            if (userType == "Customer")
            {
                query = "SELECT * FROM CustomerDetails WHERE username='" + txt_username.Text + "' AND password='" + txt_password.Text + "'";
            }

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                username = txt_username.Text;
                password = txt_password.Text;
                MessageBox.Show("Login Successfully");

                if (userType == "Customer")
                {
                    CustomerDashboard cd = new CustomerDashboard();
                    this.Hide();
                    cd.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerRegister cr = new CustomerRegister();
            this.Hide();
            cr.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            this.Hide();
            fp.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox3.Checked == true)
                {
                    txt_password.UseSystemPasswordChar = true;
                }
                else
                {
                    txt_password.UseSystemPasswordChar = false;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT customerID FROM CustomerDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    con.Close();

                    if (result != null)
                    {
                        string customerID = result.ToString();
                        textBox1.Text = customerID;

                        //MessageBox.Show("Account is ACTIVE.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("Account is NOT ACTIVE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string query2 = "SELECT name FROM CustomerDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd = new SqlCommand(query2, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    con.Close();

                    if (result != null)
                    {
                        string name = result.ToString();
                        textBox2.Text = name;

                        MessageBox.Show("Account is ACTIVE.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Account is NOT ACTIVE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            this.Hide();
            w.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Exit this Application", "Exit Conformation Message", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "SELECT customerID FROM CustomerDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    con.Close();

                    if (result != null)
                    {
                        string customerID = result.ToString();
                        textBox1.Text = customerID;

                        //MessageBox.Show("Account is ACTIVE.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("Account is NOT ACTIVE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            string query2 = "SELECT name FROM CustomerDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd = new SqlCommand(query2, con))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    con.Close();

                    if (result != null)
                    {
                        string name = result.ToString();
                        textBox2.Text = name;

                        //MessageBox.Show("Account is ACTIVE.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // MessageBox.Show("Account is NOT ACTIVE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
