using System.Data.Entity;

namespace Organizer.Models
{
    public class OrganizerContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
    }
}