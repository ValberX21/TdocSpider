using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TdocSpider.Tests.TestHelpers
{
    public class FormFileMock : IFormFile    
    {
        private readonly MemoryStream _stream;

        public FormFileMock(string fileName, string content = "fake file content")
        {
            _stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
            FileName = fileName;
        }

        public string ContentType => "application/pdf";
        public string ContentDisposition => string.Empty;
        public IHeaderDictionary Headers => null;
        public long Length => _stream.Length;
        public string Name => "file";
        public string FileName { get; }

        public void CopyTo(Stream target)
        {
            _stream.Position = 0;
            _stream.CopyTo(target);
        }

        public async Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            _stream.Position = 0;
            await _stream.CopyToAsync(target, cancellationToken);
        }

        public Stream OpenReadStream()
        {
            _stream.Position = 0;
            return _stream;
        }
    }
}
