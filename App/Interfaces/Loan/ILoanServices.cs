
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;

namespace Library.App.Interfaces.Loans
{
    public interface ILoanServices
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
    }
}