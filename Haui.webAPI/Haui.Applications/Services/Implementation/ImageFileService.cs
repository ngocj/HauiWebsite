using Haui.Application.Dtos.ImageFileDto;
using Haui.Application.Services.Interfaces;
using Haui.Domain.Entities;
using Haui.infrastructure.UnitOFwork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = Haui.Domain.Entities.Image;

namespace Haui.Application.Services.Implementation
{
    public class ImageFileService : IImageFileService
    {
        //private readonly IImageFileService _imageFileService;
        private readonly IUnitOFwork _unitOFwork;
        public ImageFileService(IUnitOFwork unitOFwork)
        {
            _unitOFwork = unitOFwork;
        }

        public async Task<ImageFileViewDto> DownloadFile(Guid id)
        {
            var image = await _unitOFwork.ImageFile.GetByIdAsync(id);

            if (image == null)
            {
                return null;
            }
            return new ImageFileViewDto
            {
                FileName = image.FileName,
                FileData = image.FileData,
                ContentType = image.ContentType,
            };

        }

        public async Task<List<ImageFileViewDto>> GetAllFileAsync()
        {
           
            var files = await _unitOFwork.ImageFile.GetAllFileAsync();
            return files.Select(f => new ImageFileViewDto
            {
                Id = f.Id,
                FileName = f.FileName,
                FileData = f.FileData,
                ContentType = f.ContentType,
            }).ToList();
        }

        public async Task UploadFileAsync(IFormFile formFile)
        {
            using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);

            var imageData = new Image
            {
                Id = Guid.NewGuid(),
                FileName = formFile.FileName,
                FileData = memoryStream.ToArray(),
                ContentType = formFile.ContentType
            };
            await _unitOFwork.ImageFile.AddAsync(imageData);
            await _unitOFwork.SaveChangeAssynt();
        }
    }
}
