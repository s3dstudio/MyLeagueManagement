using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DTO
{
    public partial class PlayersDTO
    {
        [JsonProperty("AllGoal")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AllGoal { get; set; }

        [JsonProperty("DoB")]
        public string DoB { get; set; }


        [JsonProperty("Image")]
        public string Image { get; set; }


        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        public string Nationality { get; set; }

        [JsonProperty("Number")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Number { get; set; }

        [JsonProperty("Position")]
        public string Position { get; set; }

        [JsonProperty("ClubKey")]
        public string ClubKey { get; set; }
    }

    public partial class PlayersDTO
    {
        public static Dictionary<string,PlayersDTO> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string,PlayersDTO>>(json, DTO.Converter.Settings);
    }
}
