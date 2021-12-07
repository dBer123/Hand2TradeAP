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
    class ProfileViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

      
        public List<PageItem> MenuItems { get; set; }

        public ProfileViewModel()
        {
            string icon1 = AppFonts.FontIconClass.Pencil;
            string icon2 = AppFonts.FontIconClass.PlusThick;
            string icon3 = AppFonts.FontIconClass.Heart;
            string icon4 = AppFonts.FontIconClass.Graph;
            string icon5 = AppFonts.FontIconClass.AccountCheck;
            string icon6 = AppFonts.FontIconClass.Logout;





            MenuItems = new List<PageItem>(new[]
               {
                    new PageItem { Id = 1, Title = "Edit Profile", Icon=icon1},
                    new PageItem { Id = 2, Title = "Add Item", Icon=icon2},
                    new PageItem { Id = 3, Title = "Liked Items", Icon=icon3},
                    new PageItem { Id = 4, Title = "Web Data", Icon=icon4},
                    new PageItem { Id = 5, Title = "Accounts", Icon=icon5},
                    new PageItem { Id = 6, Title = "Log Out", Icon=icon6}




                });
        }

        #region Events
        //Events
        public event Action<Page> NavigateToPageEvent;
        #endregion

        public ICommand SelctionChanged => new Command<Object>(OnSelectionChanged);
        public void OnSelectionChanged(Object obj)
        {
            if (obj is PageItem)
            {
                PageItem SelectedItem = (PageItem)obj;

                switch (SelectedItem.Id)
                {
                    case 1:
                        NavigateToPageEvent.Invoke( new EditProfile());
                        break;

                }

            }
        }

       
    }

   
}
