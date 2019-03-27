using Newtonsoft.Json;

namespace TCLegisAPI.Models
{
    public class ErrorDetails
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
