using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing.Drawing2D;

namespace Flying
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        PointPairList list5, list6, list7, list8, list9, list10, list11, list12, list13, list14, list15, list16;
        LineItem myCurve5, myCurve6, myCurve7, myCurve8, myCurve9, myCurve10, myCurve11, myCurve12, myCurve13, myCurve14, myCurve15, myCurve16;
        GraphPane pane5;

        private void Form2_Load(object sender, EventArgs e)
        {
            pane5 = zedGraphControl5.GraphPane;

            pane5.Title.Text = "";
          
            pane5.XAxis.Scale.MajorStep = 5.0;

           
            pane5.XAxis.Scale.MinorStep = 1.0;

         
            pane5.YAxis.Scale.MajorStep = 0.5;

       
            pane5.YAxis.Scale.MinorStep = 0.1;


            pane5.YAxisList.Clear();

        
            int axis1 = pane5.AddYAxis("Конечная скорость, км/с");
            int axis2 = pane5.AddYAxis("Максимальная перегрузка");
            int axis3 = pane5.AddYAxis("Время, сек");
           
           
            pane5.YAxisList[axis1].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis2].Title.FontSpec.FontColor = Color.Black;
            pane5.YAxisList[axis3].Title.FontSpec.FontColor = Color.Black;

            pane5.XAxis.Title.Text = "Угол наклона вектора скорости к местному горизонту, градусы";

            pane5 = zedGraphControl5.GraphPane;

            pane5.XAxis.MajorGrid.IsVisible = true;
            pane5.YAxis.MajorGrid.IsVisible = true;

            list5 = new PointPairList();
            list6 = new PointPairList();
            list7 = new PointPairList();
            list8 = new PointPairList();
            list9 = new PointPairList();
            list10 = new PointPairList();
            list11 = new PointPairList();
            list12 = new PointPairList();
            list13 = new PointPairList();
            list14 = new PointPairList();
            list15 = new PointPairList();
            list16 = new PointPairList();

            int numbcurve1 = 0;
            int numbercurve1_2 = 0;

            for (double z = 0; z <= 22; z++)
            {

                double[] x = new double[23] { 6, 7, 8, 9, 
                        10, 11, 12, 13, 14, 15,
                        16, 17, 18, 19, 20, 
                        21,22,23,24,25,26,27,28};

                double[] _y = new double[23] { 1.4893, 1.5722, 1.715, 1.8398, 1.9102, 
                        1.9412, 2.0661, 2.0993, 2.1204, 2.2477, 2.3142, 
                        2.2903, 2.3265, 2.4202, 2.5712, 2.5727,2.6124, 2.6893, 
                        2.8031, 2.7144, 2.8913, 2.8489, 2.826
                        };

                list5.Add(x[numbcurve1++], _y[numbercurve1_2++]);
            }

            int numbcurve2 = 0;
            int numbercurve2_2 = 0;

            for (double z = 0; z <= 27; z++)
            {

                double[] x = new double[28] { 8, 9, 10, 11, 12, 13,
                        14, 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 26, 27, 
                        28,29,30,31,32,33,34,35 };

                double[] _y = new double[28] { 0.5175, 0.5135, 0.5149, 0.5418, 0.5916, 
                        0.6626, 0.7463, 0.8362, 0.9571, 1.0683, 1.2171,
                        1.3488, 1.4243, 1.5472, 1.5472, 1.6432, 1.8733, 
                        1.9987, 2.0324, 2.2368, 2.3318, 2.2836, 2.4263,
                        2.409, 2.6072, 2.6237, 2.6545, 2.6999};

                list6.Add(x[numbcurve2++], _y[numbercurve2_2++]);
            }

            int numbcurve3 = 0;
            int numbercurve3_2 = 0;

            for (double z = 0; z <= 26; z++)
            {

                double[] x = new double[27] { 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 
                        26, 27, 28, 29, 30, 
                        31, 32,33,34,35,36,37,38,39,40,41 };

                double[] _y = new double[27] { 0.3584, 0.3465, 0.336, 0.328, 0.3271,
                        0.3365, 0.3552, 0.3774, 0.4012, 0.4182,
                        0.4254, 0.4272, 0.4259, 0.4242, 0.4142, 
                        0.4066, 0.3977, 0.3761, 0.3874, 0.3657, 
                        0.3544, 0.3437, 0.3322, 0.3218, 0.3101, 2.0805, 2.2613};

                list7.Add(x[numbcurve3++], _y[numbercurve3_2++]);
            }

            int numbcurve4 = 0;
            int numbercurve4_2 = 0;

            for (double z = 0; z <= 4; z++)
            {

                double[] x = new double[5] { 43, 44, 45, 46, 47 };

                double[] _y = new double[5] { 0.2385, 0.235, 0.2411, 0.3024, 0.4551 };

                list8.Add(x[numbcurve4++], _y[numbercurve4_2++]);
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

            int numbcurve8 = 0;
            int numbercurve8_2 = 0;

            for (double z = 0; z <= 4; z++)
            {

                double[] x = new double[5] { 43, 44, 45, 46, 47 };

                double[] _y = new double[5] { 26.6595, 27.4626, 28.3453, 29.1154, 29.9164 };


                list12.Add(x[numbcurve8++], _y[numbercurve8_2++]);
            }

            int numbcurve9= 0;
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

            int numbcurve12 = 0;
            int numbercurve12_2 = 0;

            for (double z = 0; z <= 4; z++)
            {

                double[] x = new double[5] { 43, 44, 45, 46, 47 };

                double[] _y = new double[5] { 798, 764, 727, 672, 618};


                list16.Add(x[numbcurve12++], _y[numbercurve12_2++]);
            }



            myCurve5 = pane5.AddCurve("Кб = -0.5", list5, Color.DarkGreen, SymbolType.None);

            myCurve6 = pane5.AddCurve("Кб = 0", list6, Color.DarkBlue, SymbolType.None);

            myCurve7 = pane5.AddCurve("Кб = 0.5", list7, Color.DarkMagenta, SymbolType.None);

            myCurve8 = pane5.AddCurve("Кб = 1", list8, Color.DarkRed, SymbolType.None);

            myCurve9 = pane5.AddCurve("Кб = -0.5", list9, Color.Green, SymbolType.None);

            myCurve10 = pane5.AddCurve("Кб = 0", list10, Color.Blue, SymbolType.None);

            myCurve11 = pane5.AddCurve("Кб = 0.5", list11, Color.Magenta, SymbolType.None);

            myCurve12 = pane5.AddCurve("Кб = 1", list12, Color.Red, SymbolType.None);

            myCurve13 = pane5.AddCurve("Кб = -0.5", list13, Color.LightGreen, SymbolType.None);

            myCurve14 = pane5.AddCurve("Кб = 0", list14, Color.LightBlue, SymbolType.None);

            myCurve15 = pane5.AddCurve("Кб = 0.5", list15, Color.LightPink, SymbolType.None);

            myCurve16 = pane5.AddCurve("Кб = 1", list16, Color.Brown, SymbolType.None);


            myCurve5.YAxisIndex = axis1;
            myCurve6.YAxisIndex = axis1;
            myCurve7.YAxisIndex = axis1;
            myCurve8.YAxisIndex = axis1;
            myCurve9.YAxisIndex = axis2;
            myCurve10.YAxisIndex = axis2;
            myCurve11.YAxisIndex = axis2;
            myCurve12.YAxisIndex = axis2;
            myCurve13.YAxisIndex = axis3;
            myCurve14.YAxisIndex = axis3;
            myCurve15.YAxisIndex = axis3;
            myCurve16.YAxisIndex = axis3;


         //   myCurve9.YAxisIndex = axis2;

          

       
            myCurve5.Line.IsVisible = true;

            myCurve5.Line.IsSmooth = true;

            myCurve6.Line.IsVisible = true;

            myCurve6.Line.IsSmooth = true;

            myCurve7.Line.IsVisible = true;

            myCurve7.Line.IsSmooth = true;

            myCurve8.Line.IsVisible = true;

            myCurve8.Line.IsSmooth = true;

            myCurve9.Line.IsVisible = true;

            myCurve9.Line.IsSmooth = true;

            myCurve10.Line.IsVisible = true;

            myCurve10.Line.IsSmooth = true;

            myCurve11.Line.IsVisible = true;

            myCurve11.Line.IsSmooth = true;

            myCurve12.Line.IsVisible = true;

            myCurve12.Line.IsSmooth = true;

            myCurve13.Line.IsVisible = true;

            myCurve13.Line.IsSmooth = true;

            myCurve14.Line.IsVisible = true;

            myCurve14.Line.IsSmooth = true;

            myCurve15.Line.IsVisible = true;

            myCurve15.Line.IsSmooth = true;

            myCurve16.Line.IsVisible = true;

            myCurve16.Line.IsSmooth = true;


            myCurve9.Line.Style = DashStyle.Dash;
            myCurve10.Line.Style = DashStyle.Dash;
            myCurve11.Line.Style = DashStyle.Dash;
            myCurve12.Line.Style = DashStyle.Dash;
            myCurve13.Line.Style = DashStyle.Dot;
            myCurve14.Line.Style = DashStyle.Dot;
            myCurve15.Line.Style = DashStyle.Dot;
            myCurve16.Line.Style = DashStyle.Dot;



            myCurve5.Line.Width = 5.0f;
            myCurve6.Line.Width = 5.0f;
            myCurve7.Line.Width = 5.0f;
            myCurve8.Line.Width = 5.0f;
            myCurve9.Line.Width = 5.0f;
            myCurve10.Line.Width = 5.0f;
            myCurve11.Line.Width = 5.0f;
            myCurve12.Line.Width = 5.0f;
            myCurve13.Line.Width = 5.0f;
            myCurve14.Line.Width = 5.0f;
            myCurve15.Line.Width = 5.0f;
            myCurve16.Line.Width = 5.0f;



            zedGraphControl5.AxisChange();




            //double xend = 26.0;
            //double yend = 2.8;


            //double xstart = xend + 5.0;
            //double ystart = yend + 0.1;


            //ArrowObj arrow = new ArrowObj(xstart, ystart, xend, yend);

            //pane5.GraphObjList.Add(arrow);


            //TextObj text = new TextObj("Кб= -0,5", xstart, ystart);


            //text.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text);

            //double xend7 = 11.0;
            //double yend7 = 0.2;


            //double xstart7 = xend + 5.0;
            //double ystart7 = yend + 0.1;


            //ArrowObj arrow7 = new ArrowObj(xstart7, ystart7, xend7, yend7);

            //pane5.GraphObjList.Add(arrow7);


            //TextObj text7 = new TextObj("Кб= -0,5", xstart7, ystart7);


            //text7.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text7);

            //double xend9 = 24.0;
            //double yend9 = 2.7;


            //double xstart9 = xend + 5.0;
            //double ystart9 = yend + 0.1;


            //ArrowObj arrow9 = new ArrowObj(xstart9, ystart9, xend9, yend9);

            //pane5.GraphObjList.Add(arrow9);


            //TextObj text9 = new TextObj("Кб= -0,5", xstart9, ystart9);


            //text9.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text9);

            //double xend2 = 35.0;
            //double yend2 = 3.0;


            //double xstart2 = xend + 10.0;
            //double ystart2 = yend + 0.5;


            //ArrowObj arrow2 = new ArrowObj(xstart2, ystart2, xend2, yend2);

            //pane5.GraphObjList.Add(arrow2);


            //TextObj text2 = new TextObj("Кб= 0", xstart2, ystart2);


            //text2.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text2);

            //double xend8 = 35.0;
            //double yend8 = 2.6;


            //double xstart8 = xend + 10.0;
            //double ystart8 = yend + 0.5;


            //ArrowObj arrow8 = new ArrowObj(xstart8, ystart8, xend8, yend8);

            //pane5.GraphObjList.Add(arrow8);


            //TextObj text8 = new TextObj("Кб= 0", xstart8, ystart8);


            //text8.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text8);

            //double xend10 = 35.0;
            //double yend10 = 0.1;


            //double xstart10 = xend + 10.0;
            //double ystart10 = yend + 0.5;


            //ArrowObj arrow10 = new ArrowObj(xstart10, ystart10, xend10, yend10);

            //pane5.GraphObjList.Add(arrow10);


            //TextObj text10 = new TextObj("Кб= 0", xstart10, ystart10);


            //text10.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text10);


            //double xend3 = 41.0;
            //double yend3 = 2.9;


            //double xstart3 = xend + 15.0;
            //double ystart3 = yend + 0.5;


            //ArrowObj arrow3 = new ArrowObj(xstart3, ystart3, xend3, yend3);

            //pane5.GraphObjList.Add(arrow3);


            //TextObj text3 = new TextObj("Кб= 0,5", xstart3, ystart3);


            //text3.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text3);

            //double xend4 = 40.0;
            //double yend4 = 1.5;


            //double xstart4 = xend + 15.0;
            //double ystart4 = yend + 0.5;


            //ArrowObj arrow4 = new ArrowObj(xstart4, ystart4, xend4, yend4);

            //pane5.GraphObjList.Add(arrow4);


            //TextObj text4 = new TextObj("Кб= 0,5", xstart4, ystart4);


            //text4.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text4);

            //double xend11 = 37.0;
            //double yend11= 0.7;


            //double xstart11 = xend + 15.0;
            //double ystart11 = yend + 0.5;


            //ArrowObj arrow11 = new ArrowObj(xstart11, ystart11, xend11, yend11);

            //pane5.GraphObjList.Add(arrow11);


            //TextObj text11 = new TextObj("Кб= 0,5", xstart11, ystart11);


            //text4.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text11);


            //double xend5 = 45.0;
            //double yend5 = 2.8;


            //double xstart5 = xend5 + 2.0;
            //double ystart5 = yend5 + 0.2;


            //ArrowObj arrow5 = new ArrowObj(xstart5, ystart5, xend5, yend5);

            //pane5.GraphObjList.Add(arrow5);


            //TextObj text5 = new TextObj("Кб= 1", xstart5, ystart5);


            //text5.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text5);


            //double xend6 = 45.0;
            //double yend6 = 0.3;


            //double xstart6 = xend5 + 2.0;
            //double ystart6 = yend5 + 0.2;


            //ArrowObj arrow6 = new ArrowObj(xstart6, ystart6, xend6, yend6);

            //pane5.GraphObjList.Add(arrow6);


            //TextObj text6 = new TextObj("Кб= 1", xstart6, ystart6);


            //text6.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text6);

            //double xend12 = 45.0;
            //double yend12 = 1.8;


            //double xstart12 = xend5 + 2.0;
            //double ystart12 = yend5 + 0.2;


            //ArrowObj arrow12 = new ArrowObj(xstart12, ystart12, xend12, yend12);

            //pane5.GraphObjList.Add(arrow12);


            //TextObj text12 = new TextObj("Кб= 1", xstart12, ystart12);


            //text12.FontSpec.Border.IsVisible = false;


            //pane5.GraphObjList.Add(text12);





            zedGraphControl5.Invalidate();

        }





    }
}
