namespace AUTHDEMO1.DTOs
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string AccountTitle { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public string Reference { get; set; }
        public bool IsPrimary { get; set; }
        public int EmployeeId { get; set; }
    }
}
