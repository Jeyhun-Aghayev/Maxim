using Maxim.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace Maxim.Models
{
    public class Service:BaseAudiTableEntity
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Maxsimum 100 element daxil ede bilersiz")]
        public string Icon { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage ="Maxsimum 100 element daxil ede bilersiz")]
        public string Title { get; set; }
        [Required]
        [MinLength(10,ErrorMessage ="Minimum 10 Element daxil ede bilersiz")]
        public string Description { get; set; }
    }
}
