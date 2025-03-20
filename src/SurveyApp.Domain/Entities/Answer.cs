namespace SurveyApp.Domain.Entities
{
    /// <summary>
    /// Вариант ответа на вопрос анкеты
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// ID варианта ответа
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// ID вопроса, к которому относится этот вариант ответа
        /// </summary>
        public long QuestionId { get; set; }

        /// <summary>
        /// Вопрос, к которому относится этот вариант ответа
        /// </summary>
        public Question Question { get; set; } = null!;
    }
}
