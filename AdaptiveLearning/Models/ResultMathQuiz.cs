using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public enum EmotionalState
    {
      Anger,
      Contempt,
      Disgust,
      Fear,
      Happiness,
      Neutral,
      Sadness,
      Surprise
    }

    public class ResultMathQuiz
    {       
        public int points { get; set; }
        public ICollection<Double> secsperquestion { get; set; }
        public ICollection<EmotionalState?> EmotionalStatePerQuestion { get; set; }


        public int QuizID { get; set; }


        
    }
}
