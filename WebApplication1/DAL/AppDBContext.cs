using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        public virtual DbSet<SuperRoom> SuperRooms { get; set; }
    }
}
