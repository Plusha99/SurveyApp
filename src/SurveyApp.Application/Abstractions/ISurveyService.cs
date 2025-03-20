using SurveyApp.Domain.Entities;

namespace SurveyApp.Application.Abstractions
{
    /// <summary>
    /// Интерфейс для сервиса, работающего с анкета, вопросами и ответами
    /// </summary>
    public interface ISurveyService
    {
        /// <summary>
        /// Получение вопроса анкеты по ID анкеты и ID вопрос
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="questionId">ID вопроса анкеты</param>
        /// <returns>Данные вопроса анкеты</returns>
        Task<Question> GetQuestionAsync(long surveyId, long questionId);

        /// <summary>
        /// Сохранение ответа на вопрос анкеты и получение ID следующего вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="interviewId">ID интервью (сессии анкеты)</param>
        /// <param name="questionId">ID вопроса анкеты</param>
        /// <param name="answerId">ID выбранного ответа</param>
        /// <returns>ID следующего вопроса для анкеты</returns>
        Task<long> SaveAnswerAsync(long surveyId, long interviewId, long questionId, long answerId);
    }
}
