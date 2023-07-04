using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using SurveyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _repo;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAnswerAsync(List<AnswerRequest> model)
        {
            var answers = _mapper.Map<List<Answer>>(model);
            await _repo.CreateAnswerFull(answers);
        }

        public async Task<IList<IstatisticRequest>> GetIstatistic(int id)
        {
           return await _repo.GetIstatisticDatas(id);
        }
    }
}
