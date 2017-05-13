using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public class QuizResult
    {
        public int SavedMathQuizID { get; set; }
        public SavedMathQuiz SavedMathQuiz { get; set; }

        public int ResultMathQuizID { get; set; }
        public ResultMathQuiz ResultMathQuiz { get; set; }
    }
}
