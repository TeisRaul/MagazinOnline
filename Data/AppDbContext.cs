using Microsoft.EntityFrameworkCore;

namespace Magazin_Online.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
         
    }
}
