using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Application.Dtos.BaseDto
{
    public class PageResultDto<T> 
    {
        public int Page { get; set; } // vi tri trang hien tai
        public int PageSize { get; set; } // so luong phan tu tren 1 trang
        public int TotalItem { get; set; } // tong so phan tu
        public int TotalPage => (int)Math.Ceiling((float)TotalItem / PageSize); // tong so trang
        public List<T> Items { get; set; } // danh sach phan tu tren trang
    }
}
