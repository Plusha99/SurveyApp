namespace SurveyApp.Domain.Entities
{
    /// <summary>
    /// Вопрос анкеты
    /// </summary>
    public class Question
    {
        /// <summary>
        /// ID вопроса
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// ID анкеты, к которой относится этот вопрос
        /// </summary>
        public long SurveyId { get; set; }

        /// <summary>
        /// Анкета, к которой относится этот вопрос
        /// </summary>
        public Survey Survey { get; set; } = null!;

        /// <summary>
        /// Список вариантов ответов на этот вопрос
        /// </summary>
        public List<Answer> Answers { get; set; } = new();
    }
}
