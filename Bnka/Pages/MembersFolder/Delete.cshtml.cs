using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bnka.Data;
using Bnka.Models;

namespace Bnka.Pages.MembersFolder
{
    public class DeleteModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public DeleteModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Members Members { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

            if (members == null)
            {
                return NotFound();
            }
            else
            {
                Members = members;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.FindAsync(id);
            if (members != null)
            {
                Members = members;
                _context.Members.Remove(Members);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
