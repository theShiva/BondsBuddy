using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BondsBuddy.Api.Models.Dtos;
using Newtonsoft.Json;

namespace BondsBuddy.Api.Models.Responses
{
    public class PhoneResponse : ResponseBase
    {
        [JsonProperty("data")]
        public PhoneDto Phone { get; set; }
    }
}