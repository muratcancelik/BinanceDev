using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Binance.Annotations;
using Binance.MVVM;
using Binance.ViewModel;

namespace Binance.Models
{
    public class SymbolModels : ObservableObject
    {
        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                OnPropertyChanged();
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }
        private decimal pricechangedpercent;
        public decimal PriceChangedPercent
        {
            get { return pricechangedpercent; }
            set
            {
                pricechangedpercent = value;
                OnPropertyChanged();
            }
        }

        private decimal highprice;
        public decimal HighPrice
        {
            get { return highprice; }
            set
            {
                highprice = value;
                OnPropertyChanged();
            }
        }

        private decimal lowprice;
        public decimal LowPrice
        {
            get { return lowprice; }
            set
            {
                lowprice = value;
                OnPropertyChanged();
            }
        }

        private decimal volume;
        public decimal Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                OnPropertyChanged();
            }
        }

        private decimal tradeprice;
        public decimal TradePrice
        {
            get { return tradeprice; }
            set
            {
                tradeprice = value;
                OnPropertyChanged();
            }
        }
        private decimal tradeAmount;
        public decimal TradeAmount
        {
            get { return tradeAmount; }
            set
            {
                tradeAmount = value;
               OnPropertyChanged("TradeAmount");
            }
        }


        private ObservableCollection<OHLCModel> fiveminutes;
        public ObservableCollection<OHLCModel> FiveMinutes
        {
            get { return fiveminutes; }
            set
            {
                fiveminutes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<OHLCModel> onemonth;
        public ObservableCollection<OHLCModel> OneMonth
        {
            get { return onemonth; }
            set
            {
                onehour = value;
                OnPropertyChanged();
            }
        }

      

        private ObservableCollection<OHLCModel> onehour;
        public ObservableCollection<OHLCModel>OneHour
        {
            get { return onehour; }
            set
            {
                onehour = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TradeModel> tradehistory;
        public ObservableCollection<TradeModel> TradeHistory
        {
            get { return tradehistory; }
            set
            {
                tradehistory = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<OrderViewModel> orders;
        public ObservableCollection<OrderViewModel>Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

            public SymbolModels(string symbol,decimal price)
             {
              this.symbol = symbol;
              this.price = price;
              }
        public void AddOrder(OrderViewModel order)
        {
            Orders.Add(order);
            Orders.OrderByDescending(o => o.Time);
            OnPropertyChanged();
        }
    }
}
