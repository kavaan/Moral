using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public string Id { get; set; }
    }

    public interface IBaseEntity
    {
        string Id { get; set; }
    }
}
