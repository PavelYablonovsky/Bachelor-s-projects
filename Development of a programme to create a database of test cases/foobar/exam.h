#ifndef EXAM_H_INCLUDED
#define EXAM_H_INCLUDED

class exam {
std::string exercise;
std::string answers;
std::string corr_answer;
std::string hint;
std::string add_inform;
public:
void set_exercise(std::string);
void set_answers(std::string);
void set_cor_ans(std::string);
void set_hint(std::string);
void set_add_inf(std::string);
void delete_ex(std::string);
void show_test(std::string);
void rewrite_string (std::string);
void add_quest(std::string);
exam (std::string);
};

#endif // EXAM_H_INCLUDED
