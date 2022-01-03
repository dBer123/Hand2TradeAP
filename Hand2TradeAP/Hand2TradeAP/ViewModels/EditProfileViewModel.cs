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
using Hand2TradeAP.AppFonts;
using System.Collections.ObjectModel;

namespace Hand2TradeAP.ViewModels
{
    class EditProfileViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Password 
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
        #endregion
        #region UserName
        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                ValidateUsername();
                OnPropertyChanged("UserName");
            }
        }
        private bool showUsernameError;
        public bool ShowUserNameError
        {
            get => showUsernameError;
            set
            {
                showUsernameError = value;
                OnPropertyChanged("ShowUserNameError");
            }
        }

        private string usernameError;

        public string UserNameError
        {
            get => usernameError;
            set
            {
                usernameError = value;
                OnPropertyChanged("UserNameError");
            }
        }

        private void ValidateUsername()
        {
            ShowUserNameError = false;


            if (string.IsNullOrEmpty(UserName))
            {
                UserNameError = "Username cannot be blank";
                ShowUserNameError = true;
            }
        }
        #endregion
        #region Adress
        #endregion

        private string adress;
        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                ValidateAdress();
                OnPropertyChanged("Adress");
            }
        }
        private bool showAdressError;

        public bool ShowAdressError
        {
            get => showAdressError;
            set
            {
                showAdressError = value;
                OnPropertyChanged("ShowAdressError");
            }
        }

        private string adressError;

        public string AdressError
        {
            get => adressError;
            set
            {
                adressError = value;
                OnPropertyChanged("AdressError");
            }
        }

        private void ValidateAdress()
        {
            ShowAdressError = false;


            if (string.IsNullOrEmpty(Adress))
            {
                AdressError = "Address cannot be blank";
                ShowAdressError = true;
            }
        }

        public ICommand NevigateBack => new Command(Back);
        void Back()
        {
            Page p = new Tabs();
            App.Current.MainPage = p;
        }
        FileResult imageFileResult;
        public event Action<ImageSource> SetImageSourceEvent;
        public ICommand PickImageCommand => new Command(OnPickImage);
        public async void OnPickImage()
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions()
                {
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    ImageSource imgSource = ImageSource.FromStream(() => stream);
                    if (SetImageSourceEvent != null)
                        SetImageSourceEvent(imgSource);
                }

            }
            catch { }

        }

        ///The following command handle the take photo button
        public ICommand CameraImageCommand => new Command(OnCameraImage);
        public async void OnCameraImage()
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    ImageSource imgSource = ImageSource.FromStream(() => stream);
                    if (SetImageSourceEvent != null)
                        SetImageSourceEvent(imgSource);
                }
            }
            catch { }

        }
    }
}
