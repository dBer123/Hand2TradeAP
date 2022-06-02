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
using Syncfusion.XForms.Cards;


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
        public ObservableCollection<Item> LikedItems { get; set; }
        public LikedItemsViewModel()
        {
            LikedItems = new ObservableCollection<Item>();
            GetLikedItems();
        }
        public async void GetLikedItems()
        {
            Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
            List<Item> items = await proxy.GetLikedItems();
            LikedItems.Clear();
            foreach (var Item in items)
            {
                LikedItems.Add(Item);
            }
        }
        public ICommand NevigateBack => new Command(Back);
        async void Back()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

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
            if (obj is SfCardLayout)
            {
                Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                Item item = LikedItems[((SfCardLayout)obj).VisibleCardIndex];
                bool found = await proxy.UnLike(item.ItemId);
                if (!found)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Can not Unlike Item", "OK");
                }
                else
                {
                    LikedItems.Remove(item);
                }
            }            
        }
        public async void ExploreItem(Object obj)
        {
            if (obj is SfCardLayout)
            {
                Item item = LikedItems[((SfCardLayout)obj).VisibleCardIndex];
                await App.Current.MainPage.Navigation.PushModalAsync(new ItemPage(item));
            }
        }
    }
}
