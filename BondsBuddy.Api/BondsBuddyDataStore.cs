using System.Collections.Generic;
using BondsBuddy.Api.Models;

namespace BondsBuddy.Api
{
    public class BondsBuddyDataStore
    {
        public static BondsBuddyDataStore Current { get; } = new BondsBuddyDataStore();

        public List<Phone> Phones { get; set; }

        public BondsBuddyDataStore()
        {
            Phones = new List<Phone>()
            {
                new Phone()
                {
                    Id = 1,
                    PhoneName = "Bill & Melinda Gates Foundation",
                    NationalFormattedPhoneNumber = "1-(206)709-3140",
                    RawPhoneNumber = "2067093140",
                    CountryCode = 1,
                    Iso2CountryCode = "US",
                    E164PhoneNumber="+12067093140",
                    NationalPhoneNumber="(206) 709-3140",
                    InternationalPhoneNumber="+1 206-709-3140"
                }
            };
        }
    }
}