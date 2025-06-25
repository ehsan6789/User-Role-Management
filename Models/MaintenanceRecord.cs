namespace AUTHDEMO1.Models
{
    public class MaintenanceRecord
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string? TechnicianName { get; set; }  
        public decimal Cost { get; set; }

        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
    }
}
