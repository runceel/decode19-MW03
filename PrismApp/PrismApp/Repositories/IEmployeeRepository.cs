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
            if (id == 0)
            {
                return null;
            }

            return new Employee
            {
                Id = id,
                Name = $"Tanaka Taro {id}",
            };
        }
    }
}
