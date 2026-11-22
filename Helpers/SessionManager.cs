using System;
using PinjemIn.Models;

namespace PinjemIn.Helpers
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }
        public static string AccessToken { get; set; }
        public static bool IsLoggedIn => CurrentUser != null;

        public static bool IsAdmin => CurrentUser?.Role == "admin";
        public static bool IsMember => CurrentUser?.Role == "member";

        public static void Login(User user, string token = null)
        {
            CurrentUser = user;
            AccessToken = token;
        }

        public static void Logout()
        {
            CurrentUser = null;
            AccessToken = null;
        }
    }
}