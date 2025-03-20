namespace SurveyApp.Application.Contracts
{
    /// <summary>
    /// Ответ на вопрос анкеты
    /// </summary>
    public class AnswerResponse
    {
        /// <summary>
        /// ID варианта ответа
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public string Text { get; set; } = string.Empty;
    }
}
