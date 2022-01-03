using System;
using System.Collections.Generic;
using System.Text;
using Hand2TradeAP.Services;

namespace Hand2TradeAP.Models
{
    public partial class Item
    {
        public string ImgSource
        {
            get
            {
                Hand2TradeAPIProxy proxy = Hand2TradeAPIProxy.CreateProxy();
                //Create a source with cache busting!
                Random r = new Random();
                string source = $"{proxy.GetBasePhotoUri()}/{this.ItemId}.jpg?{r.Next()}";
                return source;
            }
        }
    }
}
