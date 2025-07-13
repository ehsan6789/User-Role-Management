namespace AUTHDEMO1.DTOs
{
    public class AssetAssignmentDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    
        public string SerialNumber { get; set; }
    }
}
