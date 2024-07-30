using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author
    {
    [Key]
    public int id { get; set; }
    [Required]
    
    public string name { get; set; }

    // public ICollection<Book> Books { get; set; }
    }
}