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
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _repo;
        private readonly IMapper _mapper;

        public OptionService(IOptionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateOptionAsync(CreateOptionRequest model)
        {
            var option = _mapper.Map<Option>(model);
            await _repo.CreateAsync(option);
        }
    }
}
