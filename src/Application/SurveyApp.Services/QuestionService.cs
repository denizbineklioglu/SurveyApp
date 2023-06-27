using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class QuestionService : IQuestionService
    {

        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task CreateQuestionAsync(CreateQuestionRequest model)
        {
            var question = _mapper.Map<Question>(model);
            await _questionRepository.CreateAsync(question);
        }
    }
}
