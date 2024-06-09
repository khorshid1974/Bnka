using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bnka.Pages.Nations
{
    
    public class EditModel : PageModel
    {
        private readonly Data.ApplicationDbContext _db;
        public EditModel(Data.ApplicationDbContext db)
        {
                _db = db;


        }
        [BindProperty]
        public Models.Nationality EditObject { get; set; }
        public void OnGet(int Id)
        {
             EditObject= _db.Nationalities.Find(Id);
            if (EditObject == null)
            {
                Redirect("/Index");
            }
        }

        public void OnPost()
        {
            //var ExistingObject = _db.Nationalities.Find(EditObject.Id);
            //ExistingObject.Name= EditObject.Name;
            //_db.SaveChanges();

            _db.Attach(EditObject).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            Redirect("Index");
            

            
        }
    }
}
