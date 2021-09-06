using System.Text.Json.Serialization;

namespace WowParser.Model.Consimple
{
    public class Product
    {
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Title { get; set; }

        public int CategoryId { get; set; }
    }
}