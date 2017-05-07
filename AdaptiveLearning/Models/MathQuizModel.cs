using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public class MathQuizModel
    {
        
        public int Number1LowRange { get; set;}
        public int Number1HighRange { get; set; }

        public int Number2LowRange { get; set; }
        public int Number2HighRange { get; set; }

        public List<string> Operations { get; set; }

        public int NumQuestions { get; set; }
        
        
    }
}
