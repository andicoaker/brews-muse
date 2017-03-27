using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewsMuse.Controllers
{
    public class VendorsController : Controller
    {

        private readonly ApplicationContext _context;

        private UserManager<ApplicationUser> _userManager { get; set; }

        private IHostingEnvironment _environment { get; set; }
        public VendorsController(IHostingEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _environment = environment;
            _userManager = userManager;
            _context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/vendors")]
        public IEnumerable<Vendor> GetVendors()
        {
            //var userId = _userManager.GetUserId(User);
            return _context.Vendors
                .Include(n => n.Beers)
                .Include(q => q.Bands)
                .ToList();
        }

        //Where(q => q.OwnerId == userId).ToList();


        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/vendors/{id}")]
        public async Task<IActionResult> GetVendor(int id)
        {
            //var userId = _userManager.GetUserId(User);
            Vendor vendor = await _context.Vendors.Include(q => q.Beers).Include(n => n.Bands).SingleOrDefaultAsync(m => m.Id == id); // m.OwnerId == userId && m.Id == id);
          

            if (vendor == null)
            {
                return NotFound();
            }
            return Ok(vendor);
        }



        [HttpPost]
        [Authorize]
        [Route("~/api/vendors")]
        public async Task<IActionResult> PostVendor([FromBody] Vendor vendor)  //(int id) //[FromBody] Vendor vendor
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //vendor.OwnerId = _userManager.GetUserId(User);
            var user = await _userManager.GetUserAsync(User);

            //Vendor vendor = await _context.Vendors.Where(q => q.OwnerId == userId).SingleOrDefaultAsync(m => m.Id == id);

            vendor.Owner = user;
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return Ok(vendor);
        }

        [HttpPost]
        [Authorize]
        [Route("~/api/vendors/image")]
        public async Task<IActionResult> PostPicture(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var vendor = new Vendor();

            if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
            {
                var name = Guid.NewGuid().ToString();
                var path = Path.Combine(_environment.WebRootPath, "images", "vendors", $"{name}.{extension}");

                using (var image = System.IO.File.Create(path))
                {
                    file.CopyTo(image);
                }

                vendor.ImageURL = $"/images/vendors/{name}.{extension}";
                return Ok(vendor.ImageURL);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/bars/5
        [HttpPut("~/api/vendors/{id}")]
        [Authorize]
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

            vendor.Owner = await _userManager.GetUserAsync(User);
            _context.Entry(vendor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE api/bars/5
        [HttpDelete]
        [Route("~/api/vendors/{id}")]
        [AllowAnonymous]
        //[Authorize]
        public async Task<IActionResult> DeleteVendor(int id, [FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            vendor = _context.Vendors.SingleOrDefault(q => q.Id == id);
            if (vendor == null)
            {
                return NotFound();
            }

            //var beers = _context.Beers.Where(p => p.Vendor == vendor).ToList();
            //var bands = _context.Bands.Where(n => n.Vendor == vendor).ToList();
            //foreach (var beer in beers)
            //{
            //    _context.Beers.Remove(beer);
            //}

            //foreach (var band in bands)
            //{
            //    _context.Bands.Remove(band);
            //}
            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool VendorExists(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Vendors.Any(e => e.Owner.Id == userId && e.Id == id);
        }

    }
}

