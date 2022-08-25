#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <fstream>

using namespace std;

double integrand (double x){
    double func;
    func=(cos(50*x)+sin(20*x))*(cos(50*x)+sin(20*x));         //заданная функция
    return func;
}

double TrapezoidMethod(double a, double b, int N){         //метод трапеции
    double h=(b-a)/N;
    double evaluation;
    double x;
    evaluation=(integrand(a)+integrand(b))/2;
    for (int i=1;i<=N-1;i++){
        x=a+i*h;
        evaluation+=integrand(x);
    }
    evaluation*=h;
    return evaluation;
}

double MonteCarlo(double a,double b, int N){                  // метод Монте Карло
    srand (time(NULL));

    double* r;
    double* x;
    double* func;
    double sum=0;
    double evaluation;
    r=new double[N];
    x=new double[N];
    func=new double[N];

    for(int i=0;i<N;i++){
        r[i]=(rand()%1000)*0.001;
        x[i]=a+(b-a)*r[i];
        func[i]=integrand(x[i]);
        sum+=func[i];
    }
    evaluation=(b-a)*sum/N;

    if(N<9){
        cout<<"I[i]=    ";
        for(int i=0;i<N;i++){
            cout<<func[i]<<"\n";
        } cout<<'\n';
    }
    return evaluation;
}

int main()
{
    FILE *fw;
    if (!(fw=fopen("Fin.txt","w"))){ 		//открываем файл Fin.txt
            cout<<"Error"<<endl;
            return -1;
        }
    cout<<"calculate the integral of the function: y=(cos(50x)+sin(20x))*(cos(50x)+sin(20x))\n\n";
    int a;
    int b;
    int N;
    cout<<"enter lower and upper integration limits:\n";
    cin>>a>>b;
    cout<<"enter quantity of tests: ";
    cin>>N;

    cout<<"evaluation of Monte Carlo method= "<<MonteCarlo(a,b,N)<<'\n';

    /*for(int i=10;i<N;i++){
        //cout<<MonteCarlo(a,b,i)<<'\n';
        fprintf(fw,"%lf\n",MonteCarlo(a,b,i));
    }

    //cout<<"evaluation of trapezoid method= "<<TrapezoidMethod(a,b,N);
*/
    return 0;
}
