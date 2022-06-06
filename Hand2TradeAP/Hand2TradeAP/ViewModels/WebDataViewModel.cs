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
        public ICollection<DailyReport> dailyReports { get; set; }
        public ICollection<MonthlyReport> monthlyReports { get; set; }

        public WebDataViewModel()
        {
            dailyReports = new List<DailyReport>()
            {
                new DailyReport{ DayTime=DateTime.Today, ItemsDraded=1, NewSubs=2,ReportsNum=0},
                new DailyReport{ DayTime=DateTime.Today.AddDays(-1), ItemsDraded=3, NewSubs=2,ReportsNum=6},
                new DailyReport{ DayTime=DateTime.Today.AddDays(-2), ItemsDraded=3, NewSubs=2,ReportsNum=6},
                new DailyReport{ DayTime=DateTime.Today.AddDays(-3), ItemsDraded=3, NewSubs=2,ReportsNum=6},
                new DailyReport{ DayTime=DateTime.Today.AddDays(-4), ItemsDraded=1, NewSubs=1,ReportsNum=2},
                new DailyReport{ DayTime=DateTime.Today.AddDays(-5), ItemsDraded=5, NewSubs=5,ReportsNum=5},
                new DailyReport{ DayTime=DateTime.Today.AddDays(-6), ItemsDraded=0, NewSubs=4,ReportsNum=6}
            };


            monthlyReports = new List<MonthlyReport>();
            monthlyReports = new List<MonthlyReport>()
            {
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5), ItemsTraded=41, NewSubs=32,ReportsNum=30},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-1), ItemsTraded=3, NewSubs=2,ReportsNum=6},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-2), ItemsTraded=33, NewSubs=22,ReportsNum=33},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-3), ItemsTraded=31, NewSubs=12,ReportsNum=16},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-4), ItemsTraded=14, NewSubs=11,ReportsNum=22},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-5), ItemsTraded=15, NewSubs=35,ReportsNum=25},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-6), ItemsTraded=30, NewSubs=24,ReportsNum=16},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-7), ItemsTraded=19, NewSubs=8,ReportsNum=20},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-8), ItemsTraded=15, NewSubs=17,ReportsNum=12},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-9), ItemsTraded=9, NewSubs=11,ReportsNum=10},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-10), ItemsTraded=3, NewSubs=4,ReportsNum=6},
                new MonthlyReport{ DateOfMonth=DateTime.Today.AddDays(-5).AddMonths(-11), ItemsTraded=12, NewSubs=8,ReportsNum=5}


            };
            Data = new List<Person>()
            {
                new Person { Name = "David", Height = 180, Weight=62,Age=56 },
                new Person { Name = "Michael", Height = 170,Weight=60, Age=40},
                new Person { Name = "Steve", Height = 160,Weight=70, Age=210},
                new Person { Name = "Joel", Height = 182, Weight=88,Age=22}
            };
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
    public class Person
    {
        public string Name { get; set; }

        public double Height { get; set; }
        public double Weight { get; set; }
        public double Age { get; set; }

    }
}
