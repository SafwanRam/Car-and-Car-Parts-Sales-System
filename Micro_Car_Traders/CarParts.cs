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
    public partial class CarParts : Form
    {
        public CarParts()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

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

        private void Clear_Control()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }


        private void CarParts_Load(object sender, EventArgs e)
        {
            label11.Text = Class1.adname;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void button12_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from CarPartsDetails where part_ID ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["partName"].ToString();
                textBox4.Text = dr["carBrand"].ToString();
                textBox6.Text = dr["carModel"].ToString();
                textBox7.Text = dr["year"].ToString();
                textBox3.Text = dr["price"].ToString();
                textBox5.Text = dr["availableQuantity"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Car Part ID", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlinsert;
                sqlinsert = "insert into CarPartsDetails (partName, carBrand, carModel, year, price, availableQuantity) values ('" + textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox3.Text + "'," + "'" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(sqlinsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Parts Details Added Sucsessfully!!");
                Clear_Control();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    string sqldelete;
                    sqldelete = "delete from CarPartsDetails where part_ID='" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqldelete, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Part Details Deleted sucsessfully!!");
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
            string query = "SELECT * FROM CarPartsDetails";

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

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlupdate;
                sqlupdate = "update CarPartsDetails set partName = '" + textBox2.Text + "', carBrand = '" + textBox4.Text + "', carModel = '" + textBox6.Text + "', year = '" + textBox7.Text + "', price = '" + textBox3.Text + "', availableQuantity = '" + textBox5.Text + "'  where part_ID = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlupdate, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Car Part Details Updated Sucsessfully!!");
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
    }
}
