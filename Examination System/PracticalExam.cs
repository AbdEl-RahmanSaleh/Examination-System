using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class PracticalExam : Exam
    {
        public override void CalculateExamMark()
        {
            Console.WriteLine("Model Answer : ");
            foreach (var question in Questions)
            {
                if (question.StudentAnswer.AnswerId == question.RightAnswer?.AnswerId)
                {
                    Console.WriteLine($"The Answer for question {Questions.IndexOf(question)+1} - Is Correct ({question.RightAnswer?.AnswerId}- {question.RightAnswer?.AnswerText})");
                }
                else
                    Console.WriteLine($"The Answer for question {Questions.IndexOf(question)+1} - Is Not Correct , The Right Answer is ({question.RightAnswer?.AnswerId}- {question.RightAnswer?.AnswerText}) ");
            }
            Console.WriteLine("Good Luck");
        }
    }
}
