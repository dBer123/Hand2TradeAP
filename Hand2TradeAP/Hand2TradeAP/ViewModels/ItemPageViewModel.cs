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
    class ItemPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string price;
        public string Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        private string itemName;
        public string Itemname
        {
            get { return itemName; }
            set
            {
                itemName = value;
                OnPropertyChanged("Itemname");
            }
        }
        private User itemUser;
        public User ItemUser
        {
            get { return itemUser; }
            set
            {
                itemUser = value;
                OnPropertyChanged("ItemUser");
            }
        }

        private ImageSource itemImage;
        public ImageSource ItemImage
        {
            get { return itemImage; }
            set
            {
                itemImage = value;
                OnPropertyChanged("ItemImage");
            }
        }
        private int rate;
        public int Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }

        public ItemPageViewModel(Item item)
        {
            Price = item.Price.ToString();
            Description = item.Desrciption;
            Itemname = item.ItemName;
            ItemImage = item.ImgSource;
            ItemUser = item.User;
            Rate = item.User.SumRanks / item.User.CountRanked;


        }
    }
}
