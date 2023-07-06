using Microsoft.EntityFrameworkCore;
using SurveyApp.DataTransferObjects.Requests;
using SurveyApp.DataTransferObjects.Responses;
using SurveyApp.Entities;
using SurveyApp.Infrastructure.Context;
using SurveyApp.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SurveyApp.Infrastructure.Repositories
{
    public class EFAnswerRepository : IAnswerRepository
    {

        private readonly SurveyAppContext _context;
        public EFAnswerRepository(SurveyAppContext context)
        {
            _context = context;
        }

        public async Task CreateAnswerFull(List<Answer> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                await _context.Answers.AddAsync(model[i]);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateAsync(Answer model)
        {
            await _context.Answers.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Answer>> GetAllAsync()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer?> GetByIdAsync(int id)
        {
            return await _context.Answers.SingleOrDefaultAsync(a => a.AnswerID == id);
        }

        public async Task<IList<IstatisticRequest>> GetIstatisticDatas(int id)
        {
            var result = await _context.Answers
                        .Include(x => x.Option)
                        .Include(y => y.Question)
                        .Where(x => x.SurveyID == id)
                        .GroupBy(x => new { x.OptionID, x.SurveyID, x.Option.Value })
                        .Select(x => new IstatisticRequest
                        {
                            Count = x.Count(),
                            Value = x.Key.Value                            
                        }).ToListAsync();
            return result;
        }

        public async Task UpdateAsync(Answer model)
        {
            _context.Answers.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
