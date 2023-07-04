using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public int QuestionType { get; set; }

        public int SurveyID { get; set; }
        public Survey Survey { get; set; }

        public ICollection<Option> Options { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
