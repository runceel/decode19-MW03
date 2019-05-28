using System;
using System.ComponentModel;
using Prism.Commands;
using Prism.Navigation;
using PrismApp.Entities;
using PrismApp.UseCases;

namespace PrismApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DelegateCommand _lookupEmployeeCommand;
        public DelegateCommand LookupEmployeeCommand =>
            _lookupEmployeeCommand ?? (_lookupEmployeeCommand = new DelegateCommand(ExecuteLookupEmployeeCommand, CanExecuteLookupEmployeeCommand)
                .ObservesProperty(() => TargetEmployeeId));

        private bool CanExecuteLookupEmployeeCommand()
        {
            return int.TryParse(TargetEmployeeId, out var _);
        }

        private async void ExecuteLookupEmployeeCommand()
        {
            EmployeeLookupUseCase.TargetId = int.Parse(TargetEmployeeId);
            await EmployeeLookupUseCase.LookupAsync();
            Employee = EmployeeLookupUseCase.Employee;
        }

        private DelegateCommand _navigateToNextPageCommand;
        public DelegateCommand NavigateToNextPageCommand =>
            _navigateToNextPageCommand ?? (_navigateToNextPageCommand = new DelegateCommand(ExecuteNavigateToNextPageCommand, CanExecuteNavigateToNextPageCommand)
                .ObservesProperty(() => Employee));

        private async void ExecuteNavigateToNextPageCommand()
        {
            await NavigationService.NavigateAsync("NextPage", new NavigationParameters
            {
                { "id", Employee.Id },
            });
        }

        private bool CanExecuteNavigateToNextPageCommand() => Employee != null;

        public MainPageViewModel(INavigationService navigationService, IEmployeeLookupUseCase employeeLookupUseCase)
            : base(navigationService)
        {
            Title = "Main Page";
            EmployeeLookupUseCase = employeeLookupUseCase;
        }

        public IEmployeeLookupUseCase EmployeeLookupUseCase { get; }

        private string _targetEmployeeId;
        public string TargetEmployeeId
        {
            get { return _targetEmployeeId; }
            set { SetProperty(ref _targetEmployeeId, value); }
        }

        private Employee _employee;
        public Employee Employee
        {
            get { return _employee; }
            private set { SetProperty(ref _employee, value); }
        }
    }
}
