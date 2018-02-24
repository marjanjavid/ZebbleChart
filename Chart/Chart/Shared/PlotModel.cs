﻿using System;
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
            }
            public List<Series> Series
            {
                get;set;
            }

            //public static explicit operator OxyPlot.PlotModel(PlotModel model)
            //{
            //    return new OxyPlot.PlotModel()
            //    {
            //        Title = model.title,
            //    };
            //}
        }
    }
}
