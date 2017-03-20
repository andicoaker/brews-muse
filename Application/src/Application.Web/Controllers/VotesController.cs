using BrewsMuse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Controllers
{
    public class VotesController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }
        public VotesController(UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpPost]
        [Route("~/api/vendors")]
        public async Task<IActionResult> PostVote(int vendorId, [FromBody]Vendor Vote)
        {
            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Vote.OwnerId = _userManager.GetUserId(User);
            vendor.Vote++;

            await _context.SaveChangesAsync();

            return CreatedAtAction("PostVote", new { id = Vote.Id }, Vote);
        }
    }
}
