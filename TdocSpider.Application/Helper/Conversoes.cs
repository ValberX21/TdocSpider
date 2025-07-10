using Microsoft.AspNetCore.Http;
using System.IO;

namespace TdocSpider.Application.Helper
{
    public class Conversoes
    {
        public string GetContentType(string fileName)
        {
            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out string contentType))
            {
                contentType = "application/octet-stream";
            }

            return contentType;
        }

        public static IFormFile ByteArrayToFormFile(byte[] fileBytes, string fileName, string contentType = "application/octet-stream")
        {
            var stream = new MemoryStream(fileBytes);
            return new FormFile(stream, 0, fileBytes.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };
        }
    }
}
