using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Hand2TradeAP.ViewModels;

namespace Hand2TradeAP.Views
{
    public partial class PopUpAddImage : Popup
    {
        public PopUpAddImage(object context)
        {
            this.BindingContext = context;
            InitializeComponent();
           
        }

        private void PickImage(object sender, EventArgs e)
        {

            Dismiss("");
            
        }

        
    }
}