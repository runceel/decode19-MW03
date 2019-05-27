using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Navigation;
using PrismApp.UseCase;
using PrismApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Tests.ViewModels
{
    [TestClass]
    public class MainPageViewModelTest
    {
        [TestMethod]
        public void CanNotExecuteTest()
        {
            var mock = new ToUpperUseCaseMock { Output = "output value" };
            var vm = new MainPageViewModel(new NavigationServiceMock(), mock);
            Assert.IsFalse(vm.ToUpperCommand.CanExecute());
        }

        [TestMethod]
        public void CanExecuteTest()
        {
            var mock = new ToUpperUseCaseMock { Output = "output value" };
            var vm = new MainPageViewModel(new NavigationServiceMock(), mock);
            vm.Input = "xxx";
            Assert.IsTrue(vm.ToUpperCommand.CanExecute());
        }

        [TestMethod]
        public void ToUpperTest()
        {
            var mock = new ToUpperUseCaseMock { Output = "output value" };
            var vm = new MainPageViewModel(new NavigationServiceMock(), mock);
            vm.Input = "input";
            vm.ToUpperCommand.Execute();
            Assert.AreEqual("input", mock.Input);
            Assert.AreEqual("output value", vm.Output);
            Assert.IsTrue(mock.ToUpperAsyncInvoked);
        }
    }

    class NavigationServiceMock : INavigationService
    {
        public Task<INavigationResult> GoBackAsync()
        {
            throw new NotImplementedException();
        }

        public Task<INavigationResult> GoBackAsync(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<INavigationResult> NavigateAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task<INavigationResult> NavigateAsync(Uri uri, INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<INavigationResult> NavigateAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<INavigationResult> NavigateAsync(string name, INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }

    class ToUpperUseCaseMock : IToUpperUseCase
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public bool ToUpperAsyncInvoked { get; private set; }

        public Task ToUpperAsync()
        {
            ToUpperAsyncInvoked = true;
            return Task.CompletedTask;
        }
    }
}
