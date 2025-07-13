using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IBankAccountRepository : IRepository<BankAccount>
    {
        Task<IEnumerable<BankAccount>> GetBankAccountsByEmployeeIdAsync(int employeeId);
        Task<BankAccount> GetPrimaryBankAccountByEmployeeIdAsync(int employeeId);
        Task SetPrimaryBankAccountAsync(int employeeId, int bankAccountId);
    }
}
