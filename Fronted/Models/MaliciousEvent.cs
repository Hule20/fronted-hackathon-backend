using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Fronted.Models
{
    public class MaliciousEvent
    {
        [Key]
        public int Id { get; set; }
        public string UrlVisited { get; set; }
        public DateTime VisitedAt { get; set; } = DateTime.Now;
        public string OriginIp { get; set; }
        public ThreatLevel ThreatLevel { get; set; }
        public int DeviceId { get; set; }
        [JsonIgnore]
        public Device Device { get; set; }
        public int AssessmentReportId { get; set; }
        public AssessmentReport AssessmentReport { get; set; }
    }

    public enum ThreatLevel
    {
        High,
        Low,
        Undefined
    }
}
