using AUTHDEMO1.Enums;

namespace AUTHDEMO1.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime PurchaseDate { get; set; }
        public AssetStatus Status { get; set; } = AssetStatus.Active;
    }
}
