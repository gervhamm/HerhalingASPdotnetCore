using System.ComponentModel.DataAnnotations;

namespace HerhalingASPdotnetCore.Models
{
    public class User()
    {
        [Required(ErrorMessage ="{0} Required")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Too short or too long")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces allowed")]
        [Display(ResourceType = typeof(Resources.Models.User), Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress]
        [Display(ResourceType = typeof(Resources.Models.User), Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [StringLength(100, MinimumLength = 10,ErrorMessage ="Too short or too long")]
        [Display(ResourceType = typeof(Resources.Models.User), Name = "Message")]
        public string Message { get; set; }
    }
}
