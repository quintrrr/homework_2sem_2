using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace homework_2sem_2.DataAccess
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=193.176.190.148;Port=5432;Database=lottery;Username=homework;Password=qwerty");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
