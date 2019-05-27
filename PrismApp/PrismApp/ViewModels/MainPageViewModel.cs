using Prism.Commands;
using Prism.Navigation;
using PrismApp.UseCase;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PrismApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _input;
        public string Input
        {
            get { return _input; }
            set { SetProperty(ref _input, value); }
        }

        private string _output;
        public string Output
        {
            get { return _output; }
            set { SetProperty(ref _output, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private DelegateCommand _toUpperCommand;
        private readonly IToUpperUseCase _toUpperUseCase;

        public DelegateCommand ToUpperCommand =>
            _toUpperCommand ?? (_toUpperCommand = new DelegateCommand(ExecuteToUpperCommand, CanExecuteToUpperCommand)
                .ObservesProperty(() => Input)
                .ObservesProperty(() => IsBusy));

        private async void ExecuteToUpperCommand()
        {
            IsBusy = true;
            try
            {
                _toUpperUseCase.Input = Input;
                await _toUpperUseCase.ToUpperAsync();
                Output = _toUpperUseCase.Output;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteToUpperCommand() => !string.IsNullOrEmpty(Input) && !IsBusy;

        public MainPageViewModel(INavigationService navigationService, IToUpperUseCase toUpperUseCase)
            : base(navigationService)
        {
            Title = "Main Page";
            _toUpperUseCase = toUpperUseCase;
        }
    }
}
