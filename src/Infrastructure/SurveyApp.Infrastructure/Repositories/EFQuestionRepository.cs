using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFQuestionRepository:IQuestionRepository
    {
        private readonly SurveyAppContext _context;

        public EFQuestionRepository(SurveyAppContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Question model)
        {
            await _context.Questions.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Question>> GetAllAsync()
        {
            return await _context.Questions.ToListAsync();
        }

        public Task<Question?> GetByIdAsync(int id)
        {
            return _context.Questions.SingleOrDefaultAsync(s => s.QuestionID == id);
        }

        public async Task UpdateAsync(Question model)
        {
            _context.Questions.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
