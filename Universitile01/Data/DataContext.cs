using Microsoft.EntityFrameworkCore;
using Universitile01.Models;

namespace Universitile01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<UsersHasAnnouncement> UsersHasAnnouncements { get; set; }
        public DbSet<PerosnalInfo> PerosnalInfo { get; set;}

    }
}
