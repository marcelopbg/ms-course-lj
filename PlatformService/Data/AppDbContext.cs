using Microsoft.EntityFrameworkCore;
using PlataformService.Models;

namespace PlafatormService.DataAnnotations
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Platform> Platforms { get; set; }
    }
}