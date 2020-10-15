using Newtonsoft.Json;
using Steam.JsonModels;
using System;

namespace SteamApi.Json
{
    [JsonObject]
    public class SteamInventoryItemWithDescription
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("classid")]
        public string ClassId;

        [JsonProperty("instanceid")]
        public string InstanceId;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("icon_url")]
        public string IconUrl;

        [JsonProperty("marketHashName")]
        public string MarketHashName;

        [JsonProperty("amount")]
        public int Amount;

        [JsonProperty("pos")]
        public int Position;

        public void LoadInfoFromItem(SteamInventoryItem item)
        {
            Id = item.Id;
            ClassId = item.ClassId;
            InstanceId = item.InstanceId;
            Amount = item.Amount;
            Position = item.Position;
        }

        public void LoadInfoFromItemDescription(SteamInventoryItemDescription desc)
        {
            Name = desc.Name;
            MarketHashName = desc.MarketHashName;
        }

        public void LoadInfoFromSchema(SteamItemSchemaEntry schema)
        {
            IconUrl = schema.ImageUrl;
        }
    }
}
