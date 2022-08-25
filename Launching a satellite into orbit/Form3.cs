using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing.Drawing2D;

namespace Flying
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        PointPairList list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16, deltalist;
        LineItem myCurve5, myCurve6, myCurve7, myCurve8, myCurve9, myCurve10, myCurve11, myCurve12, myCurve13, myCurve14, myCurve15, myCurve16, deltacurve;
        GraphPane pane5;

        int axis1;
        int axis2;
        int axis3;

        private void Form3_Load(object sender, EventArgs e)
        {
            pane5 = zedGraphControl1.GraphPane;

            pane5.Title.Text = "";

            pane5.XAxis.Scale.MajorStep = 5.0;


            pane5.XAxis.Scale.MinorStep = 1.0;


            pane5.YAxis.Scale.MajorStep = 0.5;


            pane5.YAxis.Scale.MinorStep = 0.1;


            pane5.YAxisList.Clear();


            axis1 = pane5.AddYAxis("Vk, км/с");
            axis2 = pane5.AddYAxis("nmax");
            axis3 = pane5.AddYAxis("t, сек");

            //pane5.XAxis.MajorTic.IsOpposite = false;
            //pane5.XAxis.MinorTic.IsOpposite = false;
            //pane5.YAxis.MajorTic.IsOpposite = false;
            //pane5.YAxis.MinorTic.IsOpposite = false;


            pane5.YAxisList[axis1].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis2].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis3].Title.FontSpec.FontColor = Color.Black;

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
                int numbcurve1 = 0;
                int numbercurve1_2 = 0;

                for (double z = 0; z <= 4; z++)
                {

                    double[] x = new double[5] { 6,  12, 18, 22,28};

                    double[] _y = new double[5] { 1.4893, 
                         2.0661,  2.4265,  2.6893, 
                          2.826
                        };

                    list5.Add(x[numbcurve1++], _y[numbercurve1_2++]);
                }

                int numbcurve5 = 0;
                int numbercurve5_2 = 0;

                for (double z = 0; z <= 22; z++)
                {

                    double[] x = new double[23] { 6, 7, 8, 9, 
                        10, 11, 12, 13, 14, 15,
                        16, 17, 18, 19, 20, 
                        21,22,23,24,25,26,27,28 };

                    double[] _y = new double[23] { 6.3844, 10.0834, 11.6371, 12.8776, 13.9913, 
                        15.0374, 16.0296, 16.1409, 17.0112, 17.953, 
                        18.8938, 19.8173, 20.7357, 21.6455, 22.5244, 
                        23.4427, 24.3255, 25.2086, 26.0883, 26.9217, 
                        27.8221, 28.6271, 29.5141};

                    list9.Add(x[numbcurve5++], _y[numbercurve5_2++]);
                }

                int numbcurve9 = 0;
                int numbercurve9_2 = 0;

                for (double z = 0; z <= 22; z++)
                {

                    double[] x = new double[23] { 6, 7, 8, 9, 
                        10, 11, 12, 13, 14, 15,
                        16, 17, 18, 19, 20, 
                        21,22,23,24,25,26,27,28 };

                    double[] _y = new double[23] { 205,155, 129, 112, 
                        100, 91, 83, 77, 67, 63,
                        63, 60, 57, 54, 51, 
                        49,47,45,43,42,40,39,38};

                    list13.Add(x[numbcurve9++], _y[numbercurve9_2++]);
                }


                myCurve5 = pane5.AddCurve("Скорость", list5, Color.Black, SymbolType.None);
                myCurve9 = pane5.AddCurve("Перегрузка", list9, Color.Black, SymbolType.None);
                myCurve13 = pane5.AddCurve("Время", list13, Color.Black, SymbolType.None);
                myCurve5.YAxisIndex = axis1;
                myCurve9.YAxisIndex = axis2;
                myCurve13.YAxisIndex = axis3;
                myCurve5.Line.IsVisible = true;
                myCurve5.Line.IsSmooth = true;
                myCurve9.Line.IsVisible = true;
                myCurve9.Line.IsSmooth = true;
                myCurve13.Line.IsVisible = true;
                myCurve13.Line.IsSmooth = true;
                myCurve9.Line.Style = DashStyle.Dash;
                myCurve13.Line.Style = DashStyle.Dot;
                myCurve5.Line.Width = 5.0f;
                myCurve9.Line.Width = 5.0f;
                myCurve13.Line.Width = 5.0f;

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();

            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
                pane5.CurveList.Clear();

                list6 = new PointPairList();
                list10 = new PointPairList();
                list14 = new PointPairList();

                int numbcurve2 = 0;
                int numbercurve2_2 = 0;

                for (double z = 0; z <= 6; z++)
                {

                    double[] x = new double[7] { 8,  12, 
                        16,  22,  26, 32, 35 };

                    double[] _y = new double[7] { 0.5175, 
                         0.6571,  0.9432,  1.2368, 
                        1.409, 1.6072,  1.6999};

                    list6.Add(x[numbcurve2++], _y[numbercurve2_2++]);
                }


                int numbcurve6 = 0;
                int numbercurve6_2 = 0;

                for (double z = 0; z <= 27; z++)
                {

                    double[] x = new double[28] {8, 9, 10, 11, 12, 13,
                        14, 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 26, 27, 
                        28,29,30,31,32,33,34,35};

                    double[] _y = new double[28] { 2.4047, 3.7139, 4.9978, 6.2071, 7.3572, 
                        8.466, 9.5408, 10.5945, 11.6265, 12.6463, 
                        13.652, 14.6387, 15.6316, 16.6098, 17.5769, 
                        18.5248, 19.4996, 20.4295, 21.385, 22.3311, 
                        23.2632, 24.1882, 25.1082,  26.0198, 26.9128,
                        27.7688, 28.6986, 29.6036};

                    list10.Add(x[numbcurve6++], _y[numbercurve6_2++]);
                }

                int numbcurve10 = 0;
                int numbercurve10_2 = 0;

                for (double z = 0; z <= 27; z++)
                {

                    double[] x = new double[28] {8, 9, 10, 11, 12, 13,
                        14, 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 26, 27, 
                        28,29,30,31,32,33,34,35};

                    double[] _y = new double[28] { 416, 299, 240, 201, 171, 147,
                        128, 113, 100, 90, 81, 74, 69,
                        60, 56, 53, 50, 48, 45, 43, 
                        42,40,39,37,36,35,34,33};

                    list14.Add(x[numbcurve10++], _y[numbercurve10_2++]);
                }

                myCurve6 = pane5.AddCurve("Скорость", list6, Color.Black, SymbolType.None);
                myCurve10 = pane5.AddCurve("Перегрузка", list10, Color.Black, SymbolType.None);
                myCurve14 = pane5.AddCurve("Время", list14, Color.Black, SymbolType.None);
                myCurve6.YAxisIndex = axis1;
                myCurve10.YAxisIndex = axis2;
                myCurve14.YAxisIndex = axis3;
                myCurve6.Line.IsVisible = true;
                myCurve6.Line.IsSmooth = true;
                myCurve10.Line.IsVisible = true;
                myCurve10.Line.IsSmooth = true;
                myCurve14.Line.IsVisible = true;
                myCurve14.Line.IsSmooth = true;
                myCurve10.Line.Style = DashStyle.Dash;
                myCurve14.Line.Style = DashStyle.Dot;
                myCurve6.Line.Width = 5.0f;
                myCurve10.Line.Width = 5.0f;
                myCurve14.Line.Width = 5.0f;

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();

            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
                pane5.CurveList.Clear();
                list7 = new PointPairList();
                list11 = new PointPairList();
                list15 = new PointPairList();


                int numbcurve3 = 0;
                int numbercurve3_2 = 0;

                for (double z = 0; z <= 5; z++)
                {

                    double[] x = new double[6] { 15,  20,
                          
                        26,  
                        31, 36,41 };

                    double[] _y = new double[6] { 0.3584,
                        0.3700, 
                         
                        0.4066,  
                        0.3544, 0.3437, 2.2613};

                    list7.Add(x[numbcurve3++], _y[numbercurve3_2++]);
                }

                int numbcurve7 = 0;
                int numbercurve7_2 = 0;

                for (double z = 0; z <= 26; z++)
                {

                    double[] x = new double[27] { 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 
                        26, 27, 28, 29, 30, 
                        31, 32,33,34,35,36,37,38,39,40,41};

                    double[] _y = new double[27] { 6.3533, 7.2078, 8.0707, 8.9461, 9.8284, 
                        10.7131, 11.6054, 12.5053, 13.3961,14.2999, 
                        15.2066, 16.1081, 17.0087, 17.9113,18.8161, 
                        19.7202, 20.6158, 21.4899, 22.3937, 23.3075, 
                        24.1668, 25.0677, 25.9572, 26.8041, 27.7126, 28.5397, 29.4355 };

                    list11.Add(x[numbcurve7++], _y[numbercurve7_2++]);
                }

                int numbcurve11 = 0;
                int numbercurve11_2 = 0;

                for (double z = 0; z <= 26; z++)
                {

                    double[] x = new double[27] { 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 
                        26, 27, 28, 29, 30, 
                        31, 32,33,34,35,36,37,38,39,40,41};

                    double[] _y = new double[27] {1118, 971, 865, 783, 715, 656,
                        605, 562, 494, 468, 
                        468, 445, 424, 404, 387, 
                        370, 354,339,325,311,298,285,273,260,249,36,34 };

                    list15.Add(x[numbcurve11++], _y[numbercurve11_2++]);
                }


                myCurve7 = pane5.AddCurve("Скорость", list7, Color.Black, SymbolType.None);
                myCurve11 = pane5.AddCurve("Перегрузка", list11, Color.Black, SymbolType.None);
                myCurve15 = pane5.AddCurve("Время", list15, Color.Black, SymbolType.None);
                myCurve7.YAxisIndex = axis1;
                myCurve11.YAxisIndex = axis2;
                myCurve15.YAxisIndex = axis3;
                myCurve7.Line.IsVisible = true;
                myCurve7.Line.IsSmooth = true;
                myCurve11.Line.IsVisible = true;
                myCurve11.Line.IsSmooth = true;
                myCurve15.Line.IsVisible = true;
                myCurve15.Line.IsSmooth = true;
                myCurve11.Line.Style = DashStyle.Dash;
                myCurve15.Line.Style = DashStyle.Dot;
                myCurve7.Line.Width = 5.0f;
                myCurve11.Line.Width = 5.0f;
                myCurve15.Line.Width = 5.0f;

                zedGraphControl1.AxisChange();
                zedGraphControl1.Invalidate();


            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

            pane5.CurveList.Clear();
            list8 = new PointPairList();
            list12 = new PointPairList();
            list16 = new PointPairList();


            int numbcurve4 = 0;
            int numbercurve4_2 = 0;

            for (double z = 0; z <= 4; z++)
            {

                double[] x = new double[5] { 43, 44, 45, 46, 47 };

                double[] _y = new double[5] { 0.2385, 0.235, 0.2411, 0.3024, 0.4551 };

                list8.Add(x[numbcurve4++], _y[numbercurve4_2++]);
            }




            int numbcurve8 = 0;
            int numbercurve8_2 = 0;

            for (double z = 0; z <= 4; z++)
            {

                double[] x = new double[5] { 43, 44, 45, 46, 47 };

                double[] _y = new double[5] { 26.6595, 27.4626, 28.3453, 29.1154, 29.9164 };


                list12.Add(x[numbcurve8++], _y[numbercurve8_2++]);
            }


            int numbcurve12 = 0;
            int numbercurve12_2 = 0;

            for (double z = 0; z <= 4; z++)
            {

                double[] x = new double[5] { 43, 44, 45, 46, 47 };

                double[] _y = new double[5] { 798, 764, 727, 672, 618 };


                list16.Add(x[numbcurve12++], _y[numbercurve12_2++]);
            }

            myCurve8 = pane5.AddCurve("Скорость", list8, Color.Black, SymbolType.None);
            myCurve12 = pane5.AddCurve("Перегрузка", list12, Color.Black, SymbolType.None);
            myCurve16 = pane5.AddCurve("Время", list16, Color.Black, SymbolType.None);
            myCurve8.YAxisIndex = axis1;
            myCurve12.YAxisIndex = axis2;
            myCurve16.YAxisIndex = axis3;
            myCurve8.Line.IsVisible = true;
            myCurve8.Line.IsSmooth = true;
            myCurve12.Line.IsVisible = true;
            myCurve12.Line.IsSmooth = true;
            myCurve16.Line.IsVisible = true;
            myCurve16.Line.IsSmooth = true;
            myCurve12.Line.Style = DashStyle.Dash;
            myCurve16.Line.Style = DashStyle.Dot;
            myCurve8.Line.Width = 5.0f;
            myCurve12.Line.Width = 5.0f;
            myCurve16.Line.Width = 5.0f;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();


            
        }

   



    }
}
