using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bnka.Pages.Nations
{
    public class NewModel : PageModel
    {
        private readonly Bnka.Data.ApplicationDbContext _db;
        public NewModel(Data.ApplicationDbContext db)
        {
            _db = db;   
        }
        public void OnGet()
        {
        }
        public async Task OnPostAsync(string natioalty) {
            Models.Nationality n = new();
            n.Name = natioalty;
            _db.Nationalities.Add(n);
            await _db.SaveChangesAsync();
            Redirect("Nations/Index");
           
        }
    }
}
