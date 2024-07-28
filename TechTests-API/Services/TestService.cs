using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
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

        public ResultDTO GetResultDTO(int resultId)
        {
            Result result = this.DbContext.Results.First(r => r.Id == resultId);
            ResultDTO? resultDTO = JsonSerializer.Deserialize<ResultDTO>(result.ResultJson);

            if (resultDTO is null) throw new Exception();

            return resultDTO;
        }

        public async Task SaveTestResultAsync(User user, ResultDTO resultDTO)
        {
            QuestionGroup questionGroup = this.DbContext.QuestionGroups.First(qg => qg.Id == resultDTO.QuestionGroupId);
            Result result = new Result()
            {
                QuestionGroup = questionGroup,
                QuestionGroupId = resultDTO.QuestionGroupId,
                ResultJson = JsonSerializer.Serialize(resultDTO),
                DateTime = DateTime.Now,
                UserId = user.Id,
                User = user
            };

            this.DbContext.Results.Add(result);
            await this.DbContext.SaveChangesAsync();
        }

        public List<QuestionDTO> GetQuestions(int questionGroupId)
        {
            QuestionGroup? questionGroup = this.DbContext.QuestionGroups
                .Where(qg => qg.Id == questionGroupId)
                .Include(qg => qg.Question_QuestionGroup)
                .ThenInclude(qqg => qqg.Question)
                .ThenInclude(q => q.Type)
                .FirstOrDefault();
            if (questionGroup is null) return new List<QuestionDTO>();

            List<Question> questions = new();
            for (int i = 0; i < questionGroup.Question_QuestionGroup.Count; i++)
            {
                Question question = this.DbContext.Questions
                    .Where(q => q.Id == questionGroup.Question_QuestionGroup[i].Question.Id)
                    .Include(q => q.Description)
                    .Include(q => q.Category_Question)
                    .ThenInclude(cq => cq.Category)
                    .First();

                if (questionGroup.Question_QuestionGroup[i].Question.Type.Name == Constants.FOURTH_TYPE_NAME || questionGroup.Question_QuestionGroup[i].Question.Type.Name == Constants.FIFTH_TYPE_NAME)
                {
                    question.Answers = this.DbContext.Answers
                        .Where(a => a.QuestionId == question.Id)
                        .Include(a => a.AnswerValues)
                        .ToList();
                }

                questions.Add(question);
            }

            List<QuestionDTO> questionDTOs = new();
            for (int i = 0; i < questions.Count; i++)
            {
                questionDTOs.Add(FactoryDTO.GetQuestionDTO(questions[i]));
            }

            return questionDTOs;
        }

        public List<QuestionGroupDTO> GetQuestionGroups()
        {
            List<QuestionGroupDTO> questionGroups = this.DbContext.QuestionGroups
                .Select(qg => FactoryDTO.GetQuestionGroupDTO(qg))
                .ToList();            

            return questionGroups;
        }

        public QuestionGroupDTO GetQuestionGroup(int questionGroupId)
        {
            QuestionGroup? questionGroup = this.DbContext.QuestionGroups.FirstOrDefault(qg => qg.Id == questionGroupId);

            if (questionGroup is null) return new QuestionGroupDTO();
            else return FactoryDTO.GetQuestionGroupDTO(questionGroup);
        }

        public ResultDTO AnswerTest(int questionGroupId, List<AnsweredQuestionDTO> answeredQuestions)
        {
            QuestionGroup questionGroup = this.DbContext.QuestionGroups.First(qg => qg.Id == questionGroupId);
            ResultDTO result = new ResultDTO();

            result.QuestionGroupId = questionGroup.Id;
            result.Title = questionGroup.Name;

            // Gathering all questions
            List<Question> questions = this.GetQuestions(answeredQuestions);

            // Selecting all mentioned categories and questions related to selected question group
            List<Category> categories = this.GetCategoriesAndQuestions(questionGroupId, questions);

            // Calculating maximum points and earned points for each category
            List<CategoryResultDTO> categoryResults = this.GetCategoryResults(categories, answeredQuestions);
            result.CategoryResults = categoryResults;

            // Calculatuing max points and earned points
            result.Total = categoryResults.Sum(cr => cr.Total);
            result.Result = categoryResults.Sum(cr => cr.Result);

            double percentage = Math.Round(result.Result / result.Total, 2) * 100;
            result.Percentage = $"{percentage}%";

            this.DbContext.ChangeTracker.Clear();

            return result;
        }

        private List<CategoryResultDTO> GetCategoryResults(List<Category> categories, List<AnsweredQuestionDTO> answeredQuestions)
        {
            List<CategoryResultDTO> categoryResults = new();
            for (int i = 0; i < categories.Count; i++)
            {
                categoryResults.Add(new CategoryResultDTO()
                {
                    CategoryId = categories[i].Id,
                    CategoryName = categories[i].Name,
                });

                for (int j = 0; j < categories[i].Category_Question.Count; j++)
                {
                    Question question = categories[i].Category_Question[j].Question;

                    AnsweredQuestionDTO answeredQuestion = answeredQuestions.First(aq => aq.Id == categories[i].Category_Question[j].QuestionId);
                    categoryResults[i].Result += Math.Round(this.CheckQuestion(answeredQuestion) / question.Category_Question.Count, 2);
                    categoryResults[i].Total += Math.Round((double)this.GetMaxPoints(question.Id) / question.Category_Question.Count, 2);
                }
                
                double percentage = Math.Round(categoryResults[i].Result / categoryResults[i].Total, 2) * 100;
                categoryResults[i].Percentage = $"{percentage}%";
            }

            return categoryResults;
        }

        private List<Category> GetCategoriesAndQuestions(int questionGroupId, List<Question> questions)
        {
            List<Category> categories = new();
            for (int i = 0; i < questions.Count; i++)
            {
                for (int j = 0; j < questions[i].Category_Question.Count; j++)
                {
                    if (!categories.Contains(questions[i].Category_Question[j].Category))
                    {
                        categories.Add(questions[i].Category_Question[j].Category);
                    }
                }
            }

            categories.ForEach(c => c.Category_Question = new());

            for (int i = 0; i < categories.Count; i++)
            {
                Category category = this.DbContext.Categories
                    .Where(c => c.Id == categories[i].Id)
                    .Include(c => c.Category_Question)
                    .ThenInclude(cq => cq.Question)
                    .ThenInclude(q => q.Question_QuestionGroup)
                    .AsNoTracking()
                    .First();

                for (int j = 0; j < category.Category_Question.Count; j++)
                {
                    for (int k = 0; k < category.Category_Question[j].Question.Question_QuestionGroup.Count; k++)
                    {
                        if (category.Category_Question[j].Question.Question_QuestionGroup[k].QuestionGroupId == questionGroupId)
                        {
                            categories[i].Category_Question.Add(category.Category_Question[j]);
                        }
                    }
                }
            }

            categories = categories.OrderBy(c => c.Id).ToList();

            return categories;
        }

        private List<Question> GetQuestions(List<AnsweredQuestionDTO> answeredQuestions)
        {
            List<Question> questions = new();
            for (int i = 0; i < answeredQuestions.Count; i++)
            {
                Question question = this.DbContext.Questions
                    .Where(q => q.Id == answeredQuestions[i].Id)
                    .Include(q => q.Category_Question)
                    .ThenInclude(cq => cq.Category)
                    .Include(q => q.Type)
                    .Include(q => q.Description)
                    .Include(q => q.Answers)
                    .ThenInclude(a => a.AnswerValues)
                    .First();

                questions.Add(question);
            }

            return questions;
        }

        private int GetMaxPoints(int questionId)
        {
            Question question = this.DbContext.Questions.First(q => q.Id == questionId);

            int points = 0;

            switch (question.Type.Name)
            {
                case Constants.FIRST_TYPE_NAME:
                    points = Constants.FIRST_TYPE_POINTS;
                    break;

                case Constants.SECOND_TYPE_NAME:
                    points = Constants.SECOND_TYPE_POINTS;
                    break;

                case Constants.THIRD_TYPE_NAME:
                    points = Constants.THIRD_TYPE_POINTS;
                    break;

                case Constants.FOURTH_TYPE_NAME:
                    points = Constants.FOURTH_TYPE_POINTS;
                    break;

                case Constants.FIFTH_TYPE_NAME:
                    points = Constants.FIFTH_TYPE_POINTS;
                    break;
            }

            return points;
        }

        private int GetMaxPoints(Question question)
        {
            int points = 0;

            switch (question.Type.Name)
            {
                case Constants.FIRST_TYPE_NAME:
                    points = Constants.FIRST_TYPE_POINTS;
                    break;

                case Constants.SECOND_TYPE_NAME:
                    points = Constants.SECOND_TYPE_POINTS;
                    break;

                case Constants.THIRD_TYPE_NAME:
                    points = Constants.THIRD_TYPE_POINTS;
                    break;

                case Constants.FOURTH_TYPE_NAME:
                    points = Constants.FOURTH_TYPE_POINTS;
                    break;

                case Constants.FIFTH_TYPE_NAME:
                    points = Constants.FIFTH_TYPE_POINTS;
                    break;
            }

            return points;
        }

        private double CheckQuestion(AnsweredQuestionDTO answeredQuestionDTO)
        {
            if (answeredQuestionDTO.Answer.IsNullOrEmpty()) return 0;

            Question question = this.DbContext.Questions
                .Where(q => q.Id == answeredQuestionDTO.Id)
                .Include(q => q.Type)
                .Include(q => q.Answers)
                .ThenInclude(a => a.AnswerValues)
                .First();

            switch(question.Type.Name)
            {
                case Constants.FIRST_TYPE_NAME:
                    return this.CheckFirstType(question, answeredQuestionDTO);

                case Constants.SECOND_TYPE_NAME:
                    return this.CheckSecondType(question, answeredQuestionDTO);

                case Constants.THIRD_TYPE_NAME:
                    return this.CheckThirdType(question, answeredQuestionDTO);

                case Constants.FOURTH_TYPE_NAME:
                    return this.CheckFourthType(question, answeredQuestionDTO);

                case Constants.FIFTH_TYPE_NAME:
                    return this.CheckFifthType(question, answeredQuestionDTO);

                default: return 0;
            }
        }

        private double CheckFirstType(Question question, AnsweredQuestionDTO answeredQuestionDTO)
        {
            if (answeredQuestionDTO.Answer == question.Answers[0].AnswerValues[0].Value)
            {
                return Constants.FIRST_TYPE_POINTS;
            }
            else return 0;
        }

        private double CheckSecondType(Question question, AnsweredQuestionDTO answeredQuestionDTO)
        {
            List<string> correctAnswers = new();
            for (int i = 0; i < question.Answers[0].AnswerValues.Count; i++)
            {
                if (!question.IsCaseSensitive)
                {
                    correctAnswers.Add(question.Answers[0].AnswerValues[i].Value.ToLower());
                }
                else
                {
                    correctAnswers.Add(question.Answers[0].AnswerValues[i].Value);
                }
            }

            string answer = string.Empty;
            if (!question.IsCaseSensitive)
            {
                answer = answeredQuestionDTO.Answer.ToLower();
            }
            else
            {
                answer = answeredQuestionDTO.Answer;
            }

            if (correctAnswers.Any(ca => ca == answer))
            {
                return Constants.SECOND_TYPE_POINTS;
            } else
            {
                return 0;
            }
        }

        private double CheckThirdType(Question question, AnsweredQuestionDTO answeredQuestionDTO)
        {
            List<string> userAnswers = answeredQuestionDTO.Answer.Split('\n').ToList();
            if (!question.IsCaseSensitive)
            {
                userAnswers = userAnswers.Select(ua => ua.ToLower()).ToList();
            }

            List<List<string>> correctAnswerSets = new List<List<string>>();
            for (int i = 0; i < question.Answers.Count; i++)
            {
                correctAnswerSets.Add(new List<string>());
                for (int j = 0; j < question.Answers[i].AnswerValues.Count; j++)
                {
                    if (!question.IsCaseSensitive)
                    {
                        correctAnswerSets[i].Add(question.Answers[i].AnswerValues[j].Value.ToLower());
                    }
                    else
                    {
                        correctAnswerSets[i].Add(question.Answers[i].AnswerValues[j].Value);
                    }
                }
            }

            int correctAnswers = 0;
            List<int> ignored = new();
            for (int i = 0; i < userAnswers.Count; i++)
            {
                for (int j = 0; j < correctAnswerSets.Count; j++)
                {
                    if (ignored.Contains(j)) continue;
                    if (correctAnswerSets[j].Any(ca => ca == userAnswers[i]))
                    {
                        ignored.Add(j);
                        correctAnswers++;
                    }
                }
            }

            double points = (correctAnswers / userAnswers.Count) * Constants.THIRD_TYPE_POINTS;
            points = Math.Round(points, 2);

            return points;
        }

        private double CheckFourthType(Question question, AnsweredQuestionDTO answeredQuestionDTO)
        {
            int correctAnswerValueId = question.Answers[0].AnswerValues
                .Where(av => av.IsCorrect == true)
                .Select(av => av.Id)
                .First();

            int userAnswerValueId = Convert.ToInt32(answeredQuestionDTO.Answer);

            if (correctAnswerValueId == userAnswerValueId) return Constants.FOURTH_TYPE_POINTS;
            else return 0;
        }

        private double CheckFifthType(Question question, AnsweredQuestionDTO answeredQuestionDTO)
        {
            List<int> answeredIds = answeredQuestionDTO.Answer
                .Split(',')
                .Select(a => Convert.ToInt32(a))
                .ToList();

            List<int> correctIds = question.Answers[0].AnswerValues
                .Where(av => av.IsCorrect == true)
                .Select(av => av.Id)
                .ToList();

            double maxPoints = Constants.FIFTH_TYPE_POINTS;
            double ratio = answeredIds.Count / correctIds.Count;
            if (ratio > 1 && ratio < 2)
            {
                maxPoints /= ratio * 2;
            }
            else if (ratio >= 2)
            {
                return 0;
            }

            int correctAnswers = 0;
            List<int> ignored = new List<int>();
            for (int i = 0; i < answeredIds.Count; i++)
            {
                for (int j = 0; j < correctIds.Count; j++)
                {
                    if (ignored.Contains(j)) continue;

                    if (answeredIds[i] == correctIds[j])
                    {
                        correctAnswers++;
                        ignored.Add(j);
                    }
                }
            }

            double points = (correctAnswers / correctIds.Count) * maxPoints;
            points = Math.Round(points, 2);

            return points;
        }

        /*public ResultDTO AnswerTest(List<AnsweredQuestionDTO> answeredQuestions)
        {
            List<Question> questions = new();
            for (int i = 0; i < answeredQuestions.Count; i++)
            {
                questions.Add(this.DbContext.Questions
                    .Where(q => q.Id == answeredQuestions[i].Id)
                    .Include(q => q.Category_Question)
                    .ThenInclude(cq => cq.Category)
                    .Include(q => q.Type)
                    .Include(q => q.Answers)
                    .ThenInclude(a => a.AnswerValues)
                    .First());
            }

            // User answers to lower case
            for (int i = 0; i < answeredQuestions.Count; i++)
            {
                if (questions.First(q => q.Id == answeredQuestions[i].Id).IsCaseSensitive == false)
                {
                    answeredQuestions[i].Answer = answeredQuestions[i].Answer.ToLower();
                }
            }

            // Question answers to lower case
            for (int i = 0; i < questions.Count; i++)
            {
                if (!questions[i].IsCaseSensitive)
                {
                    for (int j = 0; j < questions[i].Answers.Count; j++)
                    {
                        for (int k = 0; k < questions[i].Answers[j].AnswerValues.Count; k++)
                        {
                            questions[i].Answers[j].AnswerValues[k].Value = questions[i].Answers[j].AnswerValues[k].Value.ToLower();
                        }
                    }
                }
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
                    questionPoints = this.CheckFirstType(questions[i], answeredQuestions[i].Answer);
                    result.Result += questionPoints;
                }
                else if (questions[i].Type.Name == "II")
                {
                    questionPoints = this.CheckSecondType(questions[i], answeredQuestions[i].Answer);
                    result.Result += questionPoints;
                }
                else if (questions[i].Type.Name == "III")
                {
                    questionPoints = this.CheckThirdType(questions[i], answeredQuestions[i].Answer);
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

        private int CheckFirstType(Question question, string answer)
        {
            if (question.Answers[0].AnswerValues[0].Value == answer)
            {
                return Constants.FIRST_TYPE_POINTS;
            }
            else return 0;
        }

        private int CheckSecondType(Question question, string answer)
        {
            if (question.Answers[0].AnswerValues.Any(av => av.Value == answer))
            {
                return Constants.SECOND_TYPE_POINTS;
            }
            else return 0;
        }

        private double CheckThirdType(Question question, string answer)
        {
            List<string> answers = answer.Split('\n').ToList();

            double correct = 0;
            List<int> ignoredIndexes = new();
            
            for (int i = 0; i < answers.Count; i++)
            {
                for (int j = 0; j < question.Answers.Count; j++)
                {
                    if (!ignoredIndexes.Contains(j))
                    {
                        if (question.Answers[j].AnswerValues.Any(av => av.Value == answers[i]))
                        {
                            correct++;
                            ignoredIndexes.Add(j);
                            break;
                        }
                    }
                }
            }

            double answersCount = this.DbContext.Questions.Where(q => q.Id == question.Id)
                .Include(q => q.Answers)
                .First()
                .Answers.Count;

            double result = (correct / answersCount) * Constants.THIRD_TYPE_POINTS;
            result = Math.Round(result, 2);

            return result;
        }*/
    }
}
