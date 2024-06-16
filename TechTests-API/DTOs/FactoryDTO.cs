using TechTests_API.Models;

namespace TechTests_API.DTOs
{
    public static class FactoryDTO
    {
        internal static QuestionDTO GetQuestionDTO(Question question)
        {
            return new QuestionDTO
            {
                Id = question.Id,
                Description = question.Description?.Value,
                Question = question.Value,
                Type = question.Type.Name,
                Categories = String.Join(", ", question.Categories.Select(c => c.Name).ToList())
            };
        }
    }
}
