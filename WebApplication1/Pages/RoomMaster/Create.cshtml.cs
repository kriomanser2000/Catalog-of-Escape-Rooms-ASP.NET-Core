using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Pages.RoomMaster
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication1.DAL.AppDbContext _context;

        public CreateModel(WebApplication1.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SuperRoom SuperRoom { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SuperRooms.Add(SuperRoom);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
