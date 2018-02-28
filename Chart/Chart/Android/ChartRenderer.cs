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
        //ChartLayout Container;
        PlotView Result;
        static int NextId;
        public async Task<Android.Views.View> Render(Renderer renderer)
        {
            try
            {

            
             View = (Chart)renderer.View;
            //Container = new ChartLayout(Renderer.Context) { Id = FindFreeId() };
            //await View.WhenShown(() => { Thread.UI.Run(LoadChart); });
            //return Container;
            Result = new PlotView(Renderer.Context)
            {
                Model = View.oxyplotModel,
            };

            return Result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        int FindFreeId()
        {
            NextId++;
            while (UIRuntime.CurrentActivity.FindViewById(NextId) != null) NextId++;
            return NextId;
        }

        //async Task LoadChart()
        //{
        //    //We should wait until the view id is added to resources dynamically
        //    while (UIRuntime.CurrentActivity.FindViewById(Container.Id) == null) await Task.Delay(Animation.OneFrame);

        //    var result = new PlotView(Renderer.Context)
        //    {
        //        Model = View.oxyplotModel,
        //    };
        //    Container.AddView(result);
        //    await Task.CompletedTask;
        //}

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}