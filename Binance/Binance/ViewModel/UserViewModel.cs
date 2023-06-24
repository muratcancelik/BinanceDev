using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Binance.Models;
using Binance.Database;
using System.Windows;

namespace Binance.ViewModel
{
    class UserViewModel
    {
        Connections connect = new Connections();
        SelectApi select = new SelectApi();
        LoginScreen logins;
       public void Login(UserModel user)
        {
                SqlCommand cmd=new SqlCommand("select * from UserLogin where email = '" + user.Mail + "' and password = '" + user.Password + "'", connect.connection());
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                select.Show();
                select.comboApiKey.Items.Add(reader["apikey"]);
                select.comboApiSecret.Items.Add(reader["apisecret"]);
            }
            else
            {
                MessageBox.Show("uyarı uyarı");
            }
       }

        public void Register(UserModel user)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into UserLogin(email,password,apikey,apisecret)values(@p1,@p2,@p3,@p4)", connect.connection());
                cmd.Parameters.AddWithValue("@p1", user.Mail);
                cmd.Parameters.AddWithValue("@p2", user.Password);
                cmd.Parameters.AddWithValue("@p3", user.ApiKey);
                cmd.Parameters.AddWithValue("@p4", user.ApiSecret);
                cmd.ExecuteNonQuery();
                connect.connection().Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata:" + ex);
            }
        }
    }
}
