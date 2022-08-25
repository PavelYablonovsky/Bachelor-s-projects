#include <iostream>
#include <iomanip>
#include <math.h>
#include <stdio.h>
#include <fstream>

using namespace std;

double F(double x)
{
	return atan (x);
}
int main()
{

	double x = -2,
           x0 = -2,
           e = 0.00000001,
           i = 0,
           df,
           gamma = 1.,
           x_temp;

    df = (F(x + e) - F(x))/e;
    ofstream fout ("result.txt");
    fout<<'\t';
    fout<<x      <<'\t';
    fout<<F(x)      <<'\n';
	do
	{
		x0 = x;
		x_temp = x;
		x = x0 - gamma*F(x)/df;
		if (F(x0) < F (x))
        {
            do
            {
                gamma = gamma*0.5;
                x = x0 - gamma*F(x_temp)/df;
            }
            while (F (x0) > F (x));
        }
		df = (F(x + e) - F(x))/e;
		printf ("\nx = %.18lf", x);
		printf ("\tF(x) = %.2e", F(x));
    fout.width();
    fout<<x<<'\t';
    fout.width();
    fout<<F(x)<<'\n';
		++i;
	}
	while (fabs(F(x))>e);
	cout << "\nITOG:\n";
	printf ("x = %.18lf", x);
	printf ("\nF(x) = %.2e", F(x));
    fout.width();
    fout<<x<<'\n';
    fout.width();
    fout<<F(x)<<'\n';
	cout << "\namount of it. = "<<i;
	cin.get();
	return 0;
}
