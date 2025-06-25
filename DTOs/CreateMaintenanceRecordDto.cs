namespace AUTHDEMO1.DTOs
{
    public class CreateMaintenanceRecordDto
    {
        public int AssetId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public string? TechnicianName { get; set; } 
        public decimal Cost { get; set; }           
    }
}
