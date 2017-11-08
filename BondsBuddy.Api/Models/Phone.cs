using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BondsBuddy.Api.Models
{
    public class Phone
    {
        [Required]
        public int Id { get; set; }

        public string PhoneName { get; set; }

        public int? CountryCode { get; set; }

        public string Iso2CountryCode { get; set; }

        public string E164PhoneNumber { get; set; }

        public string NationalPhoneNumber { get; set; }

        public string InternationalPhoneNumber { get; set; }

        [Required]
        public string RawPhoneNumber { get; set; }

        public string NationalFormattedPhoneNumber { get; set; }
       
    }
}