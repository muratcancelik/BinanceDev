using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Binance.ViewModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Binance.Models;

namespace Binance
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            DataContext = viewModel;
           
        }
        private void ListViewSymbols_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.MessageBox.Show("bla");
        }


        
        
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
 }

