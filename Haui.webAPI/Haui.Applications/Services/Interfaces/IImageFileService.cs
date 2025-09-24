using Haui.Application.Dtos.ImageFileDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Application.Services.Interfaces
{
    public interface IImageFileService
    {
        Task UploadFileAsync(IFormFile formFile);
        Task<ImageFileViewDto> DownloadFile(Guid id);
        Task<List<ImageFileViewDto>> GetAllFileAsync();

    }
}
