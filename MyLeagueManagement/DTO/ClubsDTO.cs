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
    public partial class ClubsDTO //: INotifyCollectionChanged
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

        public string _Key { get; set; }
    }
    public partial class ClubsDTO
    {
        public static Dictionary<string, ClubsDTO> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, ClubsDTO>>(json, DTO.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ClubsDTO self) => JsonConvert.SerializeObject(self, DTO.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
