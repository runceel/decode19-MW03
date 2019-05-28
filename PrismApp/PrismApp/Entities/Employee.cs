using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismApp.Entities
{
    public class Employee : BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
    }
}
