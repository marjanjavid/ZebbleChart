using System;
using System.Collections.Generic;
using System.Text;

namespace Zebble
{
    public partial class Chart
    {
        public class ErrorColumn:Column
        {
            public List<ErrorColumnItem> Data
            {
                get; set;
            }
        }
    }
}
