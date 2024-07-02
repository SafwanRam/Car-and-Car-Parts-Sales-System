﻿using System;
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
    public partial class OrderCarParts : Form
    {
        public OrderCarParts()
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

        public void GetID()
        {
            string ID;
            string query = "select orderID from OrderDetails order by orderID Desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                ID = id.ToString("0");
            }
            else if (Convert.IsDBNull(dr))
            {
                ID = ("0");
            }
            else
            {
                ID = ("1");
            }

            con.Close();

            textBox8.Text = ID.ToString();

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

        private void OrderCarParts_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.name;
            textBox7.Text = Class1.customerID;
            label10.Text = DateTime.Now.ToLongDateString();
            GetID();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewOrderStatus vos = new ViewOrderStatus();
            this.Hide();
            vos.Show();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            OrderCar oc = new OrderCar();
            this.Hide();
            oc.Show();
        }

        private void button10_Click(object sender, EventArgs e)
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
                textBox3.Text = dr["carModel"].ToString();
                textBox5.Text = dr["year"].ToString();
                textBox6.Text = dr["price"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Car Part ID", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Class1.partID = textBox1.Text;
            Class1.orderID = textBox8.Text;

            OrderNowCarPart ocn = new OrderNowCarPart();
            ocn.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerProfile cp = new CustomerProfile();
            this.Hide();
            cp.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
