using System.Text.Json.Serialization;

namespace WowParser.Model.Datahub
{
    public class City
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("name")]
        public string Title { get; set; }

        [JsonPropertyName("subcountry")]
        public string SubCountry { get; set; }

        [JsonPropertyName("geonameid")]
        public int GeonameId { get; set; }


    }
}