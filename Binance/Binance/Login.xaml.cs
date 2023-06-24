using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Binance.ViewModel;

namespace Binance
{
    /// <summary>
    /// Login.xaml etkileşim mantığı
    /// </summary>
    public partial class Login : Window
    {
        int i;
        DispatcherTimer timer = new DispatcherTimer();
        public Login()
        {
             i = 0;
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            i++;
            if(i==3)
            {
               LoginScreen ls = new LoginScreen();
                ls.Show();
                Close();
            }
        }
    }
}
