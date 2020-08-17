using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DTO
{
    public partial class ClubsDTO
    {
        [JsonProperty("BackGround")]
        public string BackGround { get; set; }

        [JsonProperty("ClubName")]
        public string ClubName { get; set; }

        [JsonProperty("CoverImage")]
        public string CoverImage { get; set; }

        [JsonProperty("Drawn")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Drawn { get; set; }

        [JsonProperty("GA")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Ga { get; set; }

        [JsonProperty("GD")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Gd { get; set; }

        [JsonProperty("GF")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Gf { get; set; }

        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("LeagueKey")]
        public string LeagueKey { get; set; }

        [JsonProperty("Logo")]
        public string Logo { get; set; }

        [JsonProperty("Lost")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Lost { get; set; }

        [JsonProperty("Manager")]
        public string Manager { get; set; }

        [JsonProperty("Plays")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Plays { get; set; }

        [JsonProperty("Points")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Points { get; set; }

        [JsonProperty("Position")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Position { get; set; }

        [JsonProperty("Stadium")]
        public string Stadium { get; set; }

        [JsonProperty("Won")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Won { get; set; }

        [JsonProperty("_Key")]
        public string _Key { get; set; }
    }

    public partial class ClubsDTO
    {
        public static Dictionary<string,ClubsDTO> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, ClubsDTO>>(json, DTO.Converter.Settings);
    }
}
