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
    internal class MakeLoanViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string debt;
        public string Debt
        {
            get { return debt; }
            set
            {
                debt = value;
                OnPropertyChanged("Debt");
            }
        }
        private DateTime paymentDate;
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set
            {
                paymentDate = value;
                OnPropertyChanged("PaymentDate");
            }
        }
        public MakeLoanViewModel()
        {

        }
    }
}
