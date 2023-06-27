using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class CreateOptionRequest
    {
        public string Value { get; set; }
        public int QuestionID { get; set; }
    }
}
