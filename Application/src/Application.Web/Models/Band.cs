using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ApplicationUser Owner { get; set; }
        public string UserName { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public decimal CoverCharge { get; set; }
        public int Rating { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public string Showtime { get; set; }
        public string ImageURL { get; set; }
        //public Vendor Vendor { get; set; }
    }
}
