using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismApp.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismApp.ViewModels
{
    public class NextPageViewModel : ViewModelBase
    {
        private readonly IToUpperUseCase _toUpperUseCase;
        public IToUpperUseCase ToUpperUseCase => _toUpperUseCase;

        private string _parameter;
        public string Parameter
        {
            get { return _parameter; }
            set { SetProperty(ref _parameter, value); }
        }

        public NextPageViewModel(INavigationService navigationService, IToUpperUseCase toUpperUseCase) : base(navigationService)
        {
            _toUpperUseCase = toUpperUseCase;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Parameter = parameters.GetValue<string>(KnownNavigationParameters.XamlParam);
        }
    }
}
