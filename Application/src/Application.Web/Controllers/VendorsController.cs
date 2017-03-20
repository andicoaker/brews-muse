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

        [HttpPost]
        public IActionResult Post(Vendor ImageURL)
        {
            var image = _context.Vendors.FirstOrDefault(q => q.Id == ImageURL.Id);

            if (ModelState.IsValid)
            {
                _context.Vendors.Add(ImageURL);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ImageURL);
        }

        // GET: /<controller>/
        [Route("~/vendors")]
        public IActionResult Vendor() 
        {
            return View();
        }

        [HttpGet]
        [Route("~/api/vendors")]
        public IEnumerable<Vendor> GetVendors()
        {
            var userId = _userManager.GetUserId(User);
            return _context.Vendors.Where(q => q.OwnerId == userId).ToList();
        }



        [HttpGet]
        [Route("~/api/vendors/{id}")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var userId = _userManager.GetUserId(User);
            Vendor vendor = await _context.Vendors.SingleOrDefaultAsync(m => m.OwnerId == userId && m.Id == id);

            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }

        //[HttpPost]
        //[Route("~/api/vendors/{id}")]
        //private async Task<IActionResult> PostImage([FromBody]Vendor ImageURL)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Vendors.Add(ImageURL);
        //    await _context.SaveChangesAsync();

        //    return View();
        //}

        [HttpPost]
        [Route("~/api/vendors")]
        public async Task<IActionResult> PostVendor([FromBody]Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vendor.OwnerId = _userManager.GetUserId(User);
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return View();
        }

        // PUT api/bars/5
        [HttpPut("~/api/vendors/{id}")]
        public async Task<IActionResult> PutVendor(int id, [FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendor.Id)
            {
                return BadRequest(Response);
            }

            vendor.OwnerId = _userManager.GetUserId(User);
            _context.Entry(vendor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE api/bars/5
        [HttpDelete("~/api/vendors/{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = _userManager.GetUserId(User);

            Vendor vendor = await _context.Vendors
                .Where(q => q.OwnerId == userId)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (vendor == null)
            {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return Ok(vendor);
        }

        private bool VendorExists(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Vendors.Any(e => e.OwnerId == userId && e.Id == id);
        }

    }
}

