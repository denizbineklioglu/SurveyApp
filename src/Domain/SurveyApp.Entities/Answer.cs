﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Entities
{
    public class Answer
    {
        [Key]
        public int AnswerID { get; set; }

        public int SurveyID { get; set; }
        public Survey Survey { get; set; }

        public int QuestionID { get; set; }
        public Question Question { get; set; }

        public int OptionID { get; set; }
        public Option Option { get; set; }
    }
}
