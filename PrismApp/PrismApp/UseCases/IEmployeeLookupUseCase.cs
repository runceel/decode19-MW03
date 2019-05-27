using Prism.Mvvm;
using PrismApp.Entities;
using PrismApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.UseCases
{
    public interface IEmployeeLookupUseCase : INotifyPropertyChanged
    {
        int TargetId { get; set; }
        Employee Employee { get; }
        Task LookupAsync();
    }

    public class EmployeeLookupUseCase : BindableBase, IEmployeeLookupUseCase
    {
        private int _targetId;
        public int TargetId
        {
            get { return _targetId; }
            set { SetProperty(ref _targetId, value); }
        }

        private Employee _employee;
        private readonly IEmployeeRepository _employeeRepository;

        public Employee Employee
        {
            get { return _employee; }
            private set { SetProperty(ref _employee, value); }
        }

        public EmployeeLookupUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task LookupAsync()
        {
            Employee = await _employeeRepository.GetEmployeeById(TargetId);
        }
    }
}
