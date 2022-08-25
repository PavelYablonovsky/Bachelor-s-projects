#include <iostream>
#include <cmath>
#include <stdio.h>

#define pi 3.14159265358979323846
#define toRad pi/180 //��� �������� �������� � �������
#define toDeg 180/pi //��� �������� ������ � �������
#define muE 398600.448 //�������������� �������� �����, ��^3/c^2
#define muJ 126686534 //�������������� �������� �������, ��^3/c^2
#define muS 132712440018 //�������������� �������� ������, ��^3/c^2
#define au 149598000 //��������������� ������� (��)
#define e 2.7182818284 //����� ������
#define eps 0.01

using namespace std;

double sign(double Val)
{
  if (Val == 0.)  return 0.;
  if (Val > 0.)  return 1.;
  else return -1.;
}

int main()
{
    setlocale (LC_ALL, "russian");
    FILE *res_lamb = fopen ("results_lambert.txt", "w");
    FILE *res_gamma = fopen ("results_gamma.txt", "w");
    FILE *res = fopen ("results.txt", "w");
    FILE *res_betta = fopen ("results_betta.txt", "w");
    FILE *res_gelio = fopen ("results_gelio.txt", "w");
    FILE *res_sat = fopen ("results_satelite.txt", "w");

    double
        D_start = 2460139.5, //���� ������ 14.07.2023 � ��������� �������
        t12 = 837., //����� �������, � ��������
        D_end = 2460970.5; //���� ������ 22.10.2025 � ��������� �������

    double
        xE = 54535896.71, //���������� � ������-������ �������� ����� � ���� ������
        yE = -141961127.10, //� ����������������� ����������� ��
        zE = 6905.27,
        vxE = 27.33384,
        vyE = 10.5648,
        vzE = -0.00155941,
        rE = sqrt (xE*xE + yE*yE + zE*zE),
        VE = sqrt (vxE*vxE + vyE*vyE + vzE*vzE),

        xJ = -182089828.49, //���������� � ������-������ �������� ������� � ���� ������
        yJ = 754483819.87, //� ����������������� ����������� ��
        zJ = 939906.15,
        vxJ = -12.86473,
        vyJ = -2.45571,
        vzJ = 0.29803,
        rJ = sqrt (xJ*xJ + yJ*yJ + zJ*zJ),
        VJ = sqrt (vxJ*vxJ + vyJ*vyJ + vzJ*vzJ);

    cout <<"���������� � �������� ����� \n";
    fprintf (res,"���������� � �������� ����� \n");

        printf ("\nxEarth = %.2f [km]", xE);
        fprintf (res,"\nxEarth = %.2f [km]", xE);
        printf ("\nyEarth = %.2f [km]", yE);
        fprintf (res,"\nyEarth = %.2f [km]", yE);
        printf ("\nzEarth = %.2f [km]", zE);
        fprintf (res,"\nzEarth = %.2f [km]", zE);

        printf ("\n\nVxEarth = %.6f [km/s]", vxE);
        fprintf (res,"\n\nVxEarth = %.6f [km/s]", vxE);
        printf ("\nVyEarth = %.6f [km/s]", vyE);
        fprintf (res,"\nVyEarth = %.6f [km/s]", vyE);
        printf ("\nVzEarth = %.6f [km/s]", vzE);
        fprintf (res,"\nVzEarth = %.6f [km/s]", vzE);

        printf ("\n\n������ = %.6f [km]", rE);
        fprintf (res,"\n������ = %.6f [km]", rE);
        printf ("\n�������� = %.6f [km/s]", VE);
        fprintf (res,"\n�������� = %.6f [km/s]", VE);

    cout <<"\n\n���������� � �������� ������� \n";
    fprintf (res,"\n\n���������� � �������� ������� \n");

        printf ("\nxJupiter = %.2f [km]", xJ);
        fprintf (res,"\nxJupiter = %.2f [km]", xJ);
        printf ("\nyJupiter = %.2f [km]", yJ);
        fprintf (res,"\nyJupiter = %.2f [km]", yJ);
        printf ("\nzJupiter = %.2f [km]", zJ);
        fprintf (res,"\nzJupiter = %.2f [km]", zJ);

        printf ("\n\nVxJupiter = %.6f [km/s]", vxJ);
        fprintf (res,"\n\nVxJupiter = %.6f [km/s]", vxJ);
        printf ("\nVyJupiter = %.6f [km/s]", vyJ);
        fprintf (res,"\nVyJupiter = %.6f [km/s]", vyJ);
        printf ("\nVzJupiter = %.6f [km/s]", vzJ);
        fprintf (res,"\nVzJupiter = %.6f [km/s]", vzJ);

        printf ("\n\n������ = %.6f [km]", rJ);
        fprintf (res,"\n������ = %.6f [km]", rJ);
        printf ("\n�������� = %.6f [km/s]\n", VJ);
        fprintf (res,"\n�������� = %.6f [km/s]\n", VJ);

        cout <<"\n\n*** ������ ������������������ ������� *** \n\n";
        fprintf (res,"\n\n*** ������ ������������������ ������� *** \n\n");

        double vectEJ[3], norm_vectEJ=0.; //��������� ��������� ������������ ������-�������� ����� � ������� � �� �������
        vectEJ[0] = yE*zJ - zE*yJ;
        vectEJ[1] = -xE*zJ + zE*xJ;
        vectEJ[2] = xE*yJ - xJ*yE;

        printf ("\n��������� ������������ ������-�������� ����� � �������: ");
        fprintf (res,"\n��������� ������������ ������-�������� ����� � �������: ");

        for (int k = 0; k < 3; k++)
            {
                printf ("\n%e", vectEJ[k]);
                fprintf (res,"\n%e", vectEJ[k]);
                norm_vectEJ += vectEJ[k]*vectEJ[k];
            }
        norm_vectEJ = sqrt (norm_vectEJ);

        printf ("\n\n������� ���������� ������������ ������-�������� ����� � ������� = %e\n", norm_vectEJ);
        fprintf (res,"\n\n������� ���������� ������������ ������-�������� ����� � ������� = %e\n", norm_vectEJ);

        double ort_vnesh[3];//��������� ��� ������� �������

        for (int k = 0; k < 3; k++)
            {
            ort_vnesh[k] = vectEJ[k]/norm_vectEJ;
            printf ("\n��� ������� �������  = %.6f", ort_vnesh[k]);
            fprintf (res,"\n��� ������� �������  = %.6f", ort_vnesh[k]);
            }

        double
        scalarEJ = xE*xJ + yE*yJ + zE*zJ,
        fi = acos (scalarEJ/rE/rJ); //������� ��������� �������
        printf ("\n\n������� ��������� �������(fi) = %.6f [deg]", fi*toDeg);
        fprintf (res,"\n\n������� ��������� �������(fi) = %.6f [deg]", fi*toDeg);

        if (fi > pi) fi = fi-2*pi; //���� ����������� �������

        double i = acos (ort_vnesh[2]); //���������� ������
        printf ("\n���������� ������(i) = %.6f [deg]", i*toDeg);
        fprintf (res,"\n���������� ������(i) = %.6f [deg]", i*toDeg);

        double Omega; //������� ����������� ���� ������
        if (ort_vnesh[0]>=0)
            Omega = acos (-ort_vnesh[1]/sin(i));
        else
            Omega = 2*pi - acos (-ort_vnesh[1]/sin(i));
        printf ("\n������� ����������� ���� ������(Omega) = %.6f [deg]", Omega*toDeg);
        fprintf (res,"\n������� ����������� ���� ������(Omega) = %.6f [deg]", Omega*toDeg);
        // ������ ��������
        double ist_an, exs, p, a, E0, Ek, n, t_lamb; //������ ����������
        double ist_an_temp, exs_temp, p_temp, a_temp, E0_temp, Ek_temp, t_lamb_temp, n_temp;//������ �������������� ����������

        for (ist_an = 0; ist_an<2*pi; ist_an += 0.001*toRad)//������� ���� ��� ����������� �������� ��������
        {
            fprintf (res_lamb,"\n%f", ist_an);//������ � ���� �������� �������� ��������, ������� ������������ �� 0 �� 360 ��������
            exs = (rJ/rE - 1) / (cos(ist_an) - rJ/rE * cos(ist_an+fi));//������ ���������������
            fprintf (res_lamb,"\t%f", exs);//������ � ���� �������� ���������������
            p = rE*(1+cos(ist_an)*exs);//������ ���������� ���������
            fprintf (res_lamb,"\t%f", p);//������ � ���� �������� ���������� ���������
            if (exs>1)
                a = p/(exs*exs - 1);//������ ������� �������
            if (exs<1)
                a = p/(1 - exs*exs);//������ ������� �������
            fprintf (res_lamb,"\t%f", a);//������ � ���� �������� ������� �������
            if ((exs <1.)&&(exs>0.))
                {
                E0 = 2*atan(sqrt((1-exs)/(1+exs))*tan(ist_an/2));//������ ��������������� �������� ��������� �����
                fprintf (res_lamb,"\t%f", E0);//������ � ���� ��������������� �������� ��������� �����
                Ek = 2*atan(sqrt((1-exs)/(1+exs))*tan((ist_an+fi)/2));//������ ��������������� �������� �������� �����
                fprintf (res_lamb,"\t%f", Ek);//������ � ���� ��������������� �������� �������� �����
                }
            else//��� ������������ ������� ��������� ��������������� �������� ��������� � �������� ����� ������������� �������� 0
                {
                E0 = 0;
                fprintf (res_lamb,"\t%f", E0);
                Ek = 0;
                fprintf (res_lamb,"\t%f", Ek);
                }
                if (a>0)
            n = sqrt (muS/abs(a*a*a));//������ �������� ��������
                else
            n = 1;
            fprintf (res_lamb,"\t%f", n);//������ � ���� �������� �������� ��������
            t_lamb = (Ek - E0 - exs * sin(Ek)+exs*sin(E0))/n/3600/24;//������ ������� ������
            fprintf (res_lamb,"\t%f", t_lamb);

            if ((t_lamb>t12)&&(abs(t_lamb-t12)<eps))//��� ���������� ������� ������ ����������� �������� ����������
            {
                ist_an_temp = ist_an;
                exs_temp = exs;
                p_temp = p;
                a_temp = a;
                E0_temp = E0;
                Ek_temp = Ek;
                t_lamb_temp = t_lamb;
                n_temp = n;
                break;
            }
        }
        printf ("\n�������� �������� = %.8f [deg]", ist_an_temp*toDeg);
        fprintf (res,"\n�������� �������� = %.8f [deg]", ist_an_temp*toDeg);

        printf ("\n����� �� �������� = %.5f [day]", t_lamb_temp);
        fprintf (res,"\n����� �� �������� = %.5f [day]", t_lamb_temp);

        printf ("\n��������������(e) = %.6f", exs_temp);
        fprintf (res,"\n��������������(e) = %.6f", exs_temp);

        printf ("\n��������� ��������(p) = %.6f [km]", p_temp);
        fprintf (res,"\n��������� ��������(p) = %.6f [km]", p_temp);

        printf ("\n������� �������(a) = %.6f [km]", a_temp);
        fprintf (res,"\n������� �������(a) = %.6f [km]", a_temp);

        printf ("\n������� ��������(n) = %.6f", n_temp);
        fprintf (res,"\n������� ��������(n) = %.6f", n_temp);

        printf ("\n��������������� �������� ��������� �����(E0) = %.6f", E0_temp*toDeg);
        fprintf (res,"\n��������������� �������� ��������� �����(E0) = %.6f", E0_temp*toDeg);

        printf ("\n��������������� �������� �������� �����(Ek) = %.6f", Ek_temp*toDeg);
        fprintf (res,"\n��������������� �������� �������� �����(Ek) = %.6f", Ek_temp*toDeg);

    double u0, uk, w0; //������ ���������� ��� ������� ���������� ������(u) � ��������� (w)

    u0 = acos((xE*cos(Omega)+yE*sin(Omega))/rE);
    uk = u0 + fi;
    printf ("\n\n�������� ������ (u) ����� ������(u0) = %.6f [deg]", u0*toDeg);
    fprintf (res,"\n\n�������� ������ (u) ����� ������(u0) = %.6f [deg]", u0*toDeg);
    printf ("\n�������� ������ (u) ����� �������(uk) = %.6f [deg]", uk*toDeg);
    fprintf (res,"\n�������� ������ (u) ����� �������(uk) = %.6f [deg]", uk*toDeg);

    w0 = u0 - ist_an + 2*pi;
    printf ("\n\n�������� ��������� (w0) ����� ������(w0) = %.6f [deg]", w0*toDeg);
    fprintf (res,"\n\n�������� ��������� (w0) ����� ������(w0) = %.6f [deg]", w0*toDeg);

    double Vr0, Vt0, Vrk, Vtk, V0, Vk, Vb0, Vbk; //������� ���������� � ��������������� ������������
                                                //��������� � ����������� ��
    Vr0 = sqrt (muS/p_temp)*exs_temp*sin(ist_an_temp);
    Vt0 = sqrt (muS/p_temp)*(1+exs_temp*cos(ist_an_temp));
    Vb0 = 0;
    V0 = sqrt (Vr0*Vr0 + Vt0*Vt0);

    Vrk = sqrt (muS/p_temp)*exs_temp*sin(ist_an_temp+fi);
    Vtk = sqrt (muS/p_temp)*(1+exs_temp*cos(ist_an_temp+fi));
    Vbk = 0;
    Vk = sqrt (Vrk*Vrk + Vtk*Vtk);

    cout <<"\n\n�������� � ������ ������������������ ������� � ����������� ��";
    fprintf (res,"\n\n�������� � ������ ������������������ ������� � ����������� ��");

    printf ("\n\n1)V0 = %.6f [km/s]", V0);
    fprintf (res,"\n\n1)V0 = %.6f [km/s]", V0);
    printf ("\n  Vr0 = %.6f [km/s]", Vr0);
    fprintf (res,"\n  Vr0 = %.6f [km/s]", Vr0);
    printf ("\n  Vt0 = %.6f [km/s]", Vt0);
    fprintf (res,"\n  Vt0 = %.6f [km/s]", Vt0);
    printf ("\n  Vb0 = %.1f [km/s]", Vb0);
    fprintf (res,"\n  Vb0 = %.1f [km/s]", Vb0);

    cout <<"\n\n�������� � ����� ������������������ ������� � ����������� ��";
    fprintf (res,"\n\n�������� � ����� ������������������ ������� � ����������� ��");

    printf ("\n\n2)Vk = %.6f [km/s]", Vk);
    fprintf (res,"\n\n2)Vk = %.6f [km/s]", Vk);
    printf ("\n  Vrk = %.6f [km/s]", Vrk);
    fprintf (res,"\n  Vrk = %.6f [km/s]", Vrk);
    printf ("\n  Vtk = %.6f [km/s]", Vtk);
    fprintf (res,"\n  Vtk = %.6f [km/s]", Vtk);
    printf ("\n  Vbk = %.1f [km/s]", Vbk);
    fprintf (res,"\n  Vbk = %.1f [km/s]", Vbk);

    double // ������� �������� �� ����������� � ������������� ��
        l11 = cos(u0)*cos(Omega) - sin(u0)*cos(i)*sin(Omega),
        m11 = -sin(u0)*cos(Omega) - cos(u0)*sin(Omega)*cos(i),
        n11 = sin(Omega)*sin(i),

        l21 = cos(u0)*sin(Omega) + sin(u0)*cos(i)*cos(Omega),
        m21 = -sin(u0)*sin(Omega) + cos(u0)*cos(Omega)*cos(i),
        n21 = -cos(Omega)*sin(i),

        l31 = sin(u0)*sin(i),
        m31 = cos(u0)*sin(i),
        n31 = cos(i);

    double
        l12 = cos(uk)*cos(Omega) - sin(uk)*cos(i)*sin(Omega),
        m12 = -sin(uk)*cos(Omega) - cos(uk)*sin(Omega)*cos(i),
        n12 = sin(Omega)*sin(i),

        l22 = cos(uk)*sin(Omega) + sin(uk)*cos(i)*cos(Omega),
        m22 = -sin(uk)*sin(Omega) + cos(uk)*cos(Omega)*cos(i),
        n22 = -cos(Omega)*sin(i),

        l32 = sin(uk)*sin(i),
        m32 = cos(uk)*sin(i),
        n32 = cos(i);


        double //�������� � ������������� ��
            Vx_ec_0 = l11*Vr0 + m11*Vt0 + n11*Vb0,
            Vy_ec_0 = l21*Vr0 + m21*Vt0 + n21*Vb0,
            Vz_ec_0 = l31*Vr0 + m31*Vt0 + n31*Vb0,

            Vx_ec_k = l12*Vrk + m12*Vtk + n12*Vbk,
            Vy_ec_k = l22*Vrk + m22*Vtk + n22*Vbk,
            Vz_ec_k = l32*Vrk + m32*Vtk + n32*Vbk;

        double
            V_ec_0 = sqrt(Vx_ec_0*Vx_ec_0 + Vy_ec_0*Vy_ec_0 + Vz_ec_0*Vz_ec_0),
            V_ec_k = sqrt(Vx_ec_k*Vx_ec_k + Vy_ec_k*Vy_ec_k + Vz_ec_k*Vz_ec_k);

            cout <<"\n\n�������� � ������ ������������������ ������� � ������������� ��";
            fprintf (res,"\n\n�������� � ������ ������������������ ������� � ������������� ��");

            printf ("\n\n1)V_ec_0 = %.6f [km/s]", V_ec_0);
            fprintf (res,"\n\n1)V_ec_0 = %.6f [km/s]", V_ec_0);
            printf ("\n  Vx_ec_0 = %.6f [km/s]", Vx_ec_0);
            fprintf (res,"\n  Vx_ec_0 = %.6f [km/s]", Vx_ec_0);
            printf ("\n  Vy_ec_0 = %.6f [km/s]", Vy_ec_0);
            fprintf (res,"\n  Vy_ec_0 = %.6f [km/s]", Vy_ec_0);
            printf ("\n  Vz_ec_0 = %.6f [km/s]", Vz_ec_0);
            fprintf (res,"\n  Vz_ec_0 = %.6f [km/s]", Vz_ec_0);

            cout <<"\n\n�������� � ����� ������������������ ������� � ������������� ��";
            fprintf (res,"\n\n�������� � ����� ������������������ ������� � ������������� ��");

            printf ("\n\n2)V_ec_k = %.6f [km/s]", V_ec_k);
            fprintf (res,"\n\n2)V_ec_k = %.6f [km/s]", V_ec_k);
            printf ("\n  Vx_ec_k = %.6f [km/s]", Vx_ec_k);
            fprintf (res,"\n  Vx_ec_k = %.6f [km/s]", Vx_ec_k);
            printf ("\n  Vy_ec_k = %.6f [km/s]", Vy_ec_k);
            fprintf (res,"\n  Vy_ec_k = %.6f [km/s]", Vy_ec_k);
            printf ("\n  Vz_ec_k = %.6f [km/s]", Vz_ec_k);
            fprintf (res,"\n  Vz_ec_k = %.6f [km/s]", Vz_ec_k);

        double //���������� ��������������� �������� ��������� � ������������� ��
            V_inf_st_x =Vx_ec_0 - vxE,
            V_inf_st_y =Vy_ec_0 - vyE,
            V_inf_st_z =Vz_ec_0 - vzE,

            V_inf_end_x =Vx_ec_k - vxJ,
            V_inf_end_y =Vy_ec_k - vyJ,
            V_inf_end_z =Vz_ec_k - vzJ,

            V_inf_st = sqrt(V_inf_st_x*V_inf_st_x + V_inf_st_y*V_inf_st_y + V_inf_st_z*V_inf_st_z),
            V_inf_end =  sqrt(V_inf_end_x*V_inf_end_x + V_inf_end_y*V_inf_end_y + V_inf_end_z*V_inf_end_z);

            cout <<"\n\n��������������� ������� �������� ����� ������ �� ���������� �����";
            fprintf (res,"\n\n��������������� ������� �������� ����� ������ �� ���������� �����");

            printf ("\n\n1)V_inf_st = %.6f [km/s]", V_inf_st);
            fprintf (res,"\n\n1)V_inf_st = %.6f [km/s]", V_inf_st);
            printf ("\n  V_inf_st_x = %.6f [km/s]", V_inf_st_x);
            fprintf (res,"\n  V_inf_st_x = %.6f [km/s]", V_inf_st_x);
            printf ("\n  V_inf_st_y = %.6f [km/s]", V_inf_st_y);
            fprintf (res,"\n  V_inf_st_y = %.6f [km/s]", V_inf_st_y);
            printf ("\n  V_inf_st_z = %.6f [km/s]", V_inf_st_z);
            fprintf (res,"\n  V_inf_st_z = %.6f [km/s]", V_inf_st_z);

            cout <<"\n\n��������������� ������� �������� ��� ������� � �������";
            fprintf (res,"\n\n��������������� ������� �������� ��� ������� � �������");

            printf ("\n\n2)V_inf_end = %.6f [km/s]", V_inf_end);
            fprintf (res,"\n\n2)V_inf_end = %.6f [km/s]", V_inf_end);
            printf ("\n  V_inf_end_x = %.6f [km/s]", V_inf_end_x);
            fprintf (res,"\n  V_inf_end_x = %.6f [km/s]", V_inf_end_x);
            printf ("\n  V_inf_end_y = %.6f [km/s]", V_inf_end_y);
            fprintf (res,"\n  V_inf_end_y = %.6f [km/s]", V_inf_end_y);
            printf ("\n  V_inf_end_z = %.6f [km/s]\n\n", V_inf_end_z);
            fprintf (res,"\n  V_inf_end_z = %.6f [km/s]\n\n", V_inf_end_z);



            cout <<"\n*** ������ ���������������� ������� *** \n";

            fprintf (res,"\n*** ������ ���������������� ������� *** \n");



    double//������ ������� � �������������� ��
        epsilon_E = 23.44*toRad,
        V_eqv_inf_X = V_inf_st_x,
        V_eqv_inf_Y = V_inf_st_y * cos(epsilon_E) - V_inf_st_z * sin(epsilon_E),
        V_eqv_inf_Z = V_inf_st_y * sin(epsilon_E) + V_inf_st_z * cos(epsilon_E),
        V_eqv_inf = sqrt(V_eqv_inf_X*V_eqv_inf_X + V_eqv_inf_Y*V_eqv_inf_Y + V_eqv_inf_Z*V_eqv_inf_Z);

        cout <<"\n\n�������������� �������� ��������������� ��������";
        fprintf (res,"\n\n�������������� �������� ��������������� ��������");

        printf ("\n\nV_eqv_inf = %.6f [km/s]", V_eqv_inf);
        fprintf (res,"\n\nV_eqv_inf = %.6f [km/s]", V_eqv_inf);
        printf ("\nV_eqv_inf_X = %.6f [km/s]", V_eqv_inf_X);
        fprintf (res,"\nV_eqv_inf_X = %.6f [km/s]", V_eqv_inf_X);
        printf ("\nV_eqv_inf_Y = %.6f [km/s]", V_eqv_inf_Y);
        fprintf (res,"\nV_eqv_inf_Y = %.6f [km/s]", V_eqv_inf_Y);
        printf ("\nV_eqv_inf_Z = %.6f [km/s]\n", V_eqv_inf_Z);
        fprintf (res,"\nV_eqv_inf_Z = %.6f [km/s]\n", V_eqv_inf_Z);

    double//��������� ��������������� ������ ���
        h_orb_Earth = 200,
        r_earth = 6371,
        r_pi = r_earth + h_orb_Earth,
        r0 = r_pi,
        i_geo = 51.6 * toRad,
        V0_geoc = sqrt(muE/r0),

        e_geoc0 = 1 + (r0 * V_eqv_inf * V_eqv_inf) / muE,
        p_geoc0 = r0 * (1 + e_geoc0),
        a_geoc0 = p_geoc0 / (e_geoc0*e_geoc0 - 1),

        Vn = sqrt(muE/p_geoc0) * (1 + e_geoc0),
        n_geo = sqrt(muE/abs(a_geoc0*a_geoc0*a_geoc0));

        printf ("\n��������� ��������� �������� ������� ������: ");
        fprintf (res,"\n��������� ��������� �������� ������� ������: ");

        printf ("\n������ = %.1f [km]", r0);
        fprintf (res,"\n������ = %.1f [km]", r0);
        printf ("\n���������� = %.1f [deg]", i_geo*toDeg);
        fprintf (res,"\n���������� = %.1f [deg]", i_geo*toDeg);
        printf ("\nC������� � ��������� ����� ������ = %.6f [km/s]", V0_geoc);
        fprintf (res,"\n�������� � ��������� ����� ������ = %.6f [km/s]", V0_geoc);

        printf ("\n��������� ��������������� ����������: ");
        fprintf (res,"\n��������� ��������������� ����������: ");

        printf ("\n\n��������������(e) = %.6f", e_geoc0);
        fprintf (res,"\n\n��������������(e) = %.6f", e_geoc0);
        printf ("\n��������� ��������(p) = %.6f [km]", p_geoc0);
        fprintf (res,"\n��������� ��������(p) = %.6f [km]", p_geoc0);
        printf ("\n������� �������(a) = %.6f [km]", a_geoc0);
        fprintf (res,"\n������� �������(a) = %.6f [km]", a_geoc0);
        printf ("\n������� ��������(n) = %.6f", n_geo);
        fprintf (res,"\n������� ��������(n) = %.6f", n_geo);

        printf ("\n\n�������� �� ����� �������� ���������� ����� = %.6f [km/s]\n\n", Vn);
        fprintf (res,"\n\n�������� �� ����� �������� ���������� ����� = %.6f [km/s]\n\n", Vn);

    double //��������� ������� ����������� ����, ���������, �����������,
        // �������� ���������� � ������������� ���������� ����� ������
        gamma1 = sign(cos(i_geo)),
        gamma2 = sign(V_eqv_inf_Y),
        nu = gamma2 * acos(V_eqv_inf_X / sqrt(V_eqv_inf_Y*V_eqv_inf_Y + V_eqv_inf_X*V_eqv_inf_X)),
        Omega_geo[2],
        psi = acos(-1/e_geoc0),
        phi[2],
        xyz[2],
        w_geo[2],
        delta[2],
        alfa[2],
        XA[2],
        YA[2],
        ZA[2];
    printf ("���� ����� ������ ����� � ���������� ���������(nu_lim) = %.6f [deg]\n\n",psi*toDeg);
    fprintf (res,"���� ����� ������ ����� � ���������� ���������(nu_lim) = %.6f [deg]\n\n",psi*toDeg);
    for (int j = 1; j<3; j++)
        {
            Omega_geo[j] = nu + (1-j)*pi + pow(-1,j)*asin((V_eqv_inf_Z * 1/tan(i_geo))/sqrt(V_eqv_inf_Y*V_eqv_inf_Y + V_eqv_inf_X*V_eqv_inf_X))+pi/2*(1-gamma1);
            if (Omega_geo[j]*toDeg<0)
                Omega_geo[j]=Omega_geo[j]+2*pi;

            phi[j] = sign(V_eqv_inf_Z) * acos((V_eqv_inf_X*cos(Omega_geo[j]) + V_eqv_inf_Y*sin(Omega_geo[j]))/(V_eqv_inf));

            w_geo[j] = phi[j] - psi;

            delta[j] =asin(sin(w_geo[j]) * sin(i_geo)); //asin(V_eqv_inf_Z/sqrt(V_eqv_inf_X*V_eqv_inf_X + V_eqv_inf_Y*V_eqv_inf_Y + V_eqv_inf_Z*V_eqv_inf_Z));

            if ( (w_geo[j]<=pi/2)&&(w_geo[j]>=0) || (w_geo[j]<=2*pi)&&(w_geo[j]<=(3*pi)/2) )
            alfa[j] = Omega_geo[j] + asin((sin(w_geo[j]) * cos(i_geo))/sqrt(1-sin(w_geo[j])*sin(w_geo[j])*sin(i_geo)*sin(i_geo)));
            else
            alfa[j] = Omega_geo[j] + (pi - asin((sin(w_geo[j]) * cos(i_geo))/sqrt(1-sin(w_geo[j])*sin(w_geo[j])*sin(i_geo)*sin(i_geo))));

            XA[j] = r0*cos(delta[j])*cos(alfa[j]);
            YA[j] = r0*cos(delta[j])*sin(alfa[j]);
            ZA[j] = r0*sin(delta[j]);
            xyz[j] = sqrt(XA[j]*XA[j] + YA[j]*YA[j] + ZA[j]*ZA[j]);

        printf ("������� ����������� ����(Omega)[%d] = %.6f [deg]\n",j,Omega_geo[j]*toDeg);
        fprintf (res,"������� ����������� ����(Omega)[%d] = %.6f [deg]\n",j,Omega_geo[j]*toDeg);
        printf ("���� ����� ������ ����� � ��������� �� � ������ ������(phi)[%d] = %.6f [deg]\n",j,phi[j]*toDeg);
        fprintf (res,"���� ����� ������ ����� � ��������� �� � ������ ������(phi)[%d] = %.6f [deg]\n",j,phi[j]*toDeg);
        printf ("�������� ������ ����� ������(u)[%d] = %.6f [deg]\n",j,w_geo[j]*toDeg);
        fprintf (res,"�������� ������ ����� ������(u)[%d] = %.6f [deg]\n",j,w_geo[j]*toDeg);
        printf ("��������� ����� ������(delta)[%d] = %.6f [deg]\n",j,delta[j]*toDeg);
        fprintf (res,"��������� ����� ������(delta)[%d] = %.6f [deg]\n",j,delta[j]*toDeg);
        printf ("������ ����������� ����� ������(alfa)[%d] = %.6f [deg]\n\n",j,alfa[j]*toDeg);
        fprintf (res,"������ ����������� ����� ������(alfa)[%d] = %.6f [deg]\n\n",j,alfa[j]*toDeg);
        printf ("XA[%d] = %.6f\n",j,XA[j]);
        fprintf (res,"XA[%d] = %.6f\n",j,XA[j]);
        printf ("YA[%d] = %.6f\n",j,YA[j]);
        fprintf (res,"YA[%d] = %.6f\n",j,YA[j]);
        printf ("ZA[%d] = %.6f\n\n",j,ZA[j]);
        fprintf (res,"ZA[%d] = %.6f\n\n",j,ZA[j]);
        printf ("sqrt(XA^2 + YA^2 + ZA^2)[%d] = %.6f\n\n",j,xyz[j]);
        fprintf (res,"xyz[%d] = %.6f\n\n",j,xyz[j]);
        }


            cout <<"\n*** ������ �������������������� ������� *** \n";

            fprintf (res,"\n*** ������ �������������������� ������� *** \n");

        double//�������������� ������
        r_pi_min = 670900,
        r_pi_max = 1200000,
        e_grav,
        nu_grav,
        p_grav,
        a_grav,
        rotation_angle;

        double //����� �������
            gamma_planet,

            ortX,
            ortY,
            ortZ,
            normort,

            i_gip,

            V_grav_X_inf,
            V_grav_Y_inf,
            V_grav_Z_inf,
            V_grav_inf,
            V_grav_gel_X,
            V_grav_gel_Y,
            V_grav_gel_Z,
            V_grav_gel,
            dV_grav,

            betta = 180*toRad - 2*acos(pow((1+(r_pi_min * (V_inf_end*V_inf_end))/muJ),-1.0)),
            Vxy_inf = sqrt(V_inf_end_x*V_inf_end_x + V_inf_end_y*V_inf_end_y);

        double //����������������� ������ ����� ��������������� �������
            ort_gel_X,
            ort_gel_Y,
            ort_gel_Z,
            normort_gel,
            vnesh_ort_X,
            vnesh_ort_Y,
            vnesh_ort_Z,

            i_gelio,
            Omega_gelio,
            p_gelio,
            e_gelio,
            a_gelio,
            r_pi_gelio,
            r_a_gelio;

                fprintf (res_gamma,"\ngamma");

                fprintf (res_gamma,"\tV_grav_X_inf");
                fprintf (res_gamma,"\tV_grav_Y_inf");
                fprintf (res_gamma,"\tV_grav_Z_inf");
                fprintf (res_gamma,"\tV_grav_inf");

                fprintf (res_gamma,"\ti_gip");

                fprintf (res_gamma,"\tortX");
                fprintf (res_gamma,"\tortY");
                fprintf (res_gamma,"\tortZ");
                fprintf (res_gamma,"\tnormort");

                fprintf (res_gamma,"\tV_grav_gel_X");
                fprintf (res_gamma,"\tV_grav_gel_Y");
                fprintf (res_gamma,"\tV_grav_gel_Z");
                fprintf (res_gamma,"\tV_grav_gel");
                fprintf (res_gamma,"\tdV_grav");

                fprintf (res_gelio,"\ngamma");
                fprintf (res_gelio,"\tort_gel_X");
                fprintf (res_gelio,"\tort_gel_Y");
                fprintf (res_gelio,"\tort_gel_Z");
                fprintf (res_gelio,"\tnormort_gel");
                fprintf (res_gelio,"\tvnesh_ort_X");
                fprintf (res_gelio,"\tvnesh_ort_Y");
                fprintf (res_gelio,"\tvnesh_ort_Z");

                fprintf (res_gelio,"\ti_gelio");
                fprintf (res_gelio,"\tOmega_gelio");
                fprintf (res_gelio,"\tp_gelio");
                fprintf (res_gelio,"\te_gelio");
                fprintf (res_gelio,"\ta_gelio");
                fprintf (res_gelio,"\tr_pi_gelio");
                fprintf (res_gelio,"\tr_a_gelio");

            for (gamma_planet = 0; gamma_planet<2*pi; gamma_planet += 0.1*toRad)
                {//����������� ���������������� ������� �������� ����� ��������������� �������
            V_grav_X_inf = V_inf_end_x * cos(betta) - (V_inf_end_y*V_inf_end)/Vxy_inf * sin(betta)*cos(gamma_planet) - (V_inf_end_x*V_inf_end_z)/Vxy_inf * sin(betta)*sin(gamma_planet);
            V_grav_Y_inf = V_inf_end_y * cos(betta) + (V_inf_end_x*V_inf_end)/Vxy_inf * sin(betta)*cos(gamma_planet) - (V_inf_end_y*V_inf_end_z)/Vxy_inf * sin(betta)*sin(gamma_planet);
            V_grav_Z_inf = V_inf_end_z * cos(betta) + Vxy_inf * sin(betta)*sin(gamma_planet);
            V_grav_inf = sqrt(V_grav_X_inf*V_grav_X_inf + V_grav_Y_inf*V_grav_Y_inf + V_grav_Z_inf*V_grav_Z_inf);
            //��� ������� �������
            ortX = V_inf_end_y*V_grav_Z_inf - V_inf_end_z*V_grav_Y_inf;
            ortY = V_grav_X_inf*V_inf_end_z - V_grav_Z_inf*V_inf_end_x;
            ortZ = V_inf_end_x*V_grav_Y_inf - V_inf_end_y*V_grav_X_inf;
            normort = sqrt(ortX*ortX + ortY*ortY + ortZ*ortZ);
            i_gip = acos(ortZ/normort);
            //����������������� �������� ����� ��������������� �������
            V_grav_gel_X = V_grav_X_inf + vxJ;
            V_grav_gel_Y = V_grav_Y_inf + vyJ;
            V_grav_gel_Z = V_grav_Z_inf + vzJ;
            V_grav_gel = sqrt(V_grav_gel_X*V_grav_gel_X + V_grav_gel_Y*V_grav_gel_Y + V_grav_gel_Z*V_grav_gel_Z);
            dV_grav = V_grav_gel - V_ec_k;

            ort_gel_X = yJ*V_grav_gel_Z - zJ*V_grav_gel_Y;
            ort_gel_Y = zJ*V_grav_gel_X - xJ*V_grav_gel_Z;
            ort_gel_Z = xJ*V_grav_gel_Y - yJ*V_grav_gel_X;
            normort_gel = sqrt(ort_gel_X*ort_gel_X + ort_gel_Y*ort_gel_Y + ort_gel_Z*ort_gel_Z);
            vnesh_ort_X = ort_gel_X/normort_gel;
            vnesh_ort_Y = ort_gel_Y/normort_gel;
            vnesh_ort_Z = ort_gel_Z/normort_gel;
            //��������� ����������������� ������ ����� ���� �������
            i_gelio = acos(vnesh_ort_Z);

            if (vnesh_ort_X > 0)
            Omega_gelio = acos((-vnesh_ort_Y)/sin(i_gelio));
            else
            Omega_gelio = 2*pi - acos((-vnesh_ort_Y)/sin(i_gelio));

            p_gelio = (normort_gel*normort_gel)/muS;
            e_gelio = sqrt(1 + (V_grav_gel*V_grav_gel - 2*muS/rJ) * (normort_gel*normort_gel/muS/muS));
            a_gelio = p_gelio/(1-e_gelio*e_gelio);
            r_pi_gelio = p_gelio/(1+e_gelio);
            r_a_gelio = p_gelio/(1-e_gelio);

            fprintf (res_gamma,"\n%.4f", gamma_planet*toDeg);

            fprintf (res_gamma,"\t%.4f", V_grav_X_inf);
            fprintf (res_gamma,"\t%.4f", V_grav_Y_inf);
            fprintf (res_gamma,"\t%.4f", V_grav_Z_inf);
            fprintf (res_gamma,"\t%.4f", V_grav_inf);

            fprintf (res_gamma,"\t%.4f", i_gip*toDeg);

            fprintf (res_gamma,"\t%.4f", ortX);
            fprintf (res_gamma,"\t%.4f", ortY);
            fprintf (res_gamma,"\t%.4f", ortZ);
            fprintf (res_gamma,"\t%.4f", normort);

            fprintf (res_gamma,"\t%.4f", V_grav_gel_X);
            fprintf (res_gamma,"\t%.4f", V_grav_gel_Y);
            fprintf (res_gamma,"\t%.4f", V_grav_gel_Z);
            fprintf (res_gamma,"\t%.4f", V_grav_gel);

            fprintf (res_gamma,"\t%.4f", dV_grav);

            fprintf (res_gelio,"\n%.4f", gamma_planet*toDeg);
            fprintf (res_gelio,"\t%.4f", ort_gel_X);
            fprintf (res_gelio,"\t%.4f", ort_gel_Y);
            fprintf (res_gelio,"\t%.4f", ort_gel_Z);
            fprintf (res_gelio,"\t%.4f", normort_gel);
            fprintf (res_gelio,"\t%.4f", vnesh_ort_X);
            fprintf (res_gelio,"\t%.4f", vnesh_ort_Y);
            fprintf (res_gelio,"\t%.4f", vnesh_ort_Z);

            fprintf (res_gelio,"\t%.4f", i_gelio*toDeg);
            fprintf (res_gelio,"\t%.4f", Omega_gelio*toDeg);
            fprintf (res_gelio,"\t%.4f", p_gelio/au);
            fprintf (res_gelio,"\t%.4f", e_gelio);
            fprintf (res_gelio,"\t%.4f", a_gelio/au);
            fprintf (res_gelio,"\t%.4f", r_pi_gelio/au);
            fprintf (res_gelio,"\t%.4f", r_a_gelio/au);
                }

            fprintf (res_betta,"\nr_pi_min");
            fprintf (res_betta,"\tbetta");
            fprintf (res_betta,"\te_grav");
            fprintf (res_betta,"\tp_grav");
            fprintf (res_betta,"\ta_grav");
            fprintf (res_betta,"\tnu_grav");
            //��������� ������� ���������� ��������� ������
            for (r_pi_min; r_pi_min<=r_pi_max ;r_pi_min += 100)
                {
            rotation_angle = 2*asin(1/(1+((r_pi_min*V_inf_end*V_inf_end)/muJ))),
            a_grav = muJ/V_grav_inf,
            e_grav = 1 + (r_pi_min*V_inf_end*V_inf_end)/muJ,
            nu_grav = acos(-1/e_grav),
            p_grav = a_grav*(e_grav*e_grav - 1),
            fprintf (res_betta,"\n%f", r_pi_min);
            fprintf (res_betta,"\t%f", rotation_angle*toDeg);
            fprintf (res_betta,"\t%.4f", e_grav);
            fprintf (res_betta,"\t%.4f", p_grav);
            fprintf (res_betta,"\t%.4f", a_grav);
            fprintf (res_betta,"\t%.4f", nu_grav*toDeg);
                }

        printf ("\n\n��� ���������� ������� ��������������� �������, ��� ������ ���� �������� � �����");
        fprintf (res,"\n\n��� ���������� ������� ��������������� �������, ��� ������ ���� �������� � �����");

        printf ("\n\n������� �������� �������� �� ������ �������\n");
        fprintf (res,"\n\n������� �������� �������� �� ������ �������\n");

            double//������ ������� � �������������� ��
        alfa_Jup = 268.057*toRad,
        delta_Jup = 64.496*toRad,
        V_Jup_inf[3],
        V_Jup_inf_temp[3],
        V_Jup_inf_end[3],
        V_Jup_infinity;

        //������� epsilon_E
        double arr_eps[3][3];
        arr_eps[0][0] = 1;
        arr_eps[0][1] = 0;
        arr_eps[0][2] = 0;

        arr_eps[1][0] = 0;
        arr_eps[1][1] = cos(epsilon_E);
        arr_eps[1][2] = -sin(epsilon_E);

        arr_eps[2][0] = 0;
        arr_eps[2][1] = sin(epsilon_E);
        arr_eps[2][2] = cos(epsilon_E);

        //������� alfa
        double arr_alfa[3][3];
        arr_alfa[0][0] = -sin(alfa_Jup);
        arr_alfa[0][1] = cos(alfa_Jup);
        arr_alfa[0][2] = 0;

        arr_alfa[1][0] = -cos(alfa_Jup);
        arr_alfa[1][1] = -sin(alfa_Jup);
        arr_alfa[1][2] = 0;

        arr_alfa[2][0] = 0;
        arr_alfa[2][1] = 0;
        arr_alfa[2][2] = 1;

        //������� delta
        double arr_delta[3][3];
        arr_delta[0][0] = 1;
        arr_delta[0][1] = 0;
        arr_delta[0][2] = 0;

        arr_delta[1][0] = 0;
        arr_delta[1][1] = sin(delta_Jup);
        arr_delta[1][2] = cos(delta_Jup);

        arr_delta[2][0] = 0;
        arr_delta[2][1] = -cos(delta_Jup);
        arr_delta[2][2] = sin(delta_Jup);

        //������ ���������������� ������� �������� � ���. ��. ��
        double arr_V_inf [3];
        arr_V_inf[0] = V_inf_end_x;
        arr_V_inf[1] = V_inf_end_y;
        arr_V_inf[2] = V_inf_end_z;

        //������� �� ������������� � �������������-������������� ��
        V_Jup_inf[0] = arr_eps[0][0]*arr_V_inf[0] + arr_eps[0][1]*arr_V_inf[1] + arr_eps[0][2]*arr_V_inf[2];
        V_Jup_inf[1] = arr_eps[1][0]*arr_V_inf[0] + arr_eps[1][1]*arr_V_inf[1] + arr_eps[1][2]*arr_V_inf[2];
        V_Jup_inf[2] = arr_eps[2][0]*arr_V_inf[0] + arr_eps[2][1]*arr_V_inf[1] + arr_eps[2][2]*arr_V_inf[2];

        V_Jup_inf_temp[0] = arr_alfa[0][0]*V_Jup_inf[0] + arr_alfa[0][1]*V_Jup_inf[1] + arr_alfa[0][2]*V_Jup_inf[2];
        V_Jup_inf_temp[1] = arr_alfa[1][0]*V_Jup_inf[0] + arr_alfa[1][1]*V_Jup_inf[1] + arr_alfa[1][2]*V_Jup_inf[2];
        V_Jup_inf_temp[2] = arr_alfa[2][0]*V_Jup_inf[0] + arr_alfa[2][1]*V_Jup_inf[1] + arr_alfa[2][2]*V_Jup_inf[2];

        V_Jup_inf_end[0] = arr_delta[0][0]*V_Jup_inf_temp[0] + arr_delta[0][1]*V_Jup_inf_temp[1] + arr_delta[0][2]*V_Jup_inf_temp[2];
        V_Jup_inf_end[1] = arr_delta[1][0]*V_Jup_inf_temp[0] + arr_delta[1][1]*V_Jup_inf_temp[1] + arr_delta[1][2]*V_Jup_inf_temp[2];
        V_Jup_inf_end[2] = arr_delta[2][0]*V_Jup_inf_temp[0] + arr_delta[2][1]*V_Jup_inf_temp[1] + arr_delta[2][2]*V_Jup_inf_temp[2];

        V_Jup_infinity = sqrt(V_Jup_inf_end[0]*V_Jup_inf_end[0] + V_Jup_inf_end[1]*V_Jup_inf_end[1] + V_Jup_inf_end[2]*V_Jup_inf_end[2]);

        cout <<"�������������� �������� ������������������� ��������";
        fprintf (res,"�������������� �������� ������������������� ��������");

        printf ("\n\nV_Jup_inf = %.6f [km/s]", V_Jup_infinity);
        fprintf (res,"\n\nV_Jup_inf = %.6f [km/s]", V_Jup_infinity);
        printf ("\nV_Jup_inf_X = %.6f [km/s]", V_Jup_inf_end[0]);
        fprintf (res,"\nV_Jup_inf_X = %.6f [km/s]", V_Jup_inf_end[0]);
        printf ("\nV_Jup_inf_Y = %.6f [km/s]", V_Jup_inf_end[1]);
        fprintf (res,"\nV_Jup_inf_Y = %.6f [km/s]", V_Jup_inf_end[1]);
        printf ("\nV_Jup_inf_Z = %.6f [km/s]", V_Jup_inf_end[2]);
        fprintf (res,"\nV_Jup_inf_Z = %.6f [km/s]", V_Jup_inf_end[2]);

        cout <<"\n\n��������� ��������� ������";
        fprintf (res,"\n\n��������� ��������� ������");
        double
        i_planet = -atan((V_Jup_inf_end[2])/sqrt(V_Jup_inf_end[0]*V_Jup_inf_end[0]+V_Jup_inf_end[1]*V_Jup_inf_end[1])),
        r_pi_planet = 670900,
        e_planet = 1 + (r_pi_planet * V_Jup_infinity * V_Jup_infinity) / muJ,
        a_planet = (muJ/V_Jup_infinity/V_Jup_infinity),
        p_planet = a_planet * (e_planet*e_planet - 1),
        V0_planet = sqrt(muJ/r_pi_planet),
        Vpi_planet = sqrt((2*muJ)/r_pi_planet + V_Jup_infinity*V_Jup_infinity);

        printf ("\ni_Jup = %.6f [Deg]", i_planet*toDeg);
        fprintf (res,"\ni_Jup = %.6f [Deg]", i_planet*toDeg);
        printf ("\nr_pi_planet = %.6f [Deg]", r_pi_planet);
        fprintf (res,"\nr_pi_planet = %.6f [Deg]", r_pi_planet);
        printf ("\ne_planet = %.6f [Deg]", e_planet);
        fprintf (res,"\ne_planet = %.6f [Deg]", e_planet);
        printf ("\na_planet = %.6f [Deg]", a_planet);
        fprintf (res,"\na_planet = %.6f [Deg]", a_planet);
        printf ("\np_planet = %.6f [Deg]", p_planet);
        fprintf (res,"\np_planet = %.6f [Deg]", p_planet);
        printf ("\nV0_planet = %.6f [Deg]", V0_planet);
        fprintf (res,"\nV0_planet = %.6f [Deg]", V0_planet);
        printf ("\nVpi_planet = %.6f [Deg]", Vpi_planet);
        fprintf (res,"\nVpi_planet = %.6f [Deg]", Vpi_planet);

        //������ ��������� �������� �� ������ �������
        double
        r_a_Jup_min = 1600000,
        r_a_Jup_max = 4000000,
        r_pi_Jup = 670900,
        p_el,
        a_el,
        e_el,
        T_el,
        V_a_el,
        V_pi_el,
        dV_Jup,
        dV_Jup_circ,
        dV2 = 2 * sin(i_planet/2);

        fprintf (res_sat,"\nr_a_Jup_min");
        fprintf (res_sat,"\tp_el");
        fprintf (res_sat,"\te_el");
        fprintf (res_sat,"\ta_el");
        fprintf (res_sat,"\tT_el");
        fprintf (res_sat,"\tV_pi_el");
        fprintf (res_sat,"\tV_a_el");
        fprintf (res_sat,"\tdV_Jup");
        fprintf (res_sat,"\tdV_Jup_circ");
        //����������� ������������� ������ ����� ������� �������, ��������� �� ���������
        for (r_a_Jup_min; r_a_Jup_min<=r_a_Jup_max ;r_a_Jup_min += 10000)
        {
        p_el = (2*r_pi_Jup*r_a_Jup_min)/(r_pi_Jup+r_a_Jup_min);
        e_el = (r_a_Jup_min - r_pi_Jup)/(r_pi_Jup+r_a_Jup_min);
        a_el = p_el / (1 - e_el*e_el);
        T_el = 2 * pi * sqrt((a_el*a_el*a_el)/muJ);
        V_pi_el = sqrt((2*muJ*r_a_Jup_min)/(r_pi_Jup*(r_a_Jup_min+r_pi_Jup)));
        V_a_el = sqrt((2*muJ*r_pi_Jup)/(r_a_Jup_min*(r_a_Jup_min+r_pi_Jup)));
        dV_Jup = Vpi_planet - V_pi_el;
        dV_Jup_circ = V_pi_el - V0_planet;
            fprintf (res_sat,"\n%.4f", r_a_Jup_min);
            fprintf (res_sat,"\t%.4f", p_el);
            fprintf (res_sat,"\t%.4f", e_el);
            fprintf (res_sat,"\t%.4f", a_el);
            fprintf (res_sat,"\t%.4f", T_el/86400);
            fprintf (res_sat,"\t%.4f", V_pi_el);
            fprintf (res_sat,"\t%.4f", V_a_el);
            fprintf (res_sat,"\t%.4f", dV_Jup);
            fprintf (res_sat,"\t%.4f", dV_Jup_circ);
        }
        printf ("\ndV2 = %.6f [Deg]", dV2);
        fprintf (res,"\ndV2 = %.6f [Deg]", dV2);

        cout <<"\n��������� ������������� ������ ���� �������� � ����";
        fprintf (res,"\n��������� ������������� ������ ���� �������� � ����");
    return 0;
}
