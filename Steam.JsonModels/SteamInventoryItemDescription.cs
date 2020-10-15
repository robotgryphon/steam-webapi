using Newtonsoft.Json;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamInventoryItemDescription
    {
        public string AppId;
        public string ClassId;
        public string InstanceId;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("icon_url")]
        public string IconUrl;

        [JsonProperty("market_hash_name")]
        public string MarketHashName;

        [JsonProperty("tags")]
        public SteamInventoryItemDescriptionTag[] Tags;

        [JsonProperty("app_data")]
        public SteamInventoryItemAppData AppData;
    }
}