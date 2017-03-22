using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models.API
{
    public class MessageViewModel
    {
        public string SenderUserName { get; set; }
        public string VendorName { get; set; }
        public string Body { get; set; }
        public string TimeSent { get; set; }
    }
}
