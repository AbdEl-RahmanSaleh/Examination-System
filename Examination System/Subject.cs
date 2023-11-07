using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        int examType;
        int questionType;

        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public void CreateExam() 
        {
            while (true)
            {
                Console.Write("Enter the Exam Type (1 for Final Exam, 2 for Practical Exam): ");
                if (int.TryParse(Console.ReadLine(), out examType))
                {
                    if (examType == 1)
                    {
                        Exam = new FinalExam();
                        break; 
                    }
                    else if (examType == 2)
                    {
                        Exam = new PracticalExam();
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("Invalid Exam Type. Please enter 1 for Final Exam or 2 for Practical Exam.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid exam type.");
                }
            }


            Console.Write("Enter The Duration of The Exam in Minutes : ");
            Exam.ExamDuration = TimeSpan.Parse(Console.ReadLine());

            int numberOfQuestions = 0;
            Console.Write("Enter Number Of The Questions in the Exam : ");
            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.WriteLine("Invalid input. Please enter a valid number of questions.");
                Console.Write("Enter Number Of The Questions in the Exam : ");
            }

            Exam.NumberOfQuestions = numberOfQuestions;
            List<Question> questions = new List<Question>();

            for (int i = 0; i < numberOfQuestions; i++)
            {
                Console.Clear();
                Question question;

                Console.WriteLine($"Question {i + 1}:");

                questionType = 2;  // Default to MCQ for practical exam
                if (Exam is FinalExam)
                {
                    while (true)
                    {
                        Console.Write("Enter question type (1 for TrueOrFalse , 2 for MCQ): ");
                        if (int.TryParse(Console.ReadLine(), out questionType))
                        {
                            if (questionType == 1)
                            {
                                break;
                            }
                            else if (questionType == 2)
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid question type.");
                        }
                    }
                }

                if (questionType == 1)
                {
                    question = new TFQuestion();
                }
                else if (questionType == 2)
                {
                    question = new MCQQuestion();
                }
                else
                {
                    Console.WriteLine("Invalid Question Type.");
                    continue;
                }

                question.CreateQuestion();
                question.CreateChoices();
                question.AskToEnterRightChoice();
                questions.Add(question);

                if (Exam is FinalExam finalExam)
                {
                    finalExam.Questions = questions;
                }
                else if (Exam is PracticalExam practicalExam)
                {
                    practicalExam.Questions = questions;
                }
                else
                {
                    Console.WriteLine("Something went wrong, please try again.");
                }
            }
        }
    }
}
