namespace AUTHDEMO1.DTOs
{
    public class CreateAssetAssignmentDto
    {
        public int AssetId { get; set; }
        public string AssignedTo { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Remarks { get; set; }
    }
}
