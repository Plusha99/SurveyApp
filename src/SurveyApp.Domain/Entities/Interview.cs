namespace SurveyApp.Domain.Entities
{
    /// <summary>
    /// Интервью (сессия прохождения анкеты)
    /// </summary>
    public class Interview
    {
        /// <summary>
        /// ID интервью
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ID анкеты, которая была пройдена в интервью
        /// </summary>
        public long SurveyId { get; set; }

        /// <summary>
        /// Анкета, которая была пройдена в интервью
        /// </summary>
        public Survey Survey { get; set; } = null!;

        /// <summary>
        /// Время начала интервью
        /// </summary>
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Время завершения интервью
        /// </summary>
        public DateTime CompletedAt { get; set; }

        /// <summary>
        /// Результаты интервью
        /// </summary>
        public List<Result> Results { get; set; } = new();
    }
}
