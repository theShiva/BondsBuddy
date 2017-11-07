using Newtonsoft.Json;

namespace BondsBuddy.Api.Models.Responses
{
    public class ResponseMeta
    {
        [JsonProperty("code")]
        public int HttpStatusCode { get; set; }

        [JsonProperty("errorType")]
        public string ErrorType { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        public ResponseMeta()
        {
            HttpStatusCode = 200;
        }
    }
}