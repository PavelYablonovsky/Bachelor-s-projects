#include <iostream>
#include <windows.h>
#include <locale.h>
#include <fstream>
#include <stdio.h>
#include <math.h>
using namespace std;

int main()
{
          setlocale(LC_ALL,"russian");
        cout<<"¬ведите количество точек ";
        int n;
        cin>>n;
        int m=n;

        int i,j;
        double *l;
        l=new double [n+20];
        double times=1;
        double sum=0;
        double f[n];
        double dx=1;


        double *buff;
        buff=new double[n];
        FILE *fr,*fw;

        if (!(fr=fopen("test.txt","r"))){
            cout<<"Error"<<endl;
            return -1;
        }
        if (!(fw=fopen("result.txt","w"))){
            cout<<"Error"<<endl;
            return -1;
        }
        for(i=0;i<n;i++){
            if(!(fscanf(fr,"%lf%lf",&buff[i],&f[i])==2)){
            cout<<"Error2"<<endl;
            fclose(fr);
            return -2;
            }
            cout<<buff[i]<<'\t';
            cout<<f[i]<<endl;
        }
     /*int S=0;
      cout<<"\n";
        for(int j=1;j<n;j++)
            {
                for(int i=0;i<n-j;i++){
                    f[i]=(f[i+1]-f[i])/(buff[i+j]-buff[i]);
                        //l[i]=f[i];
                    //f[i-1]=fx[i][j];
                    cout<<f[i]<<endl;
                    l[S]=f[i];
                    S++;
                }
               // dx*=
        }
        */
    int S=0;
      cout<<"\n";
        for(j=1;j<n;j++)
            {
                for(i=n-1;i>=j;i--){
                    f[i]=(f[i]-f[i-1])/(buff[i]-buff[i-j]);
                        //l[i]=f[i];
                    //f[i-1]=fx[i][j];
                   // cout<<f[i]<<endl;
                   // l[S]=f[i];
                //    S++;
                }

        }

        //for(int j=1;j<n;j++)

        for(i=0;i<n;i++)
           cout<<f[i]<<endl;

        double sum1=0;
        double px=f[0];
        double x=-5;
        double delta_x=0.003;
        for(i=0;i<5000;i++,x+=delta_x)
        {
            for(j=n-2,sum1=f[n-1];j>=0;j--)
            {
                 sum1=(x-buff[j])*sum1+f[j];
                // printf("sum1=%lf j=%d i=%d\n",sum1,j,i);
            }
            fprintf(fw,"%lf %lf\n",x,sum1);
        }
        cout<<"\n";
        //for(int i=0;i<n;i++){
         //   cout<<f[i]<<endl;

       // }

        fclose(fr);
        fclose(fw);
        return 0;
}
