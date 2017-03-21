using BrewsMuse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime TimeSent { get; set; }

        public virtual User User { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
