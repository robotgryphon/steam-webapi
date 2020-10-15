using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamUserProfile
    {
        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("more")]
        public bool More;

        [JsonProperty("rgInventory")]
        public Dictionary<string, SteamInventoryItem> Inventory;

        [JsonProperty("rgDescriptions")]
        public Dictionary<string, SteamInventoryItemDescription> ItemDescriptions;
    }
}
