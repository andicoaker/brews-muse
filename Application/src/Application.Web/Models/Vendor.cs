using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BrewsMuse.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string OwnerId { get; set; }

        //public ApplicationUser Owner { get; set; }
        public string UserName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        //public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public byte Rating { get; set; }
        public string VendorURL { get; set; }
        public string ImageURL { get; set; }
        public string Comments { get; set; }
        //public int VendorId { get; set; }
        public string VendorPhone { get; set; }
        public int Vote { get; set; }
        public int CheckIn { get; set; }
        public string Hours { get; set; }        
        public double Lat { get; set; }
        public double Lng { get; set; }
        public virtual List<Beer> Beers { get; set; }
        public virtual  List<Band> Bands { get; set; }
        public Vendor()
        {
            Beers = new List<Beer>();
            Bands = new List<Band>();
        }
    }
}