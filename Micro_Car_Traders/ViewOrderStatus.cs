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
    public partial class ViewOrderStatus : Form
    {
        public ViewOrderStatus()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FFSCS9P\\SQLEXPRESS;Initial Catalog=MicroCarTraders;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void showdata()
        {
            adpt = new SqlDataAdapter("select orderID, carID, part_ID, brand, model, item, orderDate, paymentStatus, OrderStatus from OrderDetails where customerID='" + textBox1.Text+"'", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ViewOrderStatus_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.name;
            textBox1.Text = Class1.customerID;
            showdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCar sc = new SearchCar();
            this.Hide();
            sc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchCarPartsDetails scpd = new SearchCarPartsDetails();
            this.Hide();
            scpd.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerProfile cp = new CustomerProfile();
            this.Hide();
            cp.Show();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
