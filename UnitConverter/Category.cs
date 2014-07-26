using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace UnitConverter
{
    public class Category:UnitList
    {
        #region Weight
        private static List<Unit> weight = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "千克(kg)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "克(g)", SelfCoeffient = 1000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "毫克(mg)", SelfCoeffient = 1000000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "吨(t)", SelfCoeffient = 1, StandardCoeffient = 1000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "公担(q)", SelfCoeffient = 1, StandardCoeffient = 100, Classfication = "Metric" },
            new Unit() { Name_Symbol = "克拉(Ct)", SelfCoeffient = 5000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "担", SelfCoeffient = 1, StandardCoeffient = 50, Classfication = "Metric" },
            new Unit() { Name_Symbol = "斤", SelfCoeffient = 2, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "两", SelfCoeffient = 20, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "钱", SelfCoeffient = 200, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "磅(lb)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "盎司(oz)", SelfCoeffient = 16, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "长吨(long ton)", SelfCoeffient = 1, StandardCoeffient = 2240, Classfication = "British" },
            new Unit() { Name_Symbol = "短吨(sh ton)", SelfCoeffient = 1, StandardCoeffient = 2000, Classfication = "British" },
            new Unit() { Name_Symbol = "英担(cwt)", SelfCoeffient = 1, StandardCoeffient = 112, Classfication = "British" },
            new Unit() { Name_Symbol = "美担(sh cwt)", SelfCoeffient = 1, StandardCoeffient = 100, Classfication = "British" },
            new Unit() { Name_Symbol = "英石(st)", SelfCoeffient = 1, StandardCoeffient = 14, Classfication = "British" },
            new Unit() { Name_Symbol = "打兰(dr)", SelfCoeffient = 256, StandardCoeffient = 1, Classfication = "British" }
        };
        public static UnitList WeightUnits = new UnitList(0.45359237,0,0,weight);
        #endregion

        #region Length
        private static List<Unit> length = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "米(m)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "千米(km)", SelfCoeffient = 1, StandardCoeffient = 1000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "分米(dm)", SelfCoeffient = 10, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "厘米(cm)", SelfCoeffient = 100, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "毫米(mm)", SelfCoeffient = 1000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "微米(μm)", SelfCoeffient = 1000000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "海里(NM)", SelfCoeffient = 1, StandardCoeffient = 1852, Classfication = "Metric" },
            new Unit() { Name_Symbol = "里", SelfCoeffient = 1, StandardCoeffient = 500, Classfication = "Metric" },
            new Unit() { Name_Symbol = "丈", SelfCoeffient = 0.3, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "市尺", SelfCoeffient = 3, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "市寸", SelfCoeffient = 30, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "分", SelfCoeffient = 300, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "厘", SelfCoeffient = 3000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "毫", SelfCoeffient = 30000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "英尺(ft)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "英寸(in)", SelfCoeffient = 12, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "码(yd)", SelfCoeffient = 1, StandardCoeffient = 3, Classfication = "British" },
            new Unit() { Name_Symbol = "英里(mile)", SelfCoeffient = 1, StandardCoeffient = 5280, Classfication = "British" },
            new Unit() { Name_Symbol = "英寻(fm)", SelfCoeffient = 1, StandardCoeffient = 6, Classfication = "British" },
            new Unit() { Name_Symbol = "弗隆(fur)", SelfCoeffient = 1, StandardCoeffient = 6620, Classfication = "British" },
        };
        public static UnitList LengthUnits = new UnitList(0.3048, 0, 0, length);
        #endregion

        #region Area
        private static List<Unit> area = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "平方米(m²)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方分米(dm²)", SelfCoeffient = 100, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方厘米(cm²)", SelfCoeffient = 10000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方毫米(mm²)", SelfCoeffient = 1000000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方千米(km²)", SelfCoeffient = 1, StandardCoeffient = 1000000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "公顷(ha)", SelfCoeffient = 1, StandardCoeffient = 10000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "公亩(are)", SelfCoeffient = 1, StandardCoeffient = 100, Classfication = "Metric" },
            new Unit() { Name_Symbol = "市顷", SelfCoeffient = 0.000015, StandardCoeffient = 500, Classfication = "Metric" },
            new Unit() { Name_Symbol = "市亩", SelfCoeffient = 0.0015, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方市尺", SelfCoeffient = 9, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方市寸", SelfCoeffient = 900, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "平方英尺(ft²)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "英亩(acre)", SelfCoeffient = 1, StandardCoeffient = 43560, Classfication = "British" },
            new Unit() { Name_Symbol = "平方英里(mi²)", SelfCoeffient = 1, StandardCoeffient = 27878400, Classfication = "British" },
            new Unit() { Name_Symbol = "平方码(yd²)", SelfCoeffient = 1, StandardCoeffient = 9, Classfication = "British" },
            new Unit() { Name_Symbol = "平方英寸(in²)", SelfCoeffient = 144, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "平方竿(rd²)", SelfCoeffient = 1, StandardCoeffient = 272.25, Classfication = "British" },
        };
        public static UnitList AreaUnits = new UnitList(0.09290304, 0, 0, area);
        #endregion

        #region Volume
        private static List<Unit> volume = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "升(L)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "立方米(m³)", SelfCoeffient = 1, StandardCoeffient = 1000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "立方厘米(cm³)", SelfCoeffient = 1000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "立方毫米(mm³)", SelfCoeffient = 1000000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "毫升(mL)", SelfCoeffient = 1000, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "立方英尺(ft³)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "立方英寸(in³)", SelfCoeffient = 1728, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "立方码(yd³)", SelfCoeffient = 27, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "英制品脱(imp pt)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Imperial" },
            new Unit() { Name_Symbol = "英制夸脱(imp qt)", SelfCoeffient = 1, StandardCoeffient = 2, Classfication = "Imperial" },
            new Unit() { Name_Symbol = "英制加仑(imp gal)", SelfCoeffient = 1, StandardCoeffient = 8, Classfication = "Imperial" },
            new Unit() { Name_Symbol = "美制干量品脱(US pt)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "American" },
            new Unit() { Name_Symbol = "美制干量夸脱(US qt)", SelfCoeffient = 1, StandardCoeffient = 2, Classfication = "American" },
            new Unit() { Name_Symbol = "美制干量加仑(US gal)", SelfCoeffient = 1, StandardCoeffient = 8, Classfication = "American" },
            new Unit() { Name_Symbol = "美制湿量品脱(US pt)", SelfCoeffient = 1, StandardCoeffient = 0.859367001, Classfication = "American" },
            new Unit() { Name_Symbol = "美制湿量夸脱(US qt)", SelfCoeffient = 1, StandardCoeffient = 1.718734002, Classfication = "American" },
            new Unit() { Name_Symbol = "美制湿量加仑(US gal)", SelfCoeffient = 1, StandardCoeffient = 6.874936008, Classfication = "American" },
        };
        public static UnitList VolumeUnits = new UnitList(28.3168,0.56826125,0.55061047,volume);
        #endregion

        #region Energy
        private static List<Unit> energy = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "焦耳(J)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "卡(cal)", SelfCoeffient = 1, StandardCoeffient = 4.185851820846, Classfication = "Metric" },
            new Unit() { Name_Symbol = "千卡(kcal)", SelfCoeffient = 1, StandardCoeffient = 4185.851820846, Classfication = "Metric" },
            new Unit() { Name_Symbol = "英制马力▪时(HP▪h)", SelfCoeffient = 1, StandardCoeffient = 2684519.5392, Classfication = "Metric" },
            new Unit() { Name_Symbol = "米制马力▪时(PS▪h)", SelfCoeffient = 1, StandardCoeffient = 2647795.5, Classfication = "Metric" },
            new Unit() { Name_Symbol = "千瓦时(kW▪h)", SelfCoeffient = 1, StandardCoeffient = 3600000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "英制热量单位(Btu)", SelfCoeffient = 1, StandardCoeffient = 1055.05585262, Classfication = "Metric" },
            new Unit() { Name_Symbol = "英尺▪磅(ft▪lb)", SelfCoeffient = 1, StandardCoeffient = 1.3557483731, Classfication = "Metric" },
        };
        public static UnitList EnergyUnits = new UnitList(0, 0, 0, energy);
        #endregion

        #region Angle
        private static List<Unit> angle = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "度(°)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "分(′)", SelfCoeffient = 60, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "秒(″)", SelfCoeffient = 3600, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "圆周(Cir)", SelfCoeffient = 1, StandardCoeffient = 360, Classfication = "Metric" },
            new Unit() { Name_Symbol = "弧度(rad)", SelfCoeffient = 1, StandardCoeffient = 57.29577944, Classfication = "Metric" },
            new Unit() { Name_Symbol = "毫弧度(mrad)", SelfCoeffient = 1, StandardCoeffient = 0.005729577944, Classfication = "Metric" },
            new Unit() { Name_Symbol = "百分度(gon)", SelfCoeffient = 1, StandardCoeffient = 0.9, Classfication = "Metric" },
        };
        public static UnitList AngleUnits = new UnitList(0.3048, 0, 0, angle);
        #endregion

        #region Power
        private static List<Unit> power = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "瓦(W)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "千瓦(kW)", SelfCoeffient = 1, StandardCoeffient = 1000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "焦耳/秒(J/s)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "美制马力(PS)", SelfCoeffient = 1, StandardCoeffient = 735.49875, Classfication = "Metric" },
            new Unit() { Name_Symbol = "公斤▪米/秒(kg▪m/s)", SelfCoeffient = 1, StandardCoeffient = 9.80665, Classfication = "Metric" },
            new Unit() { Name_Symbol = "千卡/秒(kcal/s)", SelfCoeffient = 1, StandardCoeffient = 4184.1004, Classfication = "Metric" },
            new Unit() { Name_Symbol = "英制马力(HP)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "英尺▪磅/秒(ft▪lb/s)", SelfCoeffient = 550, StandardCoeffient = 1, Classfication = "British" },
        };
        public static UnitList PowerUnits = new UnitList(745.699872, 0, 0, power);
        #endregion

        #region Pressure
        private static List<Unit> pressure = new List<Unit>()
        {
            new Unit() { Name_Symbol = "帕斯卡(Pa)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "千帕(KPa)", SelfCoeffient = 1, StandardCoeffient = 1000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "兆帕(MPa)", SelfCoeffient = 1, StandardCoeffient = 1000000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "工程大气压(kgf/cm²)", SelfCoeffient = 1, StandardCoeffient = 98066.5, Classfication = "Metric" },
            new Unit() { Name_Symbol = "巴(bar)", SelfCoeffient = 1, StandardCoeffient = 100000, Classfication = "Metric" },
            new Unit() { Name_Symbol = "公斤/平方米(kg/m²)", SelfCoeffient = 1, StandardCoeffient = 9.80665, Classfication = "Metric" },
            new Unit() { Name_Symbol = "磅/平方英寸(psi)", SelfCoeffient = 1, StandardCoeffient = 6894.757, Classfication = "Metric" },
            new Unit() { Name_Symbol = "标准大气压(atm)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "毫米汞柱(mmHg)", SelfCoeffient = 760, StandardCoeffient = 1, Classfication = "British" },
        };
        public static UnitList PressureUnits = new UnitList(101325, 0, 0, pressure);
        #endregion

        #region Temperature
        private static List<Unit> temperature = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "摄氏度(℃)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "华氏度(℉)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "兰氏度(°R)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "列氏度(°Re)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "开氏度(K)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" }
        };
        public static UnitList TemperatureUnits = new UnitList(0, 0, 0, temperature);
        #endregion

        #region Velocity
        private static List<Unit> velocity = new List<Unit>()
        {            
            new Unit() { Name_Symbol = "米/秒(m/s)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "公里/小时(km/h)", SelfCoeffient = 3.6, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "厘米/秒(cm/s)", SelfCoeffient = 100, StandardCoeffient = 1, Classfication = "Metric" },
            new Unit() { Name_Symbol = "马赫(M)", SelfCoeffient = 1, StandardCoeffient = 340.3, Classfication = "Metric" },
            new Unit() { Name_Symbol = "节(kts)", SelfCoeffient = 3600, StandardCoeffient = 1852, Classfication = "Metric" },
            new Unit() { Name_Symbol = "英里/小时(mph)", SelfCoeffient = 1, StandardCoeffient = 1, Classfication = "British" },
            new Unit() { Name_Symbol = "英尺/秒(ft/s)", SelfCoeffient = 5280, StandardCoeffient = 3600, Classfication = "British" },
        };
        public static UnitList VelocityUnits = new UnitList(0.44704, 0, 0, velocity);
        #endregion

        #region Currency
        public static UnitList CurrencyUnits = new UnitList();
        #endregion
    }
}
