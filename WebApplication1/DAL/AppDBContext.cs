using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
            
        }
        public virtual DbSet<SuperRooms> SuperRooms { get; set; }
    }
}
