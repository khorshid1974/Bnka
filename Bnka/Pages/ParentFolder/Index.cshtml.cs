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
    public class IndexModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public IndexModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Parent> Parent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Parent = await _context.Parents
                .Include(p => p.Nationality)
                .Include(x=>x.Childern)
                .Include(p => p.Place).ToListAsync();
        }
    }
}
