using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Abstractions;
using SurveyApp.Application.Contracts;
using SurveyApp.Domain.Entities;

namespace SurveyApp.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public SurveyController(ISurveyService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение вопроса анкеты по ID анкеты и ID вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="questionId">ID вопроса анкеты</param>
        /// <returns>Данные вопроса с вариантами ответов</returns>
        [HttpGet("{surveyId}/questions/{questionId}")]
        public async Task<IActionResult> GetQuestion(long surveyId, long questionId)
        {
            var question = await _service.GetQuestionAsync(surveyId, questionId);
            if (question == null)
            {
                return NotFound();
            }

            var response = new QuestionResponse
            {
                Id = question.Id,
                Text = question.Text,
                Answers = question.Answers.Select(a => new AnswerResponse
                {
                    Id = a.Id,
                    Text = a.Text
                }).ToList()
            };

            return Ok(response);
        }

        /// <summary>
        /// Сохранение ответа на вопрос анкеты и получение ID следующего вопроса
        /// </summary>
        /// <param name="surveyId">ID анкеты</param>
        /// <param name="interviewId">ID вопроса анкеты</param>
        /// <param name="result">Результат с выбранным ответом</param>
        /// <returns>ID следующего вопроса для анкеты</returns>
        [HttpPost("{surveyId}/interviews/{interviewId}/answers")]
        public async Task<IActionResult> SaveAnswer(long surveyId, long interviewId, [FromBody] Result result)
        {
            var nextQuestionId = await _service.SaveAnswerAsync(surveyId, interviewId, result.QuestionId, result.AnswerId);
            if (nextQuestionId > 0)
            {
                return NotFound();
            }

            var response = new SaveAnswerResponse
            {
                NextQuestionId = nextQuestionId
            };

            return Ok(response);
        }
    }
}
