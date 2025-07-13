using System.Text.Json.Serialization;
using AUTHDEMO1.Models;

namespace AUTHDEMO1.DTOs
{
    public class AttendanceDto
    {
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AttendanceStatus Status { get; set; }
    }
}
