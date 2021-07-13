using Microsoft.EntityFrameworkCore;

namespace Business.Data
{
    class ApplicationContext:DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<City> Cities{ get; private set; }
        public DbSet<Poi> Pois { get; private set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mslocaldb;Database=DatabaseName;Trusted_Connection=True;");
            }
        }
    }
}
