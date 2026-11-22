using System;
using System.Windows.Forms;
using PinjemIn.Services;

namespace PinjemIn.Forms.Rentals
{
    public partial class RentalListForm : Form
    {
        private RentalService rentalService;

        public RentalListForm()
        {
            InitializeComponent();
            rentalService = new RentalService();
            LoadData();
        }

        private void LoadData()
        {
            var rentals = rentalService.GetAllRentals();
            dgvRentals.DataSource = rentals;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entryForm = new RentalEntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRentals.CurrentRow != null)
            {
                var rentalId = (long)dgvRentals.CurrentRow.Cells["RentalId"].Value;
                var entryForm = new RentalEntryForm(rentalId);
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
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
            var rentals = rentalService.SearchRentals(searchText);
            dgvRentals.DataSource = rentals;
        }
    }
}