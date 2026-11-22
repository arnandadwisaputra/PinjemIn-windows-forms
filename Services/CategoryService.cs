using System;
using System.Collections.Generic;
using System.Linq;
using PinjemIn.Models;

namespace PinjemIn.Services
{
    public class CategoryService
    {
        private static List<Category> categories = new List<Category>();

        static CategoryService()
        {
            InitializeDummyData();
        }

        private static void InitializeDummyData()
        {
            categories.Add(new Category
            {
                CategoryId = 1,
                CategoryName = "Elektronik",
                Description = "Peralatan elektronik dan komputer",
                IsActive = true,
                CreatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                CategoryId = 2,
                CategoryName = "Komputer",
                Description = "Laptop, PC, dan aksesoris",
                IsActive = true,
                CreatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                CategoryId = 3,
                CategoryName = "Jaringan",
                Description = "Peralatan jaringan dan konektivitas",
                IsActive = true,
                CreatedAt = DateTime.Now
            });

            categories.Add(new Category
            {
                CategoryId = 4,
                CategoryName = "Fotografi",
                Description = "Peralatan fotografi dan videografi",
                IsActive = true,
                CreatedAt = DateTime.Now
            });
        }

        public List<Category> GetAllCategories()
        {
            return categories.Where(c => c.IsActive).ToList();
        }

        public Category GetCategoryById(long categoryId)
        {
            return categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public void SaveCategory(Category category)
        {
            var existing = categories.FirstOrDefault(c => c.CategoryId == category.CategoryId);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
                existing.IsActive = category.IsActive;
                existing.UpdatedAt = DateTime.Now;
            }
            else
            {
                category.CategoryId = categories.Count + 1;
                category.CreatedAt = DateTime.Now;
                categories.Add(category);
            }
        }

        public void UpdateCategory(long categoryId, Category category)
        {
            var existing = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
                existing.IsActive = category.IsActive;
                existing.UpdatedAt = DateTime.Now;
            }
        }

        public void DeactivateCategory(long categoryId)
        {
            var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category != null)
            {
                category.IsActive = false;
            }
        }

        public List<Category> SearchCategories(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllCategories();

            return categories.Where(c => c.IsActive &&
                (c.CategoryName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                 c.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ToList();
        }
    }
}