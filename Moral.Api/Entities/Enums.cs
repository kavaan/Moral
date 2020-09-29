using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public enum ContactType
    {
        Null,
        Email,
        Instagram,
        LinkedIn,
        Twitter,
        WhatsApp,
        Telegram,
        Phone,
        Home,
        Workplace,
        Cafe,
        University,
        Cemetery,
        Other
    }

    public enum RequestState
    {
        Null,
        Accepted,
        Rejected,
        Seen
    }
}
