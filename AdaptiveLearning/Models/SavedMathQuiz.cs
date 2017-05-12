using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public class SavedMathQuiz
    {

        public int ID { get; set; }
        public string questions { get; set; }
        public DateTime created { get; set; }
        public int UserID { get; set; }
        public ICollection<ResultMathQuiz> Results { get; set; }
    }
}
