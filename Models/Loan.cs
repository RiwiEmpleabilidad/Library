using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Loan
    {
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
      [Required]
    public User User { get; set; }
      [Required]
    public int BookId { get; set; }
      [Required]
    public Book Book { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    [Required]
    public string Status { get; set; }
    public DateTime? ReturnDate { get; set; }
        
    }
}