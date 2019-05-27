using System;
using Prism.Commands;
using Prism.Navigation;
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

        public async void ExecuteLookupEmployeeCommand()
        {
            EmployeeLookupUseCase.TargetId = int.Parse(TargetEmployeeId);
            await EmployeeLookupUseCase.LookupAsync();
        }

        public MainPageViewModel(INavigationService navigationService, IEmployeeLookupUseCase employeeLookupUseCase)
            : base(navigationService)
        {
            Title = "Main Page";
            EmployeeLookupUseCase = employeeLookupUseCase;
            CanNavigateToNextPage = EmployeeLookupUseCase.Employee != null;
        }

        public IEmployeeLookupUseCase EmployeeLookupUseCase { get; }

        private string _targetEmployeeId;
        public string TargetEmployeeId
        {
            get { return _targetEmployeeId; }
            set { SetProperty(ref _targetEmployeeId, value); }
        }

        private bool _canNavigateToNextPage;
        public bool CanNavigateToNextPage
        {
            get { return _canNavigateToNextPage; }
            set { SetProperty(ref _canNavigateToNextPage, value); }
        }
    }
}
