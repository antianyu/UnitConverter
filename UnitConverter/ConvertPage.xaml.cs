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
    public partial class ConvertPage : PhoneApplicationPage
    {
        public ConvertPage()
        {
            InitializeComponent();
        }

        private string category = "";
        private string tempQuantity = "";

        private double LeftUnitQuantity = 0;
        private double RightUnitQuantity = 0;

        private int LeftSelectedIndex = 0;
        private int RightSelectedIndex = 0;

        private bool isInitial = true;

        private bool isLeftConvert = false;
        private bool isRightConvert = false;

        private Unit LeftUnit = new Unit();
        private Unit RightUnit = new Unit();

        private UnitList currentList = new UnitList();

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            category = NavigationContext.QueryString["Category"];
            PageTitle.Text = String.Format("{0}", category);
            switch (category)
            {
                case "重量":
                    {
                        LeftUnitPicker.ItemsSource = Category.WeightUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.WeightUnits.UnitItems;
                        currentList = Category.WeightUnits;
                        break; 
                    }
                case "长度":
                    {
                        LeftUnitPicker.ItemsSource = Category.LengthUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.LengthUnits.UnitItems;
                        currentList = Category.LengthUnits;
                        break;
                    }
                case "面积":
                    {
                        LeftUnitPicker.ItemsSource = Category.AreaUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.AreaUnits.UnitItems;
                        currentList = Category.AreaUnits;
                        break;
                    }
                case "体积":
                    {
                        LeftUnitPicker.ItemsSource = Category.VolumeUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.VolumeUnits.UnitItems;
                        currentList = Category.VolumeUnits;
                        break;
                    }
                case "能量":
                    {
                        LeftUnitPicker.ItemsSource = Category.EnergyUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.EnergyUnits.UnitItems;
                        currentList = Category.EnergyUnits;
                        break;
                    }
                case "角度":
                    {
                        LeftUnitPicker.ItemsSource = Category.AngleUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.AngleUnits.UnitItems;
                        currentList = Category.AngleUnits;
                        break;
                    }
                case "功率":
                    {
                        LeftUnitPicker.ItemsSource = Category.PowerUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.PowerUnits.UnitItems;
                        currentList = Category.PowerUnits;
                        break;
                    }
                case "压力":
                    {
                        LeftUnitPicker.ItemsSource = Category.PressureUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.PressureUnits.UnitItems;
                        currentList = Category.PressureUnits;
                        break;
                    }
                case "温度":
                    {
                        LeftUnitPicker.ItemsSource = Category.TemperatureUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.TemperatureUnits.UnitItems;
                        MinusTipTextBlock.Visibility = Visibility.Visible;
                        LeftMinusTextBlock.Visibility = Visibility.Visible;
                        RightMinusTextBlock.Visibility = Visibility.Visible;
                        LeftUnitTextBox.Width = 390;
                        RightUnitTextBox.Width = 390;
                        LeftUnitTextBox.Margin = new Thickness(54, 101, 0, 0);
                        RightUnitTextBox.Margin = new Thickness(54, 368, 0, 0);
                        TipTextBlock.Margin = new Thickness(0, 15, 0, 0);
                        currentList = Category.TemperatureUnits;
                        break;
                    }
                case "速度":
                    {
                        LeftUnitPicker.ItemsSource = Category.VelocityUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.VelocityUnits.UnitItems;
                        currentList = Category.VelocityUnits;
                        break;
                    }
                case "货币":
                    {
                        LeftUnitPicker.ItemsSource = Category.CurrencyUnits.UnitItems;
                        RightUnitPicker.ItemsSource = Category.CurrencyUnits.UnitItems;
                        currentList = Category.CurrencyUnits;
                        ExchangeButton.Visibility = Visibility.Collapsed;
                        RateRefreshButton.Visibility = Visibility.Visible;
                        break;
                    }
            }
            if (isInitial)
            {
                switch (category)
                {
                    case "重量":
                        {
                            LeftUnitPicker.SelectedIndex = 10;
                            break;
                        }
                    case "长度":
                        {
                            LeftUnitPicker.SelectedIndex = 17;
                            break;
                        }
                    case "面积":
                        {
                            LeftUnitPicker.SelectedIndex = 11;
                            break;
                        }
                    case "体积":
                        {
                            LeftUnitPicker.SelectedIndex = 16;
                            break;
                        }
                    case "能量":
                        {
                            LeftUnitPicker.SelectedIndex = 1;
                            break;
                        }
                    case "角度":
                        {
                            LeftUnitPicker.SelectedIndex = 4;
                            break;
                        }
                    case "功率":
                        {
                            LeftUnitPicker.SelectedIndex = 3;
                            break;
                        }
                    case "压力":
                        {
                            LeftUnitPicker.SelectedIndex = 7;
                            break;
                        }
                    case "温度":
                        {
                            LeftUnitPicker.SelectedIndex = 1;
                            break;
                        }
                    case "速度":
                        {
                            LeftUnitPicker.SelectedIndex = 1;
                            break;
                        }
                    case "货币":
                        {
                            LeftUnitPicker.SelectedIndex = 3;
                            break;
                        }
                }
            }
            isInitial = false;
        }

        private void LeftUnitPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LeftUnit = (sender as ListPicker).SelectedItem as Unit;
            LeftSelectedIndex = (sender as ListPicker).SelectedIndex;
            if (!isInitial)
            {
                isRightConvert = true;
                if (Warning())
                {
                    Convert();
                    ShowLeftUnit();
                }
            }
        }

        private void RightUnitPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RightUnit = (sender as ListPicker).SelectedItem as Unit;
            RightSelectedIndex = (sender as ListPicker).SelectedIndex;
            if (!isInitial)
            {
                isLeftConvert = true;
                if (Warning())
                {
                    Convert();
                    ShowRightUnit();
                }
            }
        }

        #region LeftUnitTextBox
        private void LeftUnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isLeftConvert && LeftUnitTextBox.Text != "")
            {
                if (double.TryParse(LeftUnitTextBox.Text, out LeftUnitQuantity))
                {
                    if (Warning())
                    {
                        Convert();
                        ShowRightUnit();
                        tempQuantity = LeftUnitTextBox.Text;
                    }
                }
                else
                {
                    MessageBox.Show("输入有误，请重新输入！");
                    LeftUnitTextBox.Text = tempQuantity;
                    LeftUnitTextBox.Select(LeftUnitTextBox.Text.Length, 0);
                    LeftUnitQuantity = double.Parse(LeftUnitTextBox.Text);
                    if (Warning())
                    {
                        Convert();
                        ShowRightUnit();
                    }
                }
            }
        }

        private void LeftUnitTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isLeftConvert = true;
        }

        private void LeftUnitTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LeftUnitTextBox.Text = "";
        }

        private void LeftUnitTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (LeftUnitTextBox.Text == "")
                LeftUnitTextBox.Text = "0";
            isLeftConvert = true;
            if (double.TryParse(LeftUnitTextBox.Text, out LeftUnitQuantity) && Warning())
            {
                Convert();
                ShowRightUnit();
            }            
        }
        #endregion

        #region RightUnitTextBox
        private void RightUnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isRightConvert && RightUnitTextBox.Text != "")
            {
                if (double.TryParse(RightUnitTextBox.Text, out RightUnitQuantity))
                {
                    if (Warning())
                    {
                        Convert();
                        ShowLeftUnit();
                        tempQuantity = RightUnitTextBox.Text;
                    }
                }
                else
                {
                    MessageBox.Show("输入有误，请重新输入！");
                    RightUnitTextBox.Text = tempQuantity;
                    RightUnitTextBox.Select(RightUnitTextBox.Text.Length, 0);
                    RightUnitQuantity = double.Parse(RightUnitTextBox.Text);
                    if (Warning())
                    {
                        Convert();
                        ShowLeftUnit();
                    }
                }
            }
        }

        private void RightUnitTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            isRightConvert = true;
        }

        private void RightUnitTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            RightUnitTextBox.Text = "";
        }

        private void RightUnitTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (RightUnitTextBox.Text == "")
                RightUnitTextBox.Text = "0";
            isRightConvert = true;
            if (double.TryParse(RightUnitTextBox.Text, out RightUnitQuantity) && Warning())
            {
                Convert();
                ShowLeftUnit();
            }
        }
        #endregion

        private void LeftMinusTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (category == "温度")
            {
                if (LeftUnitQuantity <= 0)
                {
                    LeftMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    LeftUnitQuantity = Math.Abs(LeftUnitQuantity);
                }
                else
                {
                    LeftMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    LeftUnitQuantity = 0 - Math.Abs(LeftUnitQuantity);
                }
                isLeftConvert = true;
                if (Warning())
                {
                    Convert();
                    ShowRightUnit();
                } 
            }
        }

        private void RightMinusTextBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if(category=="温度")
            {
                if (RightUnitQuantity <= 0)
                {
                    RightMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
                    RightUnitQuantity = Math.Abs(RightUnitQuantity);
                }
                else
                {
                    RightMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    RightUnitQuantity = 0 - Math.Abs(RightUnitQuantity);
                }
                isRightConvert = true;
                if(Warning())
                {
                    Convert();
                    ShowLeftUnit();
                }
            }
        }

        private void ExchangeButton_Click(object sender, RoutedEventArgs e)
        {
            isLeftConvert = true;
            LeftUnitTextBox.Text = RightUnitTextBox.Text;
            LeftUnitQuantity = double.Parse(LeftUnitTextBox.Text);
            int tempIndex = LeftSelectedIndex;
            LeftUnitPicker.SelectedIndex = RightSelectedIndex;
            RightUnitPicker.SelectedIndex = tempIndex;
        }

        private void RateRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                try
                {
                    WaitingBar.Visibility = Visibility.Visible;
                    tempQuantity = LeftUnitTextBox.Text;
                    LeftUnitTextBox.IsEnabled = false;
                    RightUnitTextBox.IsEnabled = false;
                    LeftUnitPicker.IsEnabled = false;
                    RightUnitPicker.IsEnabled = false;

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

        private void Convert()
        {
            try
            {
                if (LeftUnit == RightUnit)
                {
                    if (isLeftConvert)
                        RightUnitQuantity = LeftUnitQuantity;
                    else
                        LeftUnitQuantity = RightUnitQuantity;
                }
                else
                {
                    double temp = 0;
                    if (category == "温度")
                    {
                        #region 温度
                        if (isLeftConvert)
                        {
                            switch (LeftUnit.Name_Symbol)
                            {
                                case "摄氏度(℃)":
                                    {
                                        temp = LeftUnitQuantity;
                                        break;
                                    }
                                case "华氏度(℉)":
                                    {
                                        temp = (LeftUnitQuantity - 32) / 1.8;
                                        break;
                                    }
                                case "兰氏度(°R)":
                                    {
                                        temp = LeftUnitQuantity / 1.8 - 273.15;
                                        break;
                                    }
                                case "列氏度(°Re)":
                                    {
                                        temp = LeftUnitQuantity * 1.25;
                                        break;
                                    }
                                case "开氏度(K)":
                                    {
                                        temp = LeftUnitQuantity - 273.15;
                                        break;
                                    }
                            }
                            switch (RightUnit.Name_Symbol)
                            {
                                case "摄氏度(℃)":
                                    {
                                        RightUnitQuantity = temp;
                                        break;
                                    }
                                case "华氏度(℉)":
                                    {
                                        RightUnitQuantity = temp * 1.8 + 32;
                                        break;
                                    }
                                case "兰氏度(°R)":
                                    {
                                        RightUnitQuantity = (temp + 273.15) * 1.8;
                                        break;
                                    }
                                case "列氏度(°Re)":
                                    {
                                        RightUnitQuantity = temp / 1.25;
                                        break;
                                    }
                                case "开氏度(K)":
                                    {
                                        RightUnitQuantity = temp + 273.15;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            switch (RightUnit.Name_Symbol)
                            {
                                case "摄氏度(℃)":
                                    {
                                        temp = RightUnitQuantity;
                                        break;
                                    }
                                case "华氏度(℉)":
                                    {
                                        temp = (RightUnitQuantity - 32) / 1.8;
                                        break;
                                    }
                                case "兰氏度(°R)":
                                    {
                                        temp = RightUnitQuantity / 1.8 - 273.15;
                                        break;
                                    }
                                case "列氏度(°Re)":
                                    {
                                        temp = RightUnitQuantity * 1.25;
                                        break;
                                    }
                                case "开氏度(K)":
                                    {
                                        temp = RightUnitQuantity - 273.15;
                                        break;
                                    }
                            }
                            switch (LeftUnit.Name_Symbol)
                            {
                                case "摄氏度(℃)":
                                    {
                                        LeftUnitQuantity = temp;
                                        break;
                                    }
                                case "华氏度(℉)":
                                    {
                                        LeftUnitQuantity = temp * 1.8 + 32;
                                        break;
                                    }
                                case "兰氏度(°R)":
                                    {
                                        LeftUnitQuantity = (temp + 273.15) * 1.8;
                                        break;
                                    }
                                case "列氏度(°Re)":
                                    {
                                        LeftUnitQuantity = temp / 1.25;
                                        break;
                                    }
                                case "开氏度(K)":
                                    {
                                        LeftUnitQuantity = temp + 273.15;
                                        break;
                                    }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        if (isLeftConvert)
                        {
                            if (LeftUnit.Classfication == RightUnit.Classfication)
                            {
                                RightUnitQuantity = LeftUnitQuantity * LeftUnit.StandardCoeffient / LeftUnit.SelfCoeffient * RightUnit.SelfCoeffient / RightUnit.StandardCoeffient;
                            }
                            else
                            {
                                switch (LeftUnit.Classfication)
                                {
                                    case "Metric":
                                        {
                                            temp = LeftUnitQuantity * LeftUnit.StandardCoeffient / LeftUnit.SelfCoeffient;
                                            break;
                                        }
                                    case "British":
                                        {
                                            temp = LeftUnitQuantity * LeftUnit.StandardCoeffient / LeftUnit.SelfCoeffient * currentList.Metric_British;
                                            break;
                                        }
                                    case "Imperial":
                                        {
                                            temp = LeftUnitQuantity * LeftUnit.StandardCoeffient / LeftUnit.SelfCoeffient * currentList.Metric_Imperial;
                                            break;
                                        }
                                    case "American":
                                        {
                                            temp = LeftUnitQuantity * LeftUnit.StandardCoeffient / LeftUnit.SelfCoeffient * currentList.Metric_American;
                                            break;
                                        }
                                }
                                switch (RightUnit.Classfication)
                                {
                                    case "Metric":
                                        {
                                            RightUnitQuantity = temp * RightUnit.SelfCoeffient / RightUnit.StandardCoeffient;
                                            break;
                                        }
                                    case "British":
                                        {
                                            RightUnitQuantity = temp * RightUnit.SelfCoeffient / RightUnit.StandardCoeffient / currentList.Metric_British;
                                            break;
                                        }
                                    case "Imperial":
                                        {
                                            RightUnitQuantity = temp * RightUnit.SelfCoeffient / RightUnit.StandardCoeffient / currentList.Metric_Imperial;
                                            break;
                                        }
                                    case "American":
                                        {
                                            RightUnitQuantity = temp * RightUnit.SelfCoeffient / RightUnit.StandardCoeffient / currentList.Metric_American;
                                            break;
                                        }
                                }
                            }
                        }
                        else
                        {
                            if (RightUnit.Classfication == LeftUnit.Classfication)
                            {
                                LeftUnitQuantity = RightUnitQuantity * RightUnit.StandardCoeffient / RightUnit.SelfCoeffient * LeftUnit.SelfCoeffient / LeftUnit.StandardCoeffient;
                            }
                            else
                            {
                                switch (RightUnit.Classfication)
                                {
                                    case "Metric":
                                        {
                                            temp = RightUnitQuantity * RightUnit.StandardCoeffient / RightUnit.SelfCoeffient;
                                            break;
                                        }
                                    case "British":
                                        {
                                            temp = RightUnitQuantity * RightUnit.StandardCoeffient / RightUnit.SelfCoeffient * currentList.Metric_British;
                                            break;
                                        }
                                    case "Imperial":
                                        {
                                            temp = RightUnitQuantity * RightUnit.StandardCoeffient / RightUnit.SelfCoeffient * currentList.Metric_Imperial;
                                            break;
                                        }
                                    case "American":
                                        {
                                            temp = RightUnitQuantity * RightUnit.StandardCoeffient / RightUnit.SelfCoeffient * currentList.Metric_American;
                                            break;
                                        }
                                }
                                switch (LeftUnit.Classfication)
                                {
                                    case "Metric":
                                        {
                                            LeftUnitQuantity = temp * LeftUnit.SelfCoeffient / LeftUnit.StandardCoeffient;
                                            break;
                                        }
                                    case "British":
                                        {
                                            LeftUnitQuantity = temp * LeftUnit.SelfCoeffient / LeftUnit.StandardCoeffient / currentList.Metric_British;
                                            break;
                                        }
                                    case "Imperial":
                                        {
                                            LeftUnitQuantity = temp * LeftUnit.SelfCoeffient / LeftUnit.StandardCoeffient / currentList.Metric_Imperial;
                                            break;
                                        }
                                    case "American":
                                        {
                                            LeftUnitQuantity = temp * LeftUnit.SelfCoeffient / LeftUnit.StandardCoeffient / currentList.Metric_American;
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
            catch
            { }
            isLeftConvert = false;
            isRightConvert = false;
        }

        private void ShowLeftUnit()
        {
            if (LeftUnitQuantity < 0)
                LeftMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            else
                LeftMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
            LeftUnitTextBox.Text = Math.Abs(LeftUnitQuantity).ToString();
        }

        private void ShowRightUnit()
        {
            if (RightUnitQuantity < 0)
                RightMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            else
                RightMinusTextBlock.Foreground = new SolidColorBrush(Color.FromArgb(50, 255, 255, 255));
            RightUnitTextBox.Text = Math.Abs(RightUnitQuantity).ToString();
        }

        private bool Warning()
        {
            if (category == "温度" && isLeftConvert &&((LeftUnit.Name_Symbol == "摄氏度(℃)" && LeftUnitQuantity < -273.15) || 
                (LeftUnit.Name_Symbol == "华氏度(℉)" && LeftUnitQuantity < -459.67) || (LeftUnit.Name_Symbol == "兰氏度(°R)" && LeftUnitQuantity < 0) ||
                (LeftUnit.Name_Symbol == "列氏度(°Re)" && LeftUnitQuantity < -216.92) || (LeftUnit.Name_Symbol == "开氏度(K)" && LeftUnitQuantity < 0)))
            {
                MessageBox.Show("输入范围有误，请重新输入。");
                LeftUnitQuantity = double.Parse(tempQuantity);
                ShowLeftUnit();
                Convert();
                ShowRightUnit();
                return false;
            }
            else if(category == "温度" && isRightConvert &&((RightUnit.Name_Symbol == "摄氏度(℃)" && RightUnitQuantity < -273.15) || 
                    (RightUnit.Name_Symbol == "华氏度(℉)" && RightUnitQuantity < -459.67) || (RightUnit.Name_Symbol == "兰氏度(°R)" && RightUnitQuantity < 0) || 
                    (RightUnit.Name_Symbol == "列氏度(°Re)" && RightUnitQuantity < -216.92) || (RightUnit.Name_Symbol == "开氏度(K)" && RightUnitQuantity < 0)))
            {
                MessageBox.Show("输入范围有误，请重新输入。");
                RightUnitQuantity = double.Parse(tempQuantity);
                ShowRightUnit();
                Convert();
                ShowLeftUnit();
                return false;
            }
            else
                return true;
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
            isInitial = true;
            int tempLeftIndex = LeftSelectedIndex;
            int tempRightIndex = RightSelectedIndex;
            LeftUnitTextBox.IsEnabled = true;
            RightUnitTextBox.IsEnabled = true;
            LeftUnitPicker.IsEnabled = true;
            RightUnitPicker.IsEnabled = true;
            LeftUnitTextBox.Text = tempQuantity;

            Category.CurrencyUnits.LoadData(tempCurrency);
            WaitingBar.Visibility = Visibility.Collapsed;

            LeftSelectedIndex = tempLeftIndex;
            RightSelectedIndex = tempRightIndex;
            LeftUnitPicker.SelectedIndex = LeftSelectedIndex;
            RightUnitPicker.SelectedIndex = RightSelectedIndex;
            isInitial = false;

            isLeftConvert = true;
            Convert();
            ShowRightUnit();
        }
    }
}