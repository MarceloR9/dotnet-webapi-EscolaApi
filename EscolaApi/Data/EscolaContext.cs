using EscolaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaApi.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AdminStaff> AdminStaffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Student>("Student")
                .HasValue<Teacher>("Teacher")
                .HasValue<AdminStaff>("AdminStaff");

            base.OnModelCreating(modelBuilder);
        }
    }
}
