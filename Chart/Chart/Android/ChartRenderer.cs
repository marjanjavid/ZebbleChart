namespace Zebble
{
    using System;
    using System.ComponentModel;
    using Zebble;
    using System.Threading.Tasks;
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using OxyPlot.Xamarin.Android;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ChartRenderer : INativeRenderer
    {
        Chart View;
        ChartLayout Container;
        static int NextId;

        public async Task<Android.Views.View> Render(Renderer renderer)
        {
            try
            {


                View = (Chart)renderer.View;

                Container = new ChartLayout(Renderer.Context);
                Container.Id = FindFreeId();
                await View.WhenShown(() => { Thread.UI.Run(LoadChart); });

                return Container;
            }
            catch (Exception ex)
            {
                return Container;
            }
        }
        int FindFreeId()
        {
            NextId++;
            while (UIRuntime.CurrentActivity.FindViewById(NextId) != null) NextId++;
            return NextId;
        }
        async Task LoadChart()
        {
            //We should wait until the view id is added to resources dynamically
            while (UIRuntime.CurrentActivity.FindViewById(Container.Id) == null) await Task.Delay(Animation.OneFrame);

            var view = new PlotView(Renderer.Context)
            {
                Model = CreatePlotModel(),
            };

            Container.AddView(view);

            await Task.CompletedTask;
        }
        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel { Title = View.Title };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}