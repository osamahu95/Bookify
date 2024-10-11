using Microsoft.AspNetCore.Http;

namespace Bookify.Service.Helper
{
    public class SaveImage
    {
        public static void Save(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            var fileName = file.FileName;
            var fullPath = Path.Combine(path, fileName);

            using(var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
    }
}
