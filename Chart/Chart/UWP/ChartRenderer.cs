namespace Zebble
{
    using System;
    using System.ComponentModel;
    using Windows.UI;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using OxyPlot.Windows;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ChartRenderer : INativeRenderer
    {
        Chart View;
        PlotView Result;

        public async Task<FrameworkElement> Render(Renderer renderer)
        {
            
                View = (Chart)renderer.View;
                Result = new PlotView()
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