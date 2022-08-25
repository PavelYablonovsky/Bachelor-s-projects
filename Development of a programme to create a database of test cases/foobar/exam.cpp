#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>
#include <iterator>
#include "exam.h"

void exam::set_exercise(std::string filename)
{
    getline (std::cin, exercise);
}

void exam::set_answers(std::string filename)
{
    getline (std::cin, answers);
}

void exam::set_cor_ans(std::string filename)
{
    getline (std::cin, corr_answer);
}

void exam::set_hint(std::string filename)
{
    getline (std::cin, hint);
}

void exam::set_add_inf(std::string filename)
{
    getline (std::cin, add_inform);
}

exam::exam(std::string filename)
{
    std::cout<<"Add exercise"<<std::endl;
    getline (std::cin, exercise);
    std::cout<<"Add answers"<<std::endl;
    getline (std::cin, answers);
    std::cout<<"Add corr_answer"<<std::endl;
    getline (std::cin, corr_answer);
    std::cout<<"Add hint"<<std::endl;
    getline (std::cin, hint);
    std::cout<<"Add additional inform"<<std::endl;
    getline (std::cin, add_inform);
    std::ofstream test (filename.c_str(), std::ios_base::app);
    if (!test.is_open())
        {std::cout << "No such file or directory!" << std::endl;}
    else
        {
            test << "Your exercise: " << exercise << std::endl;
            test << "Choose answer: " << answers << std::endl;
            test << "Correct answer: " << corr_answer << std::endl;
            test << "Hint : " << hint << std::endl;
            test << "Additional information : " << add_inform << std::endl<<'\n';;
        }
    test.close ();
}

void exam::show_test (std::string filename)
{
    std::string line;
    std::ifstream test (filename.c_str());
    if (!test.is_open())
        {
            std::cout << "No such file or directory!" << std::endl;
        }
    else
        {
            while (!test.eof())
                {
                    getline (test,line);
                    std::cout << line << std::endl;
                }
        }
    test.close();
}

void exam::delete_ex(std::string filename)
{
  std::ifstream file_in;
  file_in.open(filename.c_str());
 if(!file_in.is_open())
  {
    std::cout << "Error" << std::endl;
  }
  else
    {
  std::cout <<"Set number string for delete :"<< std::endl;
  int i_number_line_delete = 0;
  std::cin >> i_number_line_delete;
  int i_number_line_now = 0;
  std::string line;
  std::string line_file_text;
 while(getline(file_in,line))
 {
   i_number_line_now++;
   if(!(i_number_line_now == i_number_line_delete))
   {
       line_file_text.insert(line_file_text.size(),line);
       line_file_text.insert(line_file_text.size(),"\r\n");
   }
 }
 file_in.close();
 std::ofstream file_out;
 file_out.open (filename.c_str(),std::ios::trunc | std::ios::binary);
 file_out.write(line_file_text.c_str(), line_file_text.size());
 file_out.clear();
    }
}

void exam::rewrite_string(std::string filename)
{

}

void exam::add_quest(std::string filename)
{
    std::cout<<"Add exercise"<<std::endl;
    getline (std::cin, exercise);
    getline (std::cin, exercise);
    std::cout<<"Add answers"<<std::endl;
    getline (std::cin, answers);
    std::cout<<"Add corr_answer"<<std::endl;
    getline (std::cin, corr_answer);
    std::cout<<"Add hint"<<std::endl;
    getline (std::cin, hint);
    std::cout<<"Add additional inform"<<std::endl;
    getline (std::cin, add_inform);
    std::ofstream test (filename.c_str(), std::ios_base::app);
    if (!test.is_open())
        {std::cout << "No such file or directory!" << std::endl;}
    else
        {
            test << "Your exercise: " << exercise << std::endl;
            test << "Choose answer: " << answers << std::endl;
            test << "Correct answer: " << corr_answer << std::endl;
            test << "Hint : " << hint << std::endl;
            test << "Additional information : " << add_inform << std::endl<<'\n';
        }
    test.close ();
  }

