using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public interface IAnswerRepository: IRepository<Answer>
    {
        Task CreateAnswerFull(List<Answer> model);
        Task<IList<IstatisticRequest>> GetIstatisticDatas(int id);
    }
}
