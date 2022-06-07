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
    
        public ObservableCollection<DailyReport> dailyReports { get; set; }
        public ObservableCollection<MonthlyReport> monthlyReports { get; set; }

        public WebDataViewModel()
        {
            dailyReports = new ObservableCollection<DailyReport>();
            monthlyReports = new ObservableCollection<MonthlyReport>();
            GetReports();
        }
        public async void GetReports()
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            List<DailyReport> hr = await proxy.GetDailyReport();
            List<MonthlyReport> mr = await proxy.GetMonthlyReport();
            foreach (var dailyReport in hr)
            {
                dailyReports.Add(dailyReport);
            }
            foreach (var monthlyReport in mr)
            {
                monthlyReports.Add(monthlyReport);
            }
        }
       
    }
  
}
