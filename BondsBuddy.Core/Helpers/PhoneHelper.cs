using System;
using BondsBuddy.Core.Models;
using PhoneNumbers;

namespace BondsBuddy.Core.Helpers
{
    public class PhoneHelper
    {
        public static bool TryParse(string phoneNumberToParse, out CanonicalPhoneNumber phoneNumber, string iso2CountryCode = "US")
        {
            phoneNumber = null;

            if (string.IsNullOrEmpty(phoneNumberToParse))
            {
                return false;
            }

            phoneNumberToParse = phoneNumberToParse.Trim();

            if (phoneNumberToParse.StartsWith("00"))
            {
                phoneNumberToParse = String.Concat("+", phoneNumberToParse.Remove(0, 2));
            }

            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber number = phoneUtil.Parse(phoneNumberToParse, phoneNumberToParse.StartsWith("+") ? null : iso2CountryCode);

                if (phoneUtil.IsValidNumber(number))
                {

                    phoneNumber = new CanonicalPhoneNumber();

                    if (number.HasCountryCode)
                    {
                        phoneNumber.CountryCode = number.CountryCode;
                    }

                    phoneNumber.E164PhoneNumber = phoneUtil.Format(number, PhoneNumberFormat.E164);

                    phoneNumber.Iso2CountryCode = phoneUtil.GetRegionCodeForNumber(number);

                    phoneNumber.InternationalPhoneNumber = phoneUtil.Format(number, PhoneNumberFormat.INTERNATIONAL);

                    phoneNumber.NationalPhoneNumber = phoneUtil.Format(number, PhoneNumberFormat.NATIONAL);

                    // We probably not needed now, but is here, if you need it at a later date.
                    // string rfc3966Number = phoneUtil.Format(number, PhoneNumberFormat.RFC3966);                    

                    return true;
                }
                
            }
            catch (NumberParseException exception)
            {
                    // TODO: Log exception if you care about it.
                Console.WriteLine($"Error parsing phone number: {exception.Message}");
                return false;
            }

            return false;
        }

        public static CanonicalPhoneNumber Parse(string phoneNumberToParse, string iso2CountryCode = "US")
        {
            CanonicalPhoneNumber parsedPhoneNumber;

            if (TryParse(phoneNumberToParse, out parsedPhoneNumber, iso2CountryCode))
            {
                return parsedPhoneNumber;
            }

            return null;
        }
    }
}
