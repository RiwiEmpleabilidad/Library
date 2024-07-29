using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class  BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options){

        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<User> users { get; set; }
}}