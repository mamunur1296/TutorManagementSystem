using Microsoft.EntityFrameworkCore;

namespace TutorManagementSystem.Models.Contact
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions options) : base(options) { }

       
        public virtual DbSet<Contactinfo> Contactinfos { get; set; } = null!;
    }

   
}
