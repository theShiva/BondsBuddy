using System.Collections.Generic;
using BondsBuddy.Api.Models.Dtos;
using Newtonsoft.Json;

namespace BondsBuddy.Api.Models.Responses
{
    /// <summary>
    /// Phones Response Object
    /// </summary>
    public class PhonesResponse : ResponseBase
    {
        /// <summary>
        /// List of Phones
        /// </summary>
        [JsonProperty("data")]
        public List<PhoneDto> Phones { get; set; }
    }
}