namespace AUTHDEMO1.DTOs
{
    public class UpdateMaintenanceRecordDto
    {
        public DateTime MaintenanceDate { get; set; }
        public int AssetId { get; set; }
        public string? Description { get; set; }
        public string? TechnicianName { get; set; }
        public decimal Cost { get; set; }
    }
}
