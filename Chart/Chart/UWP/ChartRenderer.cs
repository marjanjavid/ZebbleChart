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
                    Model = View.plotModel,
                };

                return Result;
           
        }
        //private PlotModel CreatePlotModel()
        //{
        //    var plotModel = new PlotModel { Title = View.plotModel.Title };

        //    //TODO:Mohseni we should replace these 2 lines with the view amount 
        //    //how should i use the user amounts?if i want to use switch case there would be lots of properties

        //    plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
        //    plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

        //    var series1 = new LineSeries
        //    {
        //        MarkerType = MarkerType.Circle,
        //        MarkerSize = 4,
        //        MarkerStroke = OxyColors.White
        //    };

        //    series1.Points.Add(new DataPoint(0.0, 6.0));
        //    series1.Points.Add(new DataPoint(1.4, 2.1));
        //    series1.Points.Add(new DataPoint(2.0, 4.2));
        //    series1.Points.Add(new DataPoint(3.3, 2.3));
        //    series1.Points.Add(new DataPoint(4.7, 7.4));
        //    series1.Points.Add(new DataPoint(6.0, 6.2));
        //    series1.Points.Add(new DataPoint(8.9, 8.9));

        //    plotModel.Series.Add(series1);

        //    return plotModel;
        //}
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}