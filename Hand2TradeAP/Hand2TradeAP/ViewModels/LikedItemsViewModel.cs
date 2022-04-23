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
    internal class LikedItemsViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ObservableCollection<Item> SearchedItems { get; set; }
       
        public ICommand Choose => new Command<Object>(ChooseAction);
        public async void ChooseAction(Object obj)
        {
            string s = await App.Current.MainPage.DisplayActionSheet("Item Actions:", null, "CANCEL", "Explore Item", "UnLike Item");
            if (s == "Explore Item")
                ExploreItem(obj);
            else if (s == "UnLike Item") UnLikeItem(obj);
        }
        public async void UnLikeItem(Object obj)
        {
            if (obj is Item)
            {
                Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                Item item = (Item)obj;
                bool found = await proxy.UnLike(item.ItemId);
                if (!found)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Can not Unlike Item", "OK");
                }
            }            
        }
        public async void ExploreItem(Object obj)
        {
            if (obj is Item)
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ItemPage((Item)obj));
            }
        }
    }
}
