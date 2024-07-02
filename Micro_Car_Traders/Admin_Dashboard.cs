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
    public partial class Admin_Dashboard : Form
    {
        private Timer timer = new Timer();
        public Admin_Dashboard()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += label3_Click;
            timer.Start();
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

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.adname;
            label4.Text = DateTime.Now.ToLongDateString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCarDetailsForm mcdf = new ManageCarDetailsForm();
            mcdf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarParts cp = new CarParts();
            cp.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomerDetails mcd = new ManageCustomerDetails();
            mcd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageCustomerOrderDetails md = new ManageCustomerOrderDetails();
            md.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
