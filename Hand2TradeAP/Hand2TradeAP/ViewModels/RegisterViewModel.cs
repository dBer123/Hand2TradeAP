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
    class RegisterViewModel
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
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
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private int cvv;
        public int CVV
        {
            get { return cvv; }
            set
            {
                cvv = value;
                OnPropertyChanged("CVV");
            }
        }

        private int coins;
        public int Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                OnPropertyChanged("Coins");
            }
        }

        private int creditNum;
        public int CreditNum
        {
            get { return creditNum; }
            set
            {
                creditNum = value;
                OnPropertyChanged("CreditNum");
            }
        }
        
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private DateTime cardDate;
        public DateTime CardDate
        {
            get { return cardDate; }
            set
            {
                cardDate = value;
                OnPropertyChanged("CardDate");
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public RegisterViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }



        public async void OnSubmit()
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            User u= new User
            {
                Email=Email,
                Passwrd=Password,
                UserName=Username,
                Adress=Address,
                
            }

            bool isReturned = await proxy.RegisterUser(u);

            if (isReturned == false)
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");
               
            }
            else
            {
                App theApp = (App)Application.Current;
                Page p = new LogInPage();
                App.Current.MainPage = p;
            }
        }

        public ICommand NevigateToSignIn => new Command(ToSignIn);
        void ToSignIn()
        {

            Page p = new LogInPage();
            App.Current.MainPage = p;
        }
    }
}
