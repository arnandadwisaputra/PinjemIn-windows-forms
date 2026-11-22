using System;
using System.Windows.Forms;
using PinjemIn.Services;

namespace PinjemIn.Forms.Categories
{
    public partial class CategoryListForm : Form
    {
        private CategoryService categoryService;

        public CategoryListForm()
        {
            InitializeComponent();
            categoryService = new CategoryService();
            LoadData();
        }

        private void LoadData()
        {
            var categories = categoryService.GetAllCategories();
            dgvCategories.DataSource = categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entryForm = new CategoryEntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                var categoryId = (long)dgvCategories.CurrentRow.Cells["CategoryId"].Value;
                var entryForm = new CategoryEntryForm(categoryId);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.CurrentRow != null)
            {
                var result = MessageBox.Show(
                    "Apakah Anda yakin ingin menonaktifkan kategori ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var categoryId = (long)dgvCategories.CurrentRow.Cells["CategoryId"].Value;
                    categoryService.DeactivateCategory(categoryId);
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
            var categories = categoryService.SearchCategories(searchText);
            dgvCategories.DataSource = categories;
        }
    }
}