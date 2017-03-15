﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal CoverCharge { get; set; }
        public int Rating { get; set; }
    }
}
