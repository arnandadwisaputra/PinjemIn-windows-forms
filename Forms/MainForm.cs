using System;
using System.Windows.Forms;
using PinjemIn.Helpers;

namespace PinjemIn.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadUserInfo();
            ConfigureMenuAccess();
        }

        private void LoadUserInfo()
        {
            if (SessionManager.CurrentUser != null)
            {
                lblUserName.Text = SessionManager.CurrentUser.FullName;
                lblUserRole.Text = SessionManager.CurrentUser.Role.ToUpper();
            }
        }

        private void ConfigureMenuAccess()
        {
            if (SessionManager.IsAdmin)
            {
                btnUsers.Visible = true;
                btnCategories.Visible = true;
            }
            else
            {
                btnUsers.Visible = false;
                btnCategories.Visible = true;
            }
        }

        private void LoadFormInPanel(Form childForm)
        {
            panelMain.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new DashboardForm());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Users.UserListForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Categories.CategoryListForm());
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Items.ItemListForm());
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new Rentals.RentalListForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SessionManager.Logout();
                this.Close();
            }
        }
    }
}