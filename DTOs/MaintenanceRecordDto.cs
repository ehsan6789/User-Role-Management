namespace AUTHDEMO1.DTOs
{
    public class MaintenanceRecordDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public string? TechnicianName { get; set; } 
        public decimal Cost { get; set; }          
    }
}
