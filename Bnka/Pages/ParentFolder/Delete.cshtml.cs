using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bnka.Data;
using Bnka.Models;

namespace Bnka.Pages.ParentFolder
{
    public class DeleteModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public DeleteModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parent Parent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents.FirstOrDefaultAsync(m => m.Id == id);

            if (parent == null)
            {
                return NotFound();
            }
            else
            {
                Parent = parent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parent = await _context.Parents.FindAsync(id);
            if (parent != null)
            {
                Parent = parent;
                _context.Parents.Remove(Parent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
