using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Moral.Api.Entities
{
    public class Contact : BaseEntity
    {
        public ContactType ContactType { get; set; }
        public string Link { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Days { get; set; }
        public int Order { get; set; }
        public bool ShowJustForInteractions { get; set; }
    }
}
