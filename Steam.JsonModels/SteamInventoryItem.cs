using Newtonsoft.Json;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamInventoryItem
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("classid")]
        public string ClassId;

        [JsonProperty("instanceid")]
        public string InstanceId;

        [JsonProperty("amount")]
        public int Amount;

        [JsonProperty("pos")]
        public int Position;
    }
}