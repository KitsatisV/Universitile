using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Universitile01.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Universitile01.Models;

namespace Universitile01.Data
{
    public class DataContext : IdentityDbContext



    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Module> Modules { get; set; }

        // Custom method to retrieve modules using SQL code
        public async Task<List<Module>> GetModulesUsingSql()
        {
            var modules = await Modules.FromSqlRaw("SELECT * FROM modules").ToListAsync();
            return modules;
        }
        //public DbSet<Module> Modules { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Module>(entity =>
        //    {
        //        entity.HasKey(e => e.ModuleId);
        //    });
    }
    
}



