using AUTHDEMO1.Enums;

namespace AUTHDEMO1.DTOs
{
    public class AssetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string CategoryName { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsActive { get; set; }
        public DateTime PurchaseDate { get; set; }
        public AssetStatus Status { get; set; }
    }
}
