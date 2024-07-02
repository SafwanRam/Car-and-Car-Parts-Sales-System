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
    public partial class InventoryReport : Form
    {
        public InventoryReport()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        public void showdata1()
        {
            adpt = new SqlDataAdapter("select * from CarDetails", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void showdata2()
        {
            adpt = new SqlDataAdapter("select * from CarPartsDetails", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sqlsearch;
            sqlsearch = "select * from CarDetails where brand ='" + textBox2.Text + "'";
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

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            showdata1();
            showdata2();
            label1.Text = Class1.adname;
        }

        private void button1_Click(object sender, EventArgs e)
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
                dataGridView2.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data Found!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            GenerateReport gr = new GenerateReport();
            this.Hide();
            gr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OrderReport or = new OrderReport();
            this.Hide();
            or.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegisteredCustomerReport rcr = new RegisteredCustomerReport();
            this.Hide();
            rcr.Show();
        }
    }
}
