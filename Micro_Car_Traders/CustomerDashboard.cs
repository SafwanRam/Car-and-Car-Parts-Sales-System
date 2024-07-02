using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micro_Car_Traders
{
    public partial class CustomerDashboard : Form
    {
        private Timer timer = new Timer();
        public CustomerDashboard()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += label3_Click;
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchCar sc = new SearchCar();
            this.Hide();
            sc.Show();

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

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.name;
            label4.Text = DateTime.Now.ToLongDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ViewOrderStatus VOS = new ViewOrderStatus();
            this.Hide();
            VOS.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CustomerProfile cp = new CustomerProfile();
            this.Hide();
            cp.Show();
        }
    }
}
