namespace SurveyApp.Domain.Entities
{
    /// <summary>
    /// Результат прохождения анкеты (ответ на конкретный вопрос)
    /// </summary>
    public class Result
    {
        /// <summary>
        /// ID результата
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// ID интервью, к которому относится результат
        /// </summary>
        public long InterviewId { get; set; }

        /// <summary>
        /// Интервью, к которому относится этот результат
        /// </summary>
        public Interview Interview { get; set; } = null!;

        /// <summary>
        /// ID вопроса, на который был дан ответ
        /// </summary>
        public long QuestionId { get; set; }

        /// <summary>
        /// Вопрос, на который был дан ответ
        /// </summary>
        public Question Question { get; set; } = null!;

        /// <summary>
        /// ID выбранного варианта ответа
        /// </summary>
        public long AnswerId { get; set; }

        /// <summary>
        /// Вариант ответа, который был выбран
        /// </summary>
        public Answer Answer { get; set; } = null!;
    }
}
