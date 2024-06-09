using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bnka.Data;
using Bnka.Models;

namespace Bnka.Pages.ParentFolder
{
    public class CreateModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _context;

        public CreateModel(Bnka.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectedList2> NationalityList { get; set; }
        public List<SelectedList2> PlaceList { get; set; }
        public IActionResult OnGet()
        {
            NationalityList = _context.Nationalities.Select(x => new SelectedList2
            {
                value = x.Id,
                text = x.Name
            }).ToList();

            PlaceList = _context.Places.Select(x => new SelectedList2
            {
                value = x.Id,
                text = x.PlaceNumber
            }).ToList();


            return Page();
        }
        [BindProperty]
        public string? ImagePhoto { get; set; }

        [BindProperty]
        public Parent Parent { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if(Parent.Photo == null)
            {
                Parent.Photo="default.jpg";
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var ImageFile=Request.Form.Files.FirstOrDefault();
            if(ImageFile != null && ImageFile.Length > 0)
            {
                Parent.Photo = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                if (!Directory.Exists("wwwroot/Uploads"))
                {
                    Directory.CreateDirectory("wwwroot/Uploads");
                }
                var SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", Parent.Photo);
                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
            }

            _context.Parents.Add(Parent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public class SelectedList2
        {
            public int value { get; set; }
            public string text { get; set; }
        }
    }
}
