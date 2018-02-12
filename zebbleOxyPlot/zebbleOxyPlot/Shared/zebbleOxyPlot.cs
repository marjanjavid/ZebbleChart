namespace Zebble
{
    using OxyPlot;
    using OxyPlot.Annotations;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class zebbleOxyPlot : View, IRenderedBy<zebbleOxyPlotRenderer>
    {
        public PlotModel plotModel = new PlotModel();

        public PlotModel userPlotModel => plotModel;

        public async Task Add( PlotModel plotModel)
        {
            
                this.plotModel= plotModel;            
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}