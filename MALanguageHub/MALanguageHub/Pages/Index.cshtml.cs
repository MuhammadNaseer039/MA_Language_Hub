using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MALHdbcontext db;
        public Aboutus Aboutus { get; set; }
        public List<Home> Home { get; set; }

        public List<Courses> Courses { get; set; }
        public List<OurProfessionals> ourProfessionals { get; set; }
        public List<StudentReviews> StudentReviews { get; set; }
        public Contactus Contact { get; set; }
        public Settings Settings { get; set; }


        public IndexModel(MALHdbcontext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            
            Home = db.tbl_home.Take(3).ToList();
            Courses = db.tbl_courses.ToList();
            ourProfessionals = db.tbl_ourprofessionals.ToList();
            StudentReviews = db.tbl_studentreviews.ToList();
            Contact = db.tbl_contactus.FirstOrDefault();
            Aboutus = db.tbl_aboutus.FirstOrDefault();
            Settings = db.tbl_settings.FirstOrDefault();

        }
    }
}
