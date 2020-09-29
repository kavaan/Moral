using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Moral.Api.Entities
{
    public class Account : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public virtual IEnumerable<Contact> Contacts { get; set; }
        public  City City { get; set; }
        public virtual IEnumerable<Request> IncomingRequests { get; set; }
        public virtual IEnumerable<Request> OutcomingRequests { get; set; }
        public virtual IEnumerable<PersonTag> InTags { get; set; }
        public virtual IEnumerable<PersonTag> OutTags { get; set; }
        public virtual IEnumerable<MoralComment> InBoxMoralComments { get; set; }
        public virtual IEnumerable<MoralComment> SentMoralComments { get; set; }
    }
}
