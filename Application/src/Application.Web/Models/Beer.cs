using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public ApplicationUser Owner { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public string Brewery { get; set; }
        public decimal AlcoholContent { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }

        public string ImageURL { get; set; }

        //public Vendor Vendor { get; set; }

    }
}
