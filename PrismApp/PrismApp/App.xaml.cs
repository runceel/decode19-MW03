﻿using Prism;
using Prism.Ioc;
using PrismApp.Repositories;
using PrismApp.UseCases;
using PrismApp.ViewModels;
using PrismApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();

            containerRegistry.RegisterSingleton<IEmployeeLookupUseCase, EmployeeLookupUseCase>();
            containerRegistry.RegisterSingleton<IEmployeeRepository, EmployeeRepository>();
            containerRegistry.RegisterForNavigation<NextPage, NextPageViewModel>();
        }
    }
}
