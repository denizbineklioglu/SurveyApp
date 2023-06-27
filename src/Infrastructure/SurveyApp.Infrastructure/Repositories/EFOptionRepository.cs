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
    public class EFOptionRepository : IOptionRepository
    {
        private readonly SurveyAppContext _context;

        public EFOptionRepository(SurveyAppContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Option model)
        {
            await _context.Options.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var option = await _context.Options.FindAsync(id);
            _context.Options.Remove(option);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Option>> GetAllAsync()
        {
            return await _context.Options.ToListAsync();
        }

        public async Task<Option?> GetByIdAsync(int id)
        {
            return await _context.Options.SingleOrDefaultAsync(o => o.OptionID == id);           
        }

        public async Task UpdateAsync(Option model)
        {
            _context.Options.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
