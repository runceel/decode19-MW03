using Prism.Mvvm;
using PrismApp.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.UseCase
{
    public interface IToUpperUseCase
    {
        string Input { get; set; }
        string Output { get; set; }
        Task ToUpperAsync();
    }
    public class ToUpperUseCase : BindableBase, IToUpperUseCase
    {
        private readonly IToUpperRepository _toUpperRepository;

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

        public ToUpperUseCase(IToUpperRepository toUpperRepository)
        {
            _toUpperRepository = toUpperRepository;
        }

        public async Task ToUpperAsync()
        {
            Output = await _toUpperRepository.ToUpperAsync(Input);
        }
    }
}
