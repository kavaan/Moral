using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class PersonTag : BaseEntity
    {
        public virtual Account For { get; set; }
        public string ForId { get; set; }
        public virtual Account By { get; set; }
        public string ById { get; set; }
        public DateTime DateTime { get; set; }
        public virtual MoralTag MoralTag { get; set; }
        public string MoralTagId { get; set; }
    }
}
