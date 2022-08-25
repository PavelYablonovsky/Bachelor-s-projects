using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Flying
{
    public partial class All : Form
    {
        public All()
        {
            InitializeComponent();
            alpha_value.Enabled = false;
            
        }

        Form1 fm1 = new Form1();

        double M = 324858.8// произведение постоянной притяжения на массу Венеры
, R  = 6051// экваториальный радиус Венеры
, r // 
, Px // приведенная  нагрузка  на  лобовую  поверхность  КА
, b = 0.11//
, Kb // аэродинамическое качество
, y // угол  крена
, y_n // угол  крена начальный
, y_k // угол крена конечный
, ro // плотность атмосферы
, ro0 = 0.093 // начальная плотность атмосферы
, n // перегрузка
, g = 0.0088,
  alpha;
        // масса КА , используется при рассчете Px
        // масса КА = 2000

      public  double kb_depend_on_alpha;
      public  double px_depend_on_alpha;


        double[] n_array;
        double[] ro_array;

        double[] _pV, _pQ, _pE, _pH, _pA, _pF, _T, _n_array, _ro_array;

        double[] KbMass, thetaMass;

        bool fly = false;

        int k = 0;

        double dVdt(double pV, double pQ)
        {
            return -(ro * pV * pV) / (2 * Px) - (M / Math.Pow(r, 2)) * Math.Sin(pQ);
        }

        double dQdt(double pV, double pQ)
        {
            return ((ro * pV * Kb) / (2 * Px)) * Math.Cos(y) - (M / (Math.Pow(r, 2) * pV)) * Math.Cos(pQ) + (pV / r) * Math.Cos(pQ);
        }

        double dEdt(double pV, double pQ, double pE, double pF)
        {
            return ((ro * pV * Kb) / (2 * Px * Math.Cos(pQ))) * Math.Sin(y) - (pV / r) * Math.Cos(pQ) * Math.Cos(pE) * Math.Tan(pF);
        }

        double dHdt(double pV, double pQ)
        {
            return pV * Math.Sin(pQ);
        }

        double dAdt(double pV, double pQ, double pE, double pF)
        {
            return (pV / R) * ((Math.Cos(pQ) * Math.Cos(pE)) / Math.Cos(pF));
        }

        double dFdt(double pV, double pQ, double pE)
        {
            return (pV / r) * Math.Cos(pQ) * Math.Sin(pE);
        }

        double Cx(double a)
        {
           
            return 0.2 + 2.3 * Math.Pow(Math.Sin(1.125 * a + (5.625 / (180 / Math.PI))), 2); // несущий корпус
           
         
        }

        double Cy(double a)
        {
           
                return -0.1 + 2.3 * Math.Sin(1.125 * a + (5.625 / (180 / Math.PI))) * Math.Cos(1.125 * a + (5.625 / (180 / Math.PI)));// несущий корпус
           
        }


        private void All_Load(object sender, EventArgs e)
        {

        }


        private void QuantParameters()
        {
            try
            {

                StringGrid1.Rows.Clear();
                double converting = 0;
                int kbquant = 0;
                int thetacount = 0;
                int count1 = 0;
                int count2 = 0;
                fly = true;
                if (alpha_value.Enabled == true)
                converting = Convert.ToDouble(alpha_value.Text) / (180 / Math.PI);
                
            
              

                for (double j = Convert.ToDouble(Kb1.Text); j <= Convert.ToDouble(kb2.Text); j += 0.1)
                {
                    kbquant++;

                }


                KbMass = new double[kbquant];

                for (double j = Convert.ToDouble(Kb1.Text); j <= Convert.ToDouble(kb2.Text); j += 0.1)
                {
                    KbMass[count1++] = j;

                }

                for (int l = Convert.ToInt32(theta1.Text); l >= Convert.ToInt32(theta2.Text); l--)
                {
                    thetacount++;
                }


                thetaMass = new double[thetacount];

                for (int l = Convert.ToInt32(theta1.Text); l >= Convert.ToInt32(theta2.Text); l--)
                {
                    thetaMass[count2++] = l;
                }


                if (alpha_value.Enabled == true)
                {
                    kb_depend_on_alpha = Cy(Convert.ToDouble(converting)) / Cx(Convert.ToDouble(converting));
                    px_depend_on_alpha = 2000 / (Cx(Convert.ToDouble(converting)) * 10);

                    for (int l = 0; l < thetacount; l++)
                    {



                        Calculate(
                           kb_depend_on_alpha,
                           thetaMass[l],
                           px_depend_on_alpha,
                           Convert.ToDouble(fm1.EditH.Text),
                           Convert.ToDouble(fm1.EditV.Text),
                           Convert.ToDouble(0),
                           Convert.ToDouble(0),
                           Convert.ToDouble(0)
                           );


                    }
                }
                else
                {

                    for (int j = 0; j < kbquant; j++)
                    {
                        for (int l = 0; l < thetacount; l++)
                        {



                            Calculate(
                               KbMass[j],
                               thetaMass[l],
                               Convert.ToDouble(fm1.EditPx.Text),
                               Convert.ToDouble(fm1.EditH.Text),
                               Convert.ToDouble(fm1.EditV.Text),
                               Convert.ToDouble(0),
                               Convert.ToDouble(0),
                               Convert.ToDouble(0)
                               );


                        }
                    }
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
                QuantParameters();
           
             

        }

        private void Calculate(double kb, double theta, double px, double ph, double pv, double pe, double pa, double pf)
        {
            try
            {
       

                R = 6051; // км
                M = 324858.8;

                b = 0.11;

                //labelM.Text = "M: " + Convert.ToString(M);
                //labelR.Text = "R: " + Convert.ToString(R);


                int N = Convert.ToInt32(fm1.EditN.Text);//количество итераций

                double step = Convert.ToDouble(fm1.EditStep.Text);//шаг

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
                T = new double[N]; // время

                _pV = new double[N];
                _pQ = new double[N];
                _pE = new double[N];
                _pH = new double[N];
                _pA = new double[N];
                _pF = new double[N];
                _T = new double[N];
                _ro_array = new double[N];
                _n_array = new double[N];

                n_array = new double[N];
                ro_array = new double[N];

                pH[0] = ph;//высота H
                pV[0] = pv;//скорость V
                pQ[0] = (theta) / (180 / Math.PI);//угол наклона скорости к местному горизонту (тета)
                pE[0] = (pe) / (180 / Math.PI);//угол  между  проекцией  вектора  скорости  на  местный  горизонт  и  местной (e)
                pA[0] = (pa) / (180 / Math.PI);//геоцентрическая  долгота (лямбда)
                pF[0] = (pf) / (180 / Math.PI);//геоцентрическая  широта (ф)
               // y_n = Convert.ToDouble(fm1.Edityn.Text);
              //  y_k = Convert.ToDouble(fm1.Edityk.Text);

                T[0] = 0;
                ro0 = 0.093;
                g = 0.0088;
                int double_znak = 4;
                int i = 1;


                if (alpha_value.Enabled == true)
                {

                    Kb = kb_depend_on_alpha;
                    Px = px_depend_on_alpha;

                }

                else
                {


                    Kb = Convert.ToDouble(kb);
                    Px = Convert.ToDouble(px);

                }

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

                while (fly)
                {



                    T[i] = T[i - 1] + step;

                    r = R + pH[i - 1];

                    ro = ro0 * Math.Pow(Math.E, -b * pH[i - 1]) * Math.Pow(10, 3);

                    ro_array[i] = ro;




                    if (alpha_value.Enabled == true)
                    {

                        Kb = kb_depend_on_alpha;
                        Px = px_depend_on_alpha;

                    }

                    else
                    {


                        Kb = Convert.ToDouble(kb);
                        Px = Convert.ToDouble(px);

                    }


                    n = (ro * Math.Pow(pV[i - 1], 2)) / (2 * Px * g);

                    n_array[i] = n;


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



                   
                    //StringGrid1.Rows[i].Cells[0].Value = Convert.ToString(Math.Round(T[i], double_znak));
                    //StringGrid1.Rows[i].Cells[1].Value = Convert.ToString(Math.Round(pV[i], double_znak));
                    //StringGrid1.Rows[i].Cells[2].Value = Convert.ToString(Math.Round((pQ[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    //StringGrid1.Rows[i].Cells[3].Value = Convert.ToString(Math.Round((pE[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    //StringGrid1.Rows[i].Cells[4].Value = Convert.ToString(Math.Round(pH[i], double_znak));
                    //StringGrid1.Rows[i].Cells[5].Value = Convert.ToString(Math.Round((pA[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    //StringGrid1.Rows[i].Cells[6].Value = Convert.ToString(Math.Round((pF[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    //StringGrid1.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(ro, double_znak));
                    //StringGrid1.Rows[i].Cells[8].Value = Convert.ToString(Math.Round(Kb, double_znak + 2));
                    //StringGrid1.Rows[i].Cells[9].Value = Convert.ToString(Math.Round(Px, double_znak));
                    //StringGrid1.Rows[i].Cells[10].Value = Convert.ToString(Math.Round(n, double_znak));
                    
                    
                    _pV[i] = pV[i];
                    _pQ[i] = pQ[i];
                    _pH[i] = pH[i];
                    _T[i] = T[i];
                    _n_array[i] = n_array[i];
                    _ro_array[i] = ro_array[i];



                    //if (pH[i] < 30)                   
                    //    Px = Convert.ToInt32(250);

                    //if (pH[i] > 30)
                    //    Px = Convert.ToInt32(300);


                    if (pH[i] > 150 || pH[i] < 0)
                    {
                    k = StringGrid1.Rows.Add();
                    StringGrid1.Rows[k].Cells[0].Value = Convert.ToString(Math.Round(Kb, double_znak));
                    StringGrid1.Rows[k].Cells[1].Value = Convert.ToString(Math.Round((Convert.ToDouble(pQ[0]) * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    StringGrid1.Rows[k].Cells[2].Value = Convert.ToString(Math.Round(pV[i], double_znak));
                    StringGrid1.Rows[k].Cells[3].Value = Convert.ToString(Math.Round(n_array.Max(), double_znak));
                    StringGrid1.Rows[k].Cells[4].Value = Convert.ToString(Math.Round(T[i], double_znak));
                    StringGrid1.Rows[k].Cells[5].Value = Convert.ToString(Math.Round(pH[i], double_znak));
                    k++;
                    

                        break;
                    }


                    i++;

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void Calculate2(double kb, double theta, double px, double ph, double pv, double pe, double pa, double pf)
        {
            try
            {


             


                int N = Convert.ToInt32(fm1.EditN.Text);//количество итераций

                double step = Convert.ToDouble(fm1.EditStep.Text);//шаг

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
                T = new double[N]; // время

            

                pH[0] = ph;//высота H
                pV[0] = pv;//скорость V
                pQ[0] = (theta) / (180 / Math.PI);//угол наклона скорости к местному горизонту (тета)
                pE[0] = (pe) / (180 / Math.PI);//угол  между  проекцией  вектора  скорости  на  местный  горизонт  и  местной (e)
                pA[0] = (pa) / (180 / Math.PI);//геоцентрическая  долгота (лямбда)
                pF[0] = (pf) / (180 / Math.PI);//геоцентрическая  широта (ф)
                //y_n = Convert.ToDouble(fm1.Edityn.Text);
                //y_k = Convert.ToDouble(fm1.Edityk.Text);

                T[0] = 0;
           
                int double_znak = 4;
                int i = 1;


                if (alpha_value.Enabled == true)
                {

                    Kb = kb_depend_on_alpha;
                    Px = px_depend_on_alpha;

                }

                else
                {


                    Kb = Convert.ToDouble(kb);
                    Px = Convert.ToDouble(px);

                }

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



                    T[i] = T[i - 1] + step;

                    r = R + pH[i - 1];

                    ro = ro0 * Math.Pow(Math.E, -b * pH[i - 1]) * Math.Pow(10, 3);

                    ro_array[i] = ro;




                    if (alpha_value.Enabled == true)
                    {

                        Kb = kb_depend_on_alpha;
                        Px = px_depend_on_alpha;

                    }

                    else
                    {


                        Kb = Convert.ToDouble(kb);
                        Px = Convert.ToDouble(px);

                    }


                    n = (ro * Math.Pow(pV[i - 1], 2)) / (2 * Px * g);

                    n_array[i] = n;


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



                    i = AllParam.Rows.Add();
                    AllParam.Rows[i].Cells[0].Value = Convert.ToString(Math.Round(T[i], double_znak));
                    AllParam.Rows[i].Cells[1].Value = Convert.ToString(Math.Round(pV[i], double_znak));
                    AllParam.Rows[i].Cells[2].Value = Convert.ToString(Math.Round((pQ[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    AllParam.Rows[i].Cells[3].Value = Convert.ToString(Math.Round((pE[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    AllParam.Rows[i].Cells[4].Value = Convert.ToString(Math.Round(pH[i], double_znak));
                    AllParam.Rows[i].Cells[5].Value = Convert.ToString(Math.Round((pA[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    AllParam.Rows[i].Cells[6].Value = Convert.ToString(Math.Round((pF[i] * (180.0 / Math.PI)), double_znak - 2)) + "°";
                    AllParam.Rows[i].Cells[7].Value = Convert.ToString(Math.Round(ro, double_znak));
                    AllParam.Rows[i].Cells[8].Value = Convert.ToString(Math.Round(Kb, double_znak + 2));
                    AllParam.Rows[i].Cells[9].Value = Convert.ToString(Math.Round(Px, double_znak));
                    AllParam.Rows[i].Cells[10].Value = Convert.ToString(Math.Round(n, double_znak));





                    if (pH[i] > 150 || pH[i] < 0)
                        break;
                    

                    i++;

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            double _minmaxG = Convert.ToDouble(Min_MaxG.Text);
            double vkmax = Convert.ToDouble(Vk_max.Text);

           

            if (checkBox1.Checked == true)
            {
                double [] massOfBestSpeed = new double[StringGrid1.Rows.Count];

                double[] massOfBestOverload = new double[StringGrid1.Rows.Count];
                
               
           for(int i=0; i < StringGrid1.Rows.Count; i++)  
           massOfBestSpeed[i] +=  Convert.ToDouble(StringGrid1.Rows[i].Cells[2].Value);

          


          var findBestSpeed = from num in massOfBestSpeed
                       where num < vkmax
                       select num;
         
            
               
	for (int i = 0; i < StringGrid1.Rows.Count; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < StringGrid1.Columns.Count; j++)
                {
                    foreach (var s in findBestSpeed)
                    {
                         if (StringGrid1[j, i].Value.ToString() == s.ToString())
                        {
                            isVisible = true;
                        }
                    }

                    
                }
                StringGrid1.Rows[i].Visible = isVisible;
            }

                }


            if (checkBox1.Checked == false)
            {
                for (int i = 0; i < StringGrid1.Rows.Count; i++)
            {

                bool isVisible = true;

                StringGrid1.Rows[i].Visible = isVisible;

                    
            }
            }
            




            }

        private void toolStripContainer2_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          
            if (checkBox2.Checked == true)
            {
                
                double _minmaxG = Convert.ToDouble(Min_MaxG.Text);
                double vkmax = Convert.ToDouble(Vk_max.Text);

                double[] massOfBestOverload = new double[StringGrid1.Rows.Count];

              

                for (int i = 0; i < StringGrid1.Rows.Count; i++)
                    massOfBestOverload[i] += Convert.ToDouble(StringGrid1.Rows[i].Cells[3].Value);
             

              var  findBestOverload = from num2 in massOfBestOverload
                                       where num2 < _minmaxG
                                       select num2;

             



                for (int i = 0; i < StringGrid1.Rows.Count; i++)
                {
                    bool isVisible = false;
                    for (int j = 0; j < StringGrid1.Columns.Count; j++)
                    {
                        foreach (var s in findBestOverload)
                        {
                            if (StringGrid1[j, i].Value.ToString() == s.ToString())
                            {
                                isVisible = true;
                            }
                        }


                    }
                    StringGrid1.Rows[i].Visible = isVisible;
                }

            }


            if (checkBox2.Checked == false)
            {
                for (int i = 0; i < StringGrid1.Rows.Count; i++)
                {
                    bool isVisible = true;

                    StringGrid1.Rows[i].Visible = isVisible;


                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {

             

                double[] massOfHight = new double[StringGrid1.Rows.Count];


                for (int i = 0; i < StringGrid1.Rows.Count; i++)
                    massOfHight[i] += Convert.ToDouble(StringGrid1.Rows[i].Cells[5].Value);


                var findBestHight = from num2 in massOfHight
                                       where num2 <= 0.005 
                                       select num2;



                for (int i = 0; i < StringGrid1.Rows.Count; i++)
                {
                    bool isVisible = false;
                    for (int j = 0; j < StringGrid1.Columns.Count; j++)
                    {
                        foreach (var s in findBestHight)
                        {
                            if (StringGrid1[j, i].Value.ToString() == s.ToString())
                            {
                                isVisible = true;
                            }
                        }


                    }
                    StringGrid1.Rows[i].Visible = isVisible;
                }

            }


            if (checkBox3.Checked == false)
            {
                for (int i = 0; i < StringGrid1.Rows.Count; i++)
                {
                    bool isVisible = true;

                    StringGrid1.Rows[i].Visible = isVisible;


                }
            }
        }

        private void StringGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            AllParam.Rows.Clear();

                Calculate2(
                               Convert.ToDouble(StringGrid1.CurrentRow.Cells[0].Value),
                               Convert.ToDouble(StringGrid1.CurrentRow.Cells[1].Value.ToString().Trim('°')),
                               Convert.ToInt32(fm1.EditPx.Text),
                               Convert.ToDouble(fm1.EditH.Text),
                               Convert.ToDouble(fm1.EditV.Text),
                               Convert.ToDouble(0),
                               Convert.ToDouble(0),
                               Convert.ToDouble(0)
                           );
            
        }

        private void AlphaCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AlphaCheck.Checked == true)
            {
                Kb1.Enabled = false;
                kb2.Enabled = false;
                alpha_value.Enabled = true;
            }

            else
            {
                Kb1.Enabled = true;
                kb2.Enabled = true;
                alpha_value.Enabled = false;
            }
        }
        



    }
}
