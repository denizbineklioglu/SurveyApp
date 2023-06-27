using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface ISurveyService
    {
        Task CreateSurveyAsync(CreateSurveyRequest model);
        Task<IList<SurveyQuestionsListResponse>> GetSurveyQuestions(int id);

        Task<IEnumerable<SurveyListResponse>> GetSurveyList();
        
    }
}
