using System.Collections.Generic;
using System.Threading.Tasks;
using Library.App.Interfaces.Loans;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LoanController : ControllerBase
    {
        private readonly ILoanServices _loanServices;

        public LoanController(ILoanServices loanServices)
        {
            _loanServices = loanServices;
        }

        [HttpGet]
        [Route("loans")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetAllLoans()
        {
            var loans = await _loanServices.GetAllLoansAsync();
            return Ok(loans);
        }
    }
}