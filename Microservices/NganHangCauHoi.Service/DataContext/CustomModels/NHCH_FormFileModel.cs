using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.AspNetCore.Http;

namespace NganHangCauHoi.Data.CustomModels
{
    public class NHCH_FormFileModel : IFormFile
    {
        public string ContentType { get; set; }

        public string ContentDisposition { get; set; }

        public IHeaderDictionary Headers { get; set; }

        public long Length { get; set; }

        public string Name { get; set; }

        public string FileName { get; set; }
        public Stream FileStream { get; set; }

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            return FileStream;
        }
    }
}
