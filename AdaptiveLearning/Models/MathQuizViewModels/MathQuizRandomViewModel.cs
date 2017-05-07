using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models.MathQuizViewModels
{
    public class MathQuizRandomViewModel
    {
        

        public string Number1 { get; set; }

        public string Number2 { get; set; }

        public List<string> Operations { get; set; }

        public int NumQuestions { get; set; }

        public MathQuizRandomViewModel() { }

        

       
    }
}
