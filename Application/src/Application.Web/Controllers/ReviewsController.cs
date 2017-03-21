using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BrewsMuse.Models;
using Microsoft.EntityFrameworkCore;
using ChatRoom.Models.API;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<Vendor> _userManager;
    
        public ReviewsController(ApplicationContext context, UserManager<Vendor> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("~/api/rooms/{id}/messages")]
        public async Task<IActionResult> GetCommentsFromRoom(int id)
        {
            if (!_context.Vendors.Any(r => r.Id == id))
            {
                return BadRequest("No room found with id " + id + ". ");
            }

            var comments = _context.Comments.Include(m => m.VendorURL)
                                            .Where(m => m.Id == id)
                                            .ToList();

            var vendorName = (await _context.Vendors.FirstOrDefaultAsync(r => r.Id == id)).Name;

            var messagesViewModels = new List<MessageViewModel>();
        
            foreach (var comment in comments)
            {
                messagesViewModels.Add(new MessageViewModel()
                {
                    SenderUserName = comment.Name,
                    VendorName = vendorName,
                    Body = comment.Comments
                });
            }

            return Ok(messagesViewModels);
        }
        [HttpPost]
        [Route("~/api/rooms/{id}/messages")]
        public async Task<IActionResult> NewMessage(int id, [FromBody]Vendor model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);

            var room = _context.Vendors.Include(ru => ru.VendorURL)
                                          .Where(ur => ur.Id == user.Id)
                                          .FirstOrDefault(ur => ur.VendorId == id)
                                          .VendorURL;


            var comment = new Comments()
            { 
                Vendor = vendor,
                User = user,
                Body = comment.Content, 
                TimeSent = DateTime.UtcNow
            };

            comment.Add(comment);
            _context.SaveChanges();

            var messageViewModel = new MessageViewModel()
            {
                VendorName = comment.Name,
                SenderUserName = comment.Name,
                TimeSent = comment.TimeSent.ToString(),
                Body = comment.Body
            };

            return Ok(messageViewModel);
        }
    }

}
