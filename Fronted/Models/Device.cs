using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fronted.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Ipv4Address { get; set; }
        public string? MacAddress { get; set; }

        [JsonIgnore]
        public ICollection<MaliciousEvent>? MaliciousEvents { get; set; }
    }
}
