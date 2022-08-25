#include <iostream>
#include <math.h>
#include <locale>
#include <cstdlib>
#include <ctime>
#include <time.h>
#include <stdio.h>

#define MAXPRINT 10

using namespace std;

double *jordan (double *a, double *y, int n) {
double *x, max;
int k, index;
const double eps = 0.00001;
x = new double[n];
k = 0;
while (k < n) {
max = fabs(a[k*n+k]);
index = k;
for (int i = k + 1; i < n; i++) {
if (fabs(a[i*n+k]) > max) {
max = fabs(a[i*n+k]);
index = i;
}
}
if (max < eps) {
cout << "Решений нет тк есть нулевой столбец " ;
cout << index << " матрицы A" << '\n';
return 0;
}
for (int j = 0; j < n; j++) { //прямой ход
double array = a[k*n+j];
a[k*n+j] = a[index*n+j];
a[index*n+j] = array;
}
double array = y[k];
y[k] = y[index];
y[index] = array;
for (int i = k; i < n; i++) { //проверка макс элемента
double array = a[i*n+k];
if (fabs(array) < eps) continue;
for (int j = 0; j < n; j++) {
a[i*n+j] = a[i*n+j] / array;
}
y[i] = y[i] / array;
if (i == k) continue;
for (int j = 0; j < n; j++)
a[i*n+j] = a[i*n+j] - a[k*n+j];
y[i] = y[i] - y[k];
}
k++;
}
for (k = n - 2; k >= 0; k--) { //обратный ход
for (int i = k+1; i < n; i++){
    x[k] = y[k]+a[i*n+k] * x[k];
y[i] = 1./(y[i] * a[i*n+k] - x[k]);}
}
cout<<"fsdf"<<k;
return x;
}

int main() {
setlocale(LC_ALL, "Russian");

double *a, *y, *x, *a2, t;
int n;
cout << "Размерность матрицы: ";
cin >> n;
a = new double[n*n];
a2 = new double[n*n];
y = new double[n];
srand(time(NULL));
for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
    //cout << "a[" << i << "][" << j << "]= ";
    a[i*n+j] = rand()%100 ;
    //cin>>a[i*n+j];
    }
}
if(n>10){
    for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
        cout<<a[i*n+j]<<"\t";
        }
        cout<<". . .\t"<<a[i*n+(n-1)]<<"\t";
    cout<<"\n";
    }
cout<<"\n";

for(int i=0;i<3;i++){for (int j = 0; j < 10; j++){cout<<'.'<<'\t';} cout<<'\t'<<'.'<<'\n';} cout<<'\n';


    for (int j = 0; j < 10; j++) {
        cout<<a[(n-1)*n+j]<<"\t";
        }
        cout<<". . .\t"<<a[(n-1)*n+(n-1)]<<"\t";
}else{
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
        cout<<a[i*n+j]<<"\t";
        }
    cout<<"\n";
    }
}
cout<<"\n";cout<<"\n";

for (int i = 0; i < n; i++) {
    //cout << "y[" << i << "]= ";
    y[i]= rand()%100;

    //cout<<y[i]<<endl;
}
cout<<endl;
t=clock();
x = jordan(a, y, n);
t=clock()-t;
printf("Time is %lf seconds\n", t/CLOCKS_PER_SEC);
if(n>10)
{
    for (int i = 0; i < 10; i++)
    {
        cout << "x[" << i << "]=" << x[i] << '\n';
    }
    cout<<".\n.\n.\n";
    cout << "x[" << n-1 << "]=" <<x[n-1];

}
else
{
    for (int i = 0; i < n; i++)
    {
        cout << "x[" << i << "]=" << x[i] << '\n';
    }
}
cout<<"\nПроверка :"<<endl;
for(int i=0;i<n;i++){
for(int j=0;j<n;j++){
//cout << "a[" << i << "][" << j << "]= ";
a2[i*n+j]=x[i]-y[i];
//cout<<a2[i*n+j]<<'\t';
}
//cout<<'\n';
}

if(n>10){
    for (int i = 0; i < 10; i++) {
        for (int j = 0; j < 10; j++) {
        cout<<a2[i]<<"\t";
        }
        cout<<". . .\t"<<a2[(n-1)]<<"\t";
    cout<<"\n";
    }
cout<<"\n";

for(int i=0;i<3;i++){for (int j = 0; j < 10; j++){cout<<'.'<<'\t';} cout<<'\t'<<'.'<<'\n';} cout<<'\n';


    for (int j = 0; j < 10; j++) {
        cout<<a2[(n-1)*n+j]<<"\t";
        }
        cout<<". . .\t"<<a2[(n-1)*n+(n-1)]<<"\t";
}else{
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
        cout<<a2[i*n+j]<<"\t";
        }
    cout<<"\n";
    }
}
cin.get();cin.get();
return 0;
}
