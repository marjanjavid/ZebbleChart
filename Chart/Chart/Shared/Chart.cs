namespace Zebble
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class Chart : View, IRenderedBy<ChartRenderer>
    {
        public string Title { get; set; }

        
    }
}