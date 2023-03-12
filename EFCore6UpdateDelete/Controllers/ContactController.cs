using EFCore6UpdateDelete.Context;
using EFCore6UpdateDelete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore6UpdateDelete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<ContactInfo>> Get()
        {
            var result = await _context.Contacts.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddContact(ContactInfo contact)
        {            
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return Ok(contact.id);
        }

        [HttpPut]        
        public async Task<IActionResult> BulkUpdateContact()
        {
            var contacts = _context.Contacts.Where(c=>c.email==null).ToList();

            foreach (var item in contacts)
            {
                item.email = "unemail";
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> BulkDeleteContact()
        {
            var contacts = _context.Contacts.Where(c => c.email == null).ToList();

            foreach (var item in contacts)
            {
                _context.Remove(item);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
