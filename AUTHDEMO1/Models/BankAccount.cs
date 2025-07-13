namespace AUTHDEMO1.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountTitle { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public string Reference { get; set; }
        public bool IsPrimary { get; set; }

        // Foreign key
        public int EmployeeId { get; set; }

        // Navigation property
        public Employee Employee { get; set; }
    }
}
