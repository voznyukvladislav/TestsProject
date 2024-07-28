using System.Reflection.Metadata;
using System.Text.Json;
using TechTests_API.Data;
using TechTests_API.Models;

namespace TechTests_API.DTOs
{
    public static class FactoryDTO
    {
        public static ResultShortDTO GetResultDTO(Result result)
        {
            ResultDTO? resultDTO = JsonSerializer.Deserialize<ResultDTO>(result.ResultJson);
            if (resultDTO is null) throw new ArgumentException();

            return new ResultShortDTO()
            {
                DateTime = result.DateTime.ToString("dd.MM.yyyy hh:mm"),
                Result = $"{resultDTO.Result} / {resultDTO.Total} ({resultDTO.Percentage})",
                ResultId = result.Id,
                TestName = resultDTO.Title
            };
        }

        internal static QuestionDTO GetQuestionDTO(Question question)
        {
            QuestionDTO questionDTO = new QuestionDTO
            {
                Id = question.Id,
                Description = question.Description?.Value,
                Question = question.Value,
                Type = question.Type.Name,
                Categories = String.Join(", ", question.Category_Question.Select(cq => cq.Category.Name).ToList())
            };

            if (question.Type.Name == Constants.FOURTH_TYPE_NAME || question.Type.Name == Constants.FIFTH_TYPE_NAME)
            {
                for (int i = 0; i < question.Answers[0].AnswerValues.Count; i++)
                {
                    questionDTO.Answers.Add(new AnswerDTO()
                    {
                        Id = question.Answers[0].AnswerValues[i].Id,
                        Value = question.Answers[0].AnswerValues[i].Value
                    });
                }
            }

            return questionDTO;
        }

        public static QuestionGroupDTO GetQuestionGroupDTO(QuestionGroup questionGroup)
        {
            QuestionGroupDTO questionGroupDTO = new();
            questionGroupDTO.Id = questionGroup.Id;
            questionGroupDTO.Name = questionGroup.Name;

            return questionGroupDTO;
        }
    }
}
