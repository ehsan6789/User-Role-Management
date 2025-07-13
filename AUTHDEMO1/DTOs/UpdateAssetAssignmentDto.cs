namespace AUTHDEMO1.DTOs
{
    public class UpdateAssetAssignmentDto
    {
        public int AssetId { get; set; }
        public string AssignedTo { get; set; } = string.Empty;
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Remarks { get; set; }
    }
}

