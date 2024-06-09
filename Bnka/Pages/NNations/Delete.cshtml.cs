using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bnka.Data;
using Bnka.Models;

namespace Bnka.Pages.NNations
{
    public class DeleteModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public DeleteModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nationality Nationality { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities.FirstOrDefaultAsync(m => m.Id == id);

            if (nationality == null)
            {
                return NotFound();
            }
            else
            {
                Nationality = nationality;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nationality = await _context.Nationalities.FindAsync(id);
            if (nationality != null)
            {
                Nationality = nationality;
                _context.Nationalities.Remove(Nationality);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
