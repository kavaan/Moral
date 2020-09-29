using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Moral.Api.Infrastructure
{
    internal class StreamingCategoryRequirement : IAuthorizationRequirement
    {
        public string Category { get; private set; }

        public StreamingCategoryRequirement(string category) { Category = category; }
    }
}
