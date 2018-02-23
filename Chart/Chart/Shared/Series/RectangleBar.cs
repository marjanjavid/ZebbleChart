using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class RectangleBar:IPlotType
        {
            public RectangleBar()
            {
                this.Data = new List<RectangleBarItem>();
            }
            public RectangleBar(string title,List<RectangleBarItem> data)
            {
                this.Data = data;
                this.Title = title;
            }
            public string Title { get; set; }
            public List<RectangleBarItem> Data { get; private set; }
        }
    }
}
