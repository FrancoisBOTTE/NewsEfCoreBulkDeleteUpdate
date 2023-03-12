using EFCore7UpdateDelete.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore7UpdateDelete.Context
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
