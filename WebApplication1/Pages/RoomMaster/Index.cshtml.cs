using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Pages.RoomMaster
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.DAL.AppDbContext _context;

        public IndexModel(WebApplication1.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<SuperRoom> SuperRoom { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SuperRoom = await _context.SuperRooms.ToListAsync();
        }
    }
}