using Newtonsoft.Json;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamInventoryItemDescriptionTag
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("internal_name")]
        public string InternalName;
    }
}