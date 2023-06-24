using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.MVVM;

namespace Binance.Models
{
   public class UserModel:ObservableObject
    {
        private string email;
        public string Mail
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private string apikey;
        public string ApiKey
        {
            get { return apikey; }
            set
            {
                apikey = value;
                OnPropertyChanged();
            }
        }

        private string apisecret;
        public string ApiSecret
        {
            get { return apisecret; }
            set
            {
                apisecret = value;
                OnPropertyChanged();
            }
        }

    }
}
