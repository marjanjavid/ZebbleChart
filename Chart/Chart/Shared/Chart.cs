namespace Zebble
{
    using OxyPlot;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class Chart : View, IRenderedBy<ChartRenderer>
    {
        public PlotModel plotModel = new PlotModel();
        public async Task Add(PlotModel plotModel)
        {
            
                this.plotModel = plotModel;

            
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}