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
using Binance.Net;
using Newtonsoft.Json;
using Binance.Annotations;
using Binance.ViewModel;
using Binance.Database;
using System.Data;
using System.Data.SqlClient;
using Binance.Models;


namespace Binance
{
    /// <summary>
    /// LoginScreen.xaml etkileşim mantığı
    /// </summary>
    public partial class LoginScreen : Window
    {

        UserViewModel model = new UserViewModel();
        UserModel user = new UserModel();
        Connections connect = new Connections();
        MainViewModel viewModel = new MainViewModel();
        public LoginScreen()
        {
            InitializeComponent();
            DataContext = viewModel;
            SizeToContent = System.Windows.SizeToContent.Manual;
        }

     
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        RegisterWindow registerwindow = new RegisterWindow();
         

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            registerwindow.Show();
            this.Close();


        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            user.Mail = txtmail.Text;
            user.Password = txtpassword.Password;
            model.Login(user);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
