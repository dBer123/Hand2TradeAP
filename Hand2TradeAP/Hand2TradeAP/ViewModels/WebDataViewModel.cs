using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Hand2TradeAP.Services;
using Hand2TradeAP.Views;
using Hand2TradeAP.Models;
using Xamarin.Essentials;
using System.Linq;
using System.Collections.ObjectModel;

namespace Hand2TradeAP.ViewModels
{
    internal class WebDataViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    
        public List<Person> Data { get; set; }

        public WebDataViewModel()
        {
            Data = new List<Person>()
            {
                new Person { Name = "David", Height = 180, Weight=62,Age=56 },
                new Person { Name = "Michael", Height = 170,Weight=60, Age=40},
                new Person { Name = "Steve", Height = 160,Weight=70, Age=210},
                new Person { Name = "Joel", Height = 182, Weight=88,Age=22}
            };
        }
    }
    public class Person
    {
        public string Name { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }
        public double Age { get; set; }

    }
}
