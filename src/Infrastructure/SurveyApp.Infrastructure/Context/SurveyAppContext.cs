using Microsoft.EntityFrameworkCore;
using SurveyApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Infrastructure.Context
{
    public class SurveyAppContext :DbContext
    {
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        public SurveyAppContext(DbContextOptions<SurveyAppContext> options) : base(options)
        {
            
        }
    }
}
