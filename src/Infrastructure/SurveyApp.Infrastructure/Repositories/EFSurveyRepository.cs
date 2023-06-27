using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<SurveyQuestionsListResponse>> GetSurveyQuestions(int id)
        {
            var result = await _context.Questions.Where(x => x.SurveyID == id).Select(x => new SurveyQuestionsListResponse
            {
               Title = x.Survey.Title,
               Description = x.Survey.Description,
               Options = x.Options.ToList(),
               QuestionType = x.QuestionType,
               Text = x.Text
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
