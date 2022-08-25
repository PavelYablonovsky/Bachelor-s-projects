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
using System.Threading;



namespace Flying
{
    public partial class         Form1 : Form
    {

        int _i;

        public Form1()
        {
            InitializeComponent();
            //ComboBoxKA.SelectedIndex = 0;
          //  EditKb.Enabled = false;
         //   EditPx.Enabled = false;
            massa.Enabled = false;
            acceleration.Enabled = false;
            LoadGraph();
            _i = 0;

            

           
        }
        int tickstart, intmode = 1;
        double Time;

        double soft_landing;

        string writeTo;

        public static int edit_px;

        PointPairList list5 , list6, list7, list8, list9, list10, list11, list12;
        LineItem myCurve5, myCurve6, myCurve7, myCurve8, myCurve9, myCurve10, myCurve11, myCurve12;
       // GraphPane pane5, pane6;

        double M // произведение постоянной притяжения Венеры
        , R // экваториальный радиус Венеры
        , r // 
        , Px // приведенная  нагрузка  на  лобовую  поверхность  КА
        , b// логарифмический коэффициент изменения плотности атмосферы от высоты  для Венеры
        , Kb // аэродинамическое качество
        , y // угол  крена
        , y_n // угол  крена начальный
        , y_k // угол крена конечный
        , ro // плотность атмосферы
        , ro0 // начальная плотность атмосферы
        , n // перегрузка
        , g
        , alpha // угол атаки
        , cx, cy, // аэродинамические  коэффициенты  лобового  сопротивления и подъемной силы
         Q, // постоянная Стефана Больцмана
	 V1, // первая космическая скорость Марса
	 ech,//  коэффициент, характеризующий излучательную способность материала теплозащитного покрытия 
	 Ak,  // коэфф. для конвекционного теплового потока 
	 Ar,  // коэфф. для радиационного теплового потока
	 Rk; // радиус кривизны поверхности КА;
        
        double Temperature;// Температура КА    
        double q_konv;// конвективный теплопоток        
        double q_rad;// радиационный теплопоток
        // масса КА , используется при рассчете Px
        // масса КА = 2000

       
        double [] n_array, temp_array;

    double[] _pV, _pQ, _pE, _pH, _pA, _pF, _T;

double dVdt(double pV, double pQ) {
	return -(ro * pV * pV) / (2 * Px) - (M / Math.Pow(r, 2)) * Math.Sin(pQ);
}

double dQdt(double pV, double pQ) {
	return ((ro * pV * Kb) / (2 * Px)) * Math.Cos(y) - (M / (Math.Pow(r, 2) * pV)) * Math.Cos(pQ) + (pV / r) * Math.Cos(pQ);
}

double dEdt(double pV, double pQ, double pE, double pF) {
	return ((ro * pV * Kb) / (2 * Px * Math.Cos(pQ))) * Math.Sin(y) - (pV / r) * Math.Cos(pQ) * Math.Cos(pE) * Math.Tan(pF);
}

double dHdt(double pV, double pQ) {
	return pV*Math.Sin(pQ);
}

double dAdt(double pV, double pQ, double pE, double pF) {
	return (pV / R) * ((Math.Cos(pQ) * Math.Cos(pE)) / Math.Cos(pF));
}

double dFdt(double pV, double pQ, double pE) {
	return (pV / r) * Math.Cos(pQ) * Math.Sin(pE);
}

//double Cx(double a)
//{
//    if (ComboBoxKA.SelectedIndex == 0) {
        

//        return 0.2 + 2.3 * Math.Pow(Math.Sin(1.125 * a + (5.625 / (180 / Math.PI))), 2); // несущий корпус
//    }
//    else if (ComboBoxKA.SelectedIndex == 1) {
//        return 1.8 * Math.Pow(Math.Sin(a - (5 / (180 / Math.PI))),2); // космический самолет
//    }
//    else {
//        return 0;
//    }

//}

//double Cy(double a)
//{
//    if (ComboBoxKA.SelectedIndex == 0)
//    {
//        return -0.1 + 2.3 * Math.Sin(1.125 * a + (5.625 / (180 / Math.PI))) * Math.Cos(1.125 * a + (5.625 / (180 / Math.PI)));// несущий корпус
//    }
//    else if (ComboBoxKA.SelectedIndex == 1)
//    {
//        return 1.3 * Math.Sin(a - (5 / (180 / Math.PI))) * Math.Cos(a- (5 / (180 / Math.PI))); // космический самолет
//    }
//    else
//    {
//        return 0;
//    }
//}


        private void LoadGraph()
        {
            GraphPane pane = zedGraph.GraphPane;
            GraphPane pane2 = zedGraphControl1.GraphPane;
            GraphPane pane3 = zedGraphControl2.GraphPane;
            GraphPane pane4 = zedGraphControl3.GraphPane;
            GraphPane pane_temp = zedGraphControl6.GraphPane;
         
            GraphPane pane_n = zedGraphControl7.GraphPane;
            


          //  GraphPane scrollpane = zedGraphControl4.GraphPane;
            //scrollpane.Title.Text = "Движение КА";
            //scrollpane.XAxis.Title.Text = "Ось X: Время t сек";
            //scrollpane.YAxis.Title.Text = "Ось Y: Высота V км";
            //RollingPointPairList rollList = new RollingPointPairList(60000);
            //LineItem rollCurve = scrollpane.AddCurve("V", rollList, Color.Orange,SymbolType.None);

            //scrollpane.XAxis.Scale.Min = 0;
            //scrollpane.XAxis.Scale.Max = 30;
            //scrollpane.XAxis.Scale.MinorStep = 1;
            //scrollpane.XAxis.Scale.MajorStep = 5;

        //    zedGraphControl4.AxisChange();

            tickstart = Environment.TickCount;

            pane.XAxis.Title.Text = "Ось X: Время t, сек";
            pane.YAxis.Title.Text = "Ось Y: Скорость V, км/с";
            pane2.XAxis.Title.Text = "Ось X: Время t, сек";
            pane2.YAxis.Title.Text = "Ось Y: Высота h, км";
            pane3.XAxis.Title.Text = "Ось X: Высота h, км";
            pane3.YAxis.Title.Text = "Ось Y: Плотность ro, кг/м3";
            pane4.XAxis.Title.Text = "Ось X: Время t, сек";
            pane4.YAxis.Title.Text = "Ось Y: Угол наклона ветора скорости к местному горизонту theta, град";
          //  pane5.XAxis.Title.Text = "Ось X: Угол наклона вектора скорости к местному горизонту";
            //pane5.YAxis.Title.Text = "Ось Y: Конечаня скорость";
           // pane6.XAxis.Title.Text = "Ось X: Угол наклона вектора скорости к местному горизонту";
           // pane6.YAxis.Title.Text = "Ось Y: Максимальная перегрузка";
            pane_temp.XAxis.Title.Text = "Ось Х: время t, сек";
            pane_temp.YAxis.Title.Text = "Ось Y: температура, K";
            pane_n.XAxis.Title.Text = "Ось Х: время t, сек";
            pane_n.YAxis.Title.Text = "Ось Y: перегрузка";


            pane.Title.Text = "График скорости КА";
            pane.Title.FontSpec.IsBold = true;
            pane2.Title.Text = "График высоты полета КА над поверхностью Марса";
            pane2.Title.FontSpec.IsBold = true;
            pane3.Title.Text = "График плотности атмосферы";
            pane3.Title.FontSpec.IsBold = true;
            pane4.Title.Text = "График угла наклона вектора скорости к местному горизонту";
            pane4.Title.FontSpec.IsBold = true;
            pane_temp.Title.Text = "График температуры КА";
            pane_temp.Title.FontSpec.IsBold = true;
            pane_n.Title.Text = "График перегрузки";
            pane_n.Title.FontSpec.IsBold = true;

            //pane5.XAxis.Scale.Min = 0;
            //pane5.XAxis.Scale.Max = 1.2;
            //pane5.YAxis.Scale.Min = -1;
            //pane5.YAxis.Scale.Max = 1;
            //pane6.XAxis.Scale.Min = 0;
            //pane6.XAxis.Scale.Max = -0.7;
        

        }



private void Button1Click(object sender, EventArgs e)
        {
            try
            {
                diag.Items.Clear();
                    soft_landing = 0;

             //   zedGraphControl4.GraphPane.CurveList[0].Clear();

                StringGrid1.Rows.Clear();

                //timer1.Start();

                GraphPane pane = zedGraph.GraphPane;
                GraphPane pane2 = zedGraphControl1.GraphPane;
                GraphPane pane3 = zedGraphControl2.GraphPane;
                GraphPane pane4 = zedGraphControl3.GraphPane;
              

                GraphPane temp_pane = zedGraphControl6.GraphPane;
                GraphPane temp_n = zedGraphControl7.GraphPane;


                pane.XAxis.MajorGrid.IsVisible = true;
                pane.YAxis.MajorGrid.IsVisible = true;

                pane2.XAxis.MajorGrid.IsVisible = true;
                pane2.YAxis.MajorGrid.IsVisible = true;

                pane3.XAxis.MajorGrid.IsVisible = true;
                pane3.YAxis.MajorGrid.IsVisible = true;

                pane4.XAxis.MajorGrid.IsVisible = true;
                pane4.YAxis.MajorGrid.IsVisible = true;

                //pane5.XAxis.MajorGrid.IsVisible = true;
                //pane5.YAxis.MajorGrid.IsVisible = true;

                //pane6.XAxis.MajorGrid.IsVisible = true;
                //pane6.YAxis.MajorGrid.IsVisible = true;


                temp_pane.XAxis.MajorGrid.IsVisible = true;
                temp_pane.YAxis.MajorGrid.IsVisible = true;

                temp_n.XAxis.MajorGrid.IsVisible = true;
                temp_n.YAxis.MajorGrid.IsVisible = true;
                

                pane.CurveList.Clear();
                pane2.CurveList.Clear();
                pane3.CurveList.Clear();
                pane4.CurveList.Clear();

                //pane5.CurveList.Clear();
                //pane6.CurveList.Clear();

                temp_pane.CurveList.Clear();
                temp_n.CurveList.Clear();


                PointPairList list = new PointPairList();
                PointPairList list2 = new PointPairList();
                PointPairList list3 = new PointPairList();
                PointPairList list4 = new PointPairList();
                list5 = new PointPairList();
                list6 = new PointPairList();
                list7 = new PointPairList();
                list8 = new PointPairList();
                list9 = new PointPairList();
                list10 = new PointPairList();
                list11 = new PointPairList();
                list12 = new PointPairList();

                PointPairList temp_list = new PointPairList();
                PointPairList n_list = new PointPairList();

                //StringGrid1.Columns.Add("t", "t");
                //StringGrid1.Columns.Add("V", "V");
                //StringGrid1.Columns.Add("Teta", "Teta");
                //StringGrid1.Columns.Add("e", "e");
                //StringGrid1.Columns.Add("h", "h");
                //StringGrid1.Columns.Add("Lambda", "Lambda");
                //StringGrid1.Columns.Add("ф", "ф");
                //StringGrid1.Columns.Add("ro", "ro");
                //StringGrid1.Columns.Add("Kб", "Kб");
                //StringGrid1.Columns.Add("Px", "Px");

                R = 6051; // км
                M = 324858.8;

                b = 0.11;

                Q = 5.6696 * Math.Pow(10, -12); 
	            V1 = 7.328; 
	            ech = 0.9; 
	            Ak = 42.0 * Math.Pow(10,10); 
	            Ar = 7.5 * Math.Pow (10, 11); 
	            Rk = 4.3; 
                //labelM.Text = "M: " + Convert.ToString(M);
                //labelR.Text = "R: " + Convert.ToString(R);





                int N = Convert.ToInt32(EditN.Text);//количество итераций

                double step = Convert.ToDouble(EditStep.Text);//шаг

                double[] kV = new double[4];
                double[] kQ = new double[4];
                double[] kE = new double[4];
                double[] kH = new double[4];
                double[] kA = new double[4];
                double[] kF = new double[4];

                double[] pV, pQ, pE, pH, pA, pF, T;

                pV = new double[N];
                pQ = new double[N];
                pE = new double[N];
                pH = new double[N];
                pA = new double[N];
                pF = new double[N];
                T = new double[N];
              

                _pV = new double[N];
                _pQ = new double[N];
                _pE = new double[N];
                _pH = new double[N];
                _pA = new double[N];
                _pF = new double[N];
                _T = new double[N];

                n_array = new double[N];
                temp_array = new double[N];

                edit_px = Convert.ToInt32(EditPx.Text);

                pH[0] = Convert.ToDouble(EditH.Text); // высота H
                pV[0] = Convert.ToDouble(EditV.Text); // скорость V
                pQ[0] = (Convert.ToDouble(EditQ.Text)) / (180 / Math.PI); // угол наклона скорости к местному горизонту (тета)
                pE[0] = (Convert.ToDouble(0)) / (180 / Math.PI);//угол  между  проекцией  вектора  скорости  на  местный  горизонт  и  местной (e)
                pA[0] = (Convert.ToDouble(0)) / (180 / Math.PI);//геоцентрическая  долгота (лямбда)
                pF[0] = (Convert.ToDouble(0)) / (180 / Math.PI);//геоцентрическая  широта (ф)
                //y_n = Convert.ToDouble(Edityn.Text);
                //y_k = Convert.ToDouble(Edityk.Text);
                //alpha = (Convert.ToDouble(editAlpha.Text)) / (180 / Math.PI);
                //cx = Cx(alpha);
                //cy = Cy(alpha);
                

                T[0] = 0;
                ro0 = 0.093;
                g = 0.0088;
                int double_znak = 4;
                int i = 1;

                //if (ComboBoxKA.SelectedIndex == 0 || ComboBoxKA.SelectedIndex == 1)
                //{
                //    EditKb.Enabled = false;
                //    EditPx.Enabled = false;
                //    Kb = Cy(alpha) / Cx(alpha);
                //    Px = 2000 / (Cx(alpha) * 10);
                    
                //}
                //else
                //{
                    Kb = Convert.ToDouble(EditKb.Text);
                    Px = Convert.ToInt32(EditPx.Text);
                    
                //}



                //ro = ro0 * Math.Pow(Math.E, -b * pH[i - 1]) * Math.Pow(10, 3);
                //n = (ro * Math.Pow(pV[0], 2)) / (2 * Px * g);

                ////StringGrid1.Rows.Add();
                ////StringGrid1.Rows[i].Cells[0].Value = Convert.ToString(Math.Round(T[0], double_znak));
                ////StringGrid1.Rows[i].Cells[1].Value = Convert.ToString(Math.Round(pV[0], double_znak));
                ////StringGrid1.Rows[i].Cells[2].Value = Convert.ToString(Math.Round((pQ[0] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                ////StringGrid1.Rows[i].Cells[3].Value = Convert.ToString(Math.Round((pE[0] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                ////StringGrid1.Rows[i].Cells[4].Value = Convert.ToString(Math.Round(pH[0], double_znak));
                ////StringGrid1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round((pA[0] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                ////StringGrid1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round((pF[0] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                ////StringGrid1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(ro, double_znak));
                ////StringGrid1.Rows[i].Cells[8].Value = Convert.ToString(Math.Round(Kb, double_znak + 2));
                ////StringGrid1.Rows[i].Cells[9].Value = Convert.ToString(Math.Round(Px, double_znak));
                ////StringGrid1.Rows[i].Cells[10].Value = Convert.ToString(Math.Round(n, double_znak));

                ////Chart1.Series[0].Points.AddY(pV[0]);
                ////Chart1.Series[0].Points.AddY(pH[0]);

                ////Chart1.Series[0].Points.AddY(pV[0]);
                ////Chart1.Series[1].Points.AddY(pH[0]);
                ////chart2.Series[0].Points.AddXY(T[0],pV[0]);
                ////chart3.Series[0].Points.AddXY(T[0],pH[0]);



                y = y_n;

                while (i < N)
                {

                    //if (i == Convert.ToInt32(Edittk.Text))
                    //{
                    //    Edityk.BackColor = Color.Green;
                    //    y = y_k;

                    //}

                    T[i] = T[i - 1] + step;

                    r = R + pH[i - 1];

                    ro = ro0 * Math.Pow(Math.E, -b * pH[i - 1]) * Math.Pow(10, 3);

                    q_konv = (Ak / Math.Sqrt(Rk)) * Math.Pow((ro / ro0), 0.5f) * Math.Pow((pV[i -1] / V1), 3);
                    //q_konv = Ak * Mathf.Pow (Rk, - 0.5f) * Mathf.Pow (ro, 0.5f) * Mathf.Pow (Speed, 3);
                    q_rad = (Ar * (Math.Pow(ro, 2) / Math.Pow(ro0, 2))) * ((Math.Pow((pV[i-1]/ Math.Pow(10, 4)), 14)) * Rk);
                    //q_rad = Ar * Rk * Mathf.Pow (ro, 0.7f) * Mathf.Pow (Speed, 3.28f);
                    Temperature = (Math.Pow((q_konv + q_rad) / (Q * ech), 0.25)) + 273.16;

                    temp_array[i] = Temperature;


                    //if (i == Convert.ToInt32(Edittk.Text))
                    //{

                        //if (ComboBoxKA.SelectedIndex == 0 || ComboBoxKA.SelectedIndex == 1)
                        //{
                        //    EditKb.Enabled = false;
                        //    EditPx.Enabled = false;
                        //    Kb = Cy(alpha) / Cx(alpha);
                        //    Px = 2000 / (Cx(alpha) * 10);

                        //}
                        //else
                        //{

                            Kb = Convert.ToDouble(EditKb.Text);
                            Px = Convert.ToInt32(EditPx.Text);



                        //}

                    //   // Px = Convert.ToInt32(200);
                    //    Kb = Convert.ToDouble(0.4);

                    //}

                    //if (i == 55)
                    //    Kb = Convert.ToDouble(0.5);   
                    
                    n = (ro * Math.Pow(pV[i - 1], 2)) / (2* Px * g);

                    n_array[i] = n;

                    //Kb = Cy(pA[i - 1]) / Cx(pA[i - 1]);

                    //Px = 2000 / (Cx(pA[i - 1]) * 10);

                    kV[0] = step * dVdt(pV[i - 1], pQ[i - 1]);
                    kQ[0] = step * dQdt(pV[i - 1], pQ[i - 1]);
                    kE[0] = step * dEdt(pV[i - 1], pQ[i - 1], pE[i - 1], pF[i - 1]);
                    kH[0] = step * dHdt(pV[i - 1], pQ[i - 1]);
                    kA[0] = step * dAdt(pV[i - 1], pQ[i - 1], pE[i - 1], pF[i - 1]);
                    kF[0] = step * dFdt(pV[i - 1], pQ[i - 1], pE[i - 1]);

                    kV[1] = step * dVdt(pV[i - 1] + kV[0] / 2, pQ[i - 1] + kQ[0] / 2);
                    kQ[1] = step * dQdt(pV[i - 1] + kV[0] / 2, pQ[i - 1] + kQ[0] / 2);
                    kE[1] = step * dEdt(pV[i - 1] + kV[0] / 2, pQ[i - 1] + kQ[0] / 2, pE[i - 1] + kE[0] / 2, pF[i - 1] + kF[0] / 2);
                    kH[1] = step * dHdt(pV[i - 1] + kV[0] / 2, pQ[i - 1] + kQ[0] / 2);
                    kA[1] = step * dAdt(pV[i - 1] + kV[0] / 2, pQ[i - 1] + kQ[0] / 2, pE[i - 1] + kE[0] / 2, pF[i - 1] + kF[0] / 2);
                    kF[1] = step * dFdt(pV[i - 1] + kV[0] / 2, pQ[i - 1] + kQ[0] / 2, pE[i - 1] + kE[0] / 2);

                    kV[2] = step * dVdt(pV[i - 1] + kV[1] / 2, pQ[i - 1] + kQ[1] / 2);
                    kQ[2] = step * dQdt(pV[i - 1] + kV[1] / 2, pQ[i - 1] + kQ[1] / 2);
                    kE[2] = step * dEdt(pV[i - 1] + kV[1] / 2, pQ[i - 1] + kQ[1] / 2, pE[i - 1] + kE[1] / 2, pF[i - 1] + kF[1] / 2);
                    kH[2] = step * dHdt(pV[i - 1] + kV[1] / 2, pQ[i - 1] + kQ[1] / 2);
                    kA[2] = step * dAdt(pV[i - 1] + kV[1] / 2, pQ[i - 1] + kQ[1] / 2, pE[i - 1] + kE[1] / 2, pF[i - 1] + kF[1] / 2);
                    kF[2] = step * dFdt(pV[i - 1] + kV[1] / 2, pQ[i - 1] + kQ[1] / 2, pE[i - 1] + kE[1] / 2);

                    kV[3] = step * dVdt(pV[i - 1] + kV[2], pQ[i - 1] + kQ[2]);
                    kQ[3] = step * dQdt(pV[i - 1] + kV[2], pQ[i - 1] + kQ[2]);
                    kE[3] = step * dEdt(pV[i - 1] + kV[2], pQ[i - 1] + kQ[2], pE[i - 1] + kE[2], pF[i - 1] + kF[2]);
                    kH[3] = step * dHdt(pV[i - 1] + kV[2], pQ[i - 1] + kQ[2]);
                    kA[3] = step * dAdt(pV[i - 1] + kV[2], pQ[i - 1] + kQ[2], pE[i - 1] + kE[2], pF[i - 1] + kF[2]);
                    kF[3] = step * dFdt(pV[i - 1] + kV[2], pQ[i - 1] + kQ[2], pE[i - 1] + kE[2]);

                    pV[i] = pV[i - 1] + (kV[0] + 2 * kV[1] + 2 * kV[2] + kV[3]) / 6;
                    pQ[i] = pQ[i - 1] + (kQ[0] + 2 * kQ[1] + 2 * kQ[2] + kQ[3]) / 6;
                    pE[i] = pE[i - 1] + (kE[0] + 2 * kE[1] + 2 * kE[2] + kE[3]) / 6;
                    pH[i] = pH[i - 1] + (kH[0] + 2 * kH[1] + 2 * kH[2] + kH[3]) / 6;
                    pA[i] = pA[i - 1] + (kA[0] + 2 * kA[1] + 2 * kA[2] + kA[3]) / 6;
                    pF[i] = pF[i - 1] + (kF[0] + 2 * kF[1] + 2 * kF[2] + kF[3]) / 6;



                
                    i = StringGrid1.Rows.Add();
                    StringGrid1.Rows[i].Cells[0].Value = Convert.ToString(Math.Round(T[i], double_znak));
                    StringGrid1.Rows[i].Cells[1].Value = Convert.ToString(Math.Round(pV[i], double_znak));
                    StringGrid1.Rows[i].Cells[2].Value = Convert.ToString(Math.Round((pQ[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    StringGrid1.Rows[i].Cells[3].Value = Convert.ToString(Math.Round((pE[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    StringGrid1.Rows[i].Cells[4].Value = Convert.ToString(Math.Round(pH[i], double_znak));
                    StringGrid1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round((pA[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    StringGrid1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round((pF[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    StringGrid1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(ro, double_znak));
                    StringGrid1.Rows[i].Cells[8].Value = Convert.ToString(Math.Round(Kb, double_znak + 2));
                    StringGrid1.Rows[i].Cells[9].Value = Convert.ToString(Math.Round(Px, double_znak));
                    StringGrid1.Rows[i].Cells[10].Value = Convert.ToString(Math.Round(n, double_znak));
                    //StringGrid1.Rows[i].Cells[11].Value = Convert.ToString(Math.Round(cx, double_znak));
                    //StringGrid1.Rows[i].Cells[12].Value = Convert.ToString(Math.Round(cy, double_znak));
                    StringGrid1.Rows[i].Cells[11].Value = Convert.ToString(Math.Round(Temperature / 1000, double_znak - 3));

                    

                    _T[i] = T[i];
                    _pV[i] = pV[i];
                    _pH[i] = pH[i];

                    list.Add(T[i], pV[i]);
                    list2.Add(T[i], pH[i]);
                    list3.Add(pH[i], ro);
                    list4.Add(T[i], pQ[i]);
                    temp_list.Add(T[i], temp_array[i]/1000);
                    n_list.Add(T[i], n_array[i]);


       

                    //if (pH[i] < 30)                   
                    //    Px = Convert.ToInt32(250);
                    

                    //if (pH[i] > 30)
                    //    Px = Convert.ToInt32(300);

                                        
                    if (pH[i] > 150 || pH[i] < 0 || pH[i] <= 4)
                    {

                        IEnumerable<double> numQuery = pQ.Where(p => p == n_array.Max()).ToList();

                        double numQureryToDisplay = 0;

                        foreach (double j in numQuery)
                        {
                            numQureryToDisplay = j;
                        }

                        label23.Text = "Высота " + Math.Round(pH[i], double_znak) + " км";
                        label24.Text = "Траекторный угол" + Convert.ToString(Math.Round((pQ[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                        label25.Text = "Скорость" + Convert.ToString(Math.Round(pV[i], double_znak)) + " км/с";
                        label26.Text = "Температура максимальная " + Convert.ToString(Math.Round(temp_array.Max() / 1000, double_znak - 2)) + " K";
                        label20.Text = "Перегрузка максимальная" + Convert.ToString(Math.Round(n_array.Max(), double_znak - 2));
                        label27.Text = "Время конечное " + Convert.ToString(Math.Round(T[i], double_znak)) +" сек";

                        soft_landing = Math.Round(((pV[i] - 0.324) * 1000) / 5,2);

                        if (pH[i] >= 150)
                        {
                            
                                diag.Items.Add ("Аппарат вылетел за пределы атмосферы Венеры. Задача не выполнена.");


                                


                        }


                        else if (n_array.Max() >= 15.5)
                        {
                            diag.Items.Add("Превышена максимально допустимая перегрузка." + 
                             "Задача  не выполнена.");
                        }



                        else if (soft_landing <= 5)
                        {

                            diag.Items.Add("Ваш экипаж совершил мягкую посадку на поверхность Венеры. Задача выполнена.");
                            diag.Items.Add("Конечная скорость после ввода системы мягкой посадки = " + soft_landing.ToString().Trim('-') + " м/c");
                            diag.Items.Add("Введите значения Аэродинамического качаства = " + EditKb.Text + " и траекторного угла = " + EditQ.Text + " в модуле программы - Имитационное модеолирование"); 
                        }


                        else if (soft_landing == 5 && soft_landing <= 10)
                        {



                            diag.Items.Add("Ваш экипаж совершил жесткую посадку на поверхность Венеры. Разрушены некоторые элементы конструкций. Задача выполнена.");
                            diag.Items.Add("Конечная скорость после ввода системы мягкой посадки = " + soft_landing.ToString().Trim('-') + " м/c");
                            diag.Items.Add("Введите значения Аэродинамического качаства = " + EditKb.Text + " и траекторного угла = " + EditQ.Text + " в модуле программы - Имитационное модеолирование"); 

                        }

                        else if (soft_landing >= 10 && soft_landing <= 15)
                        {





                            diag.Items.Add("Ваш экипаж совершил аварийную посадку на поверхность Венеры. Предстоит работа по восстановлению КА. Задача выполнена.");
                            diag.Items.Add("Конечная скорость после ввода системы мягкой посадки = " + soft_landing.ToString().Trim('-') + " м/c");
                            diag.Items.Add("Введите значения Аэродинамического качаства = " + EditKb.Text + " и траекторного угла = " + EditQ.Text + " в модуле программы - Имитационное модеолирование"); 

                        }


                        else if (soft_landing >= 15)
                        {



                            diag.Items.Add("Экипаж не выполнил посадку на поверхность Венеры. КА разбился при контакте с поверхностью Венеры. Задача не выполнена.");

                            diag.Items.Add("Конечная скорость после ввода системы мягкой посадки = " + soft_landing.ToString().Trim('-') + " м/c");




                        }
                       



                      

                        //WRAppend("Kb заданое= " + EditKb.Text);
                        //WRAppend("Тета заданое= " + EditQ.Text);

                        writeTo = label23.Text + label24.Text + label25.Text + label26.Text + label20.Text + label27.Text;

                        Wtite.WritetoFileAppend("Kb заданое= " + EditKb.Text);
                        Wtite.WritetoFileAppend("Тета заданое= " + EditQ.Text);


                        Wtite.WritetoFileAppend(writeTo);

                        


                        //WR(label23.Text);
                        //WR(label24.Text);
                        //WR(label25.Text);
                        //WR(label26.Text);

                        break;
                    }
                

                    i++;

                }

                //int numbcurve1 = 0;
                //int numbercurve1_2 = 0;

                //for (double z = 0; z <= 22; z++)
                //{

                //    double[] x = new double[23] { 6, 7, 8, 9, 
                //        10, 11, 12, 13, 14, 15,
                //        16, 17, 18, 19, 20, 
                //        21,22,23,24,25,26,27,28};

                //    double[] _y = new double[23] { 1.4893, 1.5722, 1.715, 1.8398, 1.9102, 
                //        1.9412, 2.0661, 2.0993, 2.1204, 2.2477, 2.3142, 
                //        2.2903, 2.3265, 2.4202, 2.5712, 2.5727,2.6124, 2.6893, 
                //        2.8031, 2.7144, 2.8913, 2.8489, 2.826
                //        };

                //    list5.Add( x[numbcurve1++],_y[numbercurve1_2++]);
                //}

                //int numbcurve2 = 0;
                //int numbercurve2_2 = 0;

                //for (double z = 0; z <= 27; z++)
                //{

                //    double[] x = new double[28] { 8, 9, 10, 11, 12, 13,
                //        14, 15, 16, 17, 18, 19, 20,
                //        21, 22, 23, 24, 25, 26, 27, 
                //        28,29,30,31,32,33,34,35 };

                //    double[] _y = new double[28] { 0.5175, 0.5015, 0.5149, 0.5418, 0.5916, 
                //        0.6626, 0.7463, 0.8362, 0.9571, 1.0683, 1.2171,
                //        1.3488, 1.4243, 1.5472, 1.5472, 1.6432, 1.8733, 
                //        1.9987, 2.0324, 2.2368, 2.3318, 2.2836, 2.4263,
                //        2.409, 2.6072, 2.6237, 2.6545, 2.6999};

                //    list6.Add( x[numbcurve2++],_y[numbercurve2_2++]);
                //}

                //int numbcurve3 = 0;
                //int numbercurve3_2 = 0;

                //for (double z = 0; z <= 26; z++)
                //{

                //    double[] x = new double[27] { 15, 16, 17, 18, 19, 20,
                //        21, 22, 23, 24, 25, 
                //        26, 27, 28, 29, 30, 
                //        31, 32,33,34,35,36,37,38,39,40,41 };

                //    double[] _y = new double[27] { 0.3584, 0.3465, 0.336, 0.328, 0.3271,
                //        0.3365, 0.3552, 0.3774, 0.4012, 0.4182,
                //        0.4254, 0.4272, 0.4259, 0.4242, 0.4142, 
                //        0.4066, 0.3977, 0.3761, 0.3874, 0.3657, 
                //        0.3544, 0.3437, 0.3322, 0.3218, 0.3101, 2.0805, 2.2613};

                //    list7.Add( x[numbcurve3++],_y[numbercurve3_2++]);
                //}

                //int numbcurve4 = 0;
                //int numbercurve4_2 = 0;

                //for (double z = 0; z <= 4; z++)
                //{

                //    double[] x = new double[5] { 43,44,45,46,47};

                //    double[] _y = new double[5] { 0.2385, 0.235, 0.2411, 0.3024, 0.4551};

                //    list8.Add(x[numbcurve4++], _y[numbercurve4_2++]);
                //}


                //int numbcurve5 = 0;
                //int numbercurve5_2 = 0;

                //for (double z = 0; z <= 22; z++)
                //{

                //    double[] x = new double[23] {205, 155, 129, 112, 100, 91, 
                //        83, 77, 72, 67, 63, 
                //        60, 57, 54, 51, 49,
                //        47, 45, 43, 42, 40,
                //        39, 38 };

                //    double[] _y = new double[23] { 6.3844, 10.0834, 11.6371, 12.8776, 13.9913, 
                //        15.0374, 16.0296, 16.1409, 17.0112, 17.953, 
                //        18.8938, 19.8173, 20.7357, 21.6455, 22.5244, 
                //        23.4427, 24.3255, 25.2086, 26.0883, 26.9217, 
                //        27.8221, 28.6271, 29.5141};

                //    list9.Add(x[numbcurve5++], _y[numbercurve5_2++]);
                //}


                //int numbcurve6 = 0;
                //int numbercurve6_2 = 0;

                //for (double z = 0; z <= 27; z++)
                //{

                //    double[] x = new double[28] {416, 299, 240, 201, 171, 147, 
                //       128, 113, 100, 90, 81, 
                //        74, 69, 60, 56, 53, 
                //        50, 48,45,43,42,40,
                //        39,37,36,35,34,33};

                //    double[] _y = new double[28] { 2.4047, 3.7139, 4.9978, 6.2071, 7.3572, 
                //        8.466, 9.5408, 10.5945, 11.6265, 12.6463, 
                //        13.652, 14.6387, 15.6316, 16.6098, 17.5769, 
                //        18.5248, 19.4996, 20.4295, 21.385, 22.3311, 
                //        23.2632, 24.1882, 25.1082,  26.0198, 26.9128,
                //        27.7688, 28.6986, 29.6036};

                //    list10.Add( x[numbcurve6++],_y[numbercurve6_2++]);
                //}

                //int numbcurve7 = 0;
                //int numbercurve7_2 = 0;

                //for (double z = 0; z <= 24; z++)
                //{

                //    double[] x = new double[25] { 1118,947,865,783,715,656,
                //        605,525,494,468,445,424,387,370,354,339,325,311,298,285,273,
                //        260,249,36,34};

                //    double[] _y = new double[25] { 6.3533, 7.2078, 8.0707, 8.9461, 9.8284, 
                //        10.7131, 11.6054, 12.5053, 13.3961,14.2999, 
                //        15.2066, 16.1081, 17.0087, 17.9113,18.8161, 
                //        19.7202, 20.6158, 21.4899, 22.3937, 23.3075, 
                //        24.1668, 25.0677, 25.9572, 26.8041, 27.7126 };

                //    list11.Add(x[numbcurve7++],_y[numbercurve7_2++]);
                //}

                //int numbcurve8 = 0;
                //int numbercurve8_2 = 0;

                //for (double z = 0; z <= 17; z++)
                //{

                //    double[] x = new double[18] { 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };

                //    double[] _y = new double[18] { 26.6595, 27.4626, 28.3453, 29.1154, 29.9164, 30.7971, 31.574, 32.2519,
                //        33.1696, 33.9947, 34.7261, 35.3644, 36.247, 37.0729, 37.8182, 38.484, 39.0725, 39.8938 };


                //    list12.Add(x[numbcurve8++], _y[numbercurve8_2++]);
                //}



                LineItem myCurve = pane.AddCurve("", list, Color.Blue, SymbolType.None);
                LineItem myCurve2 = pane2.AddCurve("", list2, Color.Orange, SymbolType.None);
                LineItem myCurve3 = pane3.AddCurve("", list3, Color.Red, SymbolType.None);
                LineItem myCurve4 = pane4.AddCurve("", list4, Color.Green, SymbolType.None);

                LineItem TempCurve = temp_pane.AddCurve("", temp_list, Color.HotPink, SymbolType.None);
                LineItem Ncurve = temp_n.AddCurve("",n_list,Color.Gold,SymbolType.None);


                //myCurve5 = pane5.AddCurve("Кб = -0.5", list5, Color.DarkGreen, SymbolType.None);

                //myCurve6 = pane5.AddCurve("Кб = 0", list6, Color.DarkBlue, SymbolType.None);

                //myCurve7 = pane5.AddCurve("Кб = 0.5", list7, Color.Magenta, SymbolType.None);

                //myCurve8 = pane5.AddCurve("Кб = 1", list8, Color.Red, SymbolType.None);

                ////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////

                //myCurve9 = pane6.AddCurve("Кб = -0.6", list9, Color.DarkBlue, SymbolType.None);

                //myCurve10 = pane6.AddCurve("Кб = 0", list10, Color.Magenta, SymbolType.None);

                //myCurve11 = pane6.AddCurve("Кб = 0.5", list11, Color.DarkGreen,SymbolType.None);

                //myCurve12 = pane6.AddCurve("Кб = 1", list12, Color.Red, SymbolType.None);

                //myCurve5.Line.IsVisible = true;

                //myCurve5.Line.IsSmooth = true;

                //myCurve6.Line.IsVisible = true;

                //myCurve6.Line.IsSmooth = true;

                //myCurve7.Line.IsVisible = true;

                //myCurve7.Line.IsSmooth = true;

                //myCurve8.Line.IsVisible = true;

                //myCurve8.Line.IsSmooth = true;

                //myCurve9.Line.IsVisible = true;

                //myCurve9.Line.IsSmooth = true;

                //myCurve10.Line.IsVisible = true;

                //myCurve10.Line.IsSmooth = true;

                //myCurve11.Line.IsVisible = true;

                //myCurve11.Line.IsSmooth = true;

                //myCurve12.Line.IsVisible = true;

                //myCurve12.Line.IsSmooth = true;

                TempCurve.Line.IsVisible = true;

                TempCurve.Line.IsSmooth = true;

                Ncurve.Line.IsVisible = true;

                Ncurve.Line.IsSmooth = true;


                //myCurve5.Symbol.Fill.Color = Color.Gray;

                
                //myCurve5.Symbol.Fill.Type = FillType.Solid;

                
                //myCurve5.Symbol.Size = 10;


                zedGraph.AxisChange();
                zedGraphControl1.AxisChange();
                zedGraphControl2.AxisChange();
                zedGraphControl3.AxisChange();
             
                zedGraphControl6.AxisChange();
                zedGraphControl7.AxisChange();


                zedGraph.Invalidate();
                zedGraphControl1.Invalidate();
                zedGraphControl2.Invalidate();
                zedGraphControl3.Invalidate();
             
                zedGraphControl6.Invalidate();
                zedGraphControl7.Invalidate();

                

                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


}

    
    private void ComboBoxKA_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ComboBoxKA.SelectedIndex == 0)
        //{
        //    EditKb.Enabled = false;
        //    EditPx.Enabled = false;
        //}

        //if (ComboBoxKA.SelectedIndex == 1)
        //{
        //    EditKb.Enabled = false;
        //    EditPx.Enabled = false;
        //}

        //if (ComboBoxKA.SelectedIndex == 2)
        //{
        //    EditKb.Enabled = true;
        //    EditPx.Enabled = true;
        //}
    }

    private void Button1Click()
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    //private void button2_Click(object sender, EventArgs e)
    //{
    //    Form2 f2 = new Form2();
    //    f2.Show();
    //}

    private void timer1_Tick(object sender, EventArgs e)
    {
        try
        {
            if (_i == Convert.ToInt32(EditN.Text))
            {
                
                _i = 0;
                timer1.Stop();
            }

            else
            {
                Draw(Convert.ToString(_pH[_i]));

                label19.Text = Convert.ToString(Math.Round(_pH[_i], 2));
                label21.Text = Convert.ToString(Math.Round(_pV[_i], 2));
                _i++;
            }

        }

        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        
    }

    private void Draw(string setpoint)
    {
        try
        {
       //     double intsetpoint;
       //     double.TryParse(setpoint, out intsetpoint);
       //  //   if (zedGraphControl4.GraphPane.CurveList.Count < 0)
       //         return;

       ////     LineItem curve = zedGraphControl4.GraphPane.CurveList[0] as LineItem;
       //     if (curve == null)
       //         return;

       //     IPointListEdit list_ = curve.Points as IPointListEdit;

       //     Time = (Environment.TickCount - tickstart) / 1000.0;

       //     //if (_i == Convert.ToInt32(EditN.Text))
       //     //{

       //     //    _i = 0;
       //     //    timer1.Stop();

       //     //}

       //     list_.Add(Time, intsetpoint);

       //     Scale xScale = zedGraphControl4.GraphPane.XAxis.Scale;
       //     if (Time > xScale.Max - xScale.MajorStep)
       //     {
       //         if (intmode == 1)
       //         {
       //             xScale.Max = Time + xScale.MajorStep;
       //             xScale.Min = xScale.Max - 30.0;
       //         }
       //         else
       //         {
       //             xScale.Max = Time + xScale.MajorStep;
       //             xScale.Min = 0;
       //         }


       //     }

       //     zedGraphControl4.AxisChange();
       //     zedGraphControl4.Invalidate();


            //label19.Text = Convert.ToString(Math.Round(_pH[_i], 2));
            //label21.Text = Convert.ToString(Math.Round(_pV[_i], 2));
            //_i++;

        }


        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void button3_Click(object sender, EventArgs e)
    {
        timer1.Stop();

    }

    //private void Mode_Click(object sender, EventArgs e)
    //{
    //    if (Mode.Text == "Прокрутка")
    //    {
    //        intmode = 1;
    //        Mode.Text = "Без прокрутки";
    //    }

    //    else
    //    {
    //        intmode = 0;
    //        Mode.Text = "Прокрутка";
    //    }

    //}

    

    //private void zedGraph_MouseMove(object sender, MouseEventArgs e)
    //{
    //    GraphPane pane = zedGraph.GraphPane;
      
    //    double graphX, graphY;
     
    //    pane.ReverseTransform(new PointF(e.X, e.Y), out graphX, out graphY);
    //    graphCoord.Text = string.Format("({0:F3}; {1:F3})", graphX, graphY);
   
    //}

    //private void zedGraphControl1_MouseMove(object sender, MouseEventArgs e)
    //{
    //    GraphPane pane = zedGraph.GraphPane;

    //    double graphX, graphY;

    //    pane.ReverseTransform(new PointF(e.X, e.Y), out graphX, out graphY);
    //    graphCoord.Text = string.Format("({0:F3}; {1:F3})", graphX, graphY);

    //}

    //private void zedGraphControl2_MouseMove(object sender, MouseEventArgs e)
    //{
    //    GraphPane pane = zedGraphControl2.GraphPane;

    //    double graphX, graphY;

    //    pane.ReverseTransform(new PointF(e.X, e.Y), out graphX, out graphY);
    //    graphCoord.Text = string.Format("({0:F3}; {1:F3})", graphX, graphY);

    //}

    //private void zedGraphControl3_MouseMove(object sender, MouseEventArgs e)
    //{
    //    GraphPane pane = zedGraphControl3.GraphPane;

    //    double graphX, graphY;

    //    pane.ReverseTransform(new PointF(e.X, e.Y), out graphX, out graphY);
    //    graphCoord.Text = string.Format("({0:F3}; {1:F3})", graphX, graphY);

    //}

  

    public static string WRAppend(string text)
    {
        Wtite.WritetoFileAppend(text);
        return text;
    }


    public static string WR(string text)
    {
        Wtite.WritetoFile(text);
        return text;
    }

    private void graph_Click(object sender, EventArgs e)
    {
        Form2 fm2 = new Form2();
        fm2.ShowDialog();
    }

    private void AllRes_Click(object sender, EventArgs e)
    {
        All a = new All();
        a.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Form3 fm3 = new Form3();
        fm3.ShowDialog();
    }

    private void button3_Click_1(object sender, EventArgs e)
    {
        Form4 fm4 = new Form4();
        fm4.ShowDialog();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        Form5 fm5 = new Form5();
        fm5.ShowDialog();
    }

    private void button5_Click(object sender, EventArgs e)
    {
        Form6 fm5 = new Form6();
        fm5.ShowDialog();
    }

    private void label18_Click(object sender, EventArgs e)
    {

    }

    private void button2_Click_1(object sender, EventArgs e)
    {
        try
        {

            Random rnd = new Random();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            Bitmap bit = new Bitmap(this.Size.Width, this.Size.Height);
            this.DrawToBitmap(bit, new Rectangle(0, 0, this.Size.Width, this.Size.Height));
            bit.Save("Result/Total_" + rnd.Next() + ".jpg");

            // MessageBox.Show("Файл сохранен. \n" + Path.GetFullPath("Result/Total_" + label3.Text + ".jpg"));

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

        }

        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);                         
        }
    }

    private void label18_Click_1(object sender, EventArgs e)
    {

    }
       
}



    }

