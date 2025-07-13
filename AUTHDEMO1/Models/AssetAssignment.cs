using System.ComponentModel.DataAnnotations.Schema;

namespace AUTHDEMO1.Models
{
    public class AssetAssignment
    {
        public int Id { get; set; }

        [ForeignKey("AssetId")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
