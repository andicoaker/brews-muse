﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class PasswordChangeRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
