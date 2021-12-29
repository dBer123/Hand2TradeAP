﻿using System;
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

        private string coins;
        public string Coins
        {
            get { return coins; }
            set
            {
                coins = value;
                OnPropertyChanged("Coins");
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

        private double rating;
        public double Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
            }
        }

        public ObservableCollection<string> Stars { get; set; }
        public List<PageItem> MenuItems { get; set; }

        public ProfileViewModel()
        {
            App theApp = (App)Application.Current;
            Email = theApp.CurrentUser.Email;
            Coins = theApp.CurrentUser.Coins.ToString();
            Address = theApp.CurrentUser.Adress;
            Username = theApp.CurrentUser.UserName;
            int sum = theApp.CurrentUser.SumRanks;
            int count = theApp.CurrentUser.CountRanked;            
            if (sum != 0)
            {
                Rating = sum / count;
                double num = (double)sum / count - Rating;
                if (num > 0.5) Rating += 1;
            }
            




            string icon1 = AppFonts.FontIconClass.Pencil;
            string icon2 = AppFonts.FontIconClass.PlusThick;
            string icon3 = AppFonts.FontIconClass.Heart;
            string icon4 = AppFonts.FontIconClass.Graph;
            string icon5 = AppFonts.FontIconClass.AccountCheck;
            string icon6 = AppFonts.FontIconClass.Logout;

            Stars = new ObservableCollection<string>();
            double count2 = Rating;
            for (int i = 0; i <= 5; i++)

            {
                if (count2 >= 0.75)
                    Stars.Add(AppFonts.FontIconClass.Star);
                else if(count2 > 0.25 && count2 < 0.75)
                    Stars.Add(AppFonts.FontIconClass.StarHalfFull);
                else Stars.Add(AppFonts.FontIconClass.StarOutline);
                count2--;
            }


            if (theApp.CurrentUser.IsAdmin)
            {

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
            else
            {

                MenuItems = new List<PageItem>(new[]
                   {
                    new PageItem { Id = 1, Title = "Edit Profile", Icon=icon1},
                    new PageItem { Id = 2, Title = "Add Item", Icon=icon2},
                    new PageItem { Id = 3, Title = "Liked Items", Icon=icon3},
                    new PageItem { Id = 6, Title = "Log Out", Icon=icon6}

                });
        }

    }

       

        public ICommand SelctionChanged => new Command<Object>(OnSelectionChanged);
        public void OnSelectionChanged(Object obj)
        {
            if (obj is PageItem)
            {
                PageItem SelectedItem = (PageItem)obj;

                switch (SelectedItem.Id)
                {
                    case 1:
                        Page p1 = new EditProfile();
                        App.Current.MainPage = p1;
                        break;
                    case 2:
                        Page p2 = new AddItem();
                        App.Current.MainPage = p2;
                        break;
                    case 3:
                        Page p3 = new LikedItems();
                        App.Current.MainPage = p3;
                        break;
                    case 4:
                        Page p4 = new WebData();
                        App.Current.MainPage = p4;
                        break;
                    case 5:
                        Page p5 = new Accounts();
                        App.Current.MainPage = p5;
                        break;
                    case 6:
                        App theApp = (App)Application.Current;
                        theApp.CurrentUser = null;
                        Page p6 = new LogInPage();
                        App.Current.MainPage = p6;
                        break;
                }

            }
        }

       
    }

    public class PageItem
    {
        public PageItem()
        {
            
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }


}