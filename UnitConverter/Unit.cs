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
using System.ComponentModel;

namespace UnitConverter
{
    public class Unit:INotifyPropertyChanged
    {
        private String name_symbol;
        public String Name_Symbol
        {
            get
            {
                return name_symbol;
            }
            set
            {
                if (value != name_symbol)
                {
                    name_symbol = value;
                    NotifyPropertyChanged("Name_Symbol");
                }
            }
        }

        private String classfication;
        public String Classfication
        {
            get
            {
                return classfication;
            }
            set
            {
                if (value != classfication)
                {
                    classfication = value;
                    NotifyPropertyChanged("Classfication");
                }
            }
        }

        private double selfcoeffient;
        public double SelfCoeffient
        {
            get
            {
                return selfcoeffient;
            }
            set
            {
                if (value != selfcoeffient)
                {
                    selfcoeffient = value;
                    NotifyPropertyChanged("SelfCoeffient");
                }
            }
        }

        private double standardcoeffient;
        public double StandardCoeffient
        {
            get
            {
                return standardcoeffient;
            }
            set
            {
                if (value != standardcoeffient)
                {
                    standardcoeffient = value;
                    NotifyPropertyChanged("StandardCoeffient");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
