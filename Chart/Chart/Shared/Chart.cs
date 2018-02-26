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
        //IPlotType chart;
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
            foreach (var chart in plotModel.Series)
            {
                 if (chart is TwoColorArea)//it should be placed before Area if clause
                {
                    var twoColorAreaSeries = new TwoColorAreaSeries
                    {
                        Color = ChartColor.CastToOxyColor(((TwoColorArea)chart).Color),
                        Color2 = ChartColor.CastToOxyColor(((TwoColorArea)chart).Color2),
                        Limit = ((TwoColorArea)chart).Limit
                    };
                    foreach (var item in ((TwoColorArea)chart).Data)
                    {
                        twoColorAreaSeries.Points.Add(item);
                    }
                    this.oxyplotModel.Series.Add(twoColorAreaSeries);
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Temperature", Unit = "°C", ExtraGridlines = new[] { 0.0 } });
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Date" });
                }
                else if (chart is Area)
                {
                    var areaSeries = new AreaSeries();
                    foreach (var point in ((Area)chart).Data)
                    {
                        areaSeries.Points.Add(point);
                    }
                    this.oxyplotModel.Series.Add(areaSeries);
                }
                else if (chart is TwoColorLine)//it should be placed before line if clause
                {
                    var twoColorLineSeries = new TwoColorLineSeries
                    {
                        Color = ChartColor.CastToOxyColor(((TwoColorLine)chart).Color),
                        Color2 = ChartColor.CastToOxyColor(((TwoColorLine)chart).Color2),
                        Limit = ((TwoColorLine)chart).Limit
                    };
                    foreach (var item in ((TwoColorLine)chart).Data)
                    {
                        twoColorLineSeries.Points.Add(item);
                    }
                    this.oxyplotModel.Series.Add(twoColorLineSeries);
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Temperature", Unit = "°C", ExtraGridlines = new[] { 0.0 } });
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Date" });
                }
                else if (chart is Line)
                {
                    var lineSeries = new LineSeries
                    {
                        MarkerType = MarkerType.Circle,
                        MarkerSize = 4,
                        MarkerStroke = OxyColors.White
                    };

                    foreach (var point in ((Line)chart).Data)
                    {
                        lineSeries.Points.Add(point);
                    }
                    this.oxyplotModel.Series.Add(lineSeries);
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });
                }
                else if (chart is Pie)
                {
                    var pieSeries = new PieSeries();
                    foreach (var slice in ((Pie)chart).Data)
                    {
                        pieSeries.Slices.Add(slice);
                    }
                    this.oxyplotModel.Series.Add(pieSeries);
                }
                else if (chart is Bar)
                {
                    var barSeries = new BarSeries();
                    foreach (var item in ((Bar)chart).Data)
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
                else if(chart is ErrorColumn)
                {
                    var errorColumn = new ErrorColumnSeries();
                    foreach (ErrorColumnItem item in ((ErrorColumn)chart).Data)
                    {
                        errorColumn.Items.Add((OxyPlot.Series.ErrorColumnItem)item);
                    }
                    this.oxyplotModel.Series.Add(errorColumn);
                    var categoryAxis = new CategoryAxis { Position = AxisPosition.Bottom };
                    categoryAxis.Labels.Add("Category A");
                    categoryAxis.Labels.Add("Category B");
                    categoryAxis.Labels.Add("Category C");
                    categoryAxis.Labels.Add("Category D");

                    var valueAxis = new LinearAxis { Position = AxisPosition.Left, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0 };
                    this.oxyplotModel.Axes.Add(categoryAxis);
                    this.oxyplotModel.Axes.Add(valueAxis);
                }
                else if (chart is Column)
                {
                    var barSeries = new ColumnSeries();
                    foreach (var item in ((Column)chart).Data)
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
                else if (chart is Box)
                {
                    var boxSeries = new BoxPlotSeries();
                    foreach (var item in ((Box)chart).Data)
                    {
                        boxSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(boxSeries);
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left });
                    this.oxyplotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0.1, MaximumPadding = 0.1 });
                }
                else if (chart is Contour)
                {
                    var contourSeries = new ContourSeries
                    {
                        Data = ((Contour)chart).Data,
                        ColumnCoordinates = ((Contour)chart).ColumnCoordinates,
                        RowCoordinates = ((Contour)chart).RowCoordinates
                    };
                    this.oxyplotModel.Series.Add(contourSeries);

                }
                else if (chart is RectangleBar)
                {
                    var rectangleBarSeries = new RectangleBarSeries
                    {
                        Title = ((RectangleBar)chart).Title
                    };
                    foreach (var item in ((RectangleBar)chart).Data)
                    {
                        rectangleBarSeries.Items.Add(item);
                    }
                    this.oxyplotModel.Series.Add(rectangleBarSeries);
                }
                
            }
        }
        public override void Dispose()
        {
            base.Dispose();
        }

    }
}