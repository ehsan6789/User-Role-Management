namespace AUTHDEMO1.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
