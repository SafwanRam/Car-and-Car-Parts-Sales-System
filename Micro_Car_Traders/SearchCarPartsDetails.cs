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
    public partial class SearchCarPartsDetails : Form
    {
        public SearchCarPartsDetails()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;

        private void SearchCarPartsDetails_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.name;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to cancel this page?", "Cancel Conformation Message", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                CustomerDashboard cd = new CustomerDashboard();
                cd.Show();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from CarPartsDetails where partName ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlsearch, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Invalid Car Part Name", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            CustomerProfile cp = new CustomerProfile();
            this.Hide();
            cp.Show();
        }
    }
}
