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
using Binance.ViewModel;

namespace Binance
{
    /// <summary>
    /// SelectApi.xaml etkileşim mantığı
    /// </summary>
    public partial class SelectApi : Window
    {
        
        MainViewModel viewModel;
        public SelectApi()
        {
            InitializeComponent();
            SizeToContent = System.Windows.SizeToContent.Manual;
            viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnxd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
