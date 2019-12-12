using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using MapWinGIS;
namespace MapWinGIS
{
    public partial class Vertical_Profiling_Form : Form
    {
        double LineEquation(MapWinGIS.Point pt1, MapWinGIS.Point pt2, double x)
        {
            double y = 0;
            //http://mathworld.wolfram.com/Two-PointForm.html
            y = pt1.y + (pt2.y - pt1.y) / (pt2.x - pt1.x) * (x - pt1.x);
            return y;
        }
        public Vertical_Profiling_Form(MapWinGIS.Image demImg, MapWinGIS.Point pt1, MapWinGIS.Point pt2)
        {
            this.InitializeComponent();
            //MapWinGIS.Point pt1 = new MapWinGIS.Point();
            //pt1.Set(0, 4);
            //MapWinGIS.Point pt2 = new MapWinGIS.Point();
            //pt2.Set(2, 0);

            int row1, col1;
            demImg.ProjectionToImage(pt1.x, pt1.y, out col1, out row1);
            int row2, col2;
            demImg.ProjectionToImage(pt2.x, pt2.y, out col2, out row2);
            var myModel = new PlotModel { Title = "Mặt cắt dọc" };
            //double step = 0.1;
            //int a_count = (int)Math.Abs((pt1.x - pt2.x) / step);
            //var plot3_Series = new LineSeries { StrokeThickness = 1, MarkerSize = 1 };
            //for (int i = 0; i < a_count; i++)
            //{
            //    int row;
            //    int column;
            //    double x_val = pt1.x + i*step;
            //    double y_val = LineEquation(pt1, pt2, x_val);
            //    demImg.ProjectionToImage(x_val, y_val, out column, out row);
            //    double yDEM = 0;
            //    demImg.Band[1].get_Value(column,row,out yDEM);
            //    plot3_Series.Points.Add(new DataPoint(x_val, yDEM));

            //}
            MapWinGIS.Point ptTmp1 = new MapWinGIS.Point();
            ptTmp1.Set(col1 + 0.5, row1 + 0.5);
            MapWinGIS.Point ptTmp2 = new MapWinGIS.Point();
            ptTmp2.Set(col2 + 0.5, row2 + 0.5);

            int a_count = Math.Abs(col1 - col2);
            var plot3_Series = new LineSeries { StrokeThickness = 1, MarkerSize = 1 };
            for (int i = 0; i < a_count; i++)
            {
                double x_val = col1 + i;
                double y_val = LineEquation(ptTmp1, ptTmp2, x_val);
                double yDEM = 0;
                demImg.Band[1].get_Value((int)x_val, (int)y_val, out yDEM);
                demImg.ImageToProjection((int)x_val, (int)y_val, out x_val, out y_val);
                plot3_Series.Points.Add(new DataPoint(x_val, yDEM));

            }
            myModel.Series.Add(plot3_Series);

            this.plotView1.Model = myModel;

        }
    }
}
