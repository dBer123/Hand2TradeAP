﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebDataTabs : ContentPage
    {
        public WebDataTabs()
        {
            InitializeComponent();
        }
        void MyTab_TabTapped(System.Object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
        }
    }
}