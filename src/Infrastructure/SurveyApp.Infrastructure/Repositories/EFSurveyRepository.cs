using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFSurveyRepository : ISurveyRepository
    {
        private readonly SurveyAppContext _context;

        public EFSurveyRepository(SurveyAppContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Survey model)
        {
            await _context.Surveys.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Survey>> GetAllAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public Task<Survey?> GetByIdAsync(int id)
        {
            return _context.Surveys.SingleOrDefaultAsync(s => s.SurveyID == id);
        }

        public SurveyQuestionsListResponse GetSurveyQuestions(int id)
        {
            var q =  _context.Questions
                    .Include(x => x.Options)
                    .Include(x => x.Survey)
                    .Where(x => x.SurveyID == id)
                    .Select(x => new SurveyQuestionsListResponse()
                    {
                        SurveyID = id,
                        Options = _context.Options.ToList(),
                        Questions =x.Survey.Questions.ToList(),
                        QuestionType = x.QuestionType,
                        Text = x.Text,                        
                    });

            return q.First();
        }

        public async Task<IList<SurveyStatisticResponse>> GetSurveysStatistic()
        {
            var result = await _context.Surveys
                        .Include(x => x.Answers)
                        .Include(x => x.Questions)
                        .Select(x => new SurveyStatisticResponse()
                        {
                            SurveyID = x.SurveyID,
                            Title = x.Title,
                            IsActive = x.IsActive,
                            AnswerCount = x.Answers.Count
                        }).ToListAsync();

            return result;
        }

        public async Task UpdateAsync(Survey model)
        {
            _context.Surveys.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
