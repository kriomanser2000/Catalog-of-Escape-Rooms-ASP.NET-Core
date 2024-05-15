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
    public class DetailsModel : PageModel
    {
        private readonly WebApplication1.DAL.AppDbContext _context;

        public DetailsModel(WebApplication1.DAL.AppDbContext context)
        {
            _context = context;
        }

        public SuperRoom SuperRoom { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superroom = await _context.SuperRooms.FirstOrDefaultAsync(m => m.Id == id);
            if (superroom == null)
            {
                return NotFound();
            }
            else
            {
                SuperRoom = superroom;
            }
            return Page();
        }
    }
}
