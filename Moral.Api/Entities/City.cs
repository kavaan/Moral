﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public State State { get; set; }
        public string StateId { get; set; }
    }
}
