using System;

namespace PinjemIn.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public Guid OwnerId { get; set; }
        public long CategoryId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }
        public decimal DailyPrice { get; set; }
        public string ItemStatus { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}