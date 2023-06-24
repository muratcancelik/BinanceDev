using System;
using Binance.Net.Objects;
using Binance.MVVM;

namespace Binance.ViewModel
{
    public class OrderViewModel : ObservableObject
    {
        private long id;
        public long Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                OnPropertyChanged("Symbol");
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private decimal originalquantity;
        public decimal OriginalQuantity
        {
            get { return originalquantity; }
            set
            {
                originalquantity = value;
                OnPropertyChanged("OriginalQuantity");
            }
        }

        private decimal executedquantity;
        public decimal ExecutedQuantity
        {
            get { return executedquantity; }
            set
            {
                executedquantity = value;
                OnPropertyChanged("ExecutedQuantity");
                OnPropertyChanged("Fullfilled");
            }
        }

        public string FullFilled
            {
            get { return ExecutedQuantity + "/" + OriginalQuantity; }
            }

        private OrderStatus status;
        public OrderStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
                OnPropertyChanged("CanCancel");
            }
        }

        private OrderType type;
        public OrderType Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        private OrderSide side;
        public OrderSide Side
        {
            get { return side; }
            set
            {
                side = value;
                OnPropertyChanged("Side");
            }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        public bool Cancancel
        {
            get { return Status == OrderStatus.New || Status == OrderStatus.PartiallyFilled; }
        }
    }
}
