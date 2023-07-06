using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyQuestionsListResponse
    {
        //public string Title { get; set; }
        //public string Description { get; set; }
        public string Text { get; set; }
        public int RangeValue { get; set; }
        public IList<Question> Questions { get; set; }
        public IList<Option> Options { get; set; }
        public int QuestionType { get; set; }
        public int SurveyID { get; set; }
    }
}
