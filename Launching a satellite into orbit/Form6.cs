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
    public partial class  Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        PointPairList list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, deltalist,
            list_a, list_b, list_c, list_d;
        LineItem myCurve5, myCurve6, myCurve7, myCurve8, myCurve9, myCurve10, myCurve11, myCurve12, myCurve13, myCurve14, myCurve15, myCurve16, deltacurve,
                curve_a, curve_b, curve_c, curve_d;
        GraphPane pane5;

        int axis1;
        int axis2;
        int axis3;
        int axis4;

        private void Form6_Load(object sender, EventArgs e)
        {
            pane5 = zedGraphControl1.GraphPane;

            pane5.Title.Text = "";

            pane5.XAxis.Scale.MajorStep = 0.5;


            pane5.XAxis.Scale.MinorStep = 0.1;


            pane5.YAxis.Scale.MajorStep = 0.5;


            pane5.YAxis.Scale.MinorStep = 0.1;


            pane5.YAxisList.Clear();


            axis1 = pane5.AddYAxis("Vк, км/с");
            axis2 = pane5.AddYAxis("λк, град");
            axis3 = pane5.AddYAxis("nmax");
            axis4 = pane5.AddYAxis("tk, сек");

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


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            pane5.CurveList.Clear();
            list5 = new PointPairList();
            list9 = new PointPairList();
            list13 = new PointPairList();
            list_a = new PointPairList();
            int numbcurve1 = 0;
            int numbercurve1_2 = 0;

            for (double z = 0; z <= 3; z++)
            {

                double[] x = new double[4] { 10, 10.5, 11, 11.5,  };

                double[] _y = new double[4] { 0.5149, 
                         0.5257,  0.5418,  0.565, 
                                                  };

                list5.Add(x[numbcurve1++], _y[numbercurve1_2++]);
            }

            int numbcurve5 = 0;
            int numbercurve5_2 = 0;

            for (double z = 0; z <= 3; z++)
            {

                double[] x = new double[4] { 10, 10.5, 11, 11.5};

                double[] _y = new double[4] {12.87, 11.89, 11.07, 10.37 };

                list9.Add(x[numbcurve5++], _y[numbercurve5_2++]);
            }

            int numbcurve9 = 0;
            int numbercurve9_2 = 0;

            for (double z = 0; z <= 3; z++)
            {

                double[] x = new double[4] { 10, 10.5, 11, 11.5 };

                double[] _y = new double[4] { 4.9978, 5.611, 6.2071, 6.7888 };

                list13.Add(x[numbcurve9++], _y[numbercurve9_2++]);
            }

            int numbcurve_a = 0;
            int numbercurve_a2 = 0;

            for (double z = 0; z <= 3; z++)
            {

                double[] x = new double[4] { 10, 10.5, 11, 11.5 };

                double[] _y = new double[4] { 240, 219, 201, 185 };

                list_a.Add(x[numbcurve_a++], _y[numbercurve_a2++]);
            }


            myCurve5 = pane5.AddCurve("Скорость", list5, Color.DarkGreen, SymbolType.None);
            myCurve9 = pane5.AddCurve("Геоцентрическая  долгота", list9, Color.Green, SymbolType.None);
            myCurve13 = pane5.AddCurve("перегрукзка максимальная", list13, Color.LawnGreen, SymbolType.None);
            curve_a = pane5.AddCurve("Время", list_a, Color.ForestGreen, SymbolType.None);

            myCurve5.YAxisIndex = axis1;
            myCurve9.YAxisIndex = axis2;
            myCurve13.YAxisIndex = axis3;
            curve_a.YAxisIndex = axis4;
            myCurve5.Line.IsVisible = true;
            myCurve5.Line.IsSmooth = true;
            myCurve9.Line.IsVisible = true;
            myCurve9.Line.IsSmooth = true;
            myCurve13.Line.IsVisible = true;
            myCurve13.Line.IsSmooth = true;
            curve_a.Line.IsVisible = true;
            curve_a.Line.IsSmooth = true;
            myCurve9.Line.Style = DashStyle.Dash;
            myCurve13.Line.Style = DashStyle.Dot;
            curve_a.Line.Style = DashStyle.DashDot;
            myCurve5.Line.Width = 5.0f;
            myCurve9.Line.Width = 5.0f;
            myCurve13.Line.Width = 5.0f;
            curve_a.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            pane5.CurveList.Clear();

            list6 = new PointPairList();
            list10 = new PointPairList();
            list14 = new PointPairList();
            list_b = new PointPairList();

            int numbcurve2 = 0;
            int numbercurve2_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 12.5,  13, 
                        13.5};

                double[] _y = new double[3] { 0.7919, 0.8362, 0.899 };

                list6.Add(x[numbcurve2++], _y[numbercurve2_2++]);
            }


            int numbcurve6 = 0;
            int numbercurve6_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] {12.5,  13, 
                        13.5};

                double[] _y = new double[3] { 7.58, 7.26, 6.95};

                list10.Add(x[numbcurve6++], _y[numbercurve6_2++]);
            }

            int numbcurve10 = 0;
            int numbercurve10_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] {12.5,  13, 
                        13.5};

                double[] _y = new double[3] { 10.0701, 10.5945, 11.1132};

                list14.Add(x[numbcurve10++], _y[numbercurve10_2++]);
            }


            int numbcurveb = 0;
            int numbercurveb2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] {12.5,  13, 
                        13.5};

                double[] _y = new double[3] { 120, 113, 106 };

                list_b.Add(x[numbcurveb++], _y[numbercurveb2++]);
            }

            myCurve6 = pane5.AddCurve("Скорость", list6, Color.DarkBlue, SymbolType.None);
            myCurve10 = pane5.AddCurve("Геоцентрическая  долгота", list10, Color.Blue, SymbolType.None);
            myCurve14 = pane5.AddCurve("Максимальная перегрукка", list14, Color.SteelBlue, SymbolType.None);
            curve_b = pane5.AddCurve("Время", list_b ,Color.DeepSkyBlue, SymbolType.None);
            myCurve6.YAxisIndex = axis1;
            myCurve10.YAxisIndex = axis2;
            myCurve14.YAxisIndex = axis3;
            curve_b.YAxisIndex = axis4;
            myCurve6.Line.IsVisible = true;
            myCurve6.Line.IsSmooth = true;
            myCurve10.Line.IsVisible = true;
            myCurve10.Line.IsSmooth = true;
            myCurve14.Line.IsVisible = true;
            myCurve14.Line.IsSmooth = true;
            curve_b.Line.IsVisible = true;
            curve_b.Line.IsSmooth = true;
            myCurve10.Line.Style = DashStyle.Dash;
            myCurve14.Line.Style = DashStyle.Dot;
            curve_b.Line.Style = DashStyle.DashDot;
            myCurve6.Line.Width = 5.0f;
            myCurve10.Line.Width = 5.0f;
            myCurve14.Line.Width = 5.0f;
            curve_b.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            pane5.CurveList.Clear();
            list7 = new PointPairList();
            list11 = new PointPairList();
            list15 = new PointPairList();
            list_c = new PointPairList();


            int numbcurve3 = 0;
            int numbercurve3_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 12.5, 13, 13.5 };

                double[] _y = new double[3] { 0.3628, 0.3652, 0.3691 };

                list7.Add(x[numbcurve3++], _y[numbercurve3_2++]);
            }

            int numbcurve7 = 0;
            int numbercurve7_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 12.5, 13, 13.5 };

                double[] _y = new double[3] { 33.48, 29.05, 25.77 };

                list11.Add(x[numbcurve7++], _y[numbercurve7_2++]);
            }

            int numbcurve11 = 0;
            int numbercurve11_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 12.5, 13, 13.5 };

                double[] _y = new double[3] {4.9911, 5.4411, 5.8949 };

                list15.Add(x[numbcurve11++], _y[numbercurve11_2++]);
            }


            int numbcurve1c = 0;
            int numbercurve1c2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 12.5, 13, 13.5 };

                double[] _y = new double[3] { 856, 774, 771 };

                list_c.Add(x[numbcurve1c++], _y[numbercurve1c2++]);
            }


            myCurve7 = pane5.AddCurve("Скорость", list7, Color.DarkMagenta, SymbolType.None);
            myCurve11 = pane5.AddCurve("Геоцентрические  долгота", list11, Color.Magenta, SymbolType.None);
            myCurve15 = pane5.AddCurve("Максимальная перегрузка", list15, Color.DeepPink, SymbolType.None);
            curve_c = pane5.AddCurve("Время", list_c, Color.Violet, SymbolType.None);
            myCurve7.YAxisIndex = axis1;
            myCurve11.YAxisIndex = axis2;
            myCurve15.YAxisIndex = axis3;
            curve_c.YAxisIndex = axis4;
            myCurve7.Line.IsVisible = true;
            myCurve7.Line.IsSmooth = true;
            myCurve11.Line.IsVisible = true;
            myCurve11.Line.IsSmooth = true;
            myCurve15.Line.IsVisible = true;
            myCurve15.Line.IsSmooth = true;
            curve_c.Line.IsVisible = true;
            curve_c.Line.IsSmooth = true;
            
            myCurve11.Line.Style = DashStyle.Dash;
            myCurve15.Line.Style = DashStyle.Dot;
            curve_c.Line.Style = DashStyle.DashDot;
            myCurve7.Line.Width = 5.0f;
            myCurve11.Line.Width = 5.0f;
            myCurve15.Line.Width = 5.0f;
            curve_c.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();



        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            pane5.CurveList.Clear();
            list8 = new PointPairList();
            list12 = new PointPairList();
            list16 = new PointPairList();
            list_d = new PointPairList();


            int numbcurve4 = 0;
            int numbercurve4_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 19.5, 20, 20.5 };

                double[] _y = new double[3] { 0.4204, 0.4127, 0.4104 };

                list8.Add(x[numbcurve4++], _y[numbercurve4_2++]);
            }




            int numbcurve8 = 0;
            int numbercurve8_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 19.5, 20, 20.5 };

                double[] _y = new double[3] {10.59, 10.08, 9.6 };


                list12.Add(x[numbcurve8++], _y[numbercurve8_2++]);
            }


            int numbcurve12 = 0;
            int numbercurve12_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 19.5, 20, 20.5 };

                double[] _y = new double[3] { 11.449, 11.9143, 12.3781 };


                list16.Add(x[numbcurve12++], _y[numbercurve12_2++]);
            }

            int numbcurve1d = 0;
            int numbercurve1d2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 19.5, 20, 20.5 };

                double[] _y = new double[3] { 397, 385, 372 };


                list_d.Add(x[numbcurve1d++], _y[numbercurve1d2++]);
            }


            myCurve8 = pane5.AddCurve("Скорость", list8, Color.DarkRed, SymbolType.None);
            myCurve12 = pane5.AddCurve("Геоцентрическая  долгота", list12, Color.Red, SymbolType.None);
            myCurve16 = pane5.AddCurve("Максимальная перегрузка", list16, Color.IndianRed, SymbolType.None);
            curve_d = pane5.AddCurve("Время", list_d, Color.PaleVioletRed, SymbolType.None);

            myCurve8.YAxisIndex = axis1;
            myCurve12.YAxisIndex = axis2;
            myCurve16.YAxisIndex = axis3;
            curve_d.YAxisIndex = axis4;
            myCurve8.Line.IsVisible = true;
            myCurve8.Line.IsSmooth = true;
            myCurve12.Line.IsVisible = true;
            myCurve12.Line.IsSmooth = true;
            myCurve16.Line.IsVisible = true;
            myCurve16.Line.IsSmooth = true;
            curve_d.Line.IsVisible = true;
            curve_d.Line.IsSmooth = true;
            myCurve12.Line.Style = DashStyle.Dash;
            myCurve16.Line.Style = DashStyle.Dot;
            curve_d.Line.Style = DashStyle.DashDot;
            myCurve8.Line.Width = 5.0f;
            myCurve12.Line.Width = 5.0f;
            myCurve16.Line.Width = 5.0f;
            curve_d.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();



        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            pane5.CurveList.Clear();
            list8 = new PointPairList();
            list12 = new PointPairList();
            list16 = new PointPairList();
            list_d = new PointPairList();


            int numbcurve4 = 0;
            int numbercurve4_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 29.5, 30, 30.5 };

                double[] _y = new double[3] { 0.296, 0.2905, 0.2856 };

                list8.Add(x[numbcurve4++], _y[numbercurve4_2++]);
            }




            int numbcurve8 = 0;
            int numbercurve8_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 29.5, 30, 30.5 };

                double[] _y = new double[3] { 21.27, 20.37, 19.52 };


                list12.Add(x[numbcurve8++], _y[numbercurve8_2++]);
            }


            int numbcurve12 = 0;
            int numbercurve12_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 29.5, 30, 30.5 };

                double[] _y = new double[3] { 16.7756, 17.2132, 17.6468 };


                list16.Add(x[numbcurve12++], _y[numbercurve12_2++]);
            }

            int numbcurve1d = 0;
            int numbercurve1d2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 29.5, 30, 30.5 };

                double[] _y = new double[3] { 887, 865, 843 };


                list_d.Add(x[numbcurve1d++], _y[numbercurve1d2++]);
            }


            myCurve8 = pane5.AddCurve("Скорость", list8, Color.Gray, SymbolType.None);
            myCurve12 = pane5.AddCurve("Геоцентрическая  долгота", list12, Color.DimGray, SymbolType.None);
            myCurve16 = pane5.AddCurve("Максимальная перегрузка", list16, Color.DarkGray, SymbolType.None);
            curve_d = pane5.AddCurve("Время", list_d, Color.SlateGray, SymbolType.None);

            myCurve8.YAxisIndex = axis1;
            myCurve12.YAxisIndex = axis2;
            myCurve16.YAxisIndex = axis3;
            curve_d.YAxisIndex = axis4;
            myCurve8.Line.IsVisible = true;
            myCurve8.Line.IsSmooth = true;
            myCurve12.Line.IsVisible = true;
            myCurve12.Line.IsSmooth = true;
            myCurve16.Line.IsVisible = true;
            myCurve16.Line.IsSmooth = true;
            curve_d.Line.IsVisible = true;
            curve_d.Line.IsSmooth = true;
            myCurve12.Line.Style = DashStyle.Dash;
            myCurve16.Line.Style = DashStyle.Dot;
            curve_d.Line.Style = DashStyle.DashDot;
            myCurve8.Line.Width = 5.0f;
            myCurve12.Line.Width = 5.0f;
            myCurve16.Line.Width = 5.0f;
            curve_d.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            pane5.CurveList.Clear();
            list8 = new PointPairList();
            list12 = new PointPairList();
            list16 = new PointPairList();
            list_d = new PointPairList();


            int numbcurve4 = 0;
            int numbercurve4_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 39.5, 40, 40.5 };

                double[] _y = new double[3] { 0.4451, 0.4536, 0.6904 };

                list8.Add(x[numbcurve4++], _y[numbercurve4_2++]);
            }




            int numbcurve8 = 0;
            int numbercurve8_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 39.5, 40, 40.5 };

                double[] _y = new double[3] { 9.39, 9.05, 8.72 };


                list12.Add(x[numbcurve8++], _y[numbercurve8_2++]);
            }


            int numbcurve12 = 0;
            int numbercurve12_2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 39.5, 40, 40.5 };

                double[] _y = new double[3] { 25.3279, 25.8062, 26.2507 };


                list16.Add(x[numbcurve12++], _y[numbercurve12_2++]);
            }

            int numbcurve1d = 0;
            int numbercurve1d2 = 0;

            for (double z = 0; z <= 2; z++)
            {

                double[] x = new double[3] { 39.5, 40, 40.5 };

                double[] _y = new double[3] { 536, 526, 517 };


                list_d.Add(x[numbcurve1d++], _y[numbercurve1d2++]);
            }


            myCurve8 = pane5.AddCurve("Скорость", list8, Color.Coral, SymbolType.None);
            myCurve12 = pane5.AddCurve("Геоцентрическая  долгота", list12, Color.Tomato, SymbolType.None);
            myCurve16 = pane5.AddCurve("Максимальная перегрузка", list16, Color.Lime, SymbolType.None);
            curve_d = pane5.AddCurve("Время", list_d, Color.Firebrick, SymbolType.None);

            myCurve8.YAxisIndex = axis1;
            myCurve12.YAxisIndex = axis2;
            myCurve16.YAxisIndex = axis3;
            curve_d.YAxisIndex = axis4;
            myCurve8.Line.IsVisible = true;
            myCurve8.Line.IsSmooth = true;
            myCurve12.Line.IsVisible = true;
            myCurve12.Line.IsSmooth = true;
            myCurve16.Line.IsVisible = true;
            myCurve16.Line.IsSmooth = true;
            curve_d.Line.IsVisible = true;
            curve_d.Line.IsSmooth = true;
            myCurve12.Line.Style = DashStyle.Dash;
            myCurve16.Line.Style = DashStyle.Dot;
            curve_d.Line.Style = DashStyle.DashDot;
            myCurve8.Line.Width = 5.0f;
            myCurve12.Line.Width = 5.0f;
            myCurve16.Line.Width = 5.0f;
            curve_d.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }


    }
}
