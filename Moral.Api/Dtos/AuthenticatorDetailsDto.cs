using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Dtos
{
    public class AuthenticatorDetailsDto
    {
        public string SharedKey { get; set; }

        public string AuthenticatorUri { get; set; }
    }
}
