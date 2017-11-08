namespace BondsBuddy.Api.Models.Dtos
{
    /// <summary>
    /// Phone
    /// </summary>
    public class PhoneDto
    {
        /// <summary>
        /// The unique id of the Phone
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name associated with the phone. 
        /// </summary>
        public string PhoneName { get; set; }

        /// <summary>
        /// The phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The country code prefix number when dialing internationally
        /// </summary>
        public int? CountryCode { get; set; }

        /// <summary>
        /// The 2 Character ISO Code for the country the phone is in use in.
        /// </summary>
        public string Iso2CountryCode { get; set; }

        /// <summary>
        /// The phone number in E164 format. E.164 defines a general format for international telephone numbers.         
        /// </summary>
        public string E164PhoneNumber { get; set; }

        /// <summary>
        /// The phone number formatted according to the nation's preferred format.
        /// </summary>
        public string NationalPhoneNumber { get; set; }

        /// <summary>
        /// The phone number formatted according to the international dialing format.
        /// </summary>
        public string InternationalPhoneNumber { get; set; }

        /// <summary>
        /// The raw phone number, without any formatting. 
        /// </summary>
        public string RawPhoneNumber { get; set; }
    }
}