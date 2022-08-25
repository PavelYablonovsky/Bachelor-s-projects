using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace Flying
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        PointPairList list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, deltalist;
        LineItem myCurve5, myCurve6, myCurve7, myCurve8, myCurve9, myCurve10, myCurve11, myCurve12, myCurve13, myCurve14, myCurve15, myCurve16, deltacurve;
        GraphPane pane5;

        int axis1;
        int axis2;
        int axis3;
        int axis4;

        private void Form5_Load(object sender, EventArgs e)
        {
            pane5 = zedGraphControl1.GraphPane;

            pane5.Title.Text = "";

            pane5.XAxis.Scale.MajorStep = 5.0;


            pane5.XAxis.Scale.MinorStep = 1.0;


            pane5.YAxis.Scale.MajorStep = 0.5;


            pane5.YAxis.Scale.MinorStep = 0.1;


            pane5.YAxisList.Clear();


            axis1 = pane5.AddYAxis("tn, сек");
            axis2 = pane5.AddYAxis("tk, сек");
            axis3 = pane5.AddYAxis("Vk, км/с");
            axis4 = pane5.AddYAxis("nmax");

            //pane5.XAxis.MajorTic.IsOpposite = false;
            //pane5.XAxis.MinorTic.IsOpposite = false;
            //pane5.YAxis.MajorTic.IsOpposite = false;
            //pane5.YAxis.MinorTic.IsOpposite = false;


            pane5.YAxisList[axis1].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis2].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis3].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis4].Title.FontSpec.FontColor = Color.Black;

            pane5.XAxis.Title.Text = "-θ0, град";

            pane5 = zedGraphControl1.GraphPane;

            pane5.XAxis.MajorGrid.IsVisible = true;
            pane5.YAxis.MajorGrid.IsVisible = true;

            list5 = new PointPairList();
            list9 = new PointPairList();
            list13 = new PointPairList();
            list14 = new PointPairList();
            
            // tn
            int numbcurve1 = 0;
            int numbercurve1_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 8, 10, 12 };

                double[] _y = new double[3] { 95, 70, 55 
                        };

                list5.Add(x[numbcurve1++], _y[numbercurve1_2++]);
            }
            //tk
            int numbcurve5 = 0;
            int numbercurve5_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 8, 10, 12 };

                double[] _y = new double[3] { 775, 758, 743};

                list9.Add(x[numbcurve5++], _y[numbercurve5_2++]);
            }
            // Vk
            int numbcurve9 = 0;
            int numbercurve9_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 8,10,12 };

                double[] _y = new double[3] { 0.3313, 0.3289, 0.3275};

                list13.Add(x[numbcurve9++], _y[numbercurve9_2++]);
            }

            // nmax
            int numbcurve10 = 0;
            int numbercurve10_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 8, 10, 12 };

                double[] _y = new double[3] { 6.4759, 7.6983, 8.5856 };

                list14.Add(x[numbcurve10++], _y[numbercurve10_2++]);
            }




            myCurve5 = pane5.AddCurve("Время начальное", list5, Color.Green, SymbolType.None);
            myCurve9 = pane5.AddCurve("Время конечное", list9, Color.Red, SymbolType.None);
            myCurve13 = pane5.AddCurve("Конечная скорость", list13, Color.Blue, SymbolType.None);
            myCurve14 = pane5.AddCurve("Максимальная перегрузка", list14, Color.Gray, SymbolType.None);
            myCurve5.YAxisIndex = axis1;
            myCurve9.YAxisIndex = axis2;
            myCurve13.YAxisIndex = axis3;
            myCurve14.YAxisIndex = axis4;
            myCurve5.Line.IsVisible = true;
            myCurve5.Line.IsSmooth = true;
            myCurve9.Line.IsVisible = true;
            myCurve9.Line.IsSmooth = true;
            myCurve13.Line.IsVisible = true;
            myCurve13.Line.IsSmooth = true;
            myCurve14.Line.IsVisible = true;
            myCurve14.Line.IsSmooth = true;
            myCurve5.Line.Width = 5.0f;
            myCurve9.Line.Width = 5.0f;
            myCurve13.Line.Width = 5.0f;
            myCurve14.Line.Width = 5.0f;

            myCurve9.Line.Style = DashStyle.Dash;
            myCurve13.Line.Style = DashStyle.DashDot;
            myCurve14.Line.Style = DashStyle.DashDotDot;


            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();




        }




    }
}
