using System.Text.Json.Serialization;

namespace WowParser.Model.Consimple
{
    public class Category
    {
       public int Id { get; set; }

       [JsonPropertyName("Name")]
       public string Title { get; set; }
    }
}