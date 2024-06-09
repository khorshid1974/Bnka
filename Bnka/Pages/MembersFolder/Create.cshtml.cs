using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bnka.Data;
using Bnka.Models;

namespace Bnka.Pages.MembersFolder
{
    public class CreateModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public CreateModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ParentId"] = new SelectList(_context.Parents, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Members Members { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Members.Add(Members);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
