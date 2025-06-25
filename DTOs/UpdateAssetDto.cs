using AUTHDEMO1.Enums;

namespace AUTHDEMO1.DTOs
{
    public class UpdateAssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int CategoryId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public AssetStatus Status { get; set; }
    }
}
