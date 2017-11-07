using System.Collections.Generic;
using BondsBuddy.Api.Models.Dtos;
using Newtonsoft.Json;

namespace BondsBuddy.Api.Models.Responses
{
    public class PhonesResponse : ResponseBase
    {
        [JsonProperty("data")]
        public List<PhoneDto> Phones { get; set; }
    }
}