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
    public partial class GenerateReport : Form
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegisteredCustomerReport rcr = new RegisteredCustomerReport();
            this.Hide();
            rcr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OrderReport or = new OrderReport();
            this.Hide();
            or.Show();
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

        private void button11_Click(object sender, EventArgs e)
        {
            InventoryReport ir = new InventoryReport();
            this.Hide();
            ir.Show();
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            label1.Text = Class1.adname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageCarDetailsForm mcd = new ManageCarDetailsForm();
            this.Hide();
            mcd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarParts cp = new CarParts();
            this.Hide();
            cp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageCustomerDetails mcd = new ManageCustomerDetails();
            this.Hide();
            mcd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ManageCustomerOrderDetails mcod = new ManageCustomerOrderDetails();
            this.Hide();
            mcod.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminProfile ap = new AdminProfile();
            this.Hide();
            ap.Show();
        }
    }
}
