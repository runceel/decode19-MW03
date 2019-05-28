using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Mvvm;
using Prism.Navigation;
using PrismApp.Entities;
using PrismApp.UseCases;
using PrismApp.ViewModels;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PrismApp.Test.ViewModels
{
    [TestClass]
    public class MainPageViewModelTest
    {
        [TestMethod]
        public void EnableCase()
        {
            var empMock = new Mock<IEmployeeLookupUseCase>();
            var navMock = new Mock<INavigationService>();
            empMock.SetupSet(x => x.TargetId = 10).Verifiable();
            empMock.Setup(x => x.LookupAsync()).Returns(Task.CompletedTask).Verifiable();
            empMock.Setup(x => x.Employee).Returns(new Employee { Id = 10, Name = "Tanaka" });

            var vm = new MainPageViewModel(navMock.Object, empMock.Object);
            Assert.IsFalse(vm.LookupEmployeeCommand.CanExecute());
            vm.TargetEmployeeId = "10";
            Assert.IsTrue(vm.LookupEmployeeCommand.CanExecute());
            vm.LookupEmployeeCommand.Execute();
            empMock.Verify();
            Assert.IsTrue(vm.NavigateToNextPageCommand.CanExecute());
        }

        [TestMethod]
        public void DisableCase()
        {
            var empMock = new Mock<IEmployeeLookupUseCase>();
            var navMock = new Mock<INavigationService>();
            empMock.SetupSet(x => x.TargetId = 10).Verifiable();
            empMock.Setup(x => x.LookupAsync()).Returns(Task.CompletedTask).Verifiable();
            empMock.Setup(x => x.Employee).Returns<Employee>(null);

            var vm = new MainPageViewModel(navMock.Object, empMock.Object);
            Assert.IsFalse(vm.LookupEmployeeCommand.CanExecute());
            vm.TargetEmployeeId = "10";
            Assert.IsTrue(vm.LookupEmployeeCommand.CanExecute());
            vm.LookupEmployeeCommand.Execute();
            empMock.Verify();
            Assert.IsFalse(vm.NavigateToNextPageCommand.CanExecute());
        }
    }
}
