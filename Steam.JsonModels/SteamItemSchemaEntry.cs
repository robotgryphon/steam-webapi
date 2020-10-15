using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamItemSchemaEntry
    {
        [JsonProperty("defindex")]
        public int DefinitionIndex;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("image_url")]
        public string ImageUrl;
    }
}
