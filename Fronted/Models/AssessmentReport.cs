using System.ComponentModel.DataAnnotations;

namespace Fronted.Models
{
    public class AssessmentReport
    {
        [Key]
        public int Id { get; set; }
        public int PulseCount { get; set; }
        public int MalwareCount { get; set; }
        public ThreatType? ThreatType { get; set; } = Models.ThreatType.THREAT_TYPE_UNSPECIFIED;
        public int? PlatformTypeId { get; set; }
        public PlatformType? PlatformType { get; set; }
        public MaliciousEvent MaliciousEvent { get; set; }
    }

    public enum ThreatType
    {
        THREAT_TYPE_UNSPECIFIED,
        MALWARE,
        SOCIAL_ENGINEERING,
        UNWANTED_SOFTWARE,
        POTENTIALLY_HARMFUL_APPLICATION
    }
}
