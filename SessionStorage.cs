namespace DaniaSessionService
{
    public static class SessionStorage
    {
        private static Dictionary<string, string> sessions = new();

        public static Dictionary<string, string> Sessions => sessions;

        public static void Add(string key, string value)
        {
            Sessions.Add(key, value);
        }

        public static void Remove(string key)
        {
            sessions.Remove(key);
        }
    }
}
