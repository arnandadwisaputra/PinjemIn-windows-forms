using System;
using System.Windows.Forms;
using PinjemIn.Models;
using PinjemIn.Services;
using PinjemIn.Helpers;

namespace PinjemIn.Forms.Items
{
    public partial class ItemEntryForm : Form
    {
        private ItemService itemService;
        private CategoryService categoryService;
        private long? itemId;

        public ItemEntryForm(long? itemId = null)
        {
            InitializeComponent();
            itemService = new ItemService();
            categoryService = new CategoryService();
            this.itemId = itemId;

            LoadCategories();

            if (itemId.HasValue)
            {
                LoadItemData(itemId.Value);
            }
        }

        private void LoadCategories()
        {
            var categories = categoryService.GetAllCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void LoadItemData(long id)
        {
            var item = itemService.GetItemById(id);
            if (item != null)
            {
                txtName.Text = item.ItemName;
                cmbCategory.SelectedValue = item.CategoryId;
                txtDescription.Text = item.Description;
                txtCondition.Text = item.Condition;
                numPrice.Value = item.DailyPrice;
                chkActive.Checked = item.ItemStatus == "active";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var item = new Item
                {
                    ItemId = itemId ?? 0,
                    OwnerId = SessionManager.CurrentUser.UserId,
                    CategoryId = (long)cmbCategory.SelectedValue,
                    ItemName = txtName.Text,
                    Description = txtDescription.Text,
                    Condition = txtCondition.Text,
                    DailyPrice = numPrice.Value,
                    ItemStatus = chkActive.Checked ? "active" : "inactive",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                itemService.SaveItem(item);
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
                MessageBox.Show("Nama barang harus diisi", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Harga harus lebih besar dari 0", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}