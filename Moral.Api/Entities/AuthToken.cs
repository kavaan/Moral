﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class AuthToken
    {
        /// <summary>
        /// Gets or sets the bearer token used for authorization
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the user's email username
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the authenticated user's ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the unix timestamp of when the token expires
        /// </summary>
        public string Expires { get; set; }
    }
}
