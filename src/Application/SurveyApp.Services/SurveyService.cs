using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repo;
        private readonly IMapper _mapper;

        public SurveyService(ISurveyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> CreateSurveyAsync(CreateSurveyRequest model)
        {
            var survey = _mapper.Map<Survey>(model);
            await _repo.CreateAsync(survey);
            return survey.SurveyID;
        }

        public async Task<IEnumerable<SurveyListResponse>> GetSurveyList()
        {
            var surveys = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<SurveyListResponse>>(surveys);
        }

        public SurveyQuestionsListResponse GetSurveyQuestions(int id)
        {
            return _repo.GetSurveyQuestions(id);
        }

        public async Task<IEnumerable<SurveyStatisticResponse>> GetSurveyStatisticResponses()
        {
            return await _repo.GetSurveysStatistic();
        }
    }
}
