using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
