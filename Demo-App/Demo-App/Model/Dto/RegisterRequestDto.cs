using System.ComponentModel.DataAnnotations;

namespace Demo_App.Model.Dto
{
    public class RegisterRequestDto
    {
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
