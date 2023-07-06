using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Responses
{
    public class SurveyStatisticResponse
    {
        public int SurveyID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int AnswerCount { get; set; }
    }
}
