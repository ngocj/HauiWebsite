using Haui.Domain.Entities;
using Haui.infrastructure.Context;
using Haui.infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.infrastructure.Repositories.Implementations
{
    public class ImageFileRepository : GenericRepository<Image>, IImageFileRepository
    {
        public ImageFileRepository(HauiContext context) : base(context)
        {
        }
     
        public async Task<List<Image>> GetAllFileAsync()
        {
            return await _context.Images.ToListAsync();
        }

       /* public async Task<Image> GetImageById(Guid id)
        {
            return await _context.Images.FindAsync(id);
        }*/
    }
}
