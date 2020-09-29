﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moral.Api.Dtos
{
    public class ResultDto
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
    public enum Status
    {
        Success = 1,
        Error = 2
    }
}
