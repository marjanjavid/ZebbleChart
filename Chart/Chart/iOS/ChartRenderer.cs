namespace Zebble
{
    using System;
    using System.ComponentModel;
    using Zebble;
    using System.Threading.Tasks;
    using OxyPlot.Xamarin.iOS;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ChartRenderer : INativeRenderer
    {
        Chart View;
        PlotView Result;

        public async Task<UIKit.UIView> Render(Renderer renderer)
        {
            View = (Chart)renderer.View;
            Result = new PlotView()
            {
                Model = View.plotModel,
            };

            return Result;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}