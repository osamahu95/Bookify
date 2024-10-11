using System.Text.Json;

namespace Bookify.Service.Helper
{
    public class JsonHelper<T>
    {
        public static T DesearlizeBook(string data)
        {
            var serializedObj = JsonSerializer.Deserialize<T>(data);
            return serializedObj;
        }
    }
}
