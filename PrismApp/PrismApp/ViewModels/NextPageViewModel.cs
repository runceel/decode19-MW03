using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismApp.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismApp.ViewModels
{
    public class NextPageViewModel : ViewModelBase
    {
        public NextPageViewModel(INavigationService navigationService, IEmployeeLookupUseCase employeeLookupUseCase) : base(navigationService)
        {
            EmployeeLookupUseCase = employeeLookupUseCase;
        }

        public IEmployeeLookupUseCase EmployeeLookupUseCase { get; }
    }
}
