using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public class MathQuizModel
    {
        private static readonly Random getrandom = new Random();

        public int Number1LowRange { get; set;}
        public int Number1HighRange { get; set; }

        public int Number2LowRange { get; set; }
        public int Number2HighRange { get; set; }

        public List<string> Operations { get; set; }

        public int NumQuestions { get; set; }



        public List<string> GetNextQuestion() 
        {
            string number1 = getrandom.Next(Number1LowRange, Number1HighRange).ToString();
            string number2 = getrandom.Next(Number2LowRange, Number2HighRange).ToString();

            int num = getrandom.Next(Operations.Count);
            string op = Operations[num];

            return new List<string> { number1, op, number2 };

        }
    }
}
