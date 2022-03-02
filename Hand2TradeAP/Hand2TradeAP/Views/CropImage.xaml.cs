using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfImageEditor;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hand2TradeAP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CropImage : ContentPage
    {
        public CropImage(object context)
        {
            this.BindingContext = context;
            InitializeComponent();
            editor.SetToolbarItemVisibility("text,save,Effects,reset,undo,redo,shape,Path,free,original,3:1,3:2,4:3,5:4,16:9,Rotate,Flip,circular,ellipse", false);
        }

        private void editor_ImageEdited(object sender, Syncfusion.SfImageEditor.XForms.ImageEditedEventArgs e)
        {
            editor.SetToolbarItemVisibility("save,reset",true);
        }

        private void editor_EndReset(object sender, Syncfusion.SfImageEditor.XForms.EndResetEventArgs args)
        {
            editor.SetToolbarItemVisibility("save,reset", false);
        }
    }
}