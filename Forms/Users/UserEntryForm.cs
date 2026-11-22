using System;
using System.Windows.Forms;
using PinjemIn.Models;
using PinjemIn.Services;

namespace PinjemIn.Forms.Users
{
    public partial class UserEntryForm : Form
    {
        private UserService userService;
        private Guid? userId;

        public UserEntryForm(Guid? userId = null)
        {
            InitializeComponent();
            userService = new UserService();
            this.userId = userId;

            if (userId.HasValue)
            {
                LoadUserData(userId.Value);
            }
        }

        private void LoadUserData(Guid id)
        {
            var user = userService.GetUserById(id);
            if (user != null)
            {
                txtName.Text = user.FullName;
                txtStudentNumber.Text = user.StudentNumber;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                cmbRole.SelectedItem = user.Role;
                chkActive.Checked = user.IsActive;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var user = new User
                {
                    UserId = userId ?? Guid.NewGuid(),
                    FullName = txtName.Text,
                    StudentNumber = txtStudentNumber.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Role = cmbRole.SelectedItem.ToString(),
                    IsActive = chkActive.Checked,
                    CreatedAt = DateTime.Now
                };

                userService.SaveUser(user);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nama harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}