namespace AUTHDEMO1.DTOs
{
    public class AssignAssetDto
    {
        public int AssetId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
