using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public class QuizResultBundle
    {
        public SavedMathQuiz quiz { get; set; }
        public ResultMathQuiz result { get; set; }
    }
}
