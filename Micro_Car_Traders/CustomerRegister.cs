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


    public partial class CustomerRegister : Form
    {
        public CustomerRegister()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 lg = new Form2();
            this.Hide();
            lg.Show();
        }
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked == true)
                {
                    textBox6.UseSystemPasswordChar = true;
                }
                else
                {
                    textBox6.UseSystemPasswordChar = false;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlinsert = "INSERT INTO CustomerDetails (name, email, phone, address, registerDate, username, password) VALUES (@name, @email, @phone, @address, @date, @username, @password); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@date", label9.Text);
                cmd.Parameters.AddWithValue("@username", textBox5.Text);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);
                con.Open();
            
                int generatedID = Convert.ToInt32(cmd.ExecuteScalar());
                
                txt_cusID.Text = generatedID.ToString();

                MessageBox.Show("Registered successfully!!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                con.Close();
            }
        }
        
        private void txt_cusID_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerRegister_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();
        }
    }
}
