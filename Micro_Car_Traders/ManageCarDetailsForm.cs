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
    public partial class ManageCarDetailsForm : Form
    {
        public ManageCarDetailsForm()
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


        private void ManageCarDetailsForm_Load(object sender, EventArgs e)
        {
            label10.Text = Class1.adname;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from CarDetails where carID ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["model"].ToString();
                textBox3.Text = dr["brand"].ToString();
                textBox4.Text = dr["year"].ToString();
                textBox5.Text = dr["price"].ToString();
                textBox6.Text = dr["availableQuantity"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Car ID", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlinsert;
                sqlinsert = "insert into CarDetails (model, brand, year, price, availableQuantity) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'," + "'" + textBox6.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Details Added sucsessfully!!");
                Clear_Control();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
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
                    sqldelete = " delete from CarDetails where carID='" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Details Deleted sucsessfully!!");
                    Clear_Control();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM CarDetails";

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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update CarDetails set model = '" + textBox2.Text + "', brand = '" + textBox3.Text + "', year = '" + textBox4.Text + "', price = '" + textBox5.Text + "', availableQuantity = '" + textBox6.Text + "' where carID = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Details Updated Sucsessfully!!");
                Clear_Control();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ManageCarDetailsForm mcdf = new ManageCarDetailsForm();
            mcdf.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CarParts cp = new CarParts();
            cp.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomerDetails mcd = new ManageCustomerDetails();
            mcd.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

