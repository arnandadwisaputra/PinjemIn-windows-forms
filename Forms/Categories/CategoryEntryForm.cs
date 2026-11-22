using System;
using System.Windows.Forms;
using PinjemIn.Models;
using PinjemIn.Services;

namespace PinjemIn.Forms.Categories
{
    public partial class CategoryEntryForm : Form
    {
        private CategoryService categoryService;
        private long? categoryId;

        public CategoryEntryForm(long? categoryId = null)
        {
            InitializeComponent();
            categoryService = new CategoryService();
            this.categoryId = categoryId;

            if (categoryId.HasValue)
            {
                LoadCategoryData(categoryId.Value);
            }
        }

        private void LoadCategoryData(long id)
        {
            var category = categoryService.GetCategoryById(id);
            if (category != null)
            {
                txtName.Text = category.CategoryName;
                txtDescription.Text = category.Description;
                chkActive.Checked = category.IsActive;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var category = new Category
                {
                    CategoryId = categoryId ?? 0,
                    CategoryName = txtName.Text,
                    Description = txtDescription.Text,
                    IsActive = chkActive.Checked,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                if (categoryId.HasValue)
                {
                    categoryService.UpdateCategory(categoryId.Value, category);
                }
                else
                {
                    categoryService.SaveCategory(category);
                }

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
                MessageBox.Show("Nama kategori harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}