using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);

        Task<T?> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
    }
}
