using System.Diagnostics;

namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(10,"C#");
            subject.CreateExam(); 
            Console.Clear();

            Console.Write("Do you want to start the Exam ( Y | N ) ");
            char c = char.Parse(Console.ReadLine());

            if(c == 'y' ||c == 'Y')
            {
                Console.Clear() ;
                Console.WriteLine($"Subject : {subject.SubjectName}\t\t Duration : {subject.Exam.ExamDuration}\t\t Number Of Questions : ({subject.Exam.NumberOfQuestions})  ");
                Stopwatch sw = new Stopwatch();
                sw.Start();
                subject.Exam.ShowExam();
                Console.Clear();
                subject.Exam.CalculateExamMark();
                Console.WriteLine($"The Elapsed time = {sw.Elapsed}");
            }
            else
                Console.WriteLine("Thank you ");
        }
    }
}