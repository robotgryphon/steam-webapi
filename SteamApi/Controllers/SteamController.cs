using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Steam.JsonModels;
using SteamApi.Json;

namespace SteamApi.Controllers
{
    [Route("api/steam")]
    [ApiController]
    public class SteamController : ControllerBase
    {
        private readonly IConfiguration config;

        /// <summary>
        /// TF2
        /// </summary>
        private const string game = "440";

        public SteamController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        [Route("noop")]
        public IActionResult NoOperation()
        {
            return NoContent();
        }

        [HttpGet]
        [Route("profile/{userid}")]
        public async Task<IActionResult> GetUserProfileAsync(string userid)
        {
            string key = config.GetValue<string>("Steam:ApiKey");

            var profileData = await GetUserProfileItemsAsync(userid);

            return Ok(profileData);
        }

        private async Task<ImmutableArray<SteamInventoryItemWithDescription>> GetUserProfileItemsAsync(string userid)
        {
            string key = config.GetValue<string>("Steam:ApiKey");

            string profile = config.GetValue<string>("Steam:UrlData:Profile");
            

            // profile or id, depends on user type - id = word, 'zorntaov'
            profile = profile
                .Replace("{type}", "id")
                .Replace("{profile}", userid)
                .Replace("{game}", game);

            var responses = new List<SteamInventoryItemWithDescription>();
            using (var client = new HttpClient())
            {
                var data = await client.GetAsync(profile + "?key=" + key);
                string json = await data.Content.ReadAsStringAsync();

                SteamUserProfile userProfile = JsonConvert.DeserializeObject<SteamUserProfile>(json);
                if (!userProfile.Success)
                    return new SteamInventoryItemWithDescription[0].ToImmutableArray();

                var itemSchemaData = await client.GetAsync(config.GetValue<string>("Steam:UrlData:Items") + "?key=" + key);
                string itemSchemaJson = await itemSchemaData.Content.ReadAsStringAsync();
                SteamItemSchemaResult schemas = JsonConvert.DeserializeObject<SteamItemSchemaResult>(itemSchemaJson);

                foreach(var item in userProfile.Inventory)
                {
                    var v = userProfile.ItemDescriptions.Values
                        .FirstOrDefault(desc => item.Value.ClassId == desc.ClassId && item.Value.InstanceId == desc.InstanceId);

                    if (v == null)
                        continue;

                    

                    var id = new SteamInventoryItemWithDescription();
                    id.LoadInfoFromItem(item.Value);
                    id.LoadInfoFromItemDescription(v);

                    var schema = schemas.Result.Items.FirstOrDefault(sch => sch.DefinitionIndex == int.Parse(v.AppData.DefinitionIndex));
                    if (schema != null)
                        id.LoadInfoFromSchema(schema);

                    responses.Add(id);
                }
            }

            return responses.ToImmutableArray();
        }
    }
}
