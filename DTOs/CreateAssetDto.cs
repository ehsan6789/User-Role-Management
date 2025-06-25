using System.ComponentModel.DataAnnotations;
using AUTHDEMO1.Enums;

namespace AUTHDEMO1.DTOs
{
    public class CreateAssetDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public AssetStatus Status { get; set; }
    }
}
