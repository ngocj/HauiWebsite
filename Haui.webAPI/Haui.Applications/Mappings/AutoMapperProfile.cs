using AutoMapper;
using Haui.Application.Dtos.ImageFileDto;
using Haui.Applications.Dtos;
using Haui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Haui.Applications.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, UserDto>().ReverseMap();
              

            CreateMap<Image,ImageFileViewDto>().ReverseMap();
        }
    }
}
