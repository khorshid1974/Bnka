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
    public class DetailsModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public DetailsModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
