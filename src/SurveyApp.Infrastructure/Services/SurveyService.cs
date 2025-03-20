using SurveyApp.Application.Abstractions;
using SurveyApp.Domain.Entities;

namespace SurveyApp.Infrastructure.Services
{
    /// <summary>
    /// Реализация сервиса для работы с анкетами, вопросами и ответами
    /// </summary>
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">Репозиторий для доступа к данным анкеты и ответам</param>
        public SurveyService(ISurveyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получение вопроса анкеты по ID анкеты и ID вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="questionId">ID вопроса анкеты</param>
        /// <returns>Данные вопроса анкеты</returns>
        public async Task<Question> GetQuestionAsync(long surveyId, long questionId)
        {
            return await _repository.GetQuestionByIdAsync(surveyId, questionId);
        }

        /// <summary>
        /// Сохранение ответа на вопрос анкеты и получение ID следующего вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="interviewId">ID интервью (сессии анкеты)</param>
        /// <param name="questionId">ID вопроса анкеты</param>
        /// <param name="answerId">ID выбранного ответа</param>
        /// <returns>ID следующего вопроса анкеты</returns>
        public async Task<long> SaveAnswerAsync(long surveyId, long interviewId, long questionId, long answerId)
        {
            var result = new Result
            {
                InterviewId = interviewId,
                QuestionId = questionId,
                AnswerId = answerId
            };

            await _repository.SaveResultAsync(result);

            var nextQuestion = await _repository.GetNextQuestionAsync(surveyId, questionId);
            return nextQuestion.Id;
        }
    }
}
