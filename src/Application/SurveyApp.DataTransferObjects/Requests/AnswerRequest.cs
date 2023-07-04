using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class AnswerRequest
    {
        public int AnswerID { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public int OptionID { get; set; }
    }
}
