using System;
using System.Linq;
using System.Threading.Tasks;
using Binance.Net;
using System.Collections.ObjectModel;
using System.Windows;
using Binance.Net.Objects;
using Binance.Models;
using Binance.MVVM;
using CryptoExchange.Net.Authentication;
using System.Windows.Input;
using System.Windows.Threading;

namespace Binance.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<SymbolModels> everything;
        public ObservableCollection<SymbolModels> Everything
        {

            get { return everything; }
            set
            {
                everything = value;
                OnPropertyChanged();
            }
        }
      
        private ObservableCollection<AssetsViewModel> assets;
        public ObservableCollection<AssetsViewModel> Assets
        {
            get { return assets; }
            set
            {
                assets = value;
                OnPropertyChanged("Assets");
            }
        }

        private ObservableCollection<UserModel> usermodel;
        public ObservableCollection<UserModel>UserModel
        {
            get { return usermodel; }
            set
            {
                usermodel = value;
                OnPropertyChanged("UserModel");
            }
        }


        public ICommand BuyCommand { get; set; }
        public ICommand SellCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand Login { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand load5 { get; set; }


  
        private object orderLock;
        public static BinanceClient client;
        public static BinanceSocketClient socketclient;
        public LoginScreen loginScreen;
        private SymbolModels selectedsymbol;
        public SymbolModels SelectedSymbol
        {
            get { return selectedsymbol; }
            set
            {
                //seçilen sembolde yapılacak işlemler
                selectedsymbol = value;
                OnPropertyChanged("SelectedSymbol");
                Task.Run(() => GetTradeHistory());
                now = DateTime.Now;
                Get24HourStats();
                ChangeSymbol();
                Task.Run(() => Load1hourOhlc());
                Load5minOhlc();
                //Task.Run(() => Load1monthOhlc());
               
            }
        }

       

        public MainViewModel()
        {
            //ana ekranda yapılacak işlemler
            orderLock = new object();
            BuyCommand = new DelegateCommand(Buy);
            SellCommand = new DelegateCommand(Sell);
            CancelCommand = new DelegateCommand(Cancel);
            load5 = new DelegateCommand(Load5minOhlc);
            Login = new DelegateCommand(AgreeApi);
            client = new BinanceClient();
            socketclient = new BinanceSocketClient();
            Task.Run(() => GetAllSymbols());
            
        }

        private string apikey;
        public string ApiKey
        {
            get { return apikey; }
            set
            {
                apikey = value;
                OnPropertyChanged("ApiKey");
            }
        }
        private string secretapi;
        public string SecretApi
        {
            get { return secretapi; }
            set
            {
                secretapi = value;
                OnPropertyChanged("SecretApi");
            }
        }
        private void SubscribeUserStream()
        {
            if (ApiKey == null || SecretApi == null)
                return;
            Task.Run(() =>
            {
                using (var client = new BinanceClient())
                {
                    
                    var startOkay = client.StartUserStream();
                    if (!startOkay.Success)
                    {
                        MessageBox.Show($"Error starting user stream: {startOkay.Error.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                        
                        return;
                    }
                    var subOkay = socketclient.SubscribeToUserDataUpdates(startOkay.Data, OnAccountUpdate, OnOrderUpdate, null, null, null);
                    if (!subOkay.Success)
                    {
                        MessageBox.Show($"Error subscribing to user stream:{subOkay.Error.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    var accountResult = client.GetAccountInfo();
                    if (accountResult.Success)
                        Assets = new ObservableCollection<AssetsViewModel>(accountResult.Data.Balances.Where(b => b.Free != 0 || b.Locked != 0).Select(b => new AssetsViewModel() { Asset = b.Asset, Free = b.Free, Locked = b.Locked }).ToList());
                    else
                        MessageBox.Show($"Error requesting account info: {accountResult.Error.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        

        private void OnAccountUpdate(BinanceStreamAccountInfo data)
        {
            Assets = new ObservableCollection<AssetsViewModel>(data.Balances.Where(b => b.Free != 0 || b.Locked != 0).Select(b => new AssetsViewModel() { Asset = b.Asset, Free = b.Free, Locked = b.Locked }).ToList());
        }

        private void OnOrderUpdate(BinanceStreamOrderUpdate data)
        {
            var symbol = Everything.SingleOrDefault(a => a.Symbol == data.Symbol);
            if (symbol == null)
                return;

            lock (orderLock)
            {
                var order = symbol.Orders.SingleOrDefault(o => o.Id == data.OrderId);
                if (order == null)
                {
                    if (data.RejectReason != OrderRejectReason.None || data.ExecutionType != ExecutionType.New)
                       
                        return;

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        symbol.AddOrder(new OrderViewModel()
                        {
                            ExecutedQuantity = data.AccumulatedQuantityOfFilledTrades,
                            Id = data.OrderId,
                            OriginalQuantity = data.Quantity,
                            Price = data.Price,
                            Side = data.Side,
                            Status = data.Status,
                            Symbol = data.Symbol,
                            Time = data.Time,
                            Type = data.Type
                        });
                    });
                }
                else
                {
                    order.ExecutedQuantity = data.AccumulatedQuantityOfFilledTrades;
                    order.Status = data.Status;
                }
            }
        }
        public async Task GetAllSymbols()
        {
            var result = await client.GetAllPricesAsync();
            if (result.Success)

                Everything = new ObservableCollection<SymbolModels>(result.Data
                    .Select(r => new SymbolModels(r.Symbol, r.Price)).ToList());

            //burada priceleri güncelliyor=>
            socketclient.SubscribeToAllSymbolTickerUpdates(Data =>
            {

                foreach (var op in Data)
                {
                    var symbol = Everything.SingleOrDefault(x => x.Symbol == op.Symbol);
                    if (symbol != null)
                        symbol.Price = op.CurrentDayClosePrice;
                }
            });
        }


        private async void Deepth()
        {
            var ohlc = await client.GetKlinesAsync(SelectedSymbol.Symbol, KlineInterval.OneMonth);
            if(ohlc.Success)
            {
                SelectedSymbol.OneMonth = new ObservableCollection<OHLCModel>();
                foreach(var item in ohlc.Data)
                {
                    await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SelectedSymbol.OneMonth.Insert(0, new OHLCModel()
                        {
                            High = item.Open,
                            Low = item.Low
                        });
                    }));
                }
            }
        }


        private async void GetTradeHistory()//yeni trade eklerken null ekliyor düzelt.
        {

            try
            {
                var trades = await client.GetSymbolTradesAsync(selectedsymbol.Symbol);
                if (trades.Success)
                {
                    await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SelectedSymbol.TradeHistory = new ObservableCollection<TradeModel>(trades.Data.OrderBy(d => d.Time).Select(o => new TradeModel()
                        {
                            Price = o.Price,
                            Time = o.Time.ToLocalTime(),
                            Id = o.Id,

                        }));
                    }));


                    //socketclient.SubscribeToTradeUpdates(SelectedSymbol.Symbol,//yeni tradeleri ekliyor
                    //     trade =>
                    //     {
                    //         Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    //         {
                    //             SelectedSymbol.TradeHistory.Insert(0, new TradeModel()
                    //             {
                    //                 Price = trade.Price,
                    //                 Time = trade.TradeTime.ToLocalTime(),
                    //                 Id = trade.TradeId
                    //             });
                    //         }));
                    //     });

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
          
            
        }
      
        public void Buy(object o)
        {

            using (var client = new BinanceClient())
            {
                var result = client.PlaceOrder(SelectedSymbol.Symbol, OrderSide.Buy, OrderType.Limit, SelectedSymbol.TradeAmount, price: SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCancel);
                if (result.Success)
                    MessageBox.Show("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                else
                    MessageBox.Show($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void Sell(object o)
        {
            using (var client = new BinanceClient())
            {
                var result = client.PlaceOrder(SelectedSymbol.Symbol, OrderSide.Sell, OrderType.Limit, SelectedSymbol.TradeAmount, price: SelectedSymbol.TradePrice, timeInForce: TimeInForce.GoodTillCancel);
                if (result.Success)
                    MessageBox.Show("Order placed!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                else
                    MessageBox.Show($"Order placing failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        public void Cancel(object o)
        {
            var order = (OrderViewModel)o; 
           using(var client=new BinanceClient())
            {
                var result = client.CancelOrder(SelectedSymbol.Symbol, order.Id);
                if(result.Success)
               
                    MessageBox.Show("Order canceled!", "Sucess", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                else
                       MessageBox.Show($"Order canceling failed: {result.Error.Message}", "Failed", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }
      
     
     
        private void GetOrders()
        {
            using (var client = new BinanceClient())
            {
                var result = client.GetAllOrders(SelectedSymbol.Symbol);
                if (result.Success)
                {
                    SelectedSymbol.Orders = new ObservableCollection<OrderViewModel>(result.Data.OrderByDescending(d => d.Time).Select(o => new OrderViewModel()
                    {
                        Id = o.OrderId,
                        ExecutedQuantity = o.ExecutedQuantity,
                        OriginalQuantity = o.OriginalQuantity,
                        Price = o.Price,
                        Side = o.Side,
                        Status = o.Status,
                        Symbol = o.Symbol,
                        Time = o.Time,
                        Type = o.Type
                    }));
                }
                else
                    MessageBox.Show($"Error requesting data: {result.Error.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      

        public DateTime now;
       
        public async void Load1hourOhlc()
        {
            var ohlc = await client.GetKlinesAsync(SelectedSymbol.Symbol, KlineInterval.OneHour);
            if (ohlc.Success)
            {
                SelectedSymbol.OneHour = new ObservableCollection<OHLCModel>();
                foreach (var ıtem in ohlc.Data)
                {
                    if (ıtem.OpenTime.ToLocalTime() > now.AddHours(-36) && ıtem.OpenTime.ToLocalTime() <= now)
                    {
                        await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            SelectedSymbol.OneHour.Insert(0, new OHLCModel()
                            {
                                Open = ıtem.Open,
                                High = ıtem.High,
                                Low = ıtem.Low,
                                Close = ıtem.Close,
                                OpenTime = ıtem.OpenTime.ToLocalTime(),
                                CloseTime = ıtem.CloseTime.ToLocalTime()
                            });
                        }));
                    }
                }
            }
        }


        public async void Load5minOhlc()
        {
            var ohlc = await client.GetKlinesAsync(SelectedSymbol.Symbol, KlineInterval.OneMinute);
            if (ohlc.Success)
            {
                SelectedSymbol.FiveMinutes = new ObservableCollection<OHLCModel>();
                foreach (var item in ohlc.Data)
                {
                    if (item.OpenTime.ToLocalTime() > now.AddHours(-1)&&item.OpenTime.ToLocalTime()<=now)
                    {
                        await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            SelectedSymbol.FiveMinutes.Insert(0, new OHLCModel()
                            {
                                Open = item.Open,
                                Close = item.Close,
                                High = item.High,
                                OpenTime = item.OpenTime.ToLocalTime(),
                                CloseTime = item.CloseTime.ToLocalTime(),
                                Low = item.Low
                            });
                        }));
                    }
                }
            }
        }

        //public async void Load1monthOhlc()
        //{
        //    try
        //    {
        //        var ohlc = await client.GetKlinesAsync(SelectedSymbol.Symbol, KlineInterval.OneMonth);
        //        if (ohlc.Success)
        //        {
        //            SelectedSymbol.OneMonth = new ObservableCollection<OHLCModel>();
        //            foreach (var item in ohlc.Data)
        //            {
        //                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
        //                {
        //                    SelectedSymbol.OneMonth.Insert(0, new OHLCModel()
        //                    {
        //                        Open = item.Open,
        //                        Close = item.Close,
        //                        High = item.High,
        //                        OpenTime = item.OpenTime.ToLocalTime(),
        //                        CloseTime = item.CloseTime.ToLocalTime(),
        //                        Low = item.Low
        //                    });
        //                }));
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Error :" + ex);
        //    }
        //}


        private void Get24HourStats()
        {
            try
            {
                var result = client.Get24HPrice(SelectedSymbol.Symbol);
                if (result.Success)
                {
                    SelectedSymbol.HighPrice = result.Data.HighPrice;
                    selectedsymbol.LowPrice = result.Data.LowPrice;
                    selectedsymbol.Volume = result.Data.Volume;
                    selectedsymbol.PriceChangedPercent = result.Data.PriceChangePercent;
                }
                GetTradeHistory();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error :" + ex);
            }
        }

    
        private void ChangeSymbol()
        {
            if(SelectedSymbol!=null)
            {
                selectedsymbol.TradeAmount = 0;
                selectedsymbol.TradePrice = selectedsymbol.Price;
                Task.Run(() =>
                {
                    GetOrders();
                    Get24HourStats();
                });
            }
        }


        private void AgreeApi(object o)
        {
            SelectApi selectApi = new SelectApi();
            MainWindow window = new MainWindow();
            window.Show();
            selectApi.Close();
            if (!string.IsNullOrEmpty(apikey) && !string.IsNullOrEmpty(secretapi))
                BinanceClient.SetDefaultOptions(new BinanceClientOptions() { ApiCredentials = new ApiCredentials(apikey, secretapi) });
            SubscribeUserStream();
        }
    
        
    }
}
