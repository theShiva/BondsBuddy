using System.ComponentModel.DataAnnotations;

namespace BondsBuddy.Api.Models.Dtos
{
    /// <summary>
    /// The Phone object to create.
    /// </summary>
    public class PhoneForCreationDto
    {
        /// <summary>
        /// The name associated with the phone. 
        /// </summary>
        [MaxLength(80)]
        public string PhoneName { get; set; }


        /// <summary>
        /// The phone number
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
    }
}