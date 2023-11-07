using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer RightAnswer { get; set; }
        public Answer StudentAnswer { get; set; } = new Answer();


        public List<Answer> answers = new List<Answer>();
        public List<Answer> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public abstract void CreateQuestion();
        

        public abstract void CreateChoices();
        public abstract void AskForAnswer();
        
        public abstract void AskToEnterRightChoice();
        public void CheckRightChoice()
        {
            while (RightAnswer == null)
            {
                if (int.TryParse(Console.ReadLine() , out int rightAnswerId))
                {
                    RightAnswer = Answers?.Find(answer => answer?.AnswerId == rightAnswerId);

                    if (RightAnswer == null)
                    {
                        Console.WriteLine("Answer Not Found. Please Enter A Valid Answer Id");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }

            }
            
        }




    }
}
