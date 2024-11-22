using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class IndexModel : PageModel
    {
        private readonly MALHdbcontext db;
        public List<Home> Homedetails {  get; set; }

        public IndexModel(MALHdbcontext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            if(!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            Homedetails = db.tbl_home.Take(3).ToList();
            return Page();

        }

        public IActionResult OnGetDelete(int id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            Home deleteto =  db.tbl_home.Find(id);
            db.tbl_home.Remove(deleteto);
            db.SaveChanges();
            return RedirectToPage("index");
        }

    }
}
