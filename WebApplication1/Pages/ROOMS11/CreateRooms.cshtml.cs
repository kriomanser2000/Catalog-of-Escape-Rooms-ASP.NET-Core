using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data;

namespace WebApplication1.Pages.ROOMS11
{
    {
        private readonly RoomContext _context;
        public CreateRoomModel(RoomContext context)
        {
            _context = context;
        }
        [BindProperty]
        public RoomInfo Room { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();
            return RedirectToPage("./QuestList");
        }
        public void OnGet()
        {

        }
    }
}