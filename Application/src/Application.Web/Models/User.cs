using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoom.Models
{
    public class User : IdentityUser
    {
        public Guid Signature { get; set; }
        public virtual List<Message> Messages { get; set; }

        public User()
        {
            Messages = new List<Message>();
            Signature = Guid.NewGuid();
        }
    }
}
