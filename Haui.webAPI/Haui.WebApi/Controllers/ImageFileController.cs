using Haui.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haui.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageFileService imageFileService;

        public ImageFileController(IImageFileService imageFileService)
        {
            this.imageFileService = imageFileService;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            await imageFileService.UploadFileAsync(file);
            return Ok();
        }
        [HttpGet("Download")]
        public async Task<IActionResult> Download(Guid id)
        {
            var fileDto = await imageFileService.DownloadFile(id);
            if(fileDto == null)
            {
                return NotFound();
            }
            return File(fileDto.FileData, fileDto.ContentType, fileDto.FileName);
        }
        [HttpGet]
        public async Task<IActionResult> GetListFile()
        {
            var files = await imageFileService.GetAllFileAsync();
            return Ok(files);
        }

    }
}
