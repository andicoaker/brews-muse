using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Web.Controllers
{
    public class BandsController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }
        private IHostingEnvironment _environment { get; set; }
        public BandsController(IHostingEnvironment environment, UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _environment = environment;
            _userManager = userManager;
            _context = context;
        }

        [AllowAnonymous]
        [Route("~/api/vendors/{vendorsId}/bands")]
        public IActionResult Band(int vendorsId)
        {

            var vendors = _context.Vendors.Include(q => q.Bands).FirstOrDefault(m => m.Id == vendorsId);
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/vendors/{vendorsId}/bands")]
        public IEnumerable<Band> GetBands()
        {
            //var userId = _userManager.GetUserId(User);
            return _context.Bands.ToList();//.Where(q => q.Vendor.OwnerId == userId).ToList();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("~/api/vendors/{vendorsId}/bands/{id}")]
        public IActionResult GetBand(int vendorId)
        {
            //var userId = _userManager.GetUserId(User);

            var vendor = _context.Vendors.Include(q => q.Bands).FirstOrDefault(q => q.Id == vendorId);
            var band = vendor.Bands.FirstOrDefault(q => q.Id == vendorId);
            if (band == null)
            {
                return NotFound();
            }
            return Ok(band);
        }

        [HttpPost]
        [Authorize]
        [Route("~/api/vendors/{vendorsId}/bands/{id}")]
        public async Task<IActionResult> PostBand(int vendorId, int id)//[FromBody]Band band)
        {
            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //band.OwnerId = _userManager.GetUserId(User);

            var userId = _userManager.GetUserId(User);
            Band band = await _context.Bands.Where(q => q.OwnerId == userId).SingleOrDefaultAsync(m => m.Id == id);

            vendor.Bands.Add(band);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (BandExists(band.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetBand", new { id = band.Id }, band);
        }

        [HttpPut]
        [Authorize]
        [Route("~/api/vendors/{vendorsId}/bands/{id}")]
        public async Task<IActionResult> PutBand(int id, [FromBody] Band band)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != band.Id)
            {
                return BadRequest();
            }

            band.OwnerId = _userManager.GetUserId(User);
            _context.Entry(band).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!BandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        [Route("~/api/vendors/{vendorsId}/bands/{id}")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = _userManager.GetUserId(User);
            Band band = await _context.Bands.Where(q => q.OwnerId == userId).SingleOrDefaultAsync(m => m.Id == id);
            if (band == null)
            {
                return NotFound();
            }
            _context.Bands.Remove(band);
            await _context.SaveChangesAsync();

            return Ok(band);
        }

        [HttpPost]
        [Authorize]
        [Route("~/api/bands/image")]
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

        private bool BandExists(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Bands.Any(e => e.Id == id);//e.OwnerId == userId && e.Id == id);
        }
    }
}
