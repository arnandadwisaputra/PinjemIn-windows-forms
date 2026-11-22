namespace PinjemIn.Configuration
{
    public static class AppSettings
    {
        public static string SupabaseUrl { get; set; } = "https://your-supabase-url.supabase.co";
        public static string SupabaseKey { get; set; } = "your-supabase-key";
        public static string SupabaseStorageBucket { get; set; } = "pinjemin-images";
    }
}