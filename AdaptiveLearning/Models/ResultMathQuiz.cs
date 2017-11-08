using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public int ID { get; set; }
        public string points { get; set; }
        public string secsperquestion { get; set; }
        public string EmotionalStatePerQuestion { get; set; }
        public DateTime created { get; set; }

        [ForeignKey("SavedMathQuiz")]        
        public int SavedMathQuizID { get; set; }

       //public virtual SavedMathQuiz SavedMathQuiz { get; set; }
        
    }
}
