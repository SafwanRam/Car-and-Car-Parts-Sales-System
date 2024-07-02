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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

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

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.adminID = textBox1.Text;
            Class1.adname = textBox2.Text;

            string username;
            string password;

            username = txt_username.Text;
            password = txt_password.Text;


            /*string query1 = "SELECT adminID FROM AdminDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd1 = new SqlCommand(query1, con))
            {
                cmd1.Parameters.AddWithValue("@Username", username);
                cmd1.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd1.ExecuteScalar();
                    con.Close();

                    if (result != null)
                    {
                        string adminID = result.ToString();
                        textBox1.Text = adminID;
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

            string query2 = "SELECT username FROM AdminDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd2 = new SqlCommand(query2, con))
            {
                cmd2.Parameters.AddWithValue("@Username", username);
                cmd2.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd2.ExecuteScalar();
                    con.Close();

                    if (result != null)
                    {
                        string adname = result.ToString();
                        textBox2.Text = adname;

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
            }*/

            string userType = "";

            if (rdbtn_admin.Checked)
            {
                userType = "Admin";
            }
            /*else if (rdbtn_customer.Checked)
            {
                userType = "Customer";
            }*/

            string query = "";
            if (userType == "Admin")
            {
                query = "SELECT * FROM AdminDetails WHERE username='" + txt_username.Text + "' AND password='" + txt_password.Text + "'";
            }
            /*else if (userType == "Customer")
            {
                query = "SELECT * FROM Customer_Details WHERE username='" + txt_username.Text + "' AND password='" + txt_password.Text + "'";
            }*/

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            //if (txt_username.Text == "Admin" & txt_password.Text == "123456")
            if (dr.Read())
            {
                username = txt_username.Text;
                password = txt_password.Text;
                MessageBox.Show("Login Successfully");

                if (userType == "Admin")
                {
                    Admin_Dashboard adminDashboard = new Admin_Dashboard();
                    this.Hide();
                    adminDashboard.Show();
                }
                /*else if (userType == "Customer")
                {
                    CustomerDashboard cd = new CustomerDashboard();
                    this.Hide();
                    cd.Show();
                }*/
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            con.Close();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chkbox_admin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rdbtn_admin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            this.Hide();
            w.Show();
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

            string query1 = "SELECT adminID FROM AdminDetails WHERE username = @Username AND password = @Password";

            using (SqlCommand cmd = new SqlCommand(query1, con))
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
                        string adminID = result.ToString();
                        textBox1.Text = adminID;
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

            string query2 = "SELECT username FROM AdminDetails WHERE username = @Username AND password = @Password";

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
                        string adname = result.ToString();
                        textBox2.Text = adname;

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
        }
    }
}
    

