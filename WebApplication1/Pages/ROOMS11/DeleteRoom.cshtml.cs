using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.ROOMS11
{
    public class DeleteRoomModel : PageModel
    {
        private readonly RoomContext _context;

        public DeleteRoomModel(RoomContext context)
        {
            _context = context;
        }
        [BindProperty]
        public RoomInfo Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room = await _context.Rooms.FirstOrDefaultAsync(m => m.Id == id);
            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room = await _context.Rooms.FindAsync(id);
            if (Room != null)
            {
                _context.Rooms.Remove(Room);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./QuestList");
        }
        public void OnGet()
        {

        }
    }
}