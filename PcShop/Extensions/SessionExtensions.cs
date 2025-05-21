using System.Text.Json;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PcShop.Extensions
{
    public static class SessionExtensions
    {
        // Метод для получения объекта из сессии
        public static T? GetObjectFromJson<T>(this ISession session, string key) where T : class
        {
            var value = session.GetString(key);
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            
            return JsonConvert.DeserializeObject<T>(value);
        }

        // Метод для сохранения объекта в сессии
        public static void SetObjectAsJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}
