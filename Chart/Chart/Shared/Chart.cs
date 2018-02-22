namespace Zebble
{
    using OxyPlot;
    using OxyPlot.Axes;
    using OxyPlot.Series;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zebble;

    public partial class Chart : View, IRenderedBy<ChartRenderer>
    {
        public PlotModel plotModel { get; set; }
        public OxyPlot.PlotModel oxyplotModel { get; internal set; }
        //bool showXAxis = true, showYAxix = true, isZoomable = true, isMovable = true;
        IPlotType chart;
        //public bool ShowXAxis
        //{
        //    get => showXAxis;
        //    set
        //    {
        //        if (showXAxis == value) return;
        //        showXAxis = value;
        //    }
        //}
        //public bool ShowYAxix
        //{
        //    get => showYAxix;
        //    set
        //    {
        //        if (showYAxix == value) return;
        //        showYAxix = value;
        //    }
        //}
        //public bool IsZoomable
        //{
        //    get => isZoomable;
        //    set
        //    {
        //        if (isZoomable == value) return;
        //        isZoomable = value;
        //    }
        //}
        //public bool IsMovable
        //{
        //    get => isMovable;
        //    set
        //    {
        //        if (isMovable == value) return;
        //        isMovable = value;
        //    }
        //}

        public async Task Add(PlotModel plotModel)
        {
            this.oxyplotModel = new OxyPlot.PlotModel();
            this.oxyplotModel.Title = plotModel.Title;
            if (plotModel.Chart is Area)
            {
                var areaSeries = new AreaSeries();
                foreach (var point in ((Area)plotModel.Chart).Data)
                {
                    areaSeries.Points.Add(point);
                }
                this.oxyplotModel.Series.Add(areaSeries);
            }
            else if (plotModel.Chart is Line)
            {
                var lineSeries = new LineSeries
                {
                    MarkerType = MarkerType.Circle,
                    MarkerSize = 4,
                    MarkerStroke = OxyColors.White
                };

                foreach (var point in ((Line)plotModel.Chart).Data)
                {
                    lineSeries.Points.Add(point);
                }
                this.oxyplotModel.Series.Add(lineSeries);
                this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
                this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });
            }
            else if (plotModel.Chart is Pie)
            {
                var pieSeries = new PieSeries();
                foreach (var slice in ((Pie)plotModel.Chart).Data)
                {
                    pieSeries.Slices.Add(slice);
                }
                this.oxyplotModel.Series.Add(pieSeries);
            }
            else if (plotModel.Chart is Bar)
            {
                var barSeries = new BarSeries();
                foreach (var item in ((Bar)plotModel.Chart).Data)
                {
                    barSeries.Items.Add(item);
                }
                this.oxyplotModel.Series.Add(barSeries);
                this.oxyplotModel.Axes.Add(new CategoryAxis
                {
                    Position = AxisPosition.Left,
                    Key = "CakeAxis",
                    ItemsSource = new[]
        {
                "Apple cake",
                "Baumkuchen",
                "Bundt Cake",
                "Chocolate cake",
                "Carrot cake"
        }
                });
            }

            else if (plotModel.Chart is Column)
            {
                var barSeries = new ColumnSeries();
                foreach (var item in ((Column)plotModel.Chart).Data)
                {
                    barSeries.Items.Add(item);
                }
                this.oxyplotModel.Series.Add(barSeries);
                this.oxyplotModel.Axes.Add(new CategoryAxis
                {
                    Position = AxisPosition.Bottom,
                    Key = "CakeAxis",
                    ItemsSource = new[]
                    {
                        "A",
                        "B",
                        "C",
                        "D",
                        "E"
                     }
                });
            }
            else if (plotModel.Chart is Box )
            {
                var boxSeries = new BoxPlotSeries();
                foreach (var item in ((Box)plotModel.Chart).Data)
                {
                    boxSeries.Items.Add(item);
                }
                this.oxyplotModel.Series.Add(boxSeries);
                this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0.1, MaximumPadding = 0.1 });
            }
            else if (plotModel.Chart is Contour)
            {
                var contourSeries = new ContourSeries();
                
                contourSeries.Data = ((Contour)plotModel.Chart).Data;
                contourSeries.ColumnCoordinates = ((Contour)plotModel.Chart).ColumnCoordinates;
                contourSeries.RowCoordinates = ((Contour)plotModel.Chart).RowCoordinates;

                this.oxyplotModel.Series.Add(contourSeries);
                
            }
        }
        public override void Dispose()
        {
            base.Dispose();
        }

    }
}