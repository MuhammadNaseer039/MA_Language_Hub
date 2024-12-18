using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MALanguageHub.Pages.Admin
{
    public class AddAboutUsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public Aboutus Aboutus { get; set; }
        public string UserName;

        public AddAboutUsModel( MALHdbcontext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            ViewData["title"] = "Add AboutUs";
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }
        public IActionResult OnPost(Aboutus Aboutus)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            if (!ModelState.IsValid)
            {
                TempData["info"] = "Insert your data correctly";
                return Page();
            }
            else
            {
                try
                {
                    string ImageName = Aboutus.Image.FileName.ToString();
                    var folderpath = Path.Combine(env.WebRootPath, "images");
                    var ImageNamepath = Path.Combine(folderpath, ImageName);
                    Aboutus.Image.CopyTo(new FileStream(ImageNamepath, FileMode.Create));

                    //FileStream fs = new FileStream(ImageNamepath, FileMode.Create);
                    //Aboutus.Image.CopyTo(fs);
                    //fs.Dispose();

                    Aboutus.ImageName = ImageName;
                    db.tbl_aboutus.Add(Aboutus);
                    db.SaveChanges();
                    TempData["success"] = "Details Added Successfully";
                    return RedirectToPage("UpdateAboutUs");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Adding Details";
                    return RedirectToPage();

                }
            }
          
        }


    }
}
