using System;
using System.Collections.Generic;
using System.Linq;
using PinjemIn.Models;

namespace PinjemIn.Services
{
    public class ItemService
    {
        private static List<Item> items = new List<Item>();

        static ItemService()
        {
            InitializeDummyData();
        }

        private static void InitializeDummyData()
        {
            // Add some dummy items
            items.Add(new Item
            {
                ItemId = 1,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryId = 1,
                ItemName = "Arduino Uno R3",
                Description = "Microcontroller untuk proyek elektronik",
                Condition = "Baru",
                DailyPrice = 150000,
                ItemStatus = "active",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            items.Add(new Item
            {
                ItemId = 2,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                CategoryId = 2,
                ItemName = "Laptop Lenovo",
                Description = "Laptop untuk kebutuhan belajar",
                Condition = "Baru",
                DailyPrice = 500000,
                ItemStatus = "active",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            items.Add(new Item
            {
                ItemId = 3,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                CategoryId = 3,
                ItemName = "Kabel HDMI",
                Description = "Kabel HDMI 1 meter",
                Condition = "Baik",
                DailyPrice = 50000,
                ItemStatus = "active",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            items.Add(new Item
            {
                ItemId = 4,
                OwnerId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                CategoryId = 4,
                ItemName = "Kamera DSLR",
                Description = "Kamera digital untuk fotografi",
                Condition = "Baik",
                DailyPrice = 300000,
                ItemStatus = "active",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
        }

        public List<Item> GetAllItems()
        {
            return items.Where(i => i.ItemStatus == "active").ToList();
        }

        public Item GetItemById(long itemId)
        {
            return items.FirstOrDefault(i => i.ItemId == itemId);
        }

        public List<Item> SearchItems(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllItems();

            return items.Where(i => i.ItemStatus == "active" &&
                (i.ItemName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                 i.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public void SaveItem(Item item)
        {
            var existing = items.FirstOrDefault(i => i.ItemId == item.ItemId);
            if (existing != null)
            {
                existing.ItemName = item.ItemName;
                existing.Description = item.Description;
                existing.Condition = item.Condition;
                existing.DailyPrice = item.DailyPrice;
                existing.ItemStatus = item.ItemStatus;
                existing.UpdatedAt = DateTime.Now;
            }
            else
            {
                item.ItemId = items.Count + 1;
                item.CreatedAt = DateTime.Now;
                item.UpdatedAt = DateTime.Now;
                items.Add(item);
            }
        }

        public void DeactivateItem(long itemId)
        {
            var item = items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                item.ItemStatus = "inactive";
            }
        }

        public List<Item> GetActiveItems()
        {
            return items.Where(i => i.ItemStatus == "active").ToList();
        }
    }
}