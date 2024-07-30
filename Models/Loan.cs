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
        
        [Required]
        public int UserId { get; set; }
        
        public User? User { get; set; }
        
        [Required]
        public int BookId { get; set; }

        public Book? Book { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }
        
        public int? EmployessId { get; set; }
        
        public Employee? Employee { get; set; }

        public string? Status { get; set; }
        
        public DateTime? ReturnDate { get; set; }
    }
}