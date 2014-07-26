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
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace UnitConverter
{
    public class UnitList:INotifyPropertyChanged
    {
        public UnitList()
        {
            this.UnitItems = new ObservableCollection<Unit>();
        }

        public UnitList(double british, double imperial, double american, List<Unit> d)
        {
            this.UnitItems = new ObservableCollection<Unit>();
            Metric_British = british;
            Metric_Imperial = imperial;
            Metric_American = american;
            this.LoadData(d);
        }
        public ObservableCollection<Unit> UnitItems { get; set; }

        public void LoadData(List<Unit> aList)
        {
            UnitItems.Clear();
            for (int i = 0; i < aList.Count; i++)
                UnitItems.Add(aList[i]);
        }

        public double Metric_British { get; set; }

        public double Metric_Imperial { get; set; }

        public double Metric_American { get; set; }

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
