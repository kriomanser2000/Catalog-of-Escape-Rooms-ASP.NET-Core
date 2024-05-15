using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Pages.RoomMaster
{
    public class EditModel : PageModel
    {
        private readonly WebApplication1.DAL.AppDbContext _context;

        public EditModel(WebApplication1.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SuperRoom SuperRoom { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superroom =  await _context.SuperRooms.FirstOrDefaultAsync(m => m.Id == id);
            if (superroom == null)
            {
                return NotFound();
            }
            SuperRoom = superroom;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SuperRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperRoomExists(SuperRoom.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SuperRoomExists(int id)
        {
            return _context.SuperRooms.Any(e => e.Id == id);
        }
    }
}
