using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MALanguageHub.Models
{
    public class OurProfessionals
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        [MaxLength(18, ErrorMessage = "Title cannot exceed 18 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [MaxLength(72, ErrorMessage = "Description cannot exceed 72 characters.")]
        public string Description { get; set; }


        [Url(ErrorMessage = "Invalid URL format.")]
        [Display(Name = "Facebook")]
        public string FacebookLink { get; set; }

        [Display(Name = "WhatsApp Number Format(923XXXXXXXXX)")]
        public string WhatsAppLink { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        [Display(Name = "Instagram")]
        public string InstagramLink { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        [Display(Name = "LinkedIn")]
        public string LinkedInLink { get; set; }

        [Display(Name = "Image")]
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

    }

}
