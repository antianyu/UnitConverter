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

namespace UnitConverter
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            InfoTextBlock.Text = "Version 1.2.4 By An Tianyu\n"+"有问题请一定要告诉我帮助我改进！谢谢！\n";
            IntroductionTextBlock.Text ="V1.2.4\n" +
                                        "压力单位中添加了千帕、兆帕、工程大气压，更改磅/平方英寸的单位为psi\n" + 
                                        "V1.2.3\n" +
                                        "由于货币数据服务停止，去掉了货币转换功能，带来不便请您谅解！此功能将在后续版本中找回！\n" + 
                                        "V1.2.2\n" +
                                        "更正面积转换的错误。\n" +
                                        "V1.2.1\n" +
                                        "修复了一些Bug。\n"+
                                        "V1.2.0\n" +
                                        "加入了货币转换的功能。\n"+
                                        "修改左侧默认单位为常用单位。\n"+
                                        "修改了体积单位中美制单位的数据。\n" +
                                        "V1.0.1\n" +
                                        "修正了选择单位时辨识度不高的问题。\n\n" +
                                        "这个应用纯粹自己娱乐练练手，希望您能喜欢！\n\n" +
                                        "另外感谢LW同学对美工所作出的贡献！\n\n" +
                                        "如遇到崩溃，请将信息发送到aty_3361@sina.com帮助我改进！有任何意见或建议也可以发送到这个邮箱，谢谢！";
        }
    }
}