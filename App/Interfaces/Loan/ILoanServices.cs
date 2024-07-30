using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.App.Interfaces.Loans
{
    public interface ILoanServices
    {
        Task AddLoan(Loan loan);

        IEnumerable<Loan> GetLoans();
    }
}