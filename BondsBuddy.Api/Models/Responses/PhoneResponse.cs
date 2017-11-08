using BondsBuddy.Api.Models.Dtos;
using Newtonsoft.Json;

namespace BondsBuddy.Api.Models.Responses
{
    /// <summary>
    /// Phone Response object.
    /// </summary>
    public class PhoneResponse : ResponseBase
    {
        /// <summary>
        /// Phone
        /// </summary>
        [JsonProperty("data")]
        public PhoneDto Phone { get; set; }
    }
}