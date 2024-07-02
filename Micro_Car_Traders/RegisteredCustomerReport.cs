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
    public partial class RegisteredCustomerReport : Form
    {
        public RegisteredCustomerReport()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        private void RegisteredCustomerReport_Load(object sender, EventArgs e)
        {
            showdata();
            label1.Text = Class1.adname;
        }

        public void showdata()
        {
            adpt = new SqlDataAdapter("select customerID, name, email, phone, address, registerDate from CustomerDetails", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select customerID, name, email, phone, address, registerDate from CustomerDetails where registerDate ='" + dateTimePicker1.Text + "'";
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
                MessageBox.Show("no Data Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OrderReport or = new OrderReport();
            this.Hide();
            or.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            GenerateReport gr = new GenerateReport();
            this.Hide();
            gr.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            InventoryReport ir = new InventoryReport();
            this.Hide();
            ir.Show();
        }
    }
}
