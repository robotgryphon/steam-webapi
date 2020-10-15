using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steam.JsonModels
{
    [JsonObject]
    public class SteamItemSchemaResult
    {
        [JsonRequired]
        [JsonProperty("result")]
        public SteamItemSchemaResultInner Result;

        [JsonObject]
        public class SteamItemSchemaResultInner
        {
            [JsonProperty("status")]
            public int Status;

            [JsonProperty("items")]
            public SteamItemSchemaEntry[] Items;
        }
    }
}
