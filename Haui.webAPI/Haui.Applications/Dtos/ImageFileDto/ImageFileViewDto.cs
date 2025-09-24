using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Application.Dtos.ImageFileDto
{
    public class ImageFileViewDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public string ContentType { get; set; }

    }
}
