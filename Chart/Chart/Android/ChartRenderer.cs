namespace Zebble
{
    using System;
    using System.ComponentModel;
    using Zebble;
    using System.Threading.Tasks;
    using Android.Views;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using Android;
    using OxyPlot;
    using OxyPlot.Xamarin.Android;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ChartRenderer :INativeRenderer
    {
        Chart View;
        PlotView Result;

        public async Task<Android.Views.View> Render(Renderer renderer)
        {
            View = (Chart)renderer.View;
            Result = new PlotView(Renderer.Context)
            {
                Model = View.oxyplotModel,
            };

            return Result;
        }


        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}