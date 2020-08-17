using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DTO
{

    public partial class RulesDTO
    {
        [JsonProperty("DrawPoit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long DrawPoit { get; set; }

        [JsonProperty("LossPoit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LossPoit { get; set; }

        [JsonProperty("MaxAge")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MaxAge { get; set; }

        [JsonProperty("MaxForeign")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MaxForeign { get; set; }

        [JsonProperty("MaxSquadSize")]
        public string MaxSquadSize { get; set; }

        [JsonProperty("MinAge")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MinAge { get; set; }

        [JsonProperty("MinSquadSize")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long MinSquadSize { get; set; }

        [JsonProperty("Priority")]
        public string Priority { get; set; }

        [JsonProperty("Stoppage")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Stoppage { get; set; }

        [JsonProperty("WinPoit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long WinPoit { get; set; }

        [JsonProperty("_Key")]
        public string _Key { get; set; }
    }
    public partial class RulesDTO
    {
        public static Dictionary<string,RulesDTO> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string,RulesDTO>>(json, DTO.Converter.Settings);
    }
}
