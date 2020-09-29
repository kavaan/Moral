using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class MoralTag : BaseEntity
    {
        public string Caption { get; set; }
        public string Icon { get; set; }
        public bool HasHotFlag { get; set; }
        public int Order { get; set; }
    }
}
