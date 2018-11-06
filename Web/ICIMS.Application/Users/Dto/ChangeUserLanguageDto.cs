using System.ComponentModel.DataAnnotations;

namespace ICIMS.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}