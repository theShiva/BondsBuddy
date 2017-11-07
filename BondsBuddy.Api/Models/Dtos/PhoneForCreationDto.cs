using System.ComponentModel.DataAnnotations;

namespace BondsBuddy.Api.Models.Dtos
{
    public class PhoneForCreationDto
    {
        [MaxLength(80)]
        public string PhoneName { get; set; }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
    }
}