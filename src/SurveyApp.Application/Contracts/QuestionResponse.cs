namespace SurveyApp.Application.Contracts
{
    /// <summary>
    /// Вопрос анкеты с вариантами ответов
    /// </summary>
    public class QuestionResponse
    {
        /// <summary>
        /// ID вопроса анкеты
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Текст вопроса анкеты
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Список вариантов ответов на вопрос
        /// </summary>
        public List<AnswerResponse> Answers { get; set; } = new();
    }
}
