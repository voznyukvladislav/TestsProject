using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestsDb.DTOs;
using TechTestsDb.Models;

namespace TechTestsDb.Data
{
    internal static class DTO_Factory
    {
        public static AnswerDTO GetAnswerDTO(Answer answer)
        {
            return new AnswerDTO()
            {
                Id = $"{answer.Id}",
                QuestionId = $"{answer.QuestionId}"
            };
        }

        public static AnswerValueDTO GetAnswerValueDTO(AnswerValue answerValue)
        {
            return new AnswerValueDTO()
            {
                Id = $"{answerValue.Id}",
                AnswerId = $"{answerValue.AnswerId}",
                Value = answerValue.Value,
                IsCorrect = answerValue.IsCorrect.ToString()
            };
        }

        public static Category_QuestionDTO GetCategoryQuestionDTO(Category_Question categoryQuestion)
        {
            return new Category_QuestionDTO()
            {
                CategoryId = $"{categoryQuestion.CategoryId}",
                QuestionId = $"{categoryQuestion.QuestionId}"
            };
        }

        public static CategoryDTO GetCategoryDTO(Category category)
        {
            return new CategoryDTO()
            {
                Id = $"{category.Id}",
                Name = category.Name
            };
        }

        public static DescriptionDTO GetDescriptionDTO(Description description)
        {
            return new DescriptionDTO()
            {
                Id = $"{description.Id}",
                Value = description.Value
            };
        }

        public static Question_QuestionGroupDTO GetQuestionQuestionGroupDTO(Question_QuestionGroup questionQuestionGroup)
        {
            return new Question_QuestionGroupDTO()
            {
                QuestionId = $"{questionQuestionGroup.QuestionId}",
                QuestionGroupId = $"{questionQuestionGroup.QuestionGroupId}"
            };
        }

        public static QuestionDTO GetQuestionDTO(Question question)
        {
            return new QuestionDTO()
            {
                Id = $"{question.Id}",
                TypeId = $"{question.TypeId}",
                DescriptionId = $"{question.DescriptionId}",
                IsCaseSensitive = question.IsCaseSensitive.ToString(),
                Value = question.Value
            };
        }

        public static QuestionGroupDTO GetQuestionGroupDTO(QuestionGroup questionGroup)
        {
            return new QuestionGroupDTO()
            {
                Id = $"{questionGroup.Id}",
                Name = questionGroup.Name
            };
        }

        public static ResultDTO GetResultDTO(Result result)
        {
            return new ResultDTO()
            {
                Id = $"{result.Id}",
                QuestionGroupId = $"{result.QuestionGroupId}",
                UserId = $"{result.UserId}",
                DateTime = result.DateTime.ToShortDateString(),
                ResultJson = result.ResultJson
            };
        }

        public static TypeDTO GetTypeDTO(Models.Type type)
        {
            return new TypeDTO()
            {
                Id = $"{type.Id}",
                Name = type.Name
            };
        }

        public static UserDTO GetUserDTO(User user)
        {
            return new UserDTO()
            {
                Id = $"{user.Id}",
                Login = user.Login,
                PasswordHash = user.PasswordHash
            };
        }
    
        public static string GetStringFromDTO(AnswerDTO answerDTO)
        {
            return $"Id: {answerDTO.Id}, QuestionId: {answerDTO.QuestionId}";
        }
        public static string GetStringFromDTO(AnswerValueDTO answerValueDTO)
        {
            return $"Id: {answerValueDTO.Id}, AnswerId: {answerValueDTO.AnswerId}, Value: {answerValueDTO.Value}, IsCorrect: {answerValueDTO.IsCorrect}";
        }
        public static string GetStringFromDTO(CategoryDTO categoryDTO)
        {
            return $"Id: {categoryDTO.Id}, Name: {categoryDTO.Name}";
        }
        public static string GetStringFromDTO(Category_QuestionDTO categoryQuestionDTO)
        {
            return $"CategoryId: {categoryQuestionDTO.CategoryId}, QuestionId: {categoryQuestionDTO.QuestionId}";
        }
        public static string GetStringFromDTO(DescriptionDTO descriptionDTO)
        {
            return $"Id: {descriptionDTO.Id}, Value: {descriptionDTO.Value}";
        }
        public static string GetStringFromDTO(QuestionDTO questionDTO)
        {
            return $"Id: {questionDTO.Id}, TypeId: ";
        }
        public static string GetStringFromDTO(Question_QuestionGroupDTO questionQuestionGroupDTO)
        {
            return $"";
        }
        public static string GetStringFromDTO(QuestionGroupDTO questionGroupDTO)
        {
            return $"";
        }
        public static string GetStringFromDTO(ResultDTO resultDTO)
        {
            return $"";
        }
        public static string GetStringFromDTO(TypeDTO typeDTO)
        {
            return $"";
        }
        public static string GetStringFromDTO(UserDTO userDTO)
        {
            return $"";
        }
    }
}
