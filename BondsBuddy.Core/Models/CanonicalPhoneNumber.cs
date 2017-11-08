namespace BondsBuddy.Core.Models
{
    public class CanonicalPhoneNumber
    {
        public int? CountryCode { get; set; }

        public string Iso2CountryCode { get; set; }

        public string E164PhoneNumber { get; set; }

        public string NationalPhoneNumber { get; set; }

        public string InternationalPhoneNumber { get; set; }

        public string NationalFormattedPhoneNumber
        {
            get
            {
                if (string.IsNullOrEmpty(E164PhoneNumber) || string.IsNullOrEmpty(Iso2CountryCode))
                {
                    return E164PhoneNumber;
                }

                string rawPhoneNumber = E164PhoneNumber.Remove(0, 1);

                switch (Iso2CountryCode)
                {
                    case "US":
                        if (rawPhoneNumber.Trim().Length == 11)
                        {
                            return string.Format("{0}({1}){2}-{3}",
                                rawPhoneNumber.Substring(0, 1),
                                rawPhoneNumber.Substring(1, 3),
                                rawPhoneNumber.Substring(4, 3),
                                rawPhoneNumber.Substring(7, 4));
                        }
                        break;

                    default:
                        return rawPhoneNumber;
                }

                return rawPhoneNumber;
            }
        }                        
    }
}
