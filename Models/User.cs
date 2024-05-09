using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace HerhalingASPdotnetCore.Models
{
    public class User()
    {
        private readonly IStringLocalizer<User> _localizer;

        [Required(ErrorMessage ="{0} Required")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Too short or too long")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 10,ErrorMessage ="Too short or too long")]
        public string Message { get; set; }
    }
}
