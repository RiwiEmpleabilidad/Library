
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Loans;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.App.Services.Loans
{
    public class LoanServices : ILoanServices
    {
        private readonly DbContext _context;

        public LoanServices(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            return await _context.Set<Loan>().ToListAsync();
        }

        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            return await _context.Set<Loan>().FindAsync(id);
        }
    }
}