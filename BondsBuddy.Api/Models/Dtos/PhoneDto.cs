namespace BondsBuddy.Api.Models.Dtos
{
    public class PhoneDto
    {
        public int Id { get; set; }

        public string PhoneName { get; set; }

        public string PhoneNumber { get; set; }

        public int? CountryCode { get; set; }

        public string Iso2CountryCode { get; set; }

        public string E164PhoneNumber { get; set; }

        public string NationalPhoneNumber { get; set; }

        public string InternationalPhoneNumber { get; set; }

        public string RawPhoneNumber { get; set; }
    }
}