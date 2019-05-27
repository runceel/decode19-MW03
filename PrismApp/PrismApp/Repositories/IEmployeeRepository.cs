using PrismApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<Employee> GetEmployeeById(int id)
        {
            await Task.Delay(1000);
            return new Employee
            {
                Name = $"Tanaka Taro {id}",
            };
        }
    }
}
