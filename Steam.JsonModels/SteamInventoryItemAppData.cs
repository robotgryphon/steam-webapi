using Newtonsoft.Json;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamInventoryItemAppData
    {
        [JsonProperty("def_index")]
        public string DefinitionIndex;
    }
}