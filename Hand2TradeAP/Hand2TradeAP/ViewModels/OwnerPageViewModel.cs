using System;
using System.Collections;
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
using Hand2TradeAP.AppFonts;
using System.Collections.ObjectModel;

namespace Hand2TradeAP.ViewModels
{
    class OwnerPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string isAdmin;
        public string IsAdmin
        {
            get { return isAdmin; }
            set
            {
                isAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }
        private User owner;
        public User Owner
        {
            get { return owner; }
            set
            {
                owner = value;
                OnPropertyChanged("Owner");
            }
        }
        private double userRate;
        public double UserRate
        {
            get { return userRate; }
            set
            {
                userRate = value;
                OnPropertyChanged("UserRate");
            }
        }
        private double rated;
        public double Rated
        {
            get { return rated; }
            set
            {
                rated = value;
                OnPropertyChanged("Rated");
                RateUser(Rated);
            }
        }
        public OwnerPageViewModel(User user)
        {
            Owner = user;
            if (user.IsAdmin)
                IsAdmin = AppFonts.FontIconClass.CheckCircle;
            if (user.CountRanked != 0)
                UserRate = user.SumRanks / user.CountRanked;
            else
                UserRate = 0;
            Rated = 0;
    
        }
        public async void RateUser(double rate)
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            bool found = await proxy.Rate(Owner.UserId, rate);
            if (!found)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again later", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(null, "The report successfuly received", "OK");
            }
        }
        public ICommand Report => new Command(ReportUser);
        public async void ReportUser()
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            bool found = await proxy.Report(Owner.UserId);
            if (!found)
            {
                await App.Current.MainPage.DisplayAlert(null, "You have already reported this user", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(null, "The report successfuly received", "OK");
            }
        }
    }
}
