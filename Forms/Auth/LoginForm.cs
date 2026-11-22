using System;
using System.Windows.Forms;
using PinjemIn.Models;
using PinjemIn.Services;
using PinjemIn.Helpers;

namespace PinjemIn.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private UserService userService;

        public LoginForm()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var users = userService.GetAllUsers();
            var user = users.Find(u => u.Email == txtEmail.Text);

            if (user != null && user.IsActive)
            {
                SessionManager.Login(user);
                
                var mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => {
                    this.Show();
                };
                
                this.Hide();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Email atau password salah", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fitur registrasi akan tersedia setelah integrasi Supabase", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}