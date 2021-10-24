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
       


        public ICommand NevigateToSignIn => new Command(ToSignIn);
        void ToSignIn()
        {

            Page p = new LogInPage();
            App.Current.MainPage = p;
        }
    }
}
