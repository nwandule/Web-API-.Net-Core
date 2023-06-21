using System.ComponentModel.DataAnnotations;

namespace Demo_App.Model.Dto
{
    //passing Object
    public class AddProductRequestDto
    {
       
        public Guid Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name has to min of 3 charactors")]
        [MaxLength(20, ErrorMessage = "Name has to max of 20 charactors")]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Description has to min of 3 charactors")]
        [MaxLength(20, ErrorMessage = "Description has to max of 20 charactors")]
        public string Description { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Price has to min of 3 charactors")]
        [MaxLength(20, ErrorMessage = "Price has to max of 20 charactors")]
        public string price { get; set; }
    }
}
