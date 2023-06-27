using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Option
    {
        [Key]
        public int OptionID { get; set; }
        public string Value { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
