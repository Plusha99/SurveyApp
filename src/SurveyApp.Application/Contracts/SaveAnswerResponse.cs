namespace SurveyApp.Application.Contracts
{
    /// <summary>
    /// Ответ на запрос сохранения ответа
    /// </summary>
    public class SaveAnswerResponse
    {
        /// <summary>
        /// ID следующего вопроса
        /// </summary>
        public long NextQuestionId { get; set; }
    }
}
