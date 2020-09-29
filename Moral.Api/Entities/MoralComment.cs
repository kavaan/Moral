using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class MoralComment : BaseEntity
    {
        public string Content { get; set; }
        public virtual Account By { get; set; }
        public string ById { get; set; }
        public virtual Account For { get; set; }
        public string ForId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
