#include <iostream>
#include <math.h>
#include <stdio.h>
#include <fstream>

using namespace std;

#define Pi 3.14159
#define mu 398600.4
#define wz 7.292115/100000
#define rz 6378.136
#define re 6378.137

#define ha 860.0
#define hp 210.0
#define M 0.0
#define eps 0.001
#define a 0.0033528



int main()
{
	    setlocale(LC_ALL, "Russian");
	double e, delT ,dell , delp, period, ra, u, p, du, w, Ra, Rp, S, T, W, q, sigma, fi, i, omega, IST, m, Cxa, Fa, Sa, Ballk, S1, T1, W1, S2, T2, W2;
	IST = 0;
	w = 0;
	omega = 0.15708;
	i = 0.911062;
	u = 0.471239;
	m = 2500;
	Cxa = 2;
	Sa = 12;
	ofstream fout("Result without.txt");
	fout << '\t';
	fout << "IST       " << '\t';
	fout << "p       " << '\t';
	fout << "i       " << '\t';
	fout << "omega      " << '\t';
	fout << "e       " << '\t';
	fout << "w       " << '\t';
	fout << "S       " << '\t';
	fout << "T       " << '\t';
	fout << "W       " << '\t' << '\n';

	e = sqrt(1 - (hp + rz)*(hp + rz) / (ha + rz) / (ha + rz));
	cout << "e = " << e << '\n';
	Ra = rz + ha;
	Rp = rz + hp;
	p = Rp * (1 + e);
	cout << "p = " << p << '\n';

	q = wz * wz*rz*rz / mu;
	sigma = mu * re*re*(a - q / 2);
	Fa = (Cxa * q*Sa) / m;
	Ballk = (Cxa * Sa) / 2*m;
	period = (2*Pi)/sqrt(a*a*a);
    // ќценка вековых уходов
    delp = -4*Pi*Ballk*p*p*Rp;
    dell = 0;
    delT = (-12*period*period/sqrt(mu))* Ballk * sqrt((pow(p, 5)))*Rp;
	cout << "sigma = " << sigma << '\n';
	cout << "Fa = " << Fa << '\n';
	cout << "Delta P (изменение фокального парметра) = " << delp << '\n';
	cout << "Delta T = " << delT << '\n';
	cout << "Delta e = " << dell << '\n';
	cout << "ѕериод (cек) = " << period <<'\n';
	ra = p / (1 + e * cos(IST));
	for (u = 0; u<8 * Pi;)
	{

		du = 0.1;
		IST = u - w;
		ra = p / (1 + e * cos(IST));
		fi = asin(sin(i)*sin(u));


		S1=((sigma)/(pow(ra,4)))*(3*pow(sin(u),2)*pow(sin(i),2)-1);
        T1=(-sigma)/(pow(ra,4))*(pow(sin(i),2)*sin(2*u));
        W1=(-sigma)/(pow(ra,4))*(sin(2*i)*sin(u));

        T2=-Fa*(1+e*cos(IST))/sqrt(1+e*e+2*e*cos(IST));
        S2=-Fa*e*sin(IST)/sqrt(1+e*e+2*e*cos(IST));
        W2=0;

        S=S1+S2;
        T=T1+T2;
        W=W1+W2;

		p = 2 * ra*ra*ra / mu * T*du + p;
		e = ra * ra / mu * (sin(IST)*S + cos(IST)*(1 + ra / p)*T + e * ra / p * T)*du + e;
		w = ra * ra / (mu*e)*(-cos(IST)*S + e * sin(IST)*(1 + ra / p)*T - e * ra / (p*tan(i))*sin(u)*W)*du + w;
		omega = ra * ra*ra*sin(u) / (mu*p*sin(i))*W*du + omega;
		i = ra * ra*ra*cos(u) / (mu*p)*W*du + i;

		u = u + du;


		fout.width(15);
		fout << IST << '\t';

		fout.width(15);
		fout << p << '\t';

		fout.width(15);
		fout << i << '\t';

		fout.width(15);
		fout << omega << '\t';

		fout.width(15);
		fout << e << '\t';

		fout.width(15);
		fout << w << '\t';

		fout.width(15);
		fout << S << '\t';

		fout.width(15);
		fout << T << '\t';

		fout.width(15);
		fout << W << '\n';


	}
	fout.close();
	return 0;
}

