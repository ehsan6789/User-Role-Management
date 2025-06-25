namespace AUTHDEMO1.Models
{
    public class AssetAssignment
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        public string AssignedToUserId { get; set; }
    
        public ApplicationUser AssignedToUser { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
