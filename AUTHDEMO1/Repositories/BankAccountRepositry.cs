
using AUTHDEMO1.Data;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BankAccount>> GetBankAccountsByEmployeeIdAsync(int employeeId)
        {
            return (IEnumerable<BankAccount>)await _context.BankAccounts
                .Where(b => b.EmployeeId == employeeId)
                .ToListAsync();
        }
        public async Task<BankAccount> GetPrimaryBankAccountByEmployeeIdAsync(int employeeId)
        {
            return await _context.BankAccounts
                .Where(b => b.EmployeeId == employeeId && b.IsPrimary)
                .FirstOrDefaultAsync();

        }
        public async Task SetPrimaryBankAccountAsync(int employeeId, int bankAccountId)
        {
            // First, set all bank accounts for this employee to non-primary
            var employeeBankAccounts = await _context.BankAccounts
                .Where(b => b.EmployeeId == employeeId)
                .ToListAsync();
            foreach (var account in employeeBankAccounts)
            {
                account.IsPrimary = account.Id == bankAccountId;
            }
            await _context.SaveChangesAsync();
        }
    }
}