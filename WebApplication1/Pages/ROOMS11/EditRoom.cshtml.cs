using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Pages.ROOMS11
{
    public class EditRoomModel : PageModel
    {
        private readonly RoomContext _context;

        public EditRoomModel(RoomContext context)
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Room).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return RedirectToPage("./QuestList");
        }
        public void OnGet()
        {
        }
    }
}