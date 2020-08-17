using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DTO
{
    public partial class LeaguesDto
    {
        [JsonProperty("CoverImg")]
        public string CoverImg { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("LeagueName")]
        public string LeagueName { get; set; }

        [JsonProperty("Logo")]
        public string Logo { get; set; }

        [JsonProperty("Nationality")]
        public string Nationality { get; set; }

        [JsonProperty("NumClub")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NumClub { get; set; }

        [JsonProperty("RuleKey")]
        public string RuleKey { get; set; }

        [JsonProperty("_Key")]
        public string _Key { get; set; }
    }

    public partial class LeaguesDto
    {
        public static Dictionary<string, LeaguesDto> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, LeaguesDto>>(json, DTO.Converter.Settings);
    }
}
