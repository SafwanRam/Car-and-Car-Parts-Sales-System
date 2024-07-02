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
    public partial class OrderReport : Form
    {
        public OrderReport()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        private void OrderReport_Load(object sender, EventArgs e)
        {
            showdata();
            label1.Text = Class1.adname;
        }

        public void showdata()
        {
            adpt = new SqlDataAdapter("select * from OrderDetails", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from OrderDetails where orderDate ='" + dateTimePicker1.Text + "'";
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
                MessageBox.Show("No Data Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from OrderDetails where orderStatus = '" + comboBox1.Text + "'";
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
                MessageBox.Show("Invalid Date", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegisteredCustomerReport rcr = new RegisteredCustomerReport();
            this.Hide();
            rcr.Show();
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
