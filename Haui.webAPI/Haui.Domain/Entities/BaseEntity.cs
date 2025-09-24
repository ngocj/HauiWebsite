using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CreateNy { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
