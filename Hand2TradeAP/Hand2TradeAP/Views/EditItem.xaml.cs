using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hand2TradeAP.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using Hand2TradeAP.AppFonts;
using Syncfusion.XForms.TextInputLayout;
using Hand2TradeAP.Views;


namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItem : ContentPage
    {
        public EditItem()
        {
            AddItemViewModel context = new AddItemViewModel();
            this.BindingContext = context;
            context.SetImageSourceEvent += OnSetImageSource;
            InitializeComponent();
            itemImage.Source = "defaultItemImage.jpg";
        }

        private void ToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopUpAddImage(this.BindingContext));


        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            itemImage.Source = imgSource;
        }

        private void Label1_Focused(object sender, FocusEventArgs e)
        {
            Color color = Color.FromRgb(0, 179, 77);
            entry1.TextColor = color;
            icon1.TextColor = color;
        }
        private void Label2_Focused(object sender, FocusEventArgs e)
        {
            Color color = Color.FromRgb(0, 179, 77);
            entry2.TextColor = color;
            icon2.TextColor = color;
        }
        private void Label3_Focused(object sender, FocusEventArgs e)
        {
            Color color = Color.FromRgb(0, 179, 77);
            entry3.TextColor = color;
            icon3.TextColor = color;
        }

        private void entry1_Unfocused(object sender, FocusEventArgs e)
        {
            entry1.TextColor = default;
            icon1.TextColor = default;
        }
        private void entry2_Unfocused(object sender, FocusEventArgs e)
        {
            entry2.TextColor = default;
            icon2.TextColor = default;
        }
        private void entry3_Unfocused(object sender, FocusEventArgs e)
        {
            entry3.TextColor = default;
            icon3.TextColor = default;
        }
    }
}