#include <iostream>
#include <windows.h>
#include <locale.h>
#include <fstream>
#include <stdio.h>
#include <math.h>
#include <iomanip>
using namespace std;
void f(double x, double *y,double *dy){
dy[0]=y[1];
dy[1]=-y[0];
}
void Runge(double a,double b,double n,double *y,double *yy,double *yyy,double *dy,double *k1,double *k2,double *k3,double *k4,double *k5,double *k6,double *k7,double *y1,double *y2){
double err,b1,b2,b3,b4,b5,b6,b7;
double b1_2,b2_2,b3_2,b4_2,b5_2,b6_2,b7_2;
double h=0.01;
FILE *fw;
fw=fopen("resM.txt","w");
int i;
double x=a;
int m=2;
b1=35./384;
b2=0;
b3=500./1113;
b4=125./192;
b5=-2187./6784;
b6=11./84;
b7=0;

b1_2=5179./57600;
b2_2=0;
b3_2=7571./16695;
b4_2=393./640;
b5_2=-92097./339200;
b6_2=187./2100;
b7_2=1./40;

for (int j=0;x<100.*M_PI;j++){
    for ( i=0;i<m;i++){
    y1[i]=y[i];
    y2[i]=y[i];
    }
f(x,y1,k1);
    for ( i=0;i<m;i++){
    y1[i]=y[i]+h*0.2*k1[i];
    }

f(x+0.2*h,y1,k2);
    for (i=0;i<m;i++){
    y1[i]=y[i]+h*(3./40*k1[i]+9./40*k2[i]);
    }

f(x+0.3*h,y1,k3);
    for ( i=0;i<m;i++){
    y1[i]=y[i]+h*(44./45*k1[i]-56./15*k2[i]+32./9*k3[i]);
    }

f(x+4./5*h,y1,k4);
     for ( i=0;i<m;i++){
    y1[i]=y[i]+h*(19372./6561*k1[i]-25360./2187*k2[i]+64448./6561*k3[i]-212./729*k4[i]);
    }

f(x+8./9*h,y1,k5);
    for ( i=0;i<m;i++){
    y1[i]=y[i]+h*(9017./3168*k1[i]-355./33*k2[i]+46732./5247*k3[i]+49./176*k4[i]-5103./18656*k5[i]);
    }

f(x+1*h,y1,k6);
    for (i=0;i<m;i++){
    y1[i]=y[i]+h*(35./384*k1[i]+0*k2[i]+500./1113*k3[i]+125./192*k4[i]-2187./6784*k5[i]+11./84*k6[i]);
    }
f(x+1*h,y1,k7);
    for (i=0;i<m;i++)
        yy[i]=y[i]+h*(b1*k1[i]+b2*k2[i]+b3*k3[i]+b4*k4[i]+b5*k5[i]+b6*k6[i]+b7*k7[i]);

    for (i=0;i<m;i++)
        yyy[i]=y[i]+h*(b1_2*k1[i]+b2_2*k2[i]+b3_2*k3[i]+b4_2*k4[i]+b5_2*k5[i]+b6_2*k6[i]+b7_2*k7[i]);

    for (i=0,err=0.;i<m;i++)
        err+=(yy[i]-yyy[i])*(yy[i]-yyy[i]);//{cout<<"OK\n";}else{cout<<"NO\n";};

    if(err<1.e-7)
    {
        x+=h;
        for (i=0;i<m;i++)
            y[i]=yyy[i];
    } h=h*fmin(2,fmax(0.5,pow(((1.e-7)/err),1./(5+1))));
    if(x+h>100.*M_PI)
    {
        h=100.*M_PI-x;
    }

    for(i=0;i<m;i++){
    fprintf(fw,"%lf \t%lf\n",y1[0],y1[1]);
    //fprintf(fw,"%lf \t%lf\n",y2[0],y2[1]);
    //printf("%.4lf %.18lf\n",x+h,y[i]);
    }

    }

fclose(fw);
}
int main()
{

    double a=0;
    double b=100*M_PI;
    double h=0.01;
    int n=(b-a)/h+1;
    double *y,*yy,*yyy,*y2,*dy,*k1,*k2,*k3,*k4,*k5,*k6,*k7,*y1;
    y=new double[2];
    yy=new double[2];
    yyy=new double[2];
    dy=new double[2];
    k1=new double[2];
    k2=new double[2];
    k3=new double[2];
    k4=new double[2];
    k5=new double[2];
    k6=new double[2];
    k7=new double[2];
    y1=new double[2];
    y2=new double[2];
    y[0]=0;
    y[1]=1;
    y2[0]=0;
    y2[1]=1;
    Runge(a,b,n,y,yy,yyy,dy,k1,k2,k3,k4,k5,k6,k7,y1,y2);

    return 0;
}
