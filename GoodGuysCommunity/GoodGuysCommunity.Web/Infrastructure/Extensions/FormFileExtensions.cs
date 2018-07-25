using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GoodGuysCommunity.Web.Infrastructure.Extensions
{
    public static class FormFileExtensinos
    {
        public static async Task<byte[]> GetData(this IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                var bytes = memoryStream.ToArray();
                return bytes;
            }
        }
    }
}
