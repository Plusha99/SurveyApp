using Microsoft.EntityFrameworkCore;
using SurveyApp.Domain.Entities;

namespace SurveyApp.Infrastructure.DataContext
{
    /// <summary>
    /// Контекст данных, необходимый для взаимодействия с базой данной
    /// </summary>
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options) { }

        /// <summary>
        /// Набор данных с сущностями типа <see cref="Survey"/>.
        /// </summary>
        public DbSet<Survey> Surveys { get; set; }

        /// <summary>
        /// Набор данных с сущностями типа <see cref="Question"/>.
        /// </summary>
        public DbSet<Question> Questions { get; set; }

        /// <summary>
        /// Набор данных с сущностями типа <see cref="Answer"/>.
        /// </summary>
        public DbSet<Answer> Answers { get; set; }

        /// <summary>
        /// Набор данных с сущностями типа <see cref="Interview"/>.
        /// </summary>
        public DbSet<Interview> Interviews { get; set; }

        /// <summary>
        /// Набор данных с сущностями типа <see cref="Result"/>.
        /// </summary>
        public DbSet<Result> Results { get; set; }

        /// <summary>
        /// Задает конфигурацию базы данных для Entity Framework
        /// </summary>
        /// <param name="modelBuilder">Объект, используемый для конфигурации данного <see cref="DbContext"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Question>()
                .HasKey(q => q.Id);
            modelBuilder.Entity<Answer>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Interview>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Result>()
                .HasKey(r => r.Id);
        }
    }
}
