using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.App.Interfaces.Loans;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers.Loans
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanServices _loansService;

        public LoansController(ILoanServices loansService)
        {
            _loansService = loansService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Loan loan)
        {
            await _loansService.AddLoan(loan);
            return Ok(loan);
        }

        [HttpGet]
        public IEnumerable<Loan> GetAllLoans()
        {
            return _loansService.GetLoans();
        }
    }
}