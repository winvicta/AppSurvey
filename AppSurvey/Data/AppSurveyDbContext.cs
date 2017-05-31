using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppSurvey.Models;

namespace AppSurvey.Data
{
    public class AppSurveyDbContext : DbContext
    {
        public AppSurveyDbContext(DbContextOptions<AppSurveyDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionType> OptionTypes { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
