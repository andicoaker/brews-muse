using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewsMuse.Controllers
{
    public class VendorsController : Controller
    {

        private readonly ApplicationContext _context;

        private UserManager<ApplicationUser> _userManager { get; set; }

        public VendorsController(UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }



        // GET: /<controller>/
        [Route("~/bars")]
        public IActionResult Vendor()
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/bars")]
        public IEnumerable<Vendor> GetVendors()
        {
            var userId = _userManager.GetUserId(User);
            return _context.Vendors.Where(q => q.OwnerId == userId).ToList();
        }

        [HttpGet]
        [Route("~/api/bars/{id}")]
        public async Task<IActionResult> GetBar(int id)
        {
            var userId = _userManager.GetUserId(User);
            Vendor bar = await _context.Vendors.SingleOrDefaultAsync(m => m.OwnerId == userId && m.Id == id);

            if (bar == null)
            {
                return NotFound();
            }

            return Ok(bar);
        }

        [HttpPost]
        [Route("~/api/bars")]
        public async Task<IActionResult> PostBar([FromBody]Vendor bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bar.OwnerId = _userManager.GetUserId(User);
            _context.Vendors.Add(bar);
            await _context.SaveChangesAsync();

            return View();
        }

        // PUT api/bars/5
        [HttpPut("~/api/bars/{id}")]
        public async Task<IActionResult> PutBar(int id, [FromBody] Vendor bar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bar.Id)
            {
                return BadRequest(Response);
            }

            bar.OwnerId = _userManager.GetUserId(User);
            _context.Entry(bar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE api/bars/5
        [HttpDelete("~/api/bars/{id}")]
        public async Task<IActionResult> DeleteBar(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = _userManager.GetUserId(User);

            Vendor bar = await _context.Vendors
                .Where(q => q.OwnerId == userId)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (bar == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(bar);
            await _context.SaveChangesAsync();

            return Ok(bar);
        }

        private bool ConservationExists(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Vendors.Any(e => e.OwnerId == userId && e.Id == id);
        }

    }
}

