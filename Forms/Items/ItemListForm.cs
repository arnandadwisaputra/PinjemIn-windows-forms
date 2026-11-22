using System;
using System.Windows.Forms;
using PinjemIn.Services;

namespace PinjemIn.Forms.Items
{
    public partial class ItemListForm : Form
    {
        private ItemService itemService;

        public ItemListForm()
        {
            InitializeComponent();
            itemService = new ItemService();
            LoadData();
        }

        private void LoadData()
        {
            var items = itemService.GetAllItems();
            dgvItems.DataSource = items;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entryForm = new ItemEntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow != null)
            {
                var itemId = (long)dgvItems.CurrentRow.Cells["ItemId"].Value;
                var entryForm = new ItemEntryForm(itemId);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvItems.CurrentRow != null)
            {
                var result = MessageBox.Show(
                    "Apakah Anda yakin ingin menonaktifkan barang ini?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var itemId = (long)dgvItems.CurrentRow.Cells["ItemId"].Value;
                    itemService.DeactivateItem(itemId);
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
            var items = itemService.SearchItems(searchText);
            dgvItems.DataSource = items;
        }
    }
}