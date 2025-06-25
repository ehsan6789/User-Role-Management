namespace AUTHDEMO1.DTOs
{
    public class AssetAssignmentDto
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssignedToUserId { get; set; }
       
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
