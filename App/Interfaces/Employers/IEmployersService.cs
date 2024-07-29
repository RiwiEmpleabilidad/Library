using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.App.Interfaces.Employers
{
    public interface IEmployersService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int Id, Employee employee);
        //void DeleteEmployee (int Id);
    }
}