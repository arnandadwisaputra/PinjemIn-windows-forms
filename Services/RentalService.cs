using System;
using System.Collections.Generic;
using System.Linq;
using PinjemIn.Models;

namespace PinjemIn.Services
{
    public class RentalService
    {
        private static List<Rental> rentals = new List<Rental>();

        static RentalService()
        {
            InitializeDummyData();
        }

        private static void InitializeDummyData()
        {
            // Add some dummy rentals
            rentals.Add(new Rental
            {
                RentalId = 1,
                ItemId = 1,
                RenterId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                StartDate = new DateTime(2024, 11, 20),
                EndDate = new DateTime(2024, 11, 25),
                DailyPriceSnapshot = 150000,
                TotalPrice = 900000,
                RentalStatus = "approved",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            rentals.Add(new Rental
            {
                RentalId = 2,
                ItemId = 2,
                RenterId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                StartDate = new DateTime(2024, 11, 22),
                EndDate = new DateTime(2024, 11, 28),
                DailyPriceSnapshot = 500000,
                TotalPrice = 1500000,
                RentalStatus = "pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            rentals.Add(new Rental
            {
                RentalId = 3,
                ItemId = 3,
                RenterId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                StartDate = new DateTime(2024, 11, 15),
                EndDate = new DateTime(2024, 11, 20),
                DailyPriceSnapshot = 50000,
                TotalPrice = 300000,
                RentalStatus = "approved",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }

        public List<Rental> GetAllRentals()
        {
            return rentals;
        }

        public Rental GetRentalById(long rentalId)
        {
            return rentals.FirstOrDefault(r => r.RentalId == rentalId);
        }

        public void SaveRental(Rental rental)
        {
            var existing = rentals.FirstOrDefault(r => r.RentalId == rental.RentalId);
            if (existing != null)
            {
                existing.RenterId = rental.RenterId;
                existing.ItemId = rental.ItemId;
                existing.StartDate = rental.StartDate;
                existing.EndDate = rental.EndDate;
                existing.DailyPriceSnapshot = rental.DailyPriceSnapshot;
                existing.TotalPrice = rental.TotalPrice;
                existing.RentalStatus = rental.RentalStatus;
                existing.OwnerNote = rental.OwnerNote;
                existing.UpdatedAt = DateTime.Now;
            }
            else
            {
                rental.RentalId = rentals.Count + 1;
                rental.CreatedAt = DateTime.Now;
                rental.UpdatedAt = DateTime.Now;
                rentals.Add(rental);
            }
        }

        public void CalculateTotalPrice(Rental rental, decimal dailyPrice)
        {
            var days = (rental.EndDate.Date - rental.StartDate.Date).Days + 1;
            rental.TotalPrice = dailyPrice * days;
        }

        public List<Rental> SearchRentals(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllRentals();

            return rentals.Where(r => 
                r.RentalId.ToString().Contains(searchText) ||
                r.RentalStatus.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void DeactivateItem(long itemId)
        {
            var activeRentals = GetRentalsByItem(itemId);
            if (activeRentals.Any(r => r.RentalStatus == "approved" || 
                                         r.RentalStatus == "ongoing" || 
                                         r.RentalStatus == "pending"))
                return;
        }

        public List<Rental> GetRentalsByItem(long itemId)
        {
            return rentals.Where(r => r.ItemId == itemId).ToList();
        }

        public List<Rental> GetRentalsByRenter(Guid renterId)
        {
            return rentals.Where(r => r.RenterId == renterId).ToList();
        }

        public List<Rental> GetRentalsByStatus(string status)
        {
            return rentals.Where(r => r.RentalStatus == status).ToList();
        }

        public List<Rental> GetRentalsByDateRange(DateTime startDate, DateTime endDate)
        {
            return rentals.Where(r => 
                r.StartDate.Date >= startDate.Date && 
                r.EndDate.Date <= endDate.Date).ToList();
        }

        public Rental GetPendingRentalByItem(long itemId)
        {
            return rentals.FirstOrDefault(r => 
                r.ItemId == itemId && 
                r.RentalStatus == "pending");
        }
    }
}