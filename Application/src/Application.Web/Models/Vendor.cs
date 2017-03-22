using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string OwnerId { get; set; }

        public ApplicationUser Owner { get; set; }
        public string OwnerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public byte Rating { get; set; }
        public string VendorURL { get; set; }
        public string ImageURL { get; set; }
        public string Comments { get; set; }
        public int VendorId { get; set; }
        public string VendorPhone { get; set; }
        public int Vote { get; set; }
        public int CheckIn { get; set; }
        //public DateTime Hours { get; set; } //need start and end instead of hours. maybe timespan
        //public TimeSpan Hours { get; set; }
        public string OpeningTIme { get; set; }
        public string ClosingTime { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public List<Beer> Beers { get; set; }
        public List<Band> Bands { get; set; }
        public Vendor()
        {
            Beers = new List<Beer>();
            Bands = new List<Band>();
        }
    }
}
