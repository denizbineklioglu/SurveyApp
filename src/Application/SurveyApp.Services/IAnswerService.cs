using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public interface IAnswerService
    {
        Task CreateAnswerAsync(List<AnswerRequest> model);
        Task<IList<IstatisticRequest>> GetIstatistic();
    }
}
