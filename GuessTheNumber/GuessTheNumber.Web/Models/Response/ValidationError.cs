﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessTheNumber.Web.Models.Response
{
    public class ValidationError
    {
        public string Field { get; set; }

        public string Message { get; set; }
    }
}