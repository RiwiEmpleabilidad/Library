using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
      
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime PublicationDate { get; set; }

    public int GenderId { get; set; }
    public Gender Gender { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }

    [Required]
    public int TotalCopias { get; set; }
    [Required]
    public int CopiasAvailable { get; set; }
    [Required]
    public string Status { get; set; }

    public ICollection<Loan> Loans { get; set; }


        
    }
}