using System;

namespace PinjemIn.Models
{
    public class Rental
    {
        public long RentalId { get; set; }
        public long ItemId { get; set; }
        public Guid RenterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DailyPriceSnapshot { get; set; }
        public decimal TotalPrice { get; set; }
        public string RentalStatus { get; set; }
        public string OwnerNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}