using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class MCQQuestion : Question
    {

        public override void AskToEnterRightChoice()
        {
            Console.Write("Please Choose The Right Answer Id : ");
            CheckRightChoice();
        }

        public override void CreateChoices()
        {
            Console.Write("Enter The Number Of Choices for the Question : ");
            int numberOfChoices = 0 ;
            while (!int.TryParse(Console.ReadLine() , out numberOfChoices) && numberOfChoices ==0)
                Console.WriteLine("Invalid input. Please enter a valid integer.");


            for (int i = 0; i < numberOfChoices; i++)
            {
                Console.Write($"Enter Choice {i + 1 } : ");
                string answerText = Console.ReadLine();
                
                Answers?.Add(new Answer { AnswerId = i +1  , AnswerText = answerText });
            }
            
        }

        public override void CreateQuestion()
        {
            this.Header = "MCQ Question";
            Console.WriteLine(Header);
            Console.Write("Enter The Body Of The Question : ");
            this.Body = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter The Mark For The Question : ");

                if (int.TryParse(Console.ReadLine(), out int mark))
                {
                    Mark = mark;
                    break;
                }
                else
                {
                    Console.Write("Please Enter A Numeric Value that Represents The Mark of The Question : ");
                }
            }
        }
        public override void AskForAnswer()
        {
            Console.Write("Enter your Answer Id : ");
        }
    }
}
