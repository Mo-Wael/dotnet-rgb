using System.Text.Json.Serialization;

namespace dotnet_rgb.Models
{
    // Showing the name of enum istead of the values:
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RgpClass
    {
        Knight = 1,
        Mage = 2,
        cleric = 3

    }
}