using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Binance.Annotations;
using Binance.MVVM;

namespace Binance.Models
{
    public class OHLCModel :ObservableObject
    {
        private decimal open;
        public decimal Open
        {
            get { return open; }
            set
            {
                open = value;
                OnPropertyChanged();
            }
        }

        private decimal close;
        public decimal Close
        {
            get { return close; }
            set
            {
                close = value;
                OnPropertyChanged();
            }
        }

        private decimal high;
        public decimal High
        {
            get { return high; }
            set
            {
                high = value;
                OnPropertyChanged();
            }
        }

        private decimal low;
        public decimal Low
        {
            get { return low; }
            set
            {
                low = value;
                OnPropertyChanged();
            }
        }

        private DateTime opentime;
        public DateTime OpenTime
        {
            get { return opentime; }
            set
            {
                opentime = value;
                OnPropertyChanged();
            }
        }

        private DateTime closetime;
        public DateTime CloseTime
        {
            get { return closetime; }
            set
            {
                closetime = value;
                OnPropertyChanged();
            }
        }

    }
}
