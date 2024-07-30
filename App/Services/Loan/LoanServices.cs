using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Loans;
using Library.Data;
using Library.Models;

namespace Library.App.Services.Loans
{
    public class LoanServices : ILoanServices
    {
        private readonly BaseContext _context;
        
        public LoanServices(BaseContext context)
        {
            _context = context;
        }

        public async Task AddLoan(Loan loan)
        {
            loan.Status = "en espera";
            _context.loans.Add(loan);
            await _context.SaveChangesAsync();
        }
    }
}