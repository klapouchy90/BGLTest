using System.ComponentModel.DataAnnotations;

namespace BGL.KSzlachetka.Models
{
    public class SearchViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}