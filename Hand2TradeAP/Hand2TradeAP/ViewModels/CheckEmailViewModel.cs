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

namespace Hand2TradeAP.ViewModels
{
    class CheckEmailViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public CheckEmailViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        public ICommand SubmitCommand { protected set; get; }
        public async void OnSubmit()
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            bool isValid = await proxy.CheckEmailAsync(Password);
            if (isValid == false)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Wrong password, please check your email and try again", "OK");
            }
            else
            {

                App theApp = (App)Application.Current;
                Page p = new LogInPage();
                App.Current.MainPage = p;



            }
        }


        public ICommand NevigateToSignUn => new Command(ToSignUp);
        void ToSignUp()
        {

            Page p = new RegisterPage();
            App.Current.MainPage = p;
        }
    }
}
