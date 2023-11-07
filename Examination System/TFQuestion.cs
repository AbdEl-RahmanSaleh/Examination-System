using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class TFQuestion : Question
    {
        public override void CreateQuestion()
        {
            this.Header = "True | False Question";
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
        public override void CreateChoices()
        {
            Answers?.Add(new Answer{ AnswerId = 1 ,AnswerText = "True"});
            Answers?.Add(new Answer{ AnswerId = 2 ,AnswerText = "False"});
        }

        public override void AskToEnterRightChoice()
        {
            Console.Write("Please Choose The Right Answer Id (1 for True | 2 for False) : ");
            CheckRightChoice();
        }

        public override void AskForAnswer()
        {
            Console.Write("Enter your Answer Id (1 for True | 2 for False): ");
        }
    }
}
