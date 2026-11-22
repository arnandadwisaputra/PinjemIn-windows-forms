using System;
using System.Windows.Forms;
using PinjemIn.Models;
using PinjemIn.Services;
using PinjemIn.Helpers;

namespace PinjemIn.Forms.Rentals
{
    public partial class RentalEntryForm : Form
    {
        private RentalService rentalService;
        private ItemService itemService;
        private long? rentalId;

        public RentalEntryForm(long? rentalId = null)
        {
            InitializeComponent();
            rentalService = new RentalService();
            itemService = new ItemService();
            this.rentalId = rentalId;

            LoadItems();

            if (rentalId.HasValue)
            {
                LoadRentalData(rentalId.Value);
                cmbItem.Enabled = false;
            }
        }

        private void LoadItems()
        {
            var items = itemService.GetActiveItems();
            cmbItem.DataSource = items;
            cmbItem.DisplayMember = "ItemName";
            cmbItem.ValueMember = "ItemId";
        }

        private void LoadRentalData(long id)
        {
            var rental = rentalService.GetRentalById(id);
            if (rental != null)
            {
                cmbItem.SelectedValue = rental.ItemId;
                dtpStartDate.Value = rental.StartDate;
                dtpEndDate.Value = rental.EndDate;
                txtNote.Text = rental.OwnerNote;
                CalculateTotal();
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            if (cmbItem.SelectedValue != null)
            {
                var itemId = (long)cmbItem.SelectedValue;
                var item = itemService.GetItemById(itemId);
                
                if (item != null)
                {
                    var days = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days + 1;
                    if (days > 0)
                    {
                        var total = item.DailyPrice * days;
                        lblDays.Text = $"{days} hari";
                        lblTotal.Text = $"Rp {total:N0}";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var itemId = (long)cmbItem.SelectedValue;
                var item = itemService.GetItemById(itemId);
                var days = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days + 1;

                var rental = new Rental
                {
                    RentalId = rentalId ?? 0,
                    ItemId = itemId,
                    RenterId = SessionManager.CurrentUser.UserId,
                    StartDate = dtpStartDate.Value.Date,
                    EndDate = dtpEndDate.Value.Date,
                    DailyPriceSnapshot = item.DailyPrice,
                    TotalPrice = item.DailyPrice * days,
                    RentalStatus = "pending",
                    OwnerNote = txtNote.Text,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                rentalService.SaveRental(rental);
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
            if (cmbItem.SelectedValue == null)
            {
                MessageBox.Show("Pilih barang terlebih dahulu", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("Tanggal selesai tidak boleh lebih awal dari tanggal mulai", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}