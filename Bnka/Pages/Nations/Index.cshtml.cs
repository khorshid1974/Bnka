using Bnka.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bnka.Pages.Nations
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
                _db = db;
        }

        public List<Models.Nationality> Nationalities { get;  set; }
        public void OnGet()
        {
            //Nationalities = new ();
            Nationalities = _db.Nationalities.ToList();
        }

        public void OnPost(int Id)
        {
            var ObjectToDelete = _db.Nationalities.Find(Id);
            if (ObjectToDelete == null) return;
            _db.Nationalities.Remove(ObjectToDelete);
            _db.SaveChanges();
            Nationalities = _db.Nationalities.ToList();


        }
    }
}
