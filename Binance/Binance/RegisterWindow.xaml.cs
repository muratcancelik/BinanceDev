using System;
using System.Windows;
using System.Windows.Input;
using Binance.Database;
using System.Net.Mail;
using Binance.ViewModel;
using Binance.Models;

namespace Binance
{
    /// <summary>
    /// RegisterWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class RegisterWindow : Window
    {
        UserViewModel ViewModel = new UserViewModel();
        static Random random = new Random();
        CheckCode check = new CheckCode();
        UserModel user = new UserModel();
        public static int verfcode = random.Next(10000, 99999);


        public RegisterWindow()
        {
            InitializeComponent();
            SizeToContent = System.Windows.SizeToContent.Manual;
            
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            user.Mail = txtMail.Text;
            check.Show();
            Close();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("denemeyekmi@gmail.com", "kopkop159");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("denemeyekmi@gmail.com", "Republic of Uganda");
            mail.To.Add(user.Mail);
            mail.Subject = "Verification Code";
            mail.Body = "Your Verification Code: " + verfcode;
            smtp.Send(mail);
            check.btnRegister.Click += BtnRegister_Click;

           }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (check.txtCode.Text==verfcode.ToString())
            {
                user.Mail = txtMail.Text;
                user.Password = txtPassword.Text;
                user.ApiKey = txtApiK.Text;
                user.ApiSecret = txtApiS.Text;
                ViewModel.Register(user);
                LoginScreen loginScreen = new LoginScreen();
                loginScreen.Show();
                check.Close();
            }
        }
        

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
