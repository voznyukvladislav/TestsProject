using Microsoft.EntityFrameworkCore;
using TechTests_API.Data;
using TechTests_API.DTOs;
using TechTests_API.Models;

namespace TechTests_API.Services
{
    public class TestService
    {
        public TechTestsDbContext DbContext { get; set; }
        public TestService(TechTestsDbContext dbContext) 
        {
            this.DbContext = dbContext;
        }

        public List<QuestionDTO> GetQuestions(int count)
        {
            List<Question> questions = this.DbContext.Questions
                .Include(q => q.Categories)
                .Include(q => q.Type)
                .Include(q => q.Description)
                .ToList();

            List<Question> testQuestions = new();
            Random random = new Random();
            for (int i = 0; i < questions.Count; i++)
            {
                int randomNumber = random.Next(questions.Count);
                if (!testQuestions.Contains(questions[randomNumber]))
                {
                    testQuestions.Add(questions[randomNumber]);
                }
                else
                {
                    i--;
                }
            }

            questions = questions.Distinct().ToList();

            List<QuestionDTO> questionDTOs = testQuestions.Select(q => FactoryDTO.GetQuestionDTO(q)).ToList();
            for (int i = 0; i < questionDTOs.Count; i++)
            {
                questionDTOs[i].Title = $"Питання №{i + 1}";
            }

            return questionDTOs;
        }

        public ResultDTO AnswearTest(List<AnswearedQuestionDTO> answearedQuestions)
        {
            List<Question> questions = new();
            for (int i = 0; i < answearedQuestions.Count; i++)
            {
                questions.Add(this.DbContext.Questions
                    .Where(q => q.Id == answearedQuestions[i].Id)
                    .Include(q => q.Categories)
                    .Include(q => q.Type)
                    .Include(q => q.Answears)
                    .ThenInclude(a => a.AnswearValues)
                    .First());
            }

            ResultDTO result = new ResultDTO();
            result.Title = "Результати тесту";
            result.Total = questions.Sum(q =>
            {
                if (q.Type.Name == "I")
                {
                    return Constants.FIRST_TYPE_POINTS;
                }
                else if (q.Type.Name == "II")
                {
                    return Constants.SECOND_TYPE_POINTS;
                }
                else if (q.Type.Name == "III")
                {
                    return Constants.THIRD_TYPE_POINTS;
                }

                return 0;
            });

            // Selecting unique categories from questions
            List<Category> categories = this.GetQuestionsCategories(questions);
            List<CategoryResultDTO> categoryResults = new();
            for (int i = 0; i < categories.Count; i++)
            {
                categoryResults.Add(new CategoryResultDTO() { CategoryId = categories[i].Id, CategoryName = categories[i].Name });
            }

            // Calculating max point number for each category
            for (int i = 0; i < questions.Count; i++)
            {
                double points = 0;
                if (questions[i].Type.Name == "I")
                {
                    points = Constants.FIRST_TYPE_POINTS;
                }
                else if (questions[i].Type.Name == "II")
                {
                    points = Constants.SECOND_TYPE_POINTS;
                }
                else if (questions[i].Type.Name == "III")
                {
                    points = Constants.THIRD_TYPE_POINTS;
                }

                points /= questions[i].Categories.Count;
                points = Math.Round(points, 2);
                for (int j = 0; j < questions[i].Categories.Count; j++)
                {
                    categoryResults
                        .First(cr => cr.CategoryId == questions[i].Categories[j].Id)
                        .Total += points;
                }
            }

            // Calculating count of user points (total and for each category)
            for (int i = 0; i < questions.Count; i++)
            {
                double questionPoints = 0;
                if (questions[i].Type.Name == "I")
                {
                    questionPoints = this.CheckFirstType(questions[i], answearedQuestions[i].Answear);
                    result.Result += questionPoints;
                }
                else if (questions[i].Type.Name == "II")
                {
                    questionPoints = this.CheckSecondType(questions[i], answearedQuestions[i].Answear);
                    result.Result += questionPoints;
                }
                else if (questions[i].Type.Name == "III")
                {
                    questionPoints = this.CheckThirdType(questions[i], answearedQuestions[i].Answear);
                    result.Result += questionPoints;
                }

                for (int j = 0; j < questions[i].Categories.Count; j++)
                {
                    categoryResults.First(c => c.CategoryId == questions[i].Categories[j].Id).Result += questionPoints / questions[i].Categories.Count;
                }
            }

            result.CategoryResults = categoryResults;

            result.Percentage = $"{Math.Round(result.Result / result.Total, 2) * 100}%";

            for (int i = 0; i < result.CategoryResults.Count; i++)
            {
                result.CategoryResults[i].Percentage = $"{Math.Round(result.CategoryResults[i].Result / result.CategoryResults[i].Total, 2) * 100}%";
            }

            return result;
        }

        private List<Category> GetQuestionsCategories(List<Question> questions)
        {
            List<Category> categories = new();
            for (int i = 0; i < questions.Count; i++)
            {
                for (int j = 0; j < questions[i].Categories.Count; j++)
                {
                    if (!categories.Contains(questions[i].Categories[j]))
                    {
                        categories.Add(questions[i].Categories[j]);
                    }
                }
            }

            return categories;
        }

        private int CheckFirstType(Question question, string answear)
        {
            if (question.Answears[0].AnswearValues[0].Value == answear)
            {
                return Constants.FIRST_TYPE_POINTS;
            }
            else return 0;
        }

        private int CheckSecondType(Question question, string answear)
        {
            if (question.Answears[0].AnswearValues.Any(av => av.Value == answear))
            {
                return Constants.SECOND_TYPE_POINTS;
            }
            else return 0;
        }

        private double CheckThirdType(Question question, string answear)
        {
            List<string> answears = answear.Split('\n').ToList();

            double correct = 0;
            List<int> ignoredIndexes = new();
            
            for (int i = 0; i < answears.Count; i++)
            {
                for (int j = 0; j < question.Answears.Count; j++)
                {
                    if (!ignoredIndexes.Contains(j))
                    {
                        if (question.Answears[j].AnswearValues.Any(av => av.Value == answears[i]))
                        {
                            correct++;
                            ignoredIndexes.Add(j);
                            break;
                        }
                    }
                }
            }

            double answearsCount = this.DbContext.Questions.Where(q => q.Id == question.Id)
                .Include(q => q.Answears)
                .First()
                .Answears.Count;

            double result = (correct / answearsCount) * Constants.THIRD_TYPE_POINTS;
            result = Math.Round(result, 2);

            return result;
        }
    }
}
