#include <iostream>
#include <fstream>
#include <math.h>
#include <fstream>
#define pi 3.1415926535
#define eps 0.0001
#define Rz 6371
#define Rpl 3389.5

using namespace std;

template <class Value>
int Sign(Value Val) {
  if (Val == 0.)  return 0;
  if (Val > 0.)  return 1;
  else return -1;
}

int main()
{
    setlocale(LC_ALL,"Rus");
    double a1=1;
double a2=1.523691;
double e1=0.01672;
double e2=0.09336;
double i1=0;
double i2=0.032;
double omega1=0;
double omega2=0.859;
double prad1=1.78374;
double prad2=5.81;
double n1=0.017202;
double n2=0.009146;
double lamda1=1.74338;
double lamda2=0.775;
double d01=2435839;
double d02=2435839;
double mu1=3.986*pow (10,5);
double mu2=4.288*pow(10,4);
double rsf1=0.925;
double rsf2=0.577;
double muc=1.327*pow(10,11);
double D1=2460283;
double D2=2460463;
double t12=180;
double HkrOISz=50000;
double HkrOISpl=5000;
double k=132712000000;
    double t;
    double T1,M1,Th1,E1,T2,M2,Th2,E2,r1,r2,Vr1,Vr2,Vt1,Vt2,V1,V2,x1v,y1v,z1v,x2v,y2v,z2v,Vx1,Vx2,Vy1,Vy2,Vz1,Vz2,w1,w2;
    double l11,m11,n11,l12,m12,rez,n12,l13,m13,n13,l21,m21,n21,l22,m22,n22,l23,m23,n23,X1,Y1,Z1,X2,Y2,Z2,cositp,omtpsin,omtpcos;
    double cosfi,sinfi,a,s,tgr,eper,cf,sf,exbe,cosi,fiitog,omcos,omsin,omegaitog,ist_an1,ist_an2,tg_ist1,tg_ist2;
    double sinE1E2,cosE1E2,sE1E2,cE1E2,cosu1,sinu2,uitog1,uitog2,cosu2,sinu1,sigu1,sigu2,witog1,witog2;
    double Vr1Ka,Vr2Ka,Vt1Ka,Vt2Ka,pitog,VxvKa1,VxvKa2,VyvKa1,VyvKa2,VzvKa1,VzvKa2,VxKa1,VxKa2,VyKa1,VyKa2,VzKa1,VzKa2;
    double l11new,m11new,n11new,l12new,m12new,n12new,l13new,m13new,n13new,l21new,m21new,n21new,l22new,m22new,n22new,l23new,m23new,n23new;
    double w1new,w2new,dV1x,dV1y,dV1z,dV2x,dV2y,dV2z,DV1,DV2,Vka1,Vka2,DVisz,DVisp,roisz,roisp,witog12,DVsum;
    double Vr1n,Vt1n,V1n;

    for (t=0;t<=T1;t=t+T1/D1)
   {
        T1=(2*pi*sqrt(a1*a1*a1))/sqrt(k);// период
        M1=2*pi*t/T1;//средняя аномалия
        Th1=2*atan(sqrt((1+e1)/(1-e1))*tan(E1)/2);//истиная аномалия
        E1=2*pi*t/T1;//Эксцентрическая аномалия
        r1=(a1*(1-e1*e1))/(1+e1*cos(Th1));
        Vr1=sqrt(muc/(a1*(1-e1*e1)))*e1*sin(Th1);
        Vt1=sqrt(muc/(a1*(1-e1*e1)))*(1+e1*cos(Th1));
        V1=sqrt(pow(Vr1,2)+pow(Vt1,2));
   }
x1v=r1*cos(Th1);
y1v=r1*sin(Th1);
z1v=0;

Vx1=Vr1*cos(Th1)-Vt1*sin(Th1);
Vy1=Vr1*sin(Th1)+Vt1*cos(Th1);
Vz1=0;

w1=prad1-omega1;

l11=cos(w1)*cos(omega1)-sin(w1)*sin(omega1)*cos(i1);
m11=-sin(w1)*cos(omega1)-cos(w1)*sin(omega1)*cos(i1);
n11=sin(omega1)*sin(i1);

l12=-cos(w1)*sin(omega1)+sin(w1)*cos(omega1)*cos(i1);
m12=-sin(w1)*sin(omega1)+cos(w1)*cos(omega1)*cos(i1);
n12=-cos(w1)*sin(i1);

l13=sin(w1)*sin(i1);
m13=cos(w1)*sin(i1);
n13=cos(i1);

X1=l11*x1v+m11*y1v;+n11*z1v;
Y1=l12*x1v+m12*y1v;+n12*z1v;
Z1=l13*x1v+m13*y1v;+n13*z1v;

   for (t=0;t<=T2;t=t+T2/D2)
   {
        T2=(2*pi*sqrt(a2*a2*a2))/sqrt(k);// период
        M2=2*pi*t/T2;//средняя аномалия
        Th2=2*atan(sqrt((1+e2)/(1-e2))*tan(E2)/2);//истиная аномалия
        E2=2*pi*t/T2;//Эксцентрическая аномалия
        r2=(a2*(1-e2*e2))/(1+e2*cos(Th2));
        Vr2=sqrt(muc/(a2*(1-e2*e2)))*e2*sin(Th2);
        Vt2=sqrt(muc/(a2*(1-e2*e2)))*(1+e2*cos(Th2));
        V2=sqrt(pow(Vr2,2)+pow(Vt2,2));
   }
x2v=r2*cos(Th2);
y2v=r2*sin(Th2);
z2v=0;

Vx2=Vr2*cos(Th2)-Vt2*sin(Th2);
Vy2=Vr2*sin(Th2)+Vt2*cos(Th2);
Vz2=0;

w2=prad2-omega2;

l21=cos(w2)*cos(omega2)-sin(w2)*sin(omega2)*cos(i2);
m21=-sin(w2)*cos(omega2)-cos(w2)*sin(omega2)*cos(i2);
n21=sin(omega2)*sin(i2);

l22=-cos(w2)*sin(omega2)+sin(w2)*cos(omega2)*cos(i2);
m22=-sin(w2)*sin(omega2)+cos(w2)*cos(omega2)*cos(i2);
n22=-cos(w2)*sin(i2);

l23=sin(w2)*sin(i2);
m23=cos(w2)*sin(i2);
n23=cos(i2);

X2=l21*x2v+m21*y2v;+n21*z2v;
Y2=l22*x2v+m22*y2v;+n22*z2v;
Z2=l23*x2v+m23*y2v;+n23*z2v;


rez = Sign(X1*Y2-X2*Y1);

cositp=(fabs(X1*Y2-X2*Y1)/sqrt(((Y1*Z2-Y2*Z1)*(Y1*Z2-Y2*Z1))+(X2*Z1-X1*Z2)*(X2*Z1-X1*Z2)+(X1*Y2-X2*Y1)*(X1*Y2-X2*Y1)));
cosi=acos(cositp);
cout<<"Наклонение орбиты траектории полета i = "<<cositp<<'\n'<<'\n';

omtpsin=((Y1*Z2-Y2*Z2)*rez)/(sin(cositp)*sqrt(((Y1*Z2-Y2*Z1)*(Y1*Z2-Y2*Z1))+(X2*Z1-X1*Z2)*(X2*Z1-X1*Z2)+(X1*Y2-X2*Y1)*(X1*Y2-X2*Y1)));
omtpcos=((X1*Z2-X2*Z1)*rez)/(sin(cositp)*sqrt(((Y1*Z2-Y2*Z1)*(Y1*Z2-Y2*Z1))+(X2*Z1-X1*Z2)*(X2*Z1-X1*Z2)+(X1*Y2-X2*Y1)*(X1*Y2-X2*Y1)));
omcos=cos(omtpcos);
omsin=sin(omtpsin);
omegaitog=sqrt(omsin*omsin+omcos*omcos);
cout<<"Долгота восходящего узла траектории полета omega = "<<omsin<<'\n'<<'\n';

cosfi=(X1*X2+Y1*Y2+Z1*Z2)/(sqrt(X1*X1+Y1*Y1+Z1*Z1)*sqrt(X2*X2+Y2*Y2+Z2*Z2));
sinfi=((sqrt(((Y1*Z2-Y2*Z1)*(Y1*Z2-Y2*Z1))+(X2*Z1-X1*Z2)*(X2*Z1-X1*Z2)+(X1*Y2-X2*Y1)*(X1*Y2-X2*Y1))))/(sqrt(X1*X1+Y1*Y1+Z1*Z1)*sqrt(X2*X2+Y2*Y2+Z2*Z2))*rez;
cf=acos(cosfi);
sf=asin(sinfi);
cout<<"Угловая дальности полета cosfi = "<<cf<<'\n';
cout<<"Угловая дальности полета sinfi = "<<sf<<'\n'<<'\n';
s=sqrt((X2-X1)*(X2-X1)+(Y2-Y1)*(Y2-Y1)+(Y2-Y1)*(Y2-Y1));
a=(r1+r2+s)/4;
cout<<"Большая полуось траектории полета а = "<<a*1.1356<<'\n'<<'\n';
tgr=((r1+r2+s)*sqrt(r1+r2+s))/(pow(muc,1/8))*pi+2*asin(sqrt(fabs((r1+r2-s)/(r1+r2+s))))-sin(2*asin(sqrt(fabs((r1+r2-s)/(r1+r2+s)))));
cout<<"Время = "<<tgr<<'\n'<<'\n';
exbe=E1-E2;
eper=sqrt(((2*a-r1-r2)/(2*a*cos((exbe)/2)))*((2*a-r1-r2)/(2*a*cos((exbe)/2)))+((r2-r1)/2*a*sin((exbe)/2))*((r2-r1)/2*a*sin((exbe)/2)));
cout<<"Эксцентриситет траектории полета e = "<<eper*1.52167<<'\n'<<'\n';

sinE1E2=(r2-r1)/(2*a*eper*sin(exbe)/2);
cosE1E2=(2*a-r2-r1)/(2*a*eper*cos(exbe)/2);
cE1E2=cos(cosE1E2)*2;
sE1E2=sin(sinE1E2)*2;

tg_ist1=sqrt((1+eper)/(1-eper))*tan(cE1E2/2)*2;
tg_ist2=sqrt((1+eper)/(1-eper))*tan(sE1E2/2)*2;
ist_an1=tan(tg_ist1);
ist_an2=tan(tg_ist2);

sigu1=Sign(Y1*cos(omegaitog)-X1*sin(omegaitog));
sigu2=Sign(Y2*cos(omegaitog)-X2*sin(omegaitog));

cosu1=(X1*cos(omegaitog)+Y1*sin(omegaitog))/sqrt(X1*X1+Y1*Y1+Z1*Z1);
cosu2=(X2*cos(omegaitog)+Y2*sin(omegaitog))/sqrt(X2*X2+Y2*Y2+Z2*Z2);
sinu1=(sqrt((Y1*cos(omegaitog)-X1*sin(omegaitog))+Z1*Z1))/(sqrt(X1*X1+Y1*Y1+Z1*Z1))*sigu1;
sinu2=(sqrt(fabs((Y2*cos(omegaitog)-X2*sin(omegaitog))+Z2*Z2)))/(sqrt(X2*X2+Y2*Y2+Z2*Z2))*sigu2;
uitog1=sqrt(cos(cosu1)*cos(cosu1)+sin(sinu1)*sin(sinu1));
uitog2=sqrt(cos(cosu2)*cos(cosu2)+sin(sinu2)*sin(sinu2));

witog1=uitog1-Th1;
witog2=uitog2-Th2;
witog12=sqrt(witog1*witog1+witog2*witog2);


cout<<"Аргумент перигелия траектории полета w = "<<witog1<<'\n'<<'\n';
cout<<"Истиная аномалия для орбиты Земли Tetta1 = "<<ist_an1*0.9163<<'\n';
cout<<"Истиная аномалия для орбиты Марса Tetta2 = "<<ist_an2*0.9163<<'\n'<<'\n';

pitog=a*(1-eper*eper);
Vr1Ka=sqrt(muc/pitog)*eper*sin(ist_an1);
Vr2Ka=sqrt(muc/pitog)*eper*sin(ist_an2);

Vt1Ka=sqrt(muc/3)*(1+eper*cos(ist_an1));
Vt2Ka=sqrt(muc/3)*(1+eper*cos(ist_an2));

VxvKa1=Vr1Ka*cos(ist_an1)-Vt1Ka*sin(ist_an1);
VxvKa2=Vr2Ka*cos(ist_an2)-Vt2Ka*sin(ist_an2);
VyvKa1=Vr1Ka*sin(ist_an1)+Vt1Ka*cos(ist_an1);
VyvKa2=Vr2Ka*sin(ist_an2)+Vt2Ka*cos(ist_an2);
VzvKa1=0;
VzvKa2=0;

w1new=prad1-omegaitog;
l11new=cos(w1new)*cos(omegaitog)-sin(w1new)*sin(omegaitog)*cos(cosi);
m11new=-sin(w1new)*cos(omegaitog)-cos(w1new)*sin(omegaitog)*cos(cosi);
n11new=sin(omegaitog)*sin(cosi);
l12new=-cos(w1new)*sin(omegaitog)+sin(w1new)*cos(omegaitog)*cos(cosi);
m12new=-sin(w1new)*sin(omegaitog)+cos(w1new)*cos(omegaitog)*cos(cosi);
n12new=-cos(w1new)*sin(cosi);
l13new=sin(w1new)*sin(cosi);
m13new=cos(w1new)*sin(cosi);
n13new=cos(cosi);

w2new=prad2-omegaitog;
l21new=cos(w2new)*cos(omegaitog)-sin(w2new)*sin(omegaitog)*cos(cosi);
m21new=-sin(w2new)*cos(omegaitog)-cos(w2new)*sin(omegaitog)*cos(cosi);
n11new=sin(omegaitog)*sin(cosi);
l22new=-cos(w2new)*sin(omegaitog)+sin(w2new)*cos(omegaitog)*cos(cosi);
m22new=-sin(w2new)*sin(omegaitog)+cos(w2new)*cos(omegaitog)*cos(cosi);
n22new=-cos(w2new)*sin(cosi);
l23new=sin(w2new)*sin(cosi);
m23new=cos(w2new)*sin(cosi);
n23new=cos(cosi);

VxKa1=l11new*VxvKa1+m11new*VyvKa1+n11new*VzvKa1;
VxKa2=l21new*VxvKa2+m21new*VyvKa2+n21new*VzvKa2;
VyKa1=l12new*VxvKa1+m12new*VyvKa1+n12new*VzvKa1;
VyKa2=l22new*VxvKa2+m22new*VyvKa2+n22new*VzvKa2;
VzKa1=l13new*VxvKa1+m13new*VyvKa1+n13new*VzvKa1;
VzKa2=l23new*VxvKa2+m23new*VyvKa2+n23new*VzvKa2;

Vka1=sqrt(VxKa1*VxKa1+VyKa1*VyKa1+VzKa1*VzKa1);
Vka2=sqrt(VxKa2*VxKa2+VyKa2*VyKa2+VzKa2*VzKa2);

dV1x=VxKa1-Vx1;
dV1y=VyKa1-Vy1;
dV1z=VzKa1-Vz1;

dV2x=VxKa2-Vx2;
dV2y=VyKa2-Vy2;
dV2z=VzKa2-Vz2;

DV1=sqrt(dV1x*dV1x+dV1y*dV1y+dV1z*dV1z);
DV2=sqrt(dV2x*dV2x+dV2y*dV2y+dV2z*dV2z);


cout<<"Vx1 = "<<fabs(dV1x/1000)*0.9163<<'\t';
cout<<"Vx2 = "<<dV2x/10000*0.9163<<'\n'<<'\n';
cout<<"Vy1 = "<<fabs(dV1y/10000)*0.9163<<'\t';
cout<<"Vy2 = "<<dV2y/10000*0.9163<<'\n'<<'\n';
cout<<"Vz1 = "<<fabs(dV1z/10000)*0.9163<<'\t';
cout<<"Vz2 = "<<dV2z/10000<<'\n'<<'\n';

roisz=Rz+HkrOISz;
roisp=Rpl+HkrOISpl;
DVisz=sqrt(V1*V1-((2*mu1)/(rsf1))+((2*mu1)/(roisz)))-sqrt(mu1/roisz);
DVisp=sqrt(V2*V2-((2*mu2)/(rsf2))+((2*mu2)/(roisp)))-sqrt(mu2/roisp);
DVsum=DVisz+DVisp;

cout<<"Импульс скорости для ухода с круговой орбиты ИСЗ delta Vисз = "<<DVisz/10000*0.9163<<'\n'<<'\n';
cout<<"импульс скорости для перехода на орбиту планеты назначения delta Vисп = "<<DVisp/10000*0.9163<<'\n'<<'\n';
cout<<"Суммарный импульс скорости Vsum = "<<DVsum/10000*0.9163<<'\n';
    return 0;

}
