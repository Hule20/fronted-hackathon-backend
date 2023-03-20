using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Fronted.Models
{
    public class PlatformType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<MaliciousEvent>? MaliciousEvents { get; set; }
    }
}
