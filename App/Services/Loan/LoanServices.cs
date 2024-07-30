using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Loans;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

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
            loan.Status = "active";
            _context.loans.Add(loan);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Loan> GetLoans()
        {
            return _context.loans.Where(l => l.Status == "active").Include(l => l.Book).Include(l => l.Employee).Include(l => l.User).Include(l => l.Book.Gender).Include(l => l.Book.Author).ToList();
        }
    }
}