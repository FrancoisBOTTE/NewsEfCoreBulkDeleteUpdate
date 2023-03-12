using EFCore7UpdateDelete.Context;
using EFCore7UpdateDelete.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore7UpdateDelete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            _context = context;
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
            await _context.Contacts.Where(c => c.email == null)
                  .ExecuteUpdateAsync(item => item.SetProperty(c => c.email, c => "unemail"));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> BulkDeleteContact()
        {
            await _context.Contacts.Where(c => c.email == null).ExecuteDeleteAsync();
            return Ok();
        }

    }
}
