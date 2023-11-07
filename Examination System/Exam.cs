using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Exam
    {
        public TimeSpan ExamDuration { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public int studentMark ;
        public int totalMark;
        public abstract void CalculateExamMark();


        public void ShowExam()
        {
            foreach (var question in Questions)
            {
                totalMark += question.Mark;
                Console.WriteLine($"{question.Header}\n{Questions.IndexOf(question) + 1}) {question.Body}\t\t(Mark : {question.Mark})");

                foreach (var answer in question?.Answers)
                {
                    Console.Write($"{answer.AnswerId}- {answer.AnswerText}.\t\t");
                }
                Console.WriteLine("\n--------------------------------------------------------");
                question.AskForAnswer();
                if (int.TryParse(Console.ReadLine(), out int parsedAnswerId))
                {
                    question.StudentAnswer.AnswerId = parsedAnswerId;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                Console.WriteLine("--------------------------------------------------------");
                if (question.StudentAnswer.AnswerId == question.RightAnswer?.AnswerId)
                    studentMark += question.Mark;
            }

        }

        
    }
}
