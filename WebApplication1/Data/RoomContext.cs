using Microsoft.EntityFrameworkCore;
using WebApplication1.Pages.ROOMS11;

namespace WebApplication1.Data
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        {
        }
        public DbSet<RoomInfo> Rooms { get; set; }
    }
}