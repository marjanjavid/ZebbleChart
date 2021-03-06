﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class Pie: Series
        {           
            public Pie()
            {
                this.Data = new List<PieSlice>();
            }
            public Pie(List<PieSlice> data)
            {
                this.Data = data;
            }
            public List<PieSlice> Data
            {
                get; set;
            }
        }
    }
}
