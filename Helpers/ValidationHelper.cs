using System;
using System.Text.RegularExpressions;

namespace PinjemIn.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use simple regex for email validation
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return true; // Phone is optional

            // Simple phone validation - digits and optional +-()
            return Regex.IsMatch(phone, @"^[0-9+\-()\s]+$");
        }

        public static bool IsValidPrice(decimal price)
        {
            return price >= 0;
        }

        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return endDate >= startDate;
        }
    }
}