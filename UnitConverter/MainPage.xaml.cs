using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Xml.Linq;
using System.IO;

namespace UnitConverter
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
        }

        private void About_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void Weight_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=重量", UriKind.Relative));
        }

        private void Length_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=长度", UriKind.Relative));
        }

        private void Area_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=面积", UriKind.Relative));
        }

        private void Volume_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=体积", UriKind.Relative));
        }

        private void Energy_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=能量", UriKind.Relative));
        }

        private void Angle_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=角度", UriKind.Relative));
        }

        private void Power_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=功率", UriKind.Relative));
        }

        private void Pressure_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=压力", UriKind.Relative));
        }

        private void Temperature_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=温度", UriKind.Relative));
        }

        private void Velocity_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=速度", UriKind.Relative));
        }

        private void Currency_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (Category.CurrencyUnits.UnitItems.Count != 0)
                NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=货币", UriKind.Relative));
            else
            {
                if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    try
                    {
                        WaitingBar.Visibility = Visibility.Visible;

                        //请求地址
                        String url = "http://webservice.webxml.com.cn/WebServices/ForexRmbRateWebService.asmx/getForexRmbRate";

                        //创建WebRequest类
                        HttpWebRequest request = HttpWebRequest.CreateHttp(new Uri(url));

                        //设置请求方式
                        request.Method = "GET";

                        //返回应答请求异步操作的状态
                        request.BeginGetResponse(ResponseCallback, request);
                    }
                    catch
                    {

                    }
                }
                else
                    MessageBox.Show("未连接到网络。汇率数据需要联网请求，请打开网络连接！");
            }
        }

        private void ResponseCallback(IAsyncResult result)
        {
            try
            {
                //获取异步操作返回的的信息
                HttpWebRequest request = (HttpWebRequest)result.AsyncState;
                //结束对 Internet 资源的异步请求
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(result);
                //获取请求体信息长度
                long contentLength = response.ContentLength;

                //获取应答码
                int statusCode = (int)response.StatusCode;
                string statusText = response.StatusDescription;

                //应答头信息验证
                Stream stream = response.GetResponseStream();

                //获取请求信息
                StreamReader read = new StreamReader(stream);
                string msg = read.ReadToEnd();
                Deployment.Current.Dispatcher.BeginInvoke(() => { XMLParse(msg); });
            }
            catch
            {

            }
        }

        private void XMLParse(string text)
        {
            XDocument doc = XDocument.Parse(text);
            var currencyRate = doc.Descendants("ForexRmbRate").Select(currency => new
            {
                Name = currency.Descendants("Name").First().Value,
                Symbol = currency.Descendants("Symbol").First().Value,
                BasePrice = (string)currency.Descendants("BasePrice").First().Value,
            });
            List<Unit> tempCurrency = new List<Unit>();
            tempCurrency.Add(new Unit() { Name_Symbol = "人民币( CNY)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" });
            foreach (var res in currencyRate)
            {
                Unit tmp = new Unit();
                tmp.Name_Symbol = res.Name.ToString() + "(" + res.Symbol.ToString() + ")";
                double i;
                if (double.TryParse(res.BasePrice, out i))
                {
                    if (i != 0)
                    {
                        tmp.SelfCoeffient = 1;
                        tmp.StandardCoeffient = i / 100;
                        tmp.Classfication = "Metric";
                        tempCurrency.Add(tmp);
                    }
                }
            }
            Category.CurrencyUnits.LoadData(tempCurrency);
            WaitingBar.Visibility = Visibility.Collapsed;
            NavigationService.Navigate(new Uri("/ConvertPage.xaml?Category=货币", UriKind.Relative));
        }
    }
}