using Microsoft.EntityFrameworkCore;
using SurveyApp.Application.Abstractions;
using SurveyApp.Domain.Entities;
using SurveyApp.Infrastructure.DataContext;

namespace SurveyApp.Infrastructure.Repositories
{
    /// <summary>
    /// Репозиторий для работы с данными анкеты, вопросов и ответов
    /// </summary>
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _context;

        /// <summary>
        /// Конструктор для инъекции контекста базы данных
        /// </summary>
        /// <param name="context">Контекст базы данных для работы с анкетами и результатами</param>
        public SurveyRepository(SurveyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Сохранение результата (ответа) на вопрос анкеты
        /// </summary>
        /// <param name="result">Результат, который нужно сохранить в базу данных</param>
        public async Task SaveResultAsync(Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Получение вопроса анкеты по ID анкеты и ID вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="questionId">ID вопроса анкеты</param>
        /// <returns>Данные вопроса анкеты с вариантами ответов</returns>
        public async Task<Question> GetQuestionByIdAsync(long surveyId, long questionId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == questionId && q.SurveyId == surveyId);
        }

        /// <summary>
        /// Получение следующего вопроса анкеты по ID анкеты и ID текущего вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="questionId">ID текущего вопроса анкеты</param>
        /// <returns>Данные следующего вопроса анкеты</returns>
        public async Task<Question> GetNextQuestionAsync(long surveyId, long questionId)
        {
            return await _context.Questions
                .Where(q => q.SurveyId == surveyId && q.Id > questionId)
                .OrderBy(q => q.Id)
                .FirstOrDefaultAsync();
        }
    }
}
