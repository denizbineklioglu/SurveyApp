using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.DataTransferObjects.Requests
{
    public class CreateSurveyRequest
    {
        public string Title { get; set; }
        public string Description { get; set;}
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
