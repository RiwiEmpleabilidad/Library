using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class History
    {
    public int Id { get; set; }
    public int LoanId { get; set; }
    public Loan Loan { get; set; }
        
    }
}