using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Pages.ROOMS11;

namespace WebApplication1.Pages.ROOMS11
{
    public class QuestListModel : PageModel
    {
        private readonly RoomContext _context;

        public QuestListModel(RoomContext context)
        {
            _context = context;
        }
        public IList<RoomInfo> Rooms { get; set; }

        public async Task OnGetAsync()
        {
            Rooms = await _context.Rooms.ToListAsync();
        }
    }
}