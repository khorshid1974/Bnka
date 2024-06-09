using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bnka.Data;
using Bnka.Models;

namespace Bnka.Pages.PlacesFolder
{
    public class DeleteModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public DeleteModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Place Place { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Places.FirstOrDefaultAsync(m => m.Id == id);

            if (place == null)
            {
                return NotFound();
            }
            else
            {
                Place = place;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Places.FindAsync(id);
            if (place != null)
            {
                Place = place;
                _context.Places.Remove(Place);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
