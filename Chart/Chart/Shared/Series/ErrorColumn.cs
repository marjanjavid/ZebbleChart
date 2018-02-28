using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class ErrorColumn:Column
        {
            public ErrorColumn()
            {
                this.Data = new List<ErrorColumnItem>();
            }
            public ErrorColumn(List<ErrorColumnItem> data)
            {
                this.Data = data;
            }
            public List<ErrorColumnItem> Data
            {
                get; set;
            }
        }
    }
}
