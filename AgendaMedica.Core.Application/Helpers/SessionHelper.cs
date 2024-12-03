using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace AgendaMedica.Core.Application.Helpers
{
    public static class SessionHelper
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));      
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value)!;
        }

        public static void Logout(this ISession session, string key)
        {
            session.SetString(key, "");
        }
    }
}
