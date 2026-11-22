using System;
using System.Windows.Forms;
using PinjemIn.Services;

namespace PinjemIn.Forms.Users
{
    public partial class UserListForm : Form
    {
        private UserService userService;

        public UserListForm()
        {
            InitializeComponent();
            userService = new UserService();
            LoadData();
        }

        private void LoadData()
        {
            var users = userService.GetAllUsers();
            dgvUsers.DataSource = users;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entryForm = new UserEntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                var userId = (Guid)dgvUsers.CurrentRow.Cells["UserId"].Value;
                var entryForm = new UserEntryForm(userId);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                var result = MessageBox.Show(
                    "Apakah Anda yakin ingin menonaktifkan pengguna ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var userId = (Guid)dgvUsers.CurrentRow.Cells["UserId"].Value;
                    userService.DeactivateUser(userId);
                    LoadData();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text;
            var users = userService.SearchUsers(searchText);
            dgvUsers.DataSource = users;
        }
    }
}