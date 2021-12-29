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
    public partial class AddItem : ContentPage
    {
        public AddItem()
        {
            AddItemViewModel context = new AddItemViewModel();
            this.BindingContext = context;
            context.SetImageSourceEvent += OnSetImageSource;
            InitializeComponent();
            itemImage.Source = "itemDefault.png";
        }

        private void ToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopUpAddImage(this.BindingContext));
           

        }
        //private async void PickImage(object sender, EventArgs e)
        //{
        //    var pickImage = await FilePicker.PickAsync(new PickOptions()
        //    {
        //       FileTypes=FilePickerFileType.Images
        //    });

        //    if (pickImage != null)
        //    {
        //        var stream = await pickImage.OpenReadAsync();
        //        itemImage.Source = ImageSource.FromStream(() => stream);

        //    }
        //}

        public void OnSetImageSource(ImageSource imgSource)
        {
            itemImage = imgSource;
        }

        private void Label_Focused(object sender, FocusEventArgs e)
        {
            Color color = Color.FromRgb(0, 179, 77);
            entry1.TextColor = color;
            icon1.TextColor = color;
        }

        private void entry1_Unfocused(object sender, FocusEventArgs e)
        {
            entry1.TextColor = default;
            icon1.TextColor = default;
        }
    }
}