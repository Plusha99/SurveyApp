using SurveyApp.Domain.Entities;

namespace SurveyApp.Application.Abstractions
{
    /// <summary>
    /// Интерфейс для репозитория, работающего с анкета, вопросами и ответами.
    /// </summary>
    public interface ISurveyRepository
    {
        /// <summary>
        /// Сохранение результата (ответа) на вопрос анкеты.
        /// </summary>
        /// <param name="result">Результат, который нужно сохранить в базу данных.</param>
        public Task SaveResultAsync(Result result);

        /// <summary>
        /// Получение вопроса анкеты по ID анкеты и ID вопроса.
        /// </summary>
        /// <param name="surveyId">ID анкеты.</param>
        /// <param name="questionId">ID вопроса анкеты.</param>
        /// <returns>Данные вопроса анкеты с вариантами ответов.</returns>
        public Task<Question> GetQuestionByIdAsync(long surveyId, long questionId);

        /// <summary>
        /// Получение следующего вопроса анкеты по ID анкеты и ID текущего вопроса.
        /// </summary>
        /// <param name="surveyId">ID анкеты.</param>
        /// <param name="questionId">ID текущего вопроса анкеты.</param>
        /// <returns>Данные следующего вопроса анкеты.</returns>
        public Task<Question> GetNextQuestionAsync(long surveyId, long questionId);
    }
}
