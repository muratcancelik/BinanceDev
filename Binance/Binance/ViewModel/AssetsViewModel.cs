using Binance.MVVM;
namespace Binance.ViewModel
{
   public class AssetsViewModel:ObservableObject
    {
        private string asset;
        public string Asset
        {
            get { return asset; }
            set
            {
                asset = value;
                OnPropertyChanged("Asset");

            }
        }

        private decimal free;
        public decimal Free
        {
            get { return free; }
            set
            {
                free = value;
                OnPropertyChanged("Free");
            }
        }
        private decimal locked;
        public decimal Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                OnPropertyChanged("Locked");
            }
        }
    }
}
