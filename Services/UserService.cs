using System;
using System.Collections.Generic;
using System.Linq;
using PinjemIn.Models;

namespace PinjemIn.Services
{
    public class UserService
    {
        private static List<User> users = new List<User>();

        static UserService()
        {
            InitializeDummyData();
        }

        private static void InitializeDummyData()
        {
            users.Add(new User
            {
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                FullName = "Admin User",
                StudentNumber = "2024001",
                Email = "admin@pinjemin.local",
                Phone = "082100000001",
                Role = "admin",
                IsActive = true,
                CreatedAt = DateTime.Now
            });

            users.Add(new User
            {
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                FullName = "Budi Santoso",
                StudentNumber = "2024002",
                Email = "budi@university.local",
                Phone = "082100000002",
                Role = "member",
                IsActive = true,
                CreatedAt = DateTime.Now
            });

            users.Add(new User
            {
                UserId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                FullName = "Siti Nurhaliza",
                StudentNumber = "2024003",
                Email = "siti@university.local",
                Phone = "082100000003",
                Role = "member",
                IsActive = true,
                CreatedAt = DateTime.Now
            });
        }

        public List<User> GetAllUsers()
        {
            return users.Where(u => u.IsActive).ToList();
        }

        public User GetUserById(Guid userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }

        public List<User> SearchUsers(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                return GetAllUsers();

            return users.Where(u => u.IsActive &&
                (u.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                 u.StudentNumber.Contains(searchText) ||
                 u.Email.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public void SaveUser(User user)
        {
            var existing = users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existing != null)
            {
                existing.FullName = user.FullName;
                existing.StudentNumber = user.StudentNumber;
                existing.Email = user.Email;
                existing.Phone = user.Phone;
                existing.Role = user.Role;
                existing.IsActive = user.IsActive;
            }
            else
            {
                users.Add(user);
            }
        }

        public void DeactivateUser(Guid userId)
        {
            var user = users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.IsActive = false;
            }
        }
    }
}