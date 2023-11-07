using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Examination_System
{
    public class FinalExam : Exam
    {
        public override void CalculateExamMark()
        {
            Console.WriteLine("Model Answer : ");
            foreach (var question in Questions) 
                    Console.WriteLine($"{Questions.IndexOf(question) + 1})  {question.Body} : {question.RightAnswer.AnswerText}");

            Console.WriteLine($"Your Exam Grade is : {studentMark}/{totalMark}");
            Console.WriteLine("Good Luck");
        }
    }
}
