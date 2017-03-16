using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrewsMuse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Web.Controllers
{
    public class BandsController : Controller
    {
        private readonly ApplicationContext _context;
        private UserManager<ApplicationUser> _userManager { get; set; }
        public BandsController(UserManager<ApplicationUser> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Route("~/api/vendors/{vendorsId}/bands")]
        public IActionResult Band(int vendorsId)
        {
        
            var vendors = _context.Vendors.Include(q => q.Bands).FirstOrDefault(m => m.Id == vendorsId);
            return View();
        }
        [HttpGet]
        [Route("~/api/vendors/{vendorsId}/bands")]
        public IEnumerable<Band> GetBands()
        {
            var userId = _userManager.GetUserId(User);
            return _context.Bands.Where(q => q.Vendor.OwnerId == userId).ToList();
        }

        [HttpGet]
        [Route("~/api/vendors/{vendorsId}/bands/{id}")]
        public async Task<IActionResult> GetBand(int vendorId)
        {
            var userId = _userManager.GetUserId(User);

            var vendor = _context.Vendors.Include(q => q.Bands).FirstOrDefault(q => q.Id == vendorId);
            var band = vendor.Bands.FirstOrDefault(q => q.Id == vendorId);
            if (band == null)
            {
                return NotFound();
            }
            return Ok(band);
        }

        [HttpPost]
        [Route("~/api/vendors/{vendorsId}/bands/{id}")]
        public async Task<IActionResult> PostBand(int vendorId, [FromBody]Band band)
        {
            var vendor = _context.Vendors.FirstOrDefault(q => q.Id == vendorId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            band.OwnerId = _userManager.GetUserId(User);
            vendor.Bands.Add(band);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (GroupExists(band.Id))
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
                if (!GroupExists(id))
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

        private bool GroupExists(int id)
        {
            var userId = _userManager.GetUserId(User);
            return _context.Bands.Any(e => e.OwnerId == userId && e.Id == id);
        }





    }
}
