﻿using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public interface ISurveyRepository :IRepository<Survey>
    {
        SurveyQuestionsListResponse GetSurveyQuestions(int id);
        Task<IList<SurveyStatisticResponse>> GetSurveysStatistic();
    }
}
