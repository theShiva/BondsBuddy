using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                    RawPhoneNumber = "2067093140"
                }
            };
        }
    }
}