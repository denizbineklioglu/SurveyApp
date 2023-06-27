using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class CreateQuestionRequest
    {
        public string Text { get; set; }
        public int QuestionType { get; set; }
        public int SurveyID { get; set; }
    }
}
