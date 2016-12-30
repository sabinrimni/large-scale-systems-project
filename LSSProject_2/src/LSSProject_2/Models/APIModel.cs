using System.ComponentModel.DataAnnotations;

namespace LSSProject_2.Models
{
    public class APIModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Range(1,15, ErrorMessage = "Range must be between 1 and 15 km")]
        [Display(Name = "Range")]
        public int range { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
