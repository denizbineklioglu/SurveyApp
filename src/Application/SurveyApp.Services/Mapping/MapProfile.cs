using AutoMapper;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CreateSurveyRequest, Survey>();
            CreateMap<CreateQuestionRequest, Question>();
            CreateMap<CreateOptionRequest, Option>();

            CreateMap<Survey, SurveyListResponse>();
            CreateMap<AppUserRegisterRequest, AppUser>();
            CreateMap<AnswerRequest, Answer>();
        }
    }
}
