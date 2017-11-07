using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BondsBuddy.Api.Models.Dtos
{
    public class PhoneDto
    {
        public int Id { get; set; }

        public string PhoneName { get; set; }

        public string PhoneNumber { get; set; }
    }
}