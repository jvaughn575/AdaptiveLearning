using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveLearning.Models
{
    public class SavedMathQuiz
    {
        [Key]
        public int ID { get; set; }
        public string questions { get; set; }
        public DateTime created { get; set; }
        public string UserID { get; set; }


        public ICollection<ResultMathQuiz> Results { get; set; }
    }
}
