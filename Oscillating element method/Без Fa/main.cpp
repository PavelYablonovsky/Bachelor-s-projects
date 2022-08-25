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
	double e, delT ,dell , delp, period, ra, u, p, du, w, Ra, Rp, S, T, W, q, sigma, fi, i, omega, IST, m, Cxa, Fa, Sa, Ballk;
	IST = 0;
	w = 0;
	omega = 0.15708;
	i = 0.911062;
	u = 0.471239;
	m = 2500;
	Cxa = 2;
	Sa = 12;
	ofstream fout("Result.txt");
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
	S = ((sigma) / (pow(ra, 4)))*(3 * pow(sin(u), 2)*pow(sin(i), 2) - 1);
	T = (-sigma) / (pow(ra, 4))*(pow(sin(i), 2)*sin(2 * u));
	W = (-sigma) / (pow(ra, 4))*(sin(2 * i)*sin(u));

	for (u = 0; u<8 * Pi;)
	{

		du = 0.1;
		IST = u - w;
		ra = p / (1 + e * cos(IST));
		fi = asin(sin(i)*sin(u));

		S = ((sigma) / (pow(ra, 4)))*(3 * pow(sin(u), 2)*pow(sin(i), 2) - 1);
		T = (-sigma) / (pow(ra, 4))*(pow(sin(i), 2)*sin(2 * u));
		W = (-sigma) / (pow(ra, 4))*(sin(2 * i)*sin(u));

		p = (-2)*sigma / mu / ra * sin(i)*sin(i)*sin(2 * u)*du + p;
		i = (-sigma) / (2 * mu*p*ra)*sin(2 * i)*sin(2 * u)*du + i;
		omega = -2 * sigma / (mu*p*ra)*cos(i)*sin(u)*sin(u)*du + omega;
		e = (sigma / (mu*ra*ra)*(sin(IST)*(3 * sin(u)*sin(u)*sin(i)*sin(i) - 1) - ((1 + ra / p)*cos(IST) + e * ra / p)*sin(2 * u)*sin(i)*sin(i)))*du + e;
		w = sigma / (mu*ra*ra)*(-cos(IST) / e * (3 * sin(u)*sin(u)*sin(i)*sin(i) - 1) - (1 + ra / p)*sin(IST) / e * sin(2 * u)*sin(2 * u)*sin(i)*sin(i) + 2 * ra / p * sin(u)*sin(u)*cos(i)*cos(i))*du + w;


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



