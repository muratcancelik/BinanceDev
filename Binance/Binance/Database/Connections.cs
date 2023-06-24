using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Binance.Database
{
    class Connections
    {
        public SqlConnection connection()
        {

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BinanceTest;Integrated Security=True");
            con.Open();
            return con;
        }

    }
}
