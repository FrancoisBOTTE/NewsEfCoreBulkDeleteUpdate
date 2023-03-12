using EFCore6UpdateDelete.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore6UpdateDelete.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
        }

        public DbSet<ContactInfo> Contacts
        {
            get;
            set;
        }
    }
}
