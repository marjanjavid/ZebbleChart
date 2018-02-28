using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart {
        public class PlotModel
        {
            string title = "Zebble Chart";
            public string Title { get { return title; } set { if (title == value) return; title = value; } }
            public PlotModel()
            {
                this.Series = new List<Series>();
                this.Axes = new List<OxyPlot.Axes.Axis>();
            }
            public List<Series> Series
            {
                get; private set;
            }
            public List<OxyPlot.Axes.Axis> Axes { get;  set; }
            
        }
    }
}
