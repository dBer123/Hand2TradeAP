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
    class EditProfileViewModel : INotifyPropertyChanged, IImageSourceUpdatable
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
     
        public async void UpdateImageSource(string imgSource)
        {
            this.imageFileResult = new FileResult(imgSource);
            var stream = await imageFileResult.OpenReadAsync();
            ImageSource source = ImageSource.FromStream(() => stream);
            if (this.SetImageSourceEvent != null)
                this.SetImageSourceEvent(source);
        }
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
        async void Back()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
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
                    this.imageFileResult = result;
                    await App.Current.MainPage.Navigation.PushModalAsync(new CropImage(this));
                    //if (SetImageSourceEvent != null)
                    //    SetImageSourceEvent(imgSource);
                }

            }
            catch { }

        }
        public string ImgSource
        {
            get
            {
                if (this.imageFileResult != null)
                    return this.imageFileResult.FullPath;
                else
                    return string.Empty;
            }

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
                    this.imageFileResult = result;
                    await App.Current.MainPage.Navigation.PushModalAsync(new CropImage(this));
                    //if (SetImageSourceEvent != null)
                    //    SetImageSourceEvent(result.FullPath);
                }
            }
            catch { }

        }

        private bool ValidateForm()
        {
            //Validate all fields first
            ValidateAdress();
            ValidatePassword();
            ValidateUsername();

            //check if any validation failed
            if (ShowAdressError ||
                ShowPasswordError || ShowUserNameError)
                return false;
            return true;
        }

        public ICommand Update => new Command(SaveData);
        public async void SaveData()
        {
            if (ValidateForm())
            {
                App theApp = (App)Application.Current;
                User u = new User
                {
                    UserId = theApp.CurrentUser.UserId,
                    Passwrd = Password,
                    Adress = adress,
                    UserName = UserName
                };
                Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                User user = await proxy.UpdateUser(u);
                if (user == null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Can not Update your user", "OK");
                }
                else
                {

                    if (this.imageFileResult != null)
                    {


                        bool success = await proxy.UploadImage(new FileInfo()
                        {
                            Name = this.imageFileResult.FullPath
                        }, $"U{user.UserId}.jpg");
                    }
                    theApp.CurrentUser = user;
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
        }

        public EditProfileViewModel()
        {
            App theApp = (App)Application.Current;
            Adress = theApp.CurrentUser.Adress;
            UserName = theApp.CurrentUser.UserName;
            Password = theApp.CurrentUser.Passwrd;
        }

    }


}
