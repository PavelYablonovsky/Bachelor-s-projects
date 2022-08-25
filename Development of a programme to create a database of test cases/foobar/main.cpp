#include <iostream>
#include <fstream>
#include <string>
#include "exam.h"

using namespace std;

int main()
{
    setlocale (LC_ALL, "rus");
    string filename;
    std::cout<<"Set filename"<< std::endl;
    getline(cin, filename);
    exam myTest (filename);
    string line;
    myTest.show_test(filename);
    int a;
    do
    {
    cout<<"To add question, enter 1 "<<'\n';
    cin>>a;
    if (a==1)
    {
     myTest.add_quest(filename);
    }
    }while (a==1);
    int i;
    do
    {
    cout<<"To delete a line, enter 1 "<<'\n';
    cin>>i;
    if (i==1)
    {
    myTest.delete_ex(filename);
    }
    }while (i==1);
    //myTest.rewrite_string(filename);

    return 0;
}
