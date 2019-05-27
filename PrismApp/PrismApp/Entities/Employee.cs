using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismApp.Entities
{
    public class Employee : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
