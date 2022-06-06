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
using System.Net.Mail;

namespace Hand2TradeAP.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
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
                ValidateEmail();
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
                ValidatePassword();
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
                ValidateUsername();
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
                ValidateAddress();
                OnPropertyChanged("Address");
            }
        }

      
        
        private DateTime birthDate;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                ValidateAge();
                OnPropertyChanged("BirthDate");
            }
        }

      
      

        private bool showPasswordError;

        public bool ShowPasswordError
        {
            get => showPasswordError;
            set
            {
                showPasswordError = value;
                OnPropertyChanged("ShowPasswordError");
            }
        }

        private string passwordError;

        public string PasswordError
        {
            get => passwordError;
            set
            {
                passwordError = value;
                OnPropertyChanged("PasswordError");
            }
        }
        private void ValidatePassword()
        {
            ShowPasswordError = true;
            if (string.IsNullOrEmpty(Password))
                PasswordError = "Password cannot be blank";
            else if (Password.Length < 8)
                PasswordError = "Password must be more than 8 characters";
            else
                ShowPasswordError = false;
        }

        private bool showEmailError;

        public bool ShowEmailError
        {
            get => showEmailError;
            set
            {
                showEmailError = value;
                OnPropertyChanged("ShowEmailError");
            }
        }

        private string emailError;

        public string EmailError
        {
            get => emailError;
            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }
        }
        private void ValidateEmail()
        {
            ShowEmailError = true;
            if (!IsValid(Email))
                EmailError = "Email is not valid";
           
            else
                ShowEmailError = false;
        }
        public bool IsValid(string emailaddress)
        {
            if (string.IsNullOrEmpty(emailaddress)) return false;
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private bool showUsernameError;

        public bool ShowUsernameError
        {
            get => showUsernameError;
            set
            {
                showUsernameError = value;
                OnPropertyChanged("ShowUsernameError");
            }
        }

        private string usernameError;

        public string UsernameError
        {
            get => usernameError;
            set
            {
                usernameError = value;
                OnPropertyChanged("UsernameError");
            }
        }

        private void ValidateUsername()
        {
            ShowUsernameError = false;


            if (string.IsNullOrEmpty(Username))
            {
                UsernameError = "Username cannot be blank";
                ShowUsernameError = true;
            }
            else if (Username.Length > 10)
            {
                UsernameError = "Username is too long";
                ShowUsernameError = true;
            }
        }

        private bool showAddressError;

        public bool ShowAddressError
        {
            get => showAddressError;
            set
            {
                showAddressError = value;
                OnPropertyChanged("ShowAddressError");
            }
        }

        private string addressError;

        public string AddressError
        {
            get => addressError;
            set
            {
                addressError = value;
                OnPropertyChanged("AddressError");
            }
        }

        private void ValidateAddress()
        {
            ShowAddressError = false;


            if (string.IsNullOrEmpty(Address))
            {
                AddressError = "Address cannot be blank";
                ShowAddressError = true;
            }
        }

        private bool showAgeError;

        public bool ShowAgeError
        {
            get => showAgeError;
            set
            {
                showAgeError = value;
                OnPropertyChanged("ShowAgeError");
            }
        }
        private string ageError;

        public string AgeError
        {
            get => ageError;
            set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }
        private void ValidateAge()
        {
            ShowAgeError = true;
            if (DateTime.Now.Year-BirthDate.Year < 13)
                AgeError = "You must be older than 13 to sign up";
           
            else
                ShowAgeError = false;
        }


        private bool showGeneralError;

        public bool ShowGeneralError
        {
            get => showGeneralError;
            set
            {
                showGeneralError = value;
                OnPropertyChanged("ShowGeneralError");
            }
        }


        private bool ValidateForm()
        {
 
            ValidatePassword();
            ValidateUsername();
            ValidateAge();
            ValidateEmail();
            ValidateAddress(); 

            return !(ShowPasswordError || ShowUsernameError || ShowAgeError || ShowEmailError || ShowAddressError);
        }
        public ICommand SubmitCommand { protected set; get; }

        public RegisterViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            BirthDate=DateTime.Today.AddYears(-13);     
        }



        public async void OnSubmit()
        {
            if (ValidateForm())
            {
                Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                User u = new User
                {
                    Email = Email,
                    Passwrd = Password,
                    UserName = Username,
                    Adress = Address,
                    Coins = 500,
                    BirthDate = BirthDate,
                    IsAdmin = false,
                    IsBlocked = true,
                };

                bool isReturned = await proxy.RegisterUser(u);

                if (isReturned == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Invalid input", "OK");

                }
                else
                {
                    App theApp = (App)Application.Current;
                    Page p = new CheckEmailPage();
                    App.Current.MainPage = p;
                }
            }
        }
           

        public ICommand NevigateToSignIn => new Command(ToSignIn);
        async void ToSignIn()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
