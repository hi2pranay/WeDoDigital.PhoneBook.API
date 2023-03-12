using Microsoft.EntityFrameworkCore;

namespace WeDoDigital.PhoneBook.Infrastructure.Context
{
    public class PhoneBookDBContext : DbContext
    {
        public PhoneBookDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<WeDoDigital.PhoneBook.Core.Models.PhoneBook> PhoneBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<WeDoDigital.PhoneBook.Core.Models.PhoneBook>(b =>
            //{
            //    b.HasKey(e => e.Id);
            //    b.Property(e => e.Id).UseIdentityColumn();
            //});
        }
    }
}
