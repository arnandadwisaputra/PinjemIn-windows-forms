using System;
using System.Windows.Forms;

namespace PinjemIn.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            lblTotalUsers.Text = "0";
            lblTotalCategories.Text = "0";
            lblTotalItems.Text = "0";
            lblTotalRentals.Text = "0";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
            MessageBox.Show("Data dashboard diperbarui", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}