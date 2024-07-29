using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;

using Library.Models;

namespace Library.App.Services.Employers
{
    public class EmployersServices : IEmployersServices
    {
        public readonly BaseContext _context;
        public EmployersServices(BaseContext context){
            _context = context;
        }


        public void CreateEmployee(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployers()
        {
            return _context.employees.ToList();
        }

        public Employee GetEmployeeById(int Id)
        {
            return _context.employees.Find(Id);
        }

        public void UpdateEmployee(int Id, Employee employee)
        {
            _context.employees.Update(employee);
            _context.SaveChanges();
        }

        
    }

    public interface IEmployersServices
    {
        
    }
}