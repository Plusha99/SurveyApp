namespace SurveyApp.Domain.Entities
{
    /// <summary>
    /// Анкета, содержащая список вопросов и интервью
    /// </summary>
    public class Survey
    {
        /// <summary>
        /// ID анкеты
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Заголовок анкеты
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Список вопросов анкеты
        /// </summary>
        public List<Question> Questions { get; set; } = new();

        /// <summary>
        /// Список интервью, в которых была использована эта анкета
        /// </summary>
        public List<Interview> Interviews { get; set; } = new();
    }
}
